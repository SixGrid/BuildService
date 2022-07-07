using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BuildService.Shared
{
    public static class MainClass
    {
        public static Server Server;
        public static string BuildScriptExtension
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    return @".sh";
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    return @".bat";
                return @"";
            }
            set { }
        }

        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == @"-server")
            {
                InitalizeServer();
            }
            else
            {
                Console.Error.WriteLine(@"pls launch with the single argument '-server' to launch the BuildService server ;w;");
                Environment.Exit(1);
            }
        }

        private static void InitalizeServer()
        {
            Server = new Server();
            Server.InitalizeServer();
            Server.StartThreads();
            Console.ReadKey(true);
            Console.WriteLine(@"Goodbye!");
            Environment.Exit(-1);
        }
    }
}
