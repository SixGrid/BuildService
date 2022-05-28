using BuildService.Client.WinForms.Authentication;
using BuildService.Client.WinForms.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildService.Client.WinForms
{
    public partial class DialogConnectionModify : Form
    {
        public ConnectionProfile TargetProfile;
        public DialogConnectionModify(ConnectionProfile profile)
        {
            InitializeComponent();
            SetProfile(profile);
        }

        public void SetProfile(ConnectionProfile profile)
        {
            TargetProfile = profile;

            GenerateAuthProfileCombo();

            textBoxAddress.Text = profile.IpAddress;
            textBoxPort.Text = profile.Port.ToString();

            textBoxName.Text = profile.Name;
            textBoxDescription.Text = profile.Description;

            textBoxPath.Text = profile.Path;

            checkBoxSecure.Checked = profile.Secure;

            int index = 0;
            foreach (var item in comboBoxAuthProfile.Items)
            {
                var target = profile.GetAuthProfile();
                if (target == null) continue;
                if (item.ToString() == $@"{target.Label} ({target.ID})")
                {
                    comboBoxAuthProfile.SelectedIndex = index;
                }
                index++;
            }
        }

        private void GenerateAuthProfileCombo()
        {
            comboBoxAuthProfile.Items.Clear();
            foreach (var profile in Program.AuthenticationMan.Profiles)
            {
                comboBoxAuthProfile.Items.Add($@"{profile.Label} ({profile.ID})");
            }
        }

        private AuthenticationProfile? GetSelectedAuthProfile()
        {
            foreach (var profile in Program.AuthenticationMan.Profiles)
            {
                if (comboBoxAuthProfile.SelectedItem.ToString() == $@"{profile.Label} ({profile.ID})")
                {
                    return profile;
                }
            }
            return null;
        }

        private void textBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            var target = Convert.ToInt64(textBoxPort.Text);
            if (target > uint.MaxValue)
            {
                target = uint.MaxValue;
            }
            if (target < 0)
            {
                target = 0;
            }

            textBoxPort.Text = target.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            TargetProfile.rUpdatedAt();
            TargetProfile.IpAddress = textBoxAddress.Text;
            TargetProfile.Port = Convert.ToUInt32(textBoxPort.Text);
            TargetProfile.Name = textBoxName.Text;
            TargetProfile.Description = textBoxDescription.Text;
            TargetProfile.Secure = checkBoxSecure.Checked;
            TargetProfile.Path = textBoxPath.Text;
            string? id = GetSelectedAuthProfile()?.ID;
            TargetProfile.AuthProfileID = id == null ? @"" : id;
            Program.ConnectionMan.DatabaseSerialize();

            Close();
            Dispose();
        }

        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Program.ConnectionMan.DeleteProfile(TargetProfile);
            Program.ConnectionMan.DatabaseSerialize();

            Close();
            Dispose();
        }
    }
}
