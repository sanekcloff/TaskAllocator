using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Host.Logs;
using Host.ServerControls;
using System.ComponentModel;

namespace Host
{
    internal class Program 
    {

        static void Main(string[] args)
        {
            Server.ServerStart += Logger.OnServerAction;
            Server.ServerStop += Logger.OnServerAction;
            Server.ClientConnected += Logger.OnServerAction;
            Server.ServerThrowException += Logger.OnServerAction;
            // Запуск сервера
            Server.Start();

            // Создание базы данных при отсутсвии
            var context = new SqliteDBContext();
            new DatabaseFacade(context).EnsureCreated();

            while (true)
            {
                Server.AcceptClient();
                Server.BroadcastConnection();
            }
        }
    }
}
