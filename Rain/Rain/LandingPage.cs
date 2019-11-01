using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rain
{
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            assignDropDownFields();
        }

        private void assignDropDownFields()
        {
            var directories = Directory.GetDirectories("Classes");           

            // for each directory found in the Classes folder, identify its name and add it to dropdown menu
            for(int i = 0; i < directories.Length; i++)
            {
                directories[i] = directories[i].Substring(8);
                chooseClassDropDown.Items.Add(directories[i]);
            }

            // set text shown in drop down by default to first class in folder
            if (directories.Length > 0)
            {
                chooseClassDropDown.Text = directories[0];
            }
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {

        }

        private void loadClassButton_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu(chooseClassDropDown.Text);
            menu.Show();
            this.Hide();
        }
    }
}
