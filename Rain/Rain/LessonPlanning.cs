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

        public string CurrentLessonName;
        public JObject CurrentLesson = new JObject(
                new JProperty("description", ""),
                new JProperty("timeLimit", 0),
                new JProperty("activities", new JArray())
        );

        Point panLocation;

        bool MouseIsDown = false;
        Point MouseDownLocation;



        public LessonPlanning(string className)
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            ClassName = className;

        }

        private void LessonPlanning_Load(object sender, EventArgs e)
        {
            updateDropDownFields();
            CurrentLessonName = selectLessonDropDown.Text;
            loadCurrentLessonData();           

            Console.WriteLine("calling paint method");
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LessonPlanning_Paint);
            this.DoubleBuffered = true;
            //this.Invalidate();

            //testCreateLesson();      

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

            // TEMPORARY FOR TESTING: RESETS CURRENT LESSON TO TEMPLATE
            testCreateLesson();

            MainMenu menu = new MainMenu(ClassName);
            menu.Show();
            this.Hide();
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
                if (prompt.getLessonTimeLimit() <= 0) { return; }

                lessonName = prompt.getLessonName();
                lessonTimeLimit = prompt.getLessonTimeLimit();
            }

            JObject lessonObj = new JObject(
                new JProperty("description", ""),
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

        // update CurrentLesson JObject to reflect contents of file under CurrentLessonName
        private void loadCurrentLessonData()
        {
            string lessonPath = @"Classes\\" + ClassName + "\\Lessons\\" + CurrentLessonName + ".json";
            CurrentLesson = JObject.Parse(File.ReadAllText(lessonPath));
        }

        // update JSON file for lesson to reflect contents of CurrentLesson
        private void saveCurrentLessonData()
        {
            File.WriteAllText(getLessonPath(CurrentLessonName), CurrentLesson.ToString());
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
                new JProperty("name", (string)"Warmup"),
                new JProperty("description",(string)"Warmup for the class"),
                new JProperty("time", (double)5.0),
                new JProperty("color", (string)"-16744448")
            );
            activities.Add(act1);

            JObject act2 = new JObject(
                new JProperty("name", (string)"Powerpoint"),
                new JProperty("description", (string)"Powerpoint on new material"),
                new JProperty("time", (double)20.0),
                new JProperty("color", (string)"-16776961")
            );
            activities.Add(act2);

            JObject act3 = new JObject(
                new JProperty("name", (string)"Quiz"),
                new JProperty("description", (string)"Quiz on last week's material"),
                new JProperty("time", (double)10.0),
                new JProperty("color", (string)"-65536")
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
            using (NewActivityPrompt prompt = new NewActivityPrompt("", "", 0, Color.Yellow))
            {
                this.Enabled = false;
                prompt.ShowDialog();
                this.Enabled = true;

                // escape (do nothing) if user X'd out of Activity Editing prompt (activityTime returned 0)
                if (prompt.getActivityTime() <= 0) { return; }

                // if input for new activity was valid:

                // get current activities list from lesson
                JArray activities = getActivities(CurrentLesson);

                // create a new activity based on user input data from prompt
                JObject newAct = new JObject(
                    new JProperty("name", prompt.getActivityName()),
                    new JProperty("description", prompt.getActivityDescription()),
                    new JProperty("time", prompt.getActivityTime()),
                    new JProperty("color", prompt.getActivityColor().ToArgb().ToString())
                );

                // add said new activity to the activity list
                activities.Add(newAct);

                // update current lesson data to reflect new activity list with the new added item
                CurrentLesson["activities"] = activities;

                // update JSON file for lesson to reflect new lesson data
                saveCurrentLessonData();

                // update the panel to reflect changes
                this.Invalidate();

            }
        }

        // returns full file path for a given lesson file name
        private string getLessonPath(string fileName)
        {
            return "Classes\\" + ClassName + "\\Lessons\\" + fileName + ".json";
        }

        private void LessonPlanning_Paint(object sender, System.Windows.Forms.PaintEventArgs args)
        {
            Console.WriteLine("\n-- Painting --\n");

            panLocation = new Point((this.Width / 3), 10);

            var g = args.Graphics;


            drawAllActivities(g);

            if (MouseIsDown)
            {
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle(MouseDownLocation.X, MouseDownLocation.Y, 100, 100));
            }

        }

        private void drawAllActivities(Graphics g)
        {
            JArray activities = getActivities(CurrentLesson);

            int i = 0;
            foreach (JObject act in activities)
            {
                drawActivity(act, panLocation.X, panLocation.Y + i, 100, g);
                i += 110;
            }
        }

        // draw a single activity based on vertical position and height
        private void drawActivity(JObject act, int xPos, int yPos, int height, Graphics g)
        {
            string name = getName(act);
            double time = getTime(act);
            Color color = getColor(act);

            // inverts color, used for text on activities
            Color inverted = Color.FromArgb(color.ToArgb() ^ 0xffffff);

            //g.FillRectangle(new SolidBrush(color), new Rectangle(0, position, activitiesPanel.Width, height));
            g.FillRectangle(new SolidBrush(color), new Rectangle(xPos, yPos, 500, height));
            g.DrawString(name + ": " + time + " min", new Font("Microsoft Sans Serif", 16), new SolidBrush(inverted), xPos, yPos);
        }

        // function calls to more easily retrieve values from activity object
        private string getName(JObject a) { return (string)((JObject)a).GetValue("name"); }
        private string getDescription(JObject a) { return (string)((JObject)a).GetValue("description"); }
        private double getTime(JObject a) { return (double)((JObject)a).GetValue("time"); }
        private Color getColor(JObject a) { return Color.FromArgb(Convert.ToInt32((string)((JObject)a).GetValue("color"))); }

        // function call to more easily retrieve activities list from lesson object
        private JArray getActivities(JObject lsn) { return (JArray)((JObject)CurrentLesson).GetValue("activities"); }

        private void activitiesPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //MouseDownLocation = e.Location;
                //Console.WriteLine("Mouse down");
            }
        }

        private void activitiesPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseIsDown = true;
                MouseDownLocation = e.Location;
                //Console.WriteLine("location updated");
                this.Invalidate();
            }
        }
    }
}
