using Epic.OnlineServices.Logging;
using Epic.OnlineServices.Platform;

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
		}

		//dispose
		platformInterface.Release();
		platformInterface = null;
		var shutdownResult = PlatformInterface.Shutdown();
		Console.WriteLine($"shudown result = {shutdownResult.ToString()}");
	}


	private static void Update(PlatformInterface platformInterface, int loopCount)
	{
		platformInterface.Tick();
		Console.WriteLine($"Update Done: loopCount = {loopCount}");
	}
}
