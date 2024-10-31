using CoreWCF;
using Data.Models;


namespace Service
{

    [ServiceContract(CallbackContract = typeof(IServerClientCallBack))]
    public interface IServiceServer
    {
        delegate void ServerActionEvetHandler(object sender, EventArgs e);
        event ServerActionEvetHandler? ServerStart;
        event ServerActionEvetHandler? ServerStop;
        event ServerActionEvetHandler? ServerAcceptClient;
        event ServerActionEvetHandler? ClientConnect;
        event ServerActionEvetHandler? ClientDisconnect;
        event ServerActionEvetHandler? LogSend;

        [OperationContract]
        User Connect(ServerUser user);
        [OperationContract]
        void Disconnect(ServerUser user);
        [OperationContract(IsOneWay = true)]
        string SendLog(ServerUser user, string message);
        [OperationContract(IsOneWay = true)]
        string SendLog(string message);
    }
    public interface IServerClientCallBack
    {
        [OperationContract(IsOneWay = true)]
        void SendLogCallBack(string message);
    }
}
