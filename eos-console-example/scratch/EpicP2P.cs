//using Epic.OnlineServices.P2P;
//using Epic.OnlineServices.Platform;
//using Epic.OnlineServices;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Epic.OnlineServices.Samples;

//namespace RE_FORM.Manager
//{
//	internal class EpicP2P
//	{
//		private static EpicP2P _instance;
//		private EpicP2P() { }
//		public static EpicP2P Instance
//		{
//			get
//			{
//				if (_instance == null)
//				{
//					_instance = new EpicP2P();
//				}

//				return _instance;
//			}
//		}
//		P2PInterface P2P;
//		PlatformInterface Platform;
//		EpicManager Manager;
//		EpicConnect EpicConnect;
//		public bool IsConnected;
//		ulong NotifyPeerConnectionRequest;
//		ulong NotifyPeerConnectionEstablished;
//		bool IsAcceptedReq;
//		public ProductUserId? RemoteId;

//		public void DoConnect()
//		{
//			_instance = this;
//			Manager = EpicManager.Instance;
//			EpicConnect = EpicConnect.Instance;
//			Platform = Manager.Platform;
//			P2P = Manager.P2P;
//			IsConnected = true;
//			Notifies();
//		}

//		public void Tick()
//		{
//			GetNextReceivedPacketSizeOptions getNextReceivedPacketSizeOptions = new()
//			{
//				LocalUserId = EpicConnect.ProductUserId
//			};

//			var pakcetSizeResult = P2P.GetNextReceivedPacketSize(ref getNextReceivedPacketSizeOptions, out var outPacketSizeBytes);
//			if (pakcetSizeResult == Result.NotFound)
//				return;

//			ReceivePacketOptions receivePacketOptions = new()
//			{
//				LocalUserId = EpicConnect.ProductUserId,
//				MaxDataSizeBytes = ushort.MaxValue
//			};
//			byte[] bytes = new byte[(int)outPacketSizeBytes];

//			var res = P2P.ReceivePacket(ref receivePacketOptions, out var outPeerId, out var socketId, out var outChannel, bytes, out var outBytesWritten);
//			if (res == Result.NotFound)
//				return;
//			if (res == Result.Success)
//			{
//				if (bytes.Length != outBytesWritten)
//					bytes = bytes[..(int)outBytesWritten];
//				PrintPacket(bytes, outPeerId);
//			}
//		}

//		public void DisConnect()
//		{
//			CloseConnectionsOptions closeConnectionsOptions = new()
//			{
//				LocalUserId = EpicConnect.ProductUserId,
//				SocketId = new()
//				{
//					SocketName = "test"
//				}
//			};

//			P2P.CloseConnections(ref closeConnectionsOptions);
//			P2P.RemoveNotifyPeerConnectionEstablished(NotifyPeerConnectionRequest);
//			P2P.RemoveNotifyPeerConnectionEstablished(NotifyPeerConnectionEstablished);
//			Manager = null;
//			Platform = null;
//			P2P = null;
//			IsConnected = false;
//		}

//		public void PrintPacket(byte[] data, ProductUserId productUserId)
//		{
//			Log.WriteLine(Encoding.UTF8.GetString(data) + " | " + productUserId.ToString());
//		}

//		public void QueryNAT()
//		{
//			QueryNATTypeOptions queryNATTypeOptions = new QueryNATTypeOptions();

//			P2P.QueryNATType(ref queryNATTypeOptions, null, (ref OnQueryNATTypeCompleteInfo info) =>
//			{
//				Log.WriteLine(info.NATType.ToString());

//			});
//		}

//		public void Notifies()
//		{
//			if (!EpicConnect.ProductUserId.IsValid())
//				return;
//			AddNotifyPeerConnectionRequestOptions addNotifyPeerConnectionRequestOptions = new()
//			{
//				SocketId = new()
//				{
//					SocketName = "test"
//				},
//				LocalUserId = EpicConnect.ProductUserId
//			};

//			NotifyPeerConnectionRequest = P2P.AddNotifyPeerConnectionRequest(ref addNotifyPeerConnectionRequestOptions, null, IncomingCallConnectRequest);


//			AddNotifyPeerConnectionEstablishedOptions addNotifyPeerConnectionEstablishedOptions = new()
//			{
//				LocalUserId = EpicConnect.ProductUserId,
//				SocketId = new()
//				{
//					SocketName = "test"
//				}
//			};

//			NotifyPeerConnectionEstablished = P2P.AddNotifyPeerConnectionEstablished(ref addNotifyPeerConnectionEstablishedOptions, null, PeerConnectEstablished);
//		}

//		private void PeerConnectEstablished(ref OnPeerConnectionEstablishedInfo data)
//		{
//			Log.WriteLine("PeerConnectEstablished!");
//		}

//		private void IncomingCallConnectRequest(ref OnIncomingConnectionRequestInfo data)
//		{
//			AcceptConnectionOptions options = new()
//			{
//				LocalUserId = data.LocalUserId,
//				RemoteUserId = data.RemoteUserId,
//				SocketId = data.SocketId
//			};
//			RemoteId = data.RemoteUserId;
//			var res = P2P.AcceptConnection(ref options);
//			if (res == Result.Success)
//			{
//				IsAcceptedReq = true;
//			}
//		}


//		public void SendData(string data, ProductUserId userId)
//		{
//			SendPacketOptions sendPacketOptions = new()
//			{
//				AllowDelayedDelivery = true,
//				Channel = 0,
//				Data = Encoding.UTF8.GetBytes(data),
//				DisableAutoAcceptConnection = false,
//				LocalUserId = EpicConnect.ProductUserId,
//				Reliability = PacketReliability.ReliableOrdered,
//				RemoteUserId = userId,
//				SocketId = new()
//				{
//					SocketName = "test"
//				}
//			};

//			P2P.SendPacket(ref sendPacketOptions);

//		}
//	}
//}
