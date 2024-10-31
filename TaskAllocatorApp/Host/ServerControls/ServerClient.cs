using Data.Models;
using Host.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Host.ServerControls
{
    public class ServerClient
    {
        public string User { get; set; } = null!;
        public Guid Id { get; set; }
        public TcpClient ClientSocket { get; set; } = null!;

        PacketReader packetReader = null!;
        public ServerClient(TcpClient client) 
        {
            ClientSocket = client;
            Id = Guid.NewGuid();
            packetReader = new PacketReader(ClientSocket.GetStream());
            var opcode = packetReader.ReadByte();

            User = packetReader.ReadMessage();
        }
    }
}
