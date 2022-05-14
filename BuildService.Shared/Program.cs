using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BuildService.Shared
{
    public static class MainClass
    {
        public static Server Server = new Server();
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
            Server.InitalizeServer();
            Server.StartThreads();
            Console.ReadKey(true);
        }
    }
}
