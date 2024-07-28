using System.Runtime.CompilerServices;
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
		authInterface.Login(ref loginOptions, clientData, (ref LoginCallbackInfo callbackInfo) => tcs.SetResult(callbackInfo));

		Console.WriteLine("_LoginAsync()");
		while (tcs.Task.IsCompleted is false)
		{
			Console.Write(".");
			await Task.Delay(100);
			platformInterface.Tick(); //needs to tick for the sdk to do work
		}


		return await tcs.Task;
	}
	public static async Task<LogoutCallbackInfo> _LogoutAsync(this AuthInterface authInterface, PlatformInterface platformInterface, object clientData, LogoutOptions options)
	{
		var tcs = new TaskCompletionSource<LogoutCallbackInfo>();
		authInterface.Logout(ref options, clientData, (ref LogoutCallbackInfo callbackInfo) => tcs.SetResult(callbackInfo));

		Console.WriteLine("_LogoutAsync()");
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


	public static async Task<DeletePersistentAuthCallbackInfo> _DeletePersistentAuthAsync(this AuthInterface authInterface, PlatformInterface platformInterface, object clientData, DeletePersistentAuthOptions options)
	{
		var tcs = new TaskCompletionSource<DeletePersistentAuthCallbackInfo>();
		authInterface.DeletePersistentAuth(ref options, clientData, (ref DeletePersistentAuthCallbackInfo callbackInfo) => tcs.SetResult(callbackInfo));

		Console.WriteLine("_LogoutAsync()");
		while (tcs.Task.IsCompleted is false)
		{
			Console.Write(".");
			await Task.Delay(100);
			platformInterface.Tick(); //needs to tick for the sdk to do work
		}

		return await tcs.Task;
	}

	/// <summary>
	/// This helper does what the above async methods do, but in a more generic way.  If you have a hard time understanding it, just use adjusted versions of the above async methods.
	/// </summary>
	public static async Task<TResult> _CallAsync<TResult>(this PlatformInterface platformInterface,
		Action<TaskCompletionSource<TResult>> callbackWrapper, [CallerArgumentExpression("callbackWrapper")] string methodName="")
	{
		Console.WriteLine("_CallAsync() --> " + methodName.Substring(0, methodName.IndexOf("ref ")));

		var tcs = new TaskCompletionSource<TResult>();
		callbackWrapper(tcs);
		while (tcs.Task.IsCompleted is false)
		{
			Console.Write(".");
			await Task.Delay(100);
			platformInterface.Tick();  //needs to tick periodically for the sdk to do work
		}

		return await tcs.Task;
	}
}