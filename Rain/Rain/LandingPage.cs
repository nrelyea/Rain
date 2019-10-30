using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {

        }

        private void loadClassButton_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu("Spanish_1");
            menu.Show();
            this.Hide();
        }
    }
}
