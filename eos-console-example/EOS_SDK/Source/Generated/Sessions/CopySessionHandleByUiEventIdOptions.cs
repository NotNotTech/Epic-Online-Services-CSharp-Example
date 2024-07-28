// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Sessions
{
	/// <summary>
	/// Input parameters for the <see cref="SessionsInterface.CopySessionHandleByUiEventId" /> function.
	/// </summary>
	public struct CopySessionHandleByUiEventIdOptions
	{
		/// <summary>
		/// UI Event associated with the session
		/// </summary>
		public ulong UiEventId { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct CopySessionHandleByUiEventIdOptionsInternal : ISettable<CopySessionHandleByUiEventIdOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private ulong m_UiEventId;

		public ulong UiEventId
		{
			set
			{
				m_UiEventId = value;
			}
		}

		public void Set(ref CopySessionHandleByUiEventIdOptions other)
		{
			m_ApiVersion = SessionsInterface.CopysessionhandlebyuieventidApiLatest;
			UiEventId = other.UiEventId;
		}

		public void Set(ref CopySessionHandleByUiEventIdOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = SessionsInterface.CopysessionhandlebyuieventidApiLatest;
				UiEventId = other.Value.UiEventId;
			}
		}

		public void Dispose()
		{
		}
	}
}