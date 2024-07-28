// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.P2P
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct SocketIdInternal : IGettable<SocketId>, ISettable<SocketId>, System.IDisposable
	{
		private int m_ApiVersion;
		[System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 33)]
		private byte[] m_SocketName;

		public string SocketName
		{
			get
			{
				string value;
				Helper.Get(m_SocketName, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_SocketName, 33);
			}
		}

		public void Set(ref SocketId other)
		{
			m_ApiVersion = P2PInterface.SocketidApiLatest;
			SocketName = other.SocketName;
		}

		public void Set(ref SocketId? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = P2PInterface.SocketidApiLatest;
				SocketName = other.Value.SocketName;
			}
		}

		public void Dispose()
		{
		}

		public void Get(out SocketId output)
		{
			output = new SocketId();
			output.Set(ref this);
		}
	}
}