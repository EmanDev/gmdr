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
using System.IO;

namespace GrooveMusicDatabaseRefresh
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Kill groove if running else skip
            Process[] music = Process.GetProcessesByName("Music.UI");
            foreach (Process musicKill in music)
            {
                musicKill.Kill();
                musicKill.WaitForExit();
                musicKill.Dispose();
            }

            // Database locate-delete
            string gmPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string packagePath = @"\Packages\Microsoft.ZuneMusic_8wekyb3d8bbwe\LocalState\Database";
            string DatabasePath = gmPath + packagePath;
            DirectoryInfo di = new DirectoryInfo(DatabasePath);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

           // Run groove music auto-setup with messagebox
            string openMusic = "mswindowsmusic:";
            Process.Start(openMusic);
            MessageBox.Show("Groove Music database was refreshed.", "Groove Music Database Refresher", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
