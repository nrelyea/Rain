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

        public string savedText;

        public EditStudents(string className)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            ClassName = className;

            UpdateTextBox();
            savedText = mainTextBox.Text;
        }

        private void UpdateTextBox()
        {
            try
            {
                string json = File.ReadAllText(@"Classes\" + ClassName + "\\students.json");
                List<string> studentList = JsonConvert.DeserializeObject<List<string>>(json);
                mainTextBox.Text = string.Join("\n", studentList.ToArray());
            }
            catch (Exception exc1)
            {

            }
        }

        private void EditStudents_Load(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if(savedText != mainTextBox.Text)
            {
                DialogResult dialogResult = MessageBox.Show("Warning: There are unsaved changes to the student list!\n\n" +
                    "Would you like to save your changes before returning to the Main Menu?", "Warning: Unsaved Changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    saveStudents();
                }
            }

            MainMenu menu = new MainMenu(ClassName);
            menu.Show();
            this.Hide();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveStudents();
        }

        private void saveStudents()
        {
            try
            {
                List<string> newStudentList = mainTextBox.Text.Split('\n').ToList();
                for (int i = 0; i < newStudentList.Count; i++)
                {
                    if (newStudentList[i] == "")
                    {
                        newStudentList.RemoveAt(i);
                        i--;
                    }
                }
                File.WriteAllText(@"Classes\" + ClassName + "\\students.json", JsonConvert.SerializeObject(newStudentList));
                savedText = mainTextBox.Text;
            }
            catch (Exception exc2)
            {
                System.Windows.Forms.MessageBox.Show("There was an error saving these student names");
            }
        }
    }
}
