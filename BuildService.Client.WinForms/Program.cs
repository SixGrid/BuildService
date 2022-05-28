using BuildService.Client.WinForms.Authentication;
using BuildService.Client.WinForms.Network;

namespace BuildService.Client.WinForms
{
    public static class Program
    {
        public static int VERSION = 1;

        public static AuthenticationManager AuthenticationMan;
        public static ConnectionManager ConnectionMan;

        [STAThread]
        public static void Main()
        {
            AuthenticationMan = new AuthenticationManager();
            ConnectionMan = new ConnectionManager();
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