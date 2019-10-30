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
    public partial class EditStudents : Form
    {
        public string ClassName { get; set; }

        public EditStudents(string className)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            ClassName = className;
            UpdateTextBox();
        }

        private void UpdateTextBox()
        {
            try
            {
                string json = File.ReadAllText(@ClassName + "_students.json");
                List<string> studentList = JsonConvert.DeserializeObject<List<string>>(json);
                mainTextBox.Text = string.Join("\n", studentList.ToArray());
            }
            catch (Exception e)
            {

            }
        }

        private void EditStudents_Load(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu(ClassName);
            menu.Show();
            this.Hide();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> newStudentList = mainTextBox.Text.Split('\n').ToList();
                for(int i = 0; i < newStudentList.Count; i++)
                {
                    if(newStudentList[i] == "")
                    {
                        newStudentList.RemoveAt(i);
                        i--;
                    }
                }
                File.WriteAllText(@ClassName + "_students.json", JsonConvert.SerializeObject(newStudentList));
            }
            catch (Exception e2)
            {
                System.Windows.Forms.MessageBox.Show("There was an error saving these student names");
            }
        }
    }
}
