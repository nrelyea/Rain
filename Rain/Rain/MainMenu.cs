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
            //Console.WriteLine("Name of class loaded: " + ClassName);

            // disable certain options if student list is empty / doesn't exist
            if (!canLoadStudents())
            {
                formGroupsButton.Hide();
            }
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        // returns true if students.json file exists and contains at least one student
        private bool canLoadStudents()
        {          
            try
            {
                string json = File.ReadAllText(@"Classes\" + ClassName + "\\students.json");
                List<string> studentList = JsonConvert.DeserializeObject<List<string>>(json);
                if(studentList.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception exc)
            {
                return false;
            }           
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

        private void button3_Click(object sender, EventArgs e)
        {
            LessonPlanning plan = new LessonPlanning(ClassName);
            plan.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


    }
}
