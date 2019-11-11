using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rain
{
    public partial class LessonPlanning : Form
    {
        public string ClassName;

        public LessonPlanning(string className)
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            ClassName = className;

        }

        private void LessonPlanning_Load(object sender, EventArgs e)
        {
            updateDropDownFields();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            /*
            if (savedText != mainTextBox.Text)
            {
                DialogResult dialogResult = MessageBox.Show("Warning: There are unsaved changes to the student list!\n\n" +
                    "Would you like to save your changes before returning to the Main Menu?", "Warning: Unsaved Changes", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    saveStudents();
                }
            }
            */

            MainMenu menu = new MainMenu(ClassName);
            menu.Show();
            this.Hide();
        }

        private Point MouseDownLocation;

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int newX = e.X + button1.Left - MouseDownLocation.X;
                int newY = e.Y + button1.Top - MouseDownLocation.Y;

                //button1.Margin = new Padding(newX, newY, 0, 0);
                button1.Location = new Point(newX, newY);

                Console.WriteLine("eh");

            }
        }

        private void newLessonButton_Click(object sender, EventArgs e)
        {
            string lessonName;
            int lessonTimeLimit;

            using (NewLessonPrompt prompt = new NewLessonPrompt(ClassName))
            {
                this.Enabled = false;
                prompt.ShowDialog();
                this.Enabled = true;

                // escape (do nothing) if user X'd out of Lesson Creation prompt (lessonTimeLimit returned 0)
                if(prompt.getLessonTimeLimit() <= 0) { return; }

                lessonName = prompt.getLessonName();
                lessonTimeLimit = prompt.getLessonTimeLimit();
            }

            JObject lessonObj = new JObject(
                new JProperty("description", (string)""),
                new JProperty("timeLimit", (int)lessonTimeLimit),
                new JProperty("activities", new JArray())
            );

            File.WriteAllText(@"Classes\\" + ClassName + "\\Lessons\\" + lessonName + ".json", lessonObj.ToString());

            updateDropDownFields();

            MessageBox.Show("Your new lesson '" + lessonName + "' has been created!\n\n" +
                            "Use the tools provided to modify and add to it!");

        }



        // update drop down fields to correctly represent current lessons in this class
        private void updateDropDownFields()
        {
            selectLessonDropDown.Items.Clear();

            // get all lesson file paths from Lessons directory and put them in an array
            string[] pathArray = Directory.GetFiles(@"Classes\\" + ClassName + "\\Lessons\\", "*.json",
                                                     SearchOption.TopDirectoryOnly);

            // shorten all file paths to just lesson names and add them to the dropdown
            for(int i = 0; i < pathArray.Length; i++)
            {
                selectLessonDropDown.Items.Add(pathToFile(pathArray[i]));
            }

            if(pathArray.Length > 0)
            {
                selectLessonDropDown.Text = pathToFile(pathArray[0]);
                deleteLessonButton.Show();
            }
            else
            {
                deleteLessonButton.Hide();
            }


        }

        // converts an entire file path (i.e. \Classes\Lessons\first day.json) to just file name (first day)
        private string pathToFile(string path)
        {
            for(int i = path.Length - 1; i >= 0; i--)
            {
                if(path[i] == '\\')
                {
                    path = path.Substring(i+1);
                    path = path.Substring(0, path.Length - 5);
                    break;
                }
            }

            return path;
        }

        private void testCreateLesson()
        {
            string lessonName = "lesson 1";
            string description = "the first lesson!";
            int timeLimit = 55;

            JArray activities = new JArray();

            JObject act1 = new JObject(
                //new JProperty("name", (string)lessonName),
                new JProperty("name", (string)"Warmup"),
                new JProperty("time", (double)5.0),
                new JProperty("color", (string)"Green")
            );
            activities.Add(act1);

            JObject act2 = new JObject(
                //new JProperty("name", (string)lessonName),
                new JProperty("name", (string)"Powerpoint"),
                new JProperty("time", (double)20.0),
                new JProperty("color", (string)"Blue")
            );
            activities.Add(act2);

            JObject act3 = new JObject(
                //new JProperty("name", (string)lessonName),
                new JProperty("name", (string)"Quiz"),
                new JProperty("time", (double)10.0),
                new JProperty("color", (string)"Red")
            );
            activities.Add(act3);



            JObject lesson = new JObject(
                new JProperty("description", (string)description),
                new JProperty("timeLimit", (int)timeLimit),
                new JProperty("activities", activities)
            );

            File.WriteAllText(@"Classes\\" + ClassName + "\\Lessons\\" + lessonName + ".json", lesson.ToString());
        }

        private void deleteLessonButton_Click(object sender, EventArgs e)
        {
            string lessonToDelete = selectLessonDropDown.Text;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete '"
                + lessonToDelete + "' and all of its contents?",
                "Confirm Deletion of " + lessonToDelete, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                while (true)
                {
                    string enteredName = Interaction.InputBox("\nUse the box below to type '" + lessonToDelete +
                    "' to confirm the deletion of this lesson", "Confirm Deletion of " + lessonToDelete, "");
                    if (enteredName.Length > 0)
                    {
                        if (enteredName != lessonToDelete)
                        {
                            MessageBox.Show("The lesson name you just typed did not match the name of the lesson" +
                                " you are trying to delete.\n\nPlease re-enter the lesson name");
                        }
                        else
                        {
                            File.Delete(getLessonPath(lessonToDelete));                            
                            updateDropDownFields();

                            MessageBox.Show("The lesson '" + lessonToDelete + "' has been deleted.");

                            break;
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
        }

        private void newActivityButton_Click(object sender, EventArgs e)
        {
            using (NewActivityPrompt prompt = new NewActivityPrompt(ClassName))
            {
                this.Enabled = false;
                prompt.ShowDialog();
                this.Enabled = true;

                // escape (do nothing) if user X'd out of Lesson Creation prompt (lessonTimeLimit returned 0)
                //if (prompt.getLessonTimeLimit() <= 0) { return; }

                //lessonName = prompt.getLessonName();
                //lessonTimeLimit = prompt.getLessonTimeLimit();
            }
        }

        // returns full file path for a given lesson file name
        private string getLessonPath(string fileName)
        {
            return "Classes\\" + ClassName + "\\Lessons\\" + fileName + ".json";
        }






    }
}
