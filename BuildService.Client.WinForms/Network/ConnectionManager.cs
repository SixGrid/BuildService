using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildService.Client.WinForms.Network
{
    internal class ConnectionManager
    {
        internal List<ServerConnection> ActiveConnections = new List<ServerConnection>();
        internal List<ConnectionProfile> Profiles = new List<ConnectionProfile>();
    }
}
