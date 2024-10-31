using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Host.Logs;
using Host.Net.IO;

namespace Host.ServerControls
{
    public static class Server
    {
        #region Const's
        const string SENDER = "Server";
        public static readonly TcpListener Listener = new TcpListener(IPAddress.Any, 5000);
        #endregion

        #region Fields & Properties
        public static List<ServerClient> Users = new();
        #endregion

        #region Delegates & Events
        internal delegate void ServerActionEventHandler(string text ,LogType logType= LogType.Message);

        internal static event ServerActionEventHandler? ServerStart;
        internal static event ServerActionEventHandler? ServerStop;
        internal static event ServerActionEventHandler? ClientConnected;
        internal static event ServerActionEventHandler? ServerThrowException;
        #endregion

        #region Methods
        public static void Start() 
        {
            try
            {
                Listener.Start();
                ServerStart?.Invoke("Server started!", LogType.Alert);
            }
            catch (Exception ex)
            {
                ServerThrowException?.Invoke(ex.Message,LogType.Error);
            }
        }
        public static void Stop() 
        {
            try
            {
                Listener.Stop();
                ServerStop?.Invoke("Server stoped!", LogType.Alert);
                Users.Clear();
            }
            catch (Exception ex)
            {
                ServerThrowException?.Invoke(ex.Message, LogType.Error);
            }
        }
        public static TcpClient AcceptClient()
        {
            try
            {
                var client = new ServerClient(Listener.AcceptTcpClient());
                ClientConnected?.Invoke($"Client {client.User} connected!");
                Users.Add(client);
                return client.ClientSocket;
                
            }
            catch (Exception ex)
            {
                ServerThrowException?.Invoke(ex.Message, LogType.Error);
                return null!;
            }
        }
        public static void BroadcastConnection()
        {
            foreach (var user in Users)
            {
                foreach (var u in  Users)
                {
                    var broadcastPacket = new PacketBuilder();
                    broadcastPacket.WriteOpCode(1);
                    broadcastPacket.WriteMessage(u.User);
                    user.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
                }
            }
        }
        #endregion
    }
}
