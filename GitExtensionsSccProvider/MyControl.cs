﻿using System.Security.Permissions;
using System.Windows.Forms;

namespace Henk.GitExtensionsSccProvider
{
    /// <summary>
    /// Summary description for MyControl.
    /// </summary>
    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Let this control process the mnemonics.
        /// </summary>
        [UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        protected override bool ProcessDialogChar(char charCode)
        {
              // If we're the top-level form or control, we need to do the mnemonic handling
              if (charCode != ' ' && ProcessMnemonic(charCode))
              {
                    return true;
              }
              return base.ProcessDialogChar(charCode);
        }

        /// <summary>
        /// Enable the IME status handling for this control.
        /// </summary>
        protected override bool CanEnableIme
        {
            get
            {
                return true;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
        private void button1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(this,
                            string.Format(System.Globalization.CultureInfo.CurrentUICulture, "We are inside {0}.button1_Click()", this.ToString()),
                            "GitExtensions");
        }
    }
}
