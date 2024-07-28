// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Sessions
{
	/// <summary>
	/// Input parameters for the <see cref="ActiveSession.GetRegisteredPlayerCount" /> function.
	/// </summary>
	public struct ActiveSessionGetRegisteredPlayerCountOptions
	{
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct ActiveSessionGetRegisteredPlayerCountOptionsInternal : ISettable<ActiveSessionGetRegisteredPlayerCountOptions>, System.IDisposable
	{
		private int m_ApiVersion;

		public void Set(ref ActiveSessionGetRegisteredPlayerCountOptions other)
		{
			m_ApiVersion = ActiveSession.ActivesessionGetregisteredplayercountApiLatest;
		}

		public void Set(ref ActiveSessionGetRegisteredPlayerCountOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = ActiveSession.ActivesessionGetregisteredplayercountApiLatest;
			}
		}

		public void Dispose()
		{
		}
	}
}