// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.UserInfo
{
	public sealed partial class UserInfoInterface : Handle
	{
		public UserInfoInterface()
		{
		}

		public UserInfoInterface(System.IntPtr innerHandle) : base(innerHandle)
		{
		}

		/// <summary>
		/// The most recent version of the <see cref="BestDisplayName" /> API.
		/// </summary>
		public const int BestdisplaynameApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="CopyBestDisplayName" /> API.
		/// </summary>
		public const int CopybestdisplaynameApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="CopyBestDisplayNameWithPlatform" /> API.
		/// </summary>
		public const int CopybestdisplaynamewithplatformApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="CopyExternalUserInfoByAccountIdOptions" /> struct.
		/// </summary>
		public const int CopyexternaluserinfobyaccountidApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="CopyExternalUserInfoByIndexOptions" /> struct.
		/// </summary>
		public const int CopyexternaluserinfobyaccounttypeApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="CopyExternalUserInfoByIndexOptions" /> struct.
		/// </summary>
		public const int CopyexternaluserinfobyindexApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="CopyUserInfo" /> API.
		/// </summary>
		public const int CopyuserinfoApiLatest = 3;

		/// <summary>
		/// The most recent version of the <see cref="ExternalUserInfo" /> struct.
		/// </summary>
		public const int ExternaluserinfoApiLatest = 2;

		/// <summary>
		/// The most recent version of the <see cref="Achievements.AchievementsInterface.GetAchievementDefinitionCount" /> API.
		/// </summary>
		public const int GetexternaluserinfocountApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="GetLocalPlatformType" /> API.
		/// </summary>
		public const int GetlocalplatformtypeApiLatest = 1;

		/// <summary>
		/// The maximum length of display names, in displayable characters
		/// </summary>
		public const int MaxDisplaynameCharacters = 16;

		/// <summary>
		/// The maximum length of display names when encoded as UTF-8 as returned by <see cref="CopyUserInfo" />. This length does not include the null terminator.
		/// </summary>
		public const int MaxDisplaynameUtf8Length = 64;

		/// <summary>
		/// The most recent version of the <see cref="QueryUserInfo" /> API.
		/// </summary>
		public const int QueryuserinfoApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="QueryUserInfoByDisplayName" /> API.
		/// </summary>
		public const int QueryuserinfobydisplaynameApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="QueryUserInfoByExternalAccount" /> API.
		/// </summary>
		public const int QueryuserinfobyexternalaccountApiLatest = 1;

		/// <summary>
		/// <see cref="CopyBestDisplayName" /> is used to immediately retrieve a copy of user's best display name based on an Epic Account ID.
		/// This uses data cached by a previous call to <see cref="QueryUserInfo" />, <see cref="QueryUserInfoByDisplayName" /> or <see cref="QueryUserInfoByExternalAccount" /> as well as <see cref="Connect.ConnectInterface.QueryExternalAccountMappings" />.
		/// If the call returns an <see cref="Result.Success" /> result, the out parameter, OutBestDisplayName, must be passed to <see cref="Release" /> to release the memory associated with it.
		/// 
		/// @details The current priority for picking display name is as follows:
		/// 1. Target is online and friends with user, then use presence platform to determine display name
		/// 2. Target is in same lobby or is the owner of a lobby search result, then use lobby platform to determine display name (this requires the target's product user id to be cached)
		/// 3. Target is in same rtc room, then use rtc room platform to determine display name (this requires the target's product user id to be cached)
		/// <seealso cref="QueryUserInfo" />
		/// <seealso cref="QueryUserInfoByDisplayName" />
		/// <seealso cref="QueryUserInfoByExternalAccount" />
		/// <seealso cref="Connect.ConnectInterface.QueryExternalAccountMappings" />
		/// <seealso cref="CopyBestDisplayNameWithPlatform" />
		/// <seealso cref="CopyBestDisplayNameOptions" />
		/// <seealso cref="BestDisplayName" />
		/// <seealso cref="Release" />
		/// </summary>
		/// <param name="options">structure containing the input parameters</param>
		/// <param name="outBestDisplayName">out parameter used to receive the <see cref="BestDisplayName" /> structure.</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutBestDisplayName
		/// <see cref="Result.UserInfoBestDisplayNameIndeterminate" /> unable to determine a cert friendly display name for user, one potential solution would be to call <see cref="CopyBestDisplayNameWithPlatform" /> with <see cref="Types.OnlinePlatform.OptEpic" /> for the platform, see doc for more details
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect
		/// <see cref="Result.NotFound" /> if the user info or product user id is not locally cached
		/// </returns>
		public Result CopyBestDisplayName(ref CopyBestDisplayNameOptions options, out BestDisplayName? outBestDisplayName)
		{
			CopyBestDisplayNameOptionsInternal optionsInternal = new CopyBestDisplayNameOptionsInternal();
			optionsInternal.Set(ref options);

			var outBestDisplayNameAddress = System.IntPtr.Zero;

			var funcResult = Bindings.EOS_UserInfo_CopyBestDisplayName(InnerHandle, ref optionsInternal, ref outBestDisplayNameAddress);

			Helper.Dispose(ref optionsInternal);

			Helper.Get<BestDisplayNameInternal, BestDisplayName>(outBestDisplayNameAddress, out outBestDisplayName);
			if (outBestDisplayName != null)
			{
				Bindings.EOS_UserInfo_BestDisplayName_Release(outBestDisplayNameAddress);
			}

			return funcResult;
		}

		/// <summary>
		/// <see cref="CopyBestDisplayNameWithPlatform" /> is used to immediately retrieve a copy of user's best display name based on an Epic Account ID.
		/// This uses data cached by a previous call to <see cref="QueryUserInfo" />, <see cref="QueryUserInfoByDisplayName" /> or <see cref="QueryUserInfoByExternalAccount" />.
		/// If the call returns an <see cref="Result.Success" /> result, the out parameter, OutBestDisplayName, must be passed to <see cref="Release" /> to release the memory associated with it.
		/// 
		/// @details The current priority for picking display name is as follows:
		/// 1. If platform is non-epic, then use platform display name (if the platform is linked to the account)
		/// 2. If platform is epic and user has epic display name, then use epic display name
		/// 3. If platform is epic and user has no epic display name, then use linked external account display name
		/// <seealso cref="QueryUserInfo" />
		/// <seealso cref="QueryUserInfoByDisplayName" />
		/// <seealso cref="QueryUserInfoByExternalAccount" />
		/// <seealso cref="CopyBestDisplayNameWithPlatformOptions" />
		/// <seealso cref="BestDisplayName" />
		/// <seealso cref="Release" />
		/// </summary>
		/// <param name="options">structure containing the input parameters</param>
		/// <param name="outBestDisplayName">out parameter used to receive the <see cref="BestDisplayName" /> structure.</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutBestDisplayName
		/// <see cref="Result.UserInfoBestDisplayNameIndeterminate" /> unable to determine a cert friendly display name for user
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect
		/// <see cref="Result.NotFound" /> if the user info is not locally cached
		/// </returns>
		public Result CopyBestDisplayNameWithPlatform(ref CopyBestDisplayNameWithPlatformOptions options, out BestDisplayName? outBestDisplayName)
		{
			CopyBestDisplayNameWithPlatformOptionsInternal optionsInternal = new CopyBestDisplayNameWithPlatformOptionsInternal();
			optionsInternal.Set(ref options);

			var outBestDisplayNameAddress = System.IntPtr.Zero;

			var funcResult = Bindings.EOS_UserInfo_CopyBestDisplayNameWithPlatform(InnerHandle, ref optionsInternal, ref outBestDisplayNameAddress);

			Helper.Dispose(ref optionsInternal);

			Helper.Get<BestDisplayNameInternal, BestDisplayName>(outBestDisplayNameAddress, out outBestDisplayName);
			if (outBestDisplayName != null)
			{
				Bindings.EOS_UserInfo_BestDisplayName_Release(outBestDisplayNameAddress);
			}

			return funcResult;
		}

		/// <summary>
		/// Fetches an external user info for a given external account ID.
		/// <seealso cref="Release" />
		/// </summary>
		/// <param name="options">Structure containing the account ID being accessed</param>
		/// <param name="outExternalUserInfo">The external user info. If it exists and is valid, use <see cref="Release" /> when finished</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutExternalUserInfo
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if the external user info is not found
		/// </returns>
		public Result CopyExternalUserInfoByAccountId(ref CopyExternalUserInfoByAccountIdOptions options, out ExternalUserInfo? outExternalUserInfo)
		{
			CopyExternalUserInfoByAccountIdOptionsInternal optionsInternal = new CopyExternalUserInfoByAccountIdOptionsInternal();
			optionsInternal.Set(ref options);

			var outExternalUserInfoAddress = System.IntPtr.Zero;

			var funcResult = Bindings.EOS_UserInfo_CopyExternalUserInfoByAccountId(InnerHandle, ref optionsInternal, ref outExternalUserInfoAddress);

			Helper.Dispose(ref optionsInternal);

			Helper.Get<ExternalUserInfoInternal, ExternalUserInfo>(outExternalUserInfoAddress, out outExternalUserInfo);
			if (outExternalUserInfo != null)
			{
				Bindings.EOS_UserInfo_ExternalUserInfo_Release(outExternalUserInfoAddress);
			}

			return funcResult;
		}

		/// <summary>
		/// Fetches an external user info for a given external account type.
		/// <seealso cref="Release" />
		/// </summary>
		/// <param name="options">Structure containing the account type being accessed</param>
		/// <param name="outExternalUserInfo">The external user info. If it exists and is valid, use <see cref="Release" /> when finished</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutExternalUserInfo
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if the external user info is not found
		/// </returns>
		public Result CopyExternalUserInfoByAccountType(ref CopyExternalUserInfoByAccountTypeOptions options, out ExternalUserInfo? outExternalUserInfo)
		{
			CopyExternalUserInfoByAccountTypeOptionsInternal optionsInternal = new CopyExternalUserInfoByAccountTypeOptionsInternal();
			optionsInternal.Set(ref options);

			var outExternalUserInfoAddress = System.IntPtr.Zero;

			var funcResult = Bindings.EOS_UserInfo_CopyExternalUserInfoByAccountType(InnerHandle, ref optionsInternal, ref outExternalUserInfoAddress);

			Helper.Dispose(ref optionsInternal);

			Helper.Get<ExternalUserInfoInternal, ExternalUserInfo>(outExternalUserInfoAddress, out outExternalUserInfo);
			if (outExternalUserInfo != null)
			{
				Bindings.EOS_UserInfo_ExternalUserInfo_Release(outExternalUserInfoAddress);
			}

			return funcResult;
		}

		/// <summary>
		/// Fetches an external user info from a given index.
		/// <seealso cref="Release" />
		/// </summary>
		/// <param name="options">Structure containing the index being accessed</param>
		/// <param name="outExternalUserInfo">The external user info. If it exists and is valid, use <see cref="Release" /> when finished</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutExternalUserInfo
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.NotFound" /> if the external user info is not found
		/// </returns>
		public Result CopyExternalUserInfoByIndex(ref CopyExternalUserInfoByIndexOptions options, out ExternalUserInfo? outExternalUserInfo)
		{
			CopyExternalUserInfoByIndexOptionsInternal optionsInternal = new CopyExternalUserInfoByIndexOptionsInternal();
			optionsInternal.Set(ref options);

			var outExternalUserInfoAddress = System.IntPtr.Zero;

			var funcResult = Bindings.EOS_UserInfo_CopyExternalUserInfoByIndex(InnerHandle, ref optionsInternal, ref outExternalUserInfoAddress);

			Helper.Dispose(ref optionsInternal);

			Helper.Get<ExternalUserInfoInternal, ExternalUserInfo>(outExternalUserInfoAddress, out outExternalUserInfo);
			if (outExternalUserInfo != null)
			{
				Bindings.EOS_UserInfo_ExternalUserInfo_Release(outExternalUserInfoAddress);
			}

			return funcResult;
		}

		/// <summary>
		/// <see cref="CopyUserInfo" /> is used to immediately retrieve a copy of user information based on an Epic Account ID, cached by a previous call to <see cref="QueryUserInfo" />.
		/// If the call returns an <see cref="Result.Success" /> result, the out parameter, OutUserInfo, must be passed to <see cref="Release" /> to release the memory associated with it.
		/// <seealso cref="UserInfoData" />
		/// <seealso cref="CopyUserInfoOptions" />
		/// <seealso cref="Release" />
		/// </summary>
		/// <param name="options">structure containing the input parameters</param>
		/// <param name="outUserInfo">out parameter used to receive the <see cref="UserInfoData" /> structure.</param>
		/// <returns>
		/// <see cref="Result.Success" /> if the information is available and passed out in OutUserInfo
		/// <see cref="Result.InvalidParameters" /> if you pass a null pointer for the out parameter
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect
		/// <see cref="Result.NotFound" /> if the user info is not locally cached. The information must have been previously cached by a call to <see cref="QueryUserInfo" />
		/// </returns>
		public Result CopyUserInfo(ref CopyUserInfoOptions options, out UserInfoData? outUserInfo)
		{
			CopyUserInfoOptionsInternal optionsInternal = new CopyUserInfoOptionsInternal();
			optionsInternal.Set(ref options);

			var outUserInfoAddress = System.IntPtr.Zero;

			var funcResult = Bindings.EOS_UserInfo_CopyUserInfo(InnerHandle, ref optionsInternal, ref outUserInfoAddress);

			Helper.Dispose(ref optionsInternal);

			Helper.Get<UserInfoDataInternal, UserInfoData>(outUserInfoAddress, out outUserInfo);
			if (outUserInfo != null)
			{
				Bindings.EOS_UserInfo_Release(outUserInfoAddress);
			}

			return funcResult;
		}

		/// <summary>
		/// Fetch the number of external user infos that are cached locally.
		/// <seealso cref="CopyExternalUserInfoByIndex" />
		/// </summary>
		/// <param name="options">The options associated with retrieving the external user info count</param>
		/// <returns>
		/// The number of external user infos, or 0 if there is an error
		/// </returns>
		public uint GetExternalUserInfoCount(ref GetExternalUserInfoCountOptions options)
		{
			GetExternalUserInfoCountOptionsInternal optionsInternal = new GetExternalUserInfoCountOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UserInfo_GetExternalUserInfoCount(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// <see cref="GetLocalPlatformType" /> is used to retrieve the online platform type of the current running instance of the game.
		/// <seealso cref="GetLocalPlatformTypeOptions" />
		/// </summary>
		/// <param name="options">structure containing the input parameters</param>
		/// <returns>
		/// the online platform type of the current running instance of the game
		/// </returns>
		public uint GetLocalPlatformType(ref GetLocalPlatformTypeOptions options)
		{
			GetLocalPlatformTypeOptionsInternal optionsInternal = new GetLocalPlatformTypeOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UserInfo_GetLocalPlatformType(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// <see cref="QueryUserInfo" /> is used to start an asynchronous query to retrieve information, such as display name, about another account.
		/// Once the callback has been fired with a successful ResultCode, it is possible to call <see cref="CopyUserInfo" /> to receive an <see cref="UserInfoData" /> containing the available information.
		/// <seealso cref="UserInfoData" />
		/// <seealso cref="CopyUserInfo" />
		/// <seealso cref="QueryUserInfoOptions" />
		/// <seealso cref="OnQueryUserInfoCallback" />
		/// </summary>
		/// <param name="options">structure containing the input parameters</param>
		/// <param name="clientData">arbitrary data that is passed back to you in the CompletionDelegate</param>
		/// <param name="completionDelegate">a callback that is fired when the async operation completes, either successfully or in error</param>
		public void QueryUserInfo(ref QueryUserInfoOptions options, object clientData, OnQueryUserInfoCallback completionDelegate)
		{
			QueryUserInfoOptionsInternal optionsInternal = new QueryUserInfoOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var completionDelegateInternal = new OnQueryUserInfoCallbackInternal(OnQueryUserInfoCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			Bindings.EOS_UserInfo_QueryUserInfo(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);

			Helper.Dispose(ref optionsInternal);
		}

		/// <summary>
		/// <see cref="QueryUserInfoByDisplayName" /> is used to start an asynchronous query to retrieve user information by display name. This can be useful for getting the <see cref="EpicAccountId" /> for a display name.
		/// Once the callback has been fired with a successful ResultCode, it is possible to call <see cref="CopyUserInfo" /> to receive an <see cref="UserInfoData" /> containing the available information.
		/// <seealso cref="UserInfoData" />
		/// <seealso cref="CopyUserInfo" />
		/// <seealso cref="QueryUserInfoByDisplayNameOptions" />
		/// <seealso cref="OnQueryUserInfoByDisplayNameCallback" />
		/// </summary>
		/// <param name="options">structure containing the input parameters</param>
		/// <param name="clientData">arbitrary data that is passed back to you in the CompletionDelegate</param>
		/// <param name="completionDelegate">a callback that is fired when the async operation completes, either successfully or in error</param>
		public void QueryUserInfoByDisplayName(ref QueryUserInfoByDisplayNameOptions options, object clientData, OnQueryUserInfoByDisplayNameCallback completionDelegate)
		{
			QueryUserInfoByDisplayNameOptionsInternal optionsInternal = new QueryUserInfoByDisplayNameOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var completionDelegateInternal = new OnQueryUserInfoByDisplayNameCallbackInternal(OnQueryUserInfoByDisplayNameCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			Bindings.EOS_UserInfo_QueryUserInfoByDisplayName(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);

			Helper.Dispose(ref optionsInternal);
		}

		/// <summary>
		/// <see cref="QueryUserInfoByExternalAccount" /> is used to start an asynchronous query to retrieve user information by external accounts.
		/// This can be useful for getting the <see cref="EpicAccountId" /> for external accounts.
		/// Once the callback has been fired with a successful ResultCode, it is possible to call CopyUserInfo to receive an <see cref="UserInfoData" /> containing the available information.
		/// <seealso cref="UserInfoData" />
		/// <seealso cref="QueryUserInfoByExternalAccountOptions" />
		/// <seealso cref="OnQueryUserInfoByExternalAccountCallback" />
		/// </summary>
		/// <param name="options">structure containing the input parameters</param>
		/// <param name="clientData">arbitrary data that is passed back to you in the CompletionDelegate</param>
		/// <param name="completionDelegate">a callback that is fired when the async operation completes, either successfully or in error</param>
		public void QueryUserInfoByExternalAccount(ref QueryUserInfoByExternalAccountOptions options, object clientData, OnQueryUserInfoByExternalAccountCallback completionDelegate)
		{
			QueryUserInfoByExternalAccountOptionsInternal optionsInternal = new QueryUserInfoByExternalAccountOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var completionDelegateInternal = new OnQueryUserInfoByExternalAccountCallbackInternal(OnQueryUserInfoByExternalAccountCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			Bindings.EOS_UserInfo_QueryUserInfoByExternalAccount(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);

			Helper.Dispose(ref optionsInternal);
		}

		[MonoPInvokeCallback(typeof(OnQueryUserInfoByDisplayNameCallbackInternal))]
		internal static void OnQueryUserInfoByDisplayNameCallbackInternalImplementation(ref QueryUserInfoByDisplayNameCallbackInfoInternal data)
		{
			OnQueryUserInfoByDisplayNameCallback callback;
			QueryUserInfoByDisplayNameCallbackInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnQueryUserInfoByExternalAccountCallbackInternal))]
		internal static void OnQueryUserInfoByExternalAccountCallbackInternalImplementation(ref QueryUserInfoByExternalAccountCallbackInfoInternal data)
		{
			OnQueryUserInfoByExternalAccountCallback callback;
			QueryUserInfoByExternalAccountCallbackInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnQueryUserInfoCallbackInternal))]
		internal static void OnQueryUserInfoCallbackInternalImplementation(ref QueryUserInfoCallbackInfoInternal data)
		{
			OnQueryUserInfoCallback callback;
			QueryUserInfoCallbackInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}
	}
}