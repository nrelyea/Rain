using Newtonsoft.Json;
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
    public partial class MainMenu : Form
    {
        public string ClassName { get; set; }

        public MainMenu(string className)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            ClassName = className;
            Console.WriteLine("Name of class loaded: " + ClassName);           
        }

        private void formGroupsButton_Click(object sender, EventArgs e)
        {
            GroupForming grouping = new GroupForming(ClassName);
            grouping.Show();
            this.Hide();
        }

        private void studentsButton_Click(object sender, EventArgs e)
        {
            EditStudents edit = new EditStudents(ClassName);
            edit.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LandingPage page = new LandingPage();
            page.Show();
            this.Hide();
        }
    }
}
