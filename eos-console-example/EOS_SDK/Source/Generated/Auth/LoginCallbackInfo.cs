// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Auth
{
	/// <summary>
	/// Output parameters for the <see cref="AuthInterface.Login" /> Function.
	/// </summary>
	public struct LoginCallbackInfo : ICallbackInfo
	{
		/// <summary>
		/// The <see cref="Result" /> code for the operation. <see cref="Result.Success" /> indicates that the operation succeeded; other codes indicate errors.
		/// </summary>
		public Result ResultCode { get; set; }

		/// <summary>
		/// Context that was passed into <see cref="AuthInterface.Login" />.
		/// </summary>
		public object ClientData { get; set; }

		/// <summary>
		/// The Epic Account ID of the local user who has logged in.
		/// </summary>
		public EpicAccountId LocalUserId { get; set; }

		/// <summary>
		/// Optional data that may be returned in the middle of the login flow, when neither the in-game overlay or a platform browser is used.
		/// This data is present when the ResultCode is <see cref="Result.AuthPinGrantCode" />.
		/// </summary>
		public PinGrantInfo? PinGrantInfo { get; set; }

		/// <summary>
		/// If the user was not found with external auth credentials passed into <see cref="AuthInterface.Login" />, this continuance token can be passed to <see cref="AuthInterface.LinkAccount" /> to continue the flow.
		/// </summary>
		public ContinuanceToken ContinuanceToken { get; set; }

		/// <summary>
		/// Deprecated field that is no longer used.
		/// </summary>
		internal AccountFeatureRestrictedInfo? AccountFeatureRestrictedInfo_DEPRECATED { get; set; }

		/// <summary>
		/// The Epic Account ID that has been previously selected to be used for the current application.
		/// Applications should use this ID to authenticate with online backend services that store game-scoped data for users.
		/// 
		/// Note: This ID may be different from LocalUserId if the user has previously merged Epic accounts into the account
		/// represented by LocalUserId, and one of the accounts that got merged had game data associated with it for the application.
		/// </summary>
		public EpicAccountId SelectedAccountId { get; set; }

		public Result? GetResultCode()
		{
			return ResultCode;
		}

		internal void Set(ref LoginCallbackInfoInternal other)
		{
			ResultCode = other.ResultCode;
			ClientData = other.ClientData;
			LocalUserId = other.LocalUserId;
			PinGrantInfo = other.PinGrantInfo;
			ContinuanceToken = other.ContinuanceToken;
			AccountFeatureRestrictedInfo_DEPRECATED = other.AccountFeatureRestrictedInfo_DEPRECATED;
			SelectedAccountId = other.SelectedAccountId;
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct LoginCallbackInfoInternal : ICallbackInfoInternal, IGettable<LoginCallbackInfo>, ISettable<LoginCallbackInfo>, System.IDisposable
	{
		private Result m_ResultCode;
		private System.IntPtr m_ClientData;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_PinGrantInfo;
		private System.IntPtr m_ContinuanceToken;
		private System.IntPtr m_AccountFeatureRestrictedInfo_DEPRECATED;
		private System.IntPtr m_SelectedAccountId;

		public Result ResultCode
		{
			get
			{
				return m_ResultCode;
			}

			set
			{
				m_ResultCode = value;
			}
		}

		public object ClientData
		{
			get
			{
				object value;
				Helper.Get(m_ClientData, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_ClientData);
			}
		}

		public System.IntPtr ClientDataAddress
		{
			get
			{
				return m_ClientData;
			}
		}

		public EpicAccountId LocalUserId
		{
			get
			{
				EpicAccountId value;
				Helper.Get(m_LocalUserId, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_LocalUserId);
			}
		}

		public PinGrantInfo? PinGrantInfo
		{
			get
			{
				PinGrantInfo? value;
				Helper.Get<PinGrantInfoInternal, PinGrantInfo>(m_PinGrantInfo, out value);
				return value;
			}

			set
			{
				Helper.Set<PinGrantInfo, PinGrantInfoInternal>(ref value, ref m_PinGrantInfo);
			}
		}

		public ContinuanceToken ContinuanceToken
		{
			get
			{
				ContinuanceToken value;
				Helper.Get(m_ContinuanceToken, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_ContinuanceToken);
			}
		}

		public AccountFeatureRestrictedInfo? AccountFeatureRestrictedInfo_DEPRECATED
		{
			get
			{
				AccountFeatureRestrictedInfo? value;
				Helper.Get<AccountFeatureRestrictedInfoInternal, AccountFeatureRestrictedInfo>(m_AccountFeatureRestrictedInfo_DEPRECATED, out value);
				return value;
			}

			set
			{
				Helper.Set<AccountFeatureRestrictedInfo, AccountFeatureRestrictedInfoInternal>(ref value, ref m_AccountFeatureRestrictedInfo_DEPRECATED);
			}
		}

		public EpicAccountId SelectedAccountId
		{
			get
			{
				EpicAccountId value;
				Helper.Get(m_SelectedAccountId, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_SelectedAccountId);
			}
		}

		public void Set(ref LoginCallbackInfo other)
		{
			ResultCode = other.ResultCode;
			ClientData = other.ClientData;
			LocalUserId = other.LocalUserId;
			PinGrantInfo = other.PinGrantInfo;
			ContinuanceToken = other.ContinuanceToken;
			AccountFeatureRestrictedInfo_DEPRECATED = other.AccountFeatureRestrictedInfo_DEPRECATED;
			SelectedAccountId = other.SelectedAccountId;
		}

		public void Set(ref LoginCallbackInfo? other)
		{
			if (other.HasValue)
			{
				ResultCode = other.Value.ResultCode;
				ClientData = other.Value.ClientData;
				LocalUserId = other.Value.LocalUserId;
				PinGrantInfo = other.Value.PinGrantInfo;
				ContinuanceToken = other.Value.ContinuanceToken;
				AccountFeatureRestrictedInfo_DEPRECATED = other.Value.AccountFeatureRestrictedInfo_DEPRECATED;
				SelectedAccountId = other.Value.SelectedAccountId;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_ClientData);
			Helper.Dispose(ref m_LocalUserId);
			Helper.Dispose(ref m_PinGrantInfo);
			Helper.Dispose(ref m_ContinuanceToken);
			Helper.Dispose(ref m_AccountFeatureRestrictedInfo_DEPRECATED);
			Helper.Dispose(ref m_SelectedAccountId);
		}

		public void Get(out LoginCallbackInfo output)
		{
			output = new LoginCallbackInfo();
			output.Set(ref this);
		}
	}
}