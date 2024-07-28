// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.AntiCheatServer
{
	public struct UnregisterClientOptions
	{
		/// <summary>
		/// Locally unique value describing the remote user, as previously passed to RegisterClient
		/// </summary>
		public System.IntPtr ClientHandle { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct UnregisterClientOptionsInternal : ISettable<UnregisterClientOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_ClientHandle;

		public System.IntPtr ClientHandle
		{
			set
			{
				m_ClientHandle = value;
			}
		}

		public void Set(ref UnregisterClientOptions other)
		{
			m_ApiVersion = AntiCheatServerInterface.UnregisterclientApiLatest;
			ClientHandle = other.ClientHandle;
		}

		public void Set(ref UnregisterClientOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = AntiCheatServerInterface.UnregisterclientApiLatest;
				ClientHandle = other.Value.ClientHandle;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_ClientHandle);
		}
	}
}