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

            TargetProfile = profile;

            textBoxAddress.Text = profile.IpAddress;
            textBoxPort.Text = profile.Port.ToString();

            textBoxName.Text = profile.Name;
            textBoxDescription.Text = profile.Description;
        }

        private void textBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            TargetProfile.IpAddress = textBoxAddress.Text;
            TargetProfile.Port = Convert.ToUInt32(textBoxPort.Text);
            TargetProfile.Name = textBoxName.Text;
            TargetProfile.Description = textBoxDescription.Text;
            TargetProfile.rUpdatedAt();
            Program.ConnectionMan.DatabaseSerialize();
        }
    }
}
