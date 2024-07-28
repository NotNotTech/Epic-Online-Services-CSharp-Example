// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.ProgressionSnapshot
{
	public struct EndSnapshotOptions
	{
		/// <summary>
		/// The Snapshot Id received via a <see cref="ProgressionSnapshotInterface.BeginSnapshot" /> function.
		/// </summary>
		public uint SnapshotId { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct EndSnapshotOptionsInternal : ISettable<EndSnapshotOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private uint m_SnapshotId;

		public uint SnapshotId
		{
			set
			{
				m_SnapshotId = value;
			}
		}

		public void Set(ref EndSnapshotOptions other)
		{
			m_ApiVersion = ProgressionSnapshotInterface.EndsnapshotApiLatest;
			SnapshotId = other.SnapshotId;
		}

		public void Set(ref EndSnapshotOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = ProgressionSnapshotInterface.EndsnapshotApiLatest;
				SnapshotId = other.Value.SnapshotId;
			}
		}

		public void Dispose()
		{
		}
	}
}