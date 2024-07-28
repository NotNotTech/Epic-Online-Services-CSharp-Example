using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Platform;
using Epic.OnlineServices.UserInfo;

namespace eos_console_example;

/// <summary>
/// helper methods to make EOS work with async/await
/// </summary>
public static class zz_Extensions
{
	public static async Task<LoginCallbackInfo> _LoginAsync(this AuthInterface authInterface, PlatformInterface platformInterface, object clientData, LoginOptions loginOptions)
	{
		var tcs = new TaskCompletionSource<LoginCallbackInfo>();
		authInterface.Login(ref loginOptions, clientData, (ref LoginCallbackInfo callbackInfo)=>tcs.SetResult(callbackInfo));

		Console.WriteLine("_LoginAsync()");
		while (tcs.Task.IsCompleted is false)
		{
			Console.Write(".");
			await Task.Delay(100);
			platformInterface.Tick(); //needs to tick for the sdk to do work
		}


		return await tcs.Task;
	}

	public static async Task<QueryUserInfoCallbackInfo> _QueryUserInfoAsync(this UserInfoInterface userInfoInterface, PlatformInterface platformInterface,  QueryUserInfoOptions queryUserInfoOptions,
		object clientData)
	{

		var tcs = new TaskCompletionSource<QueryUserInfoCallbackInfo>();

		userInfoInterface.QueryUserInfo(ref queryUserInfoOptions, clientData, (ref QueryUserInfoCallbackInfo callbackInfo) => tcs.SetResult(callbackInfo));

		Console.WriteLine("_QueryUserInfoAsync()");
		while (tcs.Task.IsCompleted is false)
		{
			Console.Write(".");
			await Task.Delay(100);
			platformInterface.Tick(); //needs to tick for the sdk to do work
		}


		return await tcs.Task;
	}
}