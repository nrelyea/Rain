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
        public MainMenu()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            List<string> studentList = new List<string>
            {
                "Javier",
                "Yexalan",
                "Cesar",
                "Truc",
                "Yung Venice",
                "Andrew",
                "Other Andrew",
                "Trinity",
                "Ashonty",
                "Noah"
            };

            File.WriteAllText(@"c:../../students.json", JsonConvert.SerializeObject(studentList));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GroupForming form2 = new GroupForming();
            form2.Show();
            this.Hide();
        }
    }
}
