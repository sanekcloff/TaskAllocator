using ConsoleClient.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.Net
{
    internal class Server
    {
        TcpClient client;
        public PacketReader PacketReader;
        public event Action ConnectedEvent;
        public Server()
        {
            client = new();
        }

        public void Connect(string username)
        {
            if (!client.Connected)
            {
                client.Connect("127.0.0.1",5000);
                PacketReader = new PacketReader(client.GetStream());
                if (string.IsNullOrEmpty(username))
                {
                    var connectPacket = new PacketBuilder();
                    connectPacket.WriteOpCode(0);
                    connectPacket.WriteString(username);
                    client.Client.Send(connectPacket.GetPacketBytes());
                }
                ReadPackets();
            }
        }

        private void ReadPackets()
        {
            Task.Run(()=>
            {
                while(true)
                {
                    var opcode = PacketReader.ReadByte();
                    switch (opcode)
                    {
                        case 1:
                            ConnectedEvent?.Invoke();
                            break;
                        default:
                            Console.WriteLine("Forgot username!");
                            break;
                    }
                }
            });
        }
    }
}
