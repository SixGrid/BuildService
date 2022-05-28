using BuildService.Client.WinForms.Authentication;
using BuildService.Client.WinForms.Network;

namespace BuildService.Client.WinForms
{
    public partial class MainDashboard : Form
    {
        public MainDashboard()
        {
            InitializeComponent();

            ReloadList_AuthProfiles();
            ReloadList_ConnectionProfiles();
        }

        public void ReloadList_AuthProfiles()
        {
            listView_Auth.Items.Clear();
            foreach (var profile in Program.AuthenticationMan.Profiles)
            {
                var item = new ListViewItem(new String[] {
                    profile.Label,
                    profile.Username
                });
                item.Tag = profile.ID;

                listView_Auth.Items.Add(item);
            }
        }
        public void ReloadList_ConnectionProfiles()
        {
            listView_Connections.Items.Clear();
            foreach (var profile in Program.ConnectionMan.Profiles)
            {
                var item = new ListViewItem(new String[] {
                    profile.Name,
                    $@"{profile.IpAddress}:{profile.Port}{profile.Path}"
                });
                item.Tag = profile.ID;

                listView_Connections.Items.Add(item);
            }
        }
        public void ReloadList_All()
        {
            ReloadList_AuthProfiles();
            ReloadList_ConnectionProfiles();
        }

        ConnectionProfile SelectedConnectionProfile = null;

        private void listView_Connections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Connections.SelectedItems.Count < 1)
            {
                toolStripButton_ConnectionEdit.Enabled = false;
                toolStripButton_ConnectionRemove.Enabled = false;
                SelectedConnectionProfile = null;
                return;
            }

            var res = Program.ConnectionMan.GetProfileByID(listView_Connections.SelectedItems[0].Tag.ToString());
            SelectedConnectionProfile = res == null ? null : res;
            if (SelectedConnectionProfile != null)
            {
                toolStripButton_ConnectionEdit.Enabled = true;
                toolStripButton_ConnectionRemove.Enabled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Save();
        }

        DialogAccountModify accountModifyDialog;
        private void toolStripButton_AuthAdd_Click(object sender, EventArgs e)
        {
            var profile = new AuthenticationProfile();
            Program.AuthenticationMan.Profiles.Add(profile);

            if (accountModifyDialog == null || accountModifyDialog.IsDisposed)
            {
                accountModifyDialog = new DialogAccountModify(profile);
            }
            else
            {
                accountModifyDialog.Focus();
            }

            accountModifyDialog.SetProfile(profile);

            accountModifyDialog.Show();
        }

        private void profileListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadList_AuthProfiles();
        }
        private void connectionProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadList_ConnectionProfiles();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadList_AuthProfiles();
            ReloadList_ConnectionProfiles();
        }

        DialogConnectionModify connectionModifyDialog;
        private void toolStripButton_ConnectionAdd_Click(object sender, EventArgs e)
        {
            var profile = new ConnectionProfile();
            Program.ConnectionMan.Profiles.Add(profile);

            if (connectionModifyDialog == null || connectionModifyDialog.IsDisposed)
            {
                connectionModifyDialog = new DialogConnectionModify(profile);
            }
            else
            {
                connectionModifyDialog.Focus();
            }
            connectionModifyDialog.SetProfile(profile);

            connectionModifyDialog.Show();
        }

        private void toolStripButton_ConnectionRemove_Click(object sender, EventArgs e)
        {
            Program.ConnectionMan.DeleteProfile(SelectedConnectionProfile);
            SelectedConnectionProfile = null;
            ReloadList_All();
        }

        private void toolStripButton_ConnectionEdit_Click(object sender, EventArgs e)
        {
            if (connectionModifyDialog == null || connectionModifyDialog.IsDisposed)
            {
                connectionModifyDialog = new DialogConnectionModify(SelectedConnectionProfile);
            }
            else
            {
                connectionModifyDialog.Focus();
            }
            connectionModifyDialog.SetProfile(SelectedConnectionProfile);

            connectionModifyDialog.Show();
        }
    }
}