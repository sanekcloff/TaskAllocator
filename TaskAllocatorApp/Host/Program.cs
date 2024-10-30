using Data.DataContext;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using static Host.Logger;

namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new DatabaseFacade(new SqliteDBContext()).EnsureCreated();
            LogWrite("Server started");
            while(true) { }
        }
    }
    static class Logger
    {
        const string loggerName = "Logger";
        public static void LogWrite(string text)
        {
            Console.Write($"\n[{DateTime.Now.ToString("f")}] - {loggerName}: {text}");
        }
    }
}
