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
    public partial class NewLessonPrompt : Form
    {
        public string ClassName;

        public string LessonName;
        public int LessonTimeLimit = 0;

        public NewLessonPrompt(string className)
        {
            InitializeComponent();

            ClassName = className;
        }

        private void NewLessonPrompt_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void createLessonButton_Click(object sender, EventArgs e)
        {
            string lessonName = nameTextBox.Text;

            if (validLessonName(lessonName) && lessonName.Length > 0)
            {
                if (!lessonAlreadyExists(lessonName))
                {
                    if (validTimeLimit(timeLimitTextBox.Text))
                    {
                        LessonName = lessonName;
                        LessonTimeLimit = Int32.Parse(timeLimitTextBox.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Invalid Time Limit!\n\n " +
                                        "Make sure your lesson time limit is a number between 0 and 180");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: Invalid Lesson Name!\n\n " +
                                        "The lesson name you have entered already exists for this class!\n\n" +
                                        "Either enter a different lesson name, or first delete the current lesson that shares this name");
                }
            }
            else
            {
                MessageBox.Show("ERROR: Invalid Lesson Name!\n\n " +
                                        "Please only use letters, numbers, and spaces\n" +
                                        "The following characters are also allowed:  '  _  - ");
            }           


        }

        
        private bool lessonAlreadyExists(string str)
        {
            // get all lesson file paths from Lessons directory and put them in an array
            string[] pathArray = Directory.GetFiles(@"Classes\" + ClassName + "\\Lessons\\", "*.json",
                                                     SearchOption.TopDirectoryOnly);

            foreach (string path in pathArray)
            {
                if(path == "Classes\\" + ClassName + "\\Lessons\\" + str + ".json")
                {
                    return true;
                }
            }

            return false;
        }

        private bool validTimeLimit(string timeStr)
        {
            try
            {
                int time = Int32.Parse(timeStr);
                if(time <= 0)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool validLessonName(string name)
        {
            // list of special characters that are allowed in a lesson name
            List<char> validChars = new List<char> { ' ', '_', '-', '\'' };

            for (int i = 0; i < name.Length; i++)
            {
                if (!(
                    Char.IsDigit(name[i]) |
                    Char.IsLetter(name[i]) |
                    validChars.Contains(name[i])))
                {
                    return false;
                }
            }
            return true;
        }

        public string getLessonName()
        {
            return LessonName;
        }

        public int getLessonTimeLimit()
        {
            return LessonTimeLimit;
        }


    }
}
