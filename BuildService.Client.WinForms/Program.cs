using BuildService.Client.WinForms.Authentication;

namespace BuildService.Client.WinForms
{
    public static class Program
    {
        public static int VERSION = 1;

        internal static AuthenticationManager AuthManager = new AuthenticationManager();

        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainDashboard());
        }
    }
}