using ConsoleClient.Net;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.ConnectedEvent += Server_ConnectedEvent;
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            server.Connect(username);
            while (true)
            {
                Console.Write("Send message: ");
                var msg = Console.ReadLine();
                Console.Clear();
            }
        }

        private static void Server_ConnectedEvent()
        {
            Console.WriteLine("Hello");
        }
    }
}
