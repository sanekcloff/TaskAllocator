﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Net.IO
{
    internal class PacketBuilder
    {
        MemoryStream ms;
        public PacketBuilder()
        {
            ms = new MemoryStream();
        }
        public void WriteOpCode(byte opcode)
        {
            ms.WriteByte(opcode);
        }
        public void WriteMessage(string msg)
        {
            var msgLength = msg.Length;
            ms.Write(BitConverter.GetBytes(msgLength));
            ms.Write(Encoding.UTF8.GetBytes(msg));
        }
        public byte[] GetPacketBytes()
        {
            return ms.ToArray();
        }
    }
}
