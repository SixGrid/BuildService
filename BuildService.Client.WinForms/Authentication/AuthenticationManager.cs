using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BuildServiceCommon.Helpers;

namespace BuildService.Client.WinForms.Authentication
{
    internal class AuthenticationManager
    {
        internal AuthenticationManager()
        {
            databaseDeserialize();
        }

        internal List<AuthenticationProfile> Profiles;
        internal int DatabaseVersion;
        internal bool InitialLoadComplete { get; private set; }

        public void Delete(AuthenticationProfile profile)
        {
            var newProfiles = new List<AuthenticationProfile>();
            foreach (AuthenticationProfile p in Profiles)
                if (p != profile)
                    newProfiles.Add(p);
            Profiles = newProfiles;
            DatabaseSerialize();
        }

        private string DATABASE_FILENAME = Path.Join(
            Directory.GetCurrentDirectory(),
            @"auth.db"
        );

        private void databaseDeserialize()
        {
            DatabaseHelper.Read(DATABASE_FILENAME, sr =>
            {
                DatabaseVersion = sr.ReadInt32();

                Profiles = (List<AuthenticationProfile>)sr.ReadBList<AuthenticationProfile>();
            }, () =>
            {
                MessageBox.Show(@"The local authentication database looks like it's corrupt. Oh well...", @"BuildService Client - Authentication Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });

            databasePostProcess();
        }
        internal void DatabaseSerialize()
        {
            DatabaseHelper.Write(DATABASE_FILENAME, sw =>
            {
                sw.Write(DatabaseVersion);
                sw.Write(Profiles);
            });
        }

        private void databasePostProcess()
        {
            if (Profiles == null)
            {
                Profiles = new List<AuthenticationProfile>();
                DatabaseVersion = BuildService.Client.WinForms.Program.VERSION;
                InitialLoadComplete = true;
                return;
            }
            InitialLoadComplete = true;
        }
    }
}
