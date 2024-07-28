using System.Diagnostics;
using Epic.OnlineServices;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Logging;
using Epic.OnlineServices.Platform;
using Epic.OnlineServices.UserInfo;

namespace eos_console_example;

internal class Program
{

	public static bool isShutdown = false;

	static async Task Main(string[] args)
	{
		Console.WriteLine("Hello, World!");

		var initOptions = new InitializeOptions()
		{
			ProductName = "vUltra-test1",
			ProductVersion = "1.0.0",
		};

		var initResult = PlatformInterface.Initialize(ref initOptions);
		Console.WriteLine($"Initialize: {initResult.ToString()}");

		//add EOS logging
		_ = LoggingInterface.SetLogLevel(LogCategory.AllCategories, LogLevel.Info);
		_ = LoggingInterface.SetCallback((ref LogMessage message) => Console.WriteLine($"[{message.Level}] {message.Category} - {message.Message}"));



		/********  CONNECT TO EOS  ********/
		var options = new Options()
		{
			//get your own product id, sandbox id, client id, and client secret from
			// https://dev.epicgames.com
			ProductId = "a9acd901f8b04a2ebef1e170b7950acd",
			SandboxId = "3eb2fc858abb4fc2b4816cf0f90e3a78",
			ClientCredentials = new()
			{
				ClientId = "xyza7891nMxs9jY4nfYdv2IBkSyyz9E2",
				ClientSecret = Environment.GetEnvironmentVariable("EosClientSecret"),
			},
			DeploymentId = "65a58e8519a74dd9b8cc1a2fc71b60e0",
			Flags = PlatformFlags.DisableOverlay,
			IsServer = false,

			
		};

		var platformInterface = PlatformInterface.Create(ref options);

		if (platformInterface is null)
		{
			throw new Exception("Failed to create platform.");
		}


		/********  LOGIN: translated from: https://dev.epicgames.com/en-US/news/player-authentication-with-epic-account-services-eas ********/
		//login via epic (not needed for most strictly EGS features)
		var eosAuthLoginOptions = new LoginOptions()
		{
			Credentials = new()
			{
				Type = LoginCredentialType.AccountPortal,
				ExternalType = ExternalCredentialType.Epic,
				Id = "",
				Token = "",
			},
			ScopeFlags = AuthScopeFlags.BasicProfile,
		};

		var authInterface = platformInterface.GetAuthInterface();
		var loginCallbackInfo = await authInterface._LoginAsync(platformInterface,null, eosAuthLoginOptions);
		Console.WriteLine($"LOGIN COMPLETE, result = {loginCallbackInfo.ResultCode.ToString()}");

		if (loginCallbackInfo.ResultCode != Result.Success)
		{
			throw new Exception("failed loginCallbackInfo.  If you have the epic client installed + logged in, the above would have auto popped up an auth webpage and would succeed (on win11 at least)");
		}
		else
		{
			Console.WriteLine("loginCallbackInfo success" + loginCallbackInfo.LocalUserId.ToString());
		}


		/****************** query user info: translated from: https://dev.epicgames.com/en-US/news/player-authentication-with-epic-account-services-eas *******/
		//var accountId = loginCallbackInfo.LocalUserId;
		var userInfoInterface = platformInterface.GetUserInfoInterface();

		var queryUserInfoOptions = new QueryUserInfoOptions()
		{
			LocalUserId = loginCallbackInfo.LocalUserId,
			TargetUserId = loginCallbackInfo.LocalUserId,
		};

		var queryUserInfoCallbackInfo = await userInfoInterface._QueryUserInfoAsync(platformInterface, queryUserInfoOptions,null);
		Console.WriteLine($"QueryUserInfo COMPLETE, result = {queryUserInfoCallbackInfo.ResultCode.ToString()}");

		if (queryUserInfoCallbackInfo.ResultCode != Result.Success)
		{
			throw new Exception("failed queryUserInfoCallbackInfo");
		}
		else
		{
			Console.WriteLine("queryUserInfoCallbackInfo User info retrieved");
		}

		/*****  copyUserInfo: translated from: https://dev.epicgames.com/en-US/news/player-authentication-with-epic-account-services-eas ********/
		var copyUserInfoOptions = new CopyUserInfoOptions()
		{
			LocalUserId = queryUserInfoCallbackInfo.LocalUserId,
			TargetUserId = queryUserInfoCallbackInfo.TargetUserId
		};
		var result = userInfoInterface.CopyUserInfo(ref copyUserInfoOptions, out var userInfoData);
		Console.WriteLine($"CopyUserInfo: {result}, DisplayName={userInfoData.Value.DisplayName}");





		/**********  "GAME" LOOP *********/
		Console.WriteLine("Done with auth, now just simple fake game loop. PRESS [Q] KEY TO LOGOFF/EXIT");
		

		var loopCount = 0;
		while (true)
		{

			await Task.Delay(500);
			Update(platformInterface, loopCount);

			if (isShutdown)
			{
				break;
			}
			loopCount++;

			//shutdown if user presses Q
			while (Console.KeyAvailable )
			{
				var keyInfo = Console.ReadKey();
				if (keyInfo.Key == ConsoleKey.Q)
				{
					isShutdown = true;
					break;
				}
			}
		}


		/**************** LOGOFF:  translated from https://dev.epicgames.com/en-US/news/player-authentication-with-epic-account-services-eas ************/
		var logoutCallbackInfo = await authInterface._LogoutAsync(platformInterface, null, new() { LocalUserId = loginCallbackInfo.LocalUserId });
		Console.WriteLine($"LOGOUT COMPLETE:  {logoutCallbackInfo.ResultCode}");
		Debug.Assert(logoutCallbackInfo.ResultCode == Result.Success);

		var deletePersistentAuthOptions = new DeletePersistentAuthOptions();
		//instead of one-off helper methods like the above _LogoutAsync and _QueryUserInfoAsync, I wrote a more generic _CallAsync() to avoid making more async helpers.
		//if you have problems understanding it, just use the above _LogoutAsync and _QueryUserInfoAsync methods.  the logic is the same.
		var deletePersistentAuthCallbackInfo = await platformInterface._CallAsync< DeletePersistentAuthCallbackInfo>(
			(tcs) => authInterface.DeletePersistentAuth(ref deletePersistentAuthOptions, null,
			(ref DeletePersistentAuthCallbackInfo callbackInfo) =>
			{
				tcs.SetResult(callbackInfo);
			}));
		//this is the same as the above _CallAsync() call
		//var deletePersistentAuthCallbackInfo = await authInterface._DeletePersistentAuthAsync(platformInterface, null, deletePersistentAuthOptions); 
		Console.WriteLine($"persistent auth deleted  result={deletePersistentAuthCallbackInfo.ResultCode.ToString()}");
		Debug.Assert(deletePersistentAuthCallbackInfo.ResultCode == Result.Success);


		


		//dispose
		platformInterface.Release();
		platformInterface = null;
		var shutdownResult = PlatformInterface.Shutdown();
		Console.WriteLine($"SHUTDOWN result = {shutdownResult.ToString()}");
	}


	private static void Update(PlatformInterface platformInterface, int loopCount)
	{
		platformInterface.Tick(); //needs to tick periodically for the sdk to do work
		Console.Write($" . ");
	}
}