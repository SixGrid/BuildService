using BuildServiceCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildService.Client.WinForms.Network
{
    public class ConnectionManager
    {
        public ConnectionManager()
        {
            databaseDeserialize();
        }

        internal List<ServerConnection> ActiveConnections = new List<ServerConnection>();
        public List<ConnectionProfile> Profiles = new List<ConnectionProfile>();
        internal int DatabaseVersion;
        internal bool InitialLoadComplete { get; private set; }

        public void DeleteProfile(ConnectionProfile profile)
        {
            bool allow = true;
            foreach (var connection in ActiveConnections)
            {
                if (connection.Profile == profile)
                    allow = false;
            }

            if (allow)
            {
                var newProfiles = new List<ConnectionProfile>();
                foreach (var item in Profiles)
                {
                    if (item != profile)
                        newProfiles.Add(item);
                }
                Profiles = newProfiles;
                DatabaseSerialize();
            }
        }

        public ConnectionProfile? GetProfileByID(string id)
        {
            foreach (var profile in Profiles)
            {
                if (profile.ID == id)
                    return profile;
            }
            return null;
        }

        private string DATABASE_FILENAME = Path.Join(
            Directory.GetCurrentDirectory(),
            @"connection.db"
        );

        private void databaseDeserialize()
        {
            DatabaseHelper.Read(DATABASE_FILENAME, sr =>
            {
                DatabaseVersion = sr.ReadInt32();

                Profiles = (List<ConnectionProfile>)sr.ReadBList<ConnectionProfile>();
            }, () =>
            {
                MessageBox.Show(@"The connection profile database looks like it's corrupt. Oh well...", @"BuildService Client - Connection Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });

            databasePostProcess();
        }
        public void DatabaseSerialize()
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
                Profiles = new List<ConnectionProfile>();
                DatabaseVersion = BuildService.Client.WinForms.Program.VERSION;
                InitialLoadComplete = true;
                return;
            }
            InitialLoadComplete = true;
        }
    }
}
