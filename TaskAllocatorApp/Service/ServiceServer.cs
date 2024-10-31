using CoreWCF;
using Data.Models;
using System;

using static Service.IServiceServer; 

namespace Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceServer : IServiceServer
    {
        public event ServerActionEvetHandler? ServerStart;
        public event ServerActionEvetHandler? ServerStop;
        public event ServerActionEvetHandler? ServerAcceptClient;
        public event ServerActionEvetHandler? ClientConnect;
        public event ServerActionEvetHandler? ClientDisconnect;
        public event ServerActionEvetHandler? LogSend;

        public User Connect(ServerUser user)
        {
            ClientConnect?.Invoke(this, EventArgs.Empty);
            SendLog($"{user.User.Fullname} connected to server");
            return null!;
        }

        public void Disconnect(ServerUser user)
        {
            ClientDisconnect?.Invoke(this, EventArgs.Empty);
        }

        public string SendLog(ServerUser user, string message)
        {
            LogSend?.Invoke(this, EventArgs.Empty);  
            return message;
        }

        public string SendLog(string message)
        {
            LogSend?.Invoke(this, EventArgs.Empty);
            
            return message;
        }
    }
}