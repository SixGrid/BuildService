using BuildService.Client.WinForms.Authentication;
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
    public partial class DialogAccountModify : Form
    {
        public DialogAccountModify(AuthenticationProfile profile)
        {
            InitializeComponent();
            SetProfile(profile);
        }
        private AuthenticationProfile AuthProfile;

        public void SetProfile(AuthenticationProfile profile)
        {
            AuthProfile = profile;

            textBoxLabel.Text = profile.Label;
            textBoxDescription.Text = profile.Description;
            textBoxUsername.Text = profile.Username;
            textBoxPassword.Text = profile.Passphrase;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            AuthProfile.Label = textBoxLabel.Text;
            AuthProfile.Description = textBoxDescription.Text;
            AuthProfile.Username = textBoxUsername.Text;
            AuthProfile.Passphrase = textBoxPassword.Text;
            AuthProfile.rUpdatedAt();

            Program.AuthenticationMan.DatabaseSerialize();

            Close();
            Dispose();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Program.AuthenticationMan.Delete(AuthProfile);

            Close();
            Dispose();
        }

        private void buttonDiscard_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
