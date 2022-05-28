using BuildService.Client.WinForms.Authentication;
using BuildService.Client.WinForms.Network;

namespace BuildService.Client.WinForms
{
    public static class Program
    {
        public static int VERSION = 1;

        public static AuthenticationManager AuthenticationMan = new AuthenticationManager();
        public static ConnectionManager ConnectionMan = new ConnectionManager();

        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainDashboard());
        }

        public static void Save()
        {
            AuthenticationMan.DatabaseSerialize();
            ConnectionMan.DatabaseSerialize();
        }
    }
}