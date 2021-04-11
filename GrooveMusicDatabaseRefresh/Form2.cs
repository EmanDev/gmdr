using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Diagnostics;

namespace GrooveMusicDatabaseRefresh
{
    public partial class Form2 : MaterialForm
    {
        public Form2()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        // Disable Windows State Maximize
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MAXIMIZEBOX = 0x00010000;
                var cp = base.CreateParams;
                cp.Style &= ~WS_MAXIMIZEBOX;
                return cp;
            }

        }

        // Disable Windows State Minimize
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xf020;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == SC_MINIMIZE)
                {
                    m.Result = IntPtr.Zero;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Groove Music Database Refresher Version 1.2 by Eman Marcaida", "Tool Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/EmanDev/gmdr");
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/EmanDev/gmdr/issues");
        }
    }
}
