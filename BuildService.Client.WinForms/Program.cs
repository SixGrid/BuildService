using BuildService.Client.WinForms.Authentication;
using BuildService.Client.WinForms.Network;

namespace BuildService.Client.WinForms
{
    public static class Program
    {
        public static int VERSION = 1;

        internal static AuthenticationManager AuthenticationMan = new AuthenticationManager();
        internal static ConnectionManager ConnectionMan = new ConnectionManager();

        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainDashboard());
        }
    }
}