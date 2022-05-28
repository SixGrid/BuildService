using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildService.Client.WinForms.UserControl
{
    public partial class IPTextBox : TextBox
    {
        public IPTextBox() : base()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ClassName = "SysIPAddress32";
                return cp;
            }
        }
    }
}
