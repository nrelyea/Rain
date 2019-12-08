using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        public Point panLocation;
        public int panWidth;

        Point InitialMouseLocation;
        int SelectedActivityIndex;

        public int paintCount;


        public LessonPlanning(string className)
        {

            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            ClassName = className;

            paintCount = 0;



        }

        private void LessonPlanning_Load(object sender, EventArgs e)
        {
            this.Text = "Rain | " + ClassName + " | Lesson Planning";

            updateDropDownFields();
            CurrentLessonName = selectLessonDropDown.Text;
            loadCurrentLessonData();

            //this.Paint += new System.Windows.Forms.PaintEventHandler(this.LessonPlanning_Paint);
            this.DoubleBuffered = true;
            //this.Invalidate();           

            //testCreateLesson();
        }

        private void backButton_Click(object sender, EventArgs e)
        {

            ///*
            
            // TEMPORARY FOR TESTING: RESETS CURRENT LESSON TO TEMPLATE
            //testCreateLesson();

            MainMenu menu = new MainMenu(ClassName);
            menu.Show();
            this.Hide();

            //*/

        }

        private void newLessonButton_Click(object sender, EventArgs e)
        {
            string lessonName;
            string lessonDescription;
            int lessonTimeLimit;

            using (NewLessonPrompt prompt = new NewLessonPrompt(ClassName, "", "", 0))
            {
                this.Enabled = false;
                prompt.ShowDialog();
                this.Enabled = true;

                // escape (do nothing) if user X'd out of Lesson Creation prompt (lessonTimeLimit returned 0)
                if (prompt.getLessonTimeLimit() <= 0) { return; }

                lessonName = prompt.getLessonName();
                lessonDescription = prompt.getLessonDescription();
                lessonTimeLimit = prompt.getLessonTimeLimit();
            }

            JObject lessonObj = new JObject(
                new JProperty("description", (string)lessonDescription),
                new JProperty("timeLimit", (int)lessonTimeLimit),
                new JProperty("activities", new JArray())
            );

            File.WriteAllText(@"Classes\\" + ClassName + "\\Lessons\\" + lessonName + ".json", lessonObj.ToString());

            updateDropDownFields();

            CurrentLessonName = lessonName;
            loadCurrentLessonData();

            adjustDropDown(lessonName);
            
            MessageBox.Show("Your new lesson '" + lessonName + "' has been created!\n\n" +
                            "Use the tools provided to modify and add to it!");

        }

        private void editLessonButton_Click(object sender, EventArgs e)
        {
            using (NewLessonPrompt prompt = new NewLessonPrompt(ClassName, CurrentLessonName, (string)CurrentLesson["description"], (int)CurrentLesson["timeLimit"]))
            {
                this.Enabled = false;
                prompt.ShowDialog();
                this.Enabled = true;

                //if (prompt.getLessonTimeLimit() <= 0) { return; }

                // update data name to reflect any potential changes
                System.IO.File.Move(getLessonPath(CurrentLessonName), getLessonPath(prompt.getLessonName()));

                CurrentLessonName = prompt.getLessonName();
                CurrentLesson["description"] = prompt.getLessonDescription();
                CurrentLesson["timeLimit"] = prompt.getLessonTimeLimit();

                saveCurrentLessonData();

                updateDropDownFields();

                adjustDropDown(prompt.getLessonName());

                //lessonName = prompt.getLessonName();
                //lessonTimeLimit = prompt.getLessonTimeLimit();
            }
        }

        // double clicking info label also brings up lesson editing 
        private void infoLabel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editLessonButton_Click(sender, e);
        }

        // find index of newly created / edited lesson name in drop down list and make it the selected one
        private void adjustDropDown(string lsnName)
        {
            // find index of newly created lesson name in drop down list and make it the selected one
            for (int i = 0; i < selectLessonDropDown.Items.Count; i++)
            {
                if (selectLessonDropDown.Items[i].ToString() == lsnName)
                {
                    selectLessonDropDown.SelectedIndex = i;
                    break;
                }
            }
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
                            updateInfoLabel();
                            Invalidate();

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
                editLessonButton.Show();
                newActivityButton.Show();

                selectLessonDropDown.Enabled = true;
            }
            else
            {
                deleteLessonButton.Hide();
                editLessonButton.Hide();
                newActivityButton.Hide();

                selectLessonDropDown.Enabled = false;
            }


        }

        // update CurrentLesson JObject to reflect contents of file under CurrentLessonName
        private void loadCurrentLessonData()
        {
            this.Text = "Rain | " + ClassName + " | Lesson Planning";

            if (CurrentLessonName.Length > 0)
            {
                string lessonPath = @"Classes\\" + ClassName + "\\Lessons\\" + CurrentLessonName + ".json";
                CurrentLesson = JObject.Parse(File.ReadAllText(lessonPath));
            }

            updateInfoLabel();
        }

        // update the main info label
        private void updateInfoLabel()
        {
            infoLabel.Text = "";

            // if lesson list is blank, escape without writing anything
            if(selectLessonDropDown.Items.Count == 0) { return; }

            string desc = (string)CurrentLesson["description"];
            if (desc.Length > 0)
            {
                infoLabel.Text = desc + "\n\n";

            }
            infoLabel.Text += "Lesson Time Limit:   " + (string)CurrentLesson["timeLimit"] + " minutes";
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

        // create and save a template lesson for testing with a title, description, time limit, and 3 activities
        private void testCreateLesson()
        {
            string lessonName = "lesson 1";
            string description = "The first lesson!";
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

        private void newActivityButton_Click(object sender, EventArgs e)
        {
            using (NewActivityPrompt prompt = new NewActivityPrompt("", "", 0, Color.White, -1))
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
                this.Refresh();

            }
        }

        // returns full file path for a given lesson file name
        private string getLessonPath(string fileName)
        {
            return "Classes\\" + ClassName + "\\Lessons\\" + fileName + ".json";
        }

        private void LessonPlanning_Paint(object sender, System.Windows.Forms.PaintEventArgs args)
        {
            // if drop down text is blank (no lesson selected / available) don't paint anything
            if(selectLessonDropDown.Text.Length < 1) { return; }

            // setting reference location for activities drawing to match sidebar (1/3 across screen)
            panLocation = new Point((this.Width / 3) + 4, 9);
            // setting reference width that each activity painted should be
            panWidth = this.Width * 17 / 30 - 27;

            var g = args.Graphics;

            
            drawAllActivities(g);

        }

        private void drawAllActivities(Graphics g)
        {
            JArray activities = getActivities(CurrentLesson);

            List<int> posList = getActivityPositionList(activities);

            int i = 0;
            foreach (JObject act in activities)
            {
                drawActivity(act, panLocation.X, panLocation.Y + posList[i], posList[i+1] - posList[i], g);
                i++;
            }


            Font newFont = new Font("Microsoft Sans Serif", 24);
            newFont = new Font(newFont, FontStyle.Bold);

            double timeToDisplay = getTimeSum(activities);

            Color timeColor = Color.Green;
            
            // if total lesson time exceeds proposed time limit, write lesson time in RED instead of GREEN
            if(timeToDisplay > (double)((JObject)CurrentLesson).GetValue("timeLimit"))
            {
                timeColor = Color.Red;
            }

            g.DrawString("Total Lesson Time:", newFont, new SolidBrush(Color.Black), panLocation.X + panWidth / 2 - 200, this.Height - 100);
            g.DrawString(timeToDisplay.ToString() + " min", newFont, new SolidBrush(timeColor), panLocation.X + panWidth / 2 + 100, this.Height - 100);
        }

        // draw a single activity based on vertical position and height
        private void drawActivity(JObject act, int xPos, int yPos, int height, Graphics g)
        {
            string name = getName(act);
            double time = getTime(act);
            Color color = getColor(act);

            // creates new brush that inverts color, used for text on activities
            SolidBrush invertedBrush = new SolidBrush(Color.FromArgb(color.ToArgb() ^ 0xffffff));

            g.FillRectangle(new SolidBrush(color), new Rectangle(xPos, yPos, panWidth, height));
            g.DrawString(name, new Font("Microsoft Sans Serif", 16), invertedBrush, xPos + 30, yPos + height / 2 - 14);
            g.DrawString(time + " min", new Font("Microsoft Sans Serif", 16), invertedBrush, xPos + panWidth - 100, yPos + height / 2 - 14);
            
        }

        // function calls to more easily retrieve values from activity object
        private string getName(JObject a) { return (string)((JObject)a).GetValue("name"); }
        private string getDescription(JObject a) { return (string)((JObject)a).GetValue("description"); }
        private double getTime(JObject a) { return (double)((JObject)a).GetValue("time"); }
        private Color getColor(JObject a) { return Color.FromArgb(Convert.ToInt32((string)((JObject)a).GetValue("color"))); }

        // function call to more easily retrieve activities list from lesson object
        private JArray getActivities(JObject lsn) { return (JArray)((JObject)lsn).GetValue("activities"); }

        

        // Returns pixel positions that each activity should be painted at
        // This list is ONE unit longer than number of activities, as last element
        // is reserved for position of bottom edge of activities block
        private List<int> getActivityPositionList(JArray actList)
        {
            // initialize the position list, with first activity's position always being 0
            List<int> posList = new List<int> { 0 };

            List<double> timeList = new List<double> { };
            double timeSum = getTimeSum(actList);
            int panLimit = activitiesPanel.Height * 9 / 10;

            // pull time data from each activity and add to time list
            // also update timeSum to reflect total sum of time spent on each activity
            foreach (JObject act in actList)
            {
                timeList.Add(getTime(act));
            }

            double timeLimit = (double)((JObject)CurrentLesson).GetValue("timeLimit");

            // if total lesson time exceeds proposed timeLimit, fit activities to lesson time total
            // instead of timeLimit
            if(timeSum > timeLimit)
            {
                timeLimit = timeSum;
            }

            // for each time in timeList:
            for (int i = 0; i < timeList.Count; i++)
            {
                // determine amount of vertical space the activity should occupy
                int actHeight = (int)((double)panLimit * timeList[i] / timeLimit);
                // add that height to the previous position, and add that total to the position list
                posList.Add(actHeight + posList[i]);
            }

            return posList;
        }

        // returns index of activity clicked on based on position of mouse at time of click
        private int getActivityIndexFromMousePosition(Point clickPos)
        {
            List<int> posList = getActivityPositionList(getActivities(CurrentLesson));
            for(int i = 1; i < posList.Count; i++)
            {
                if(clickPos.Y <= posList[i])
                {
                    return i - 1;
                }
            }
            return -1;
        }

        // returns sum of activity times in activity list
        private double getTimeSum(JArray actList)
        {
            double sum = 0;

            foreach (JObject act in actList)
            {
                sum += getTime(act);
            }

            return sum;
        }

        // swaps two activities within the current activity list of the current lesson based on their indices
        private void swapActivities(int indexA, int indexB)
        {
            JArray activities = getActivities(CurrentLesson);
            var tempAct = activities[indexA];
            activities[indexA] = activities[indexB];
            activities[indexB] = tempAct;

            saveCurrentLessonData();
        }

        private void activitiesPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                InitialMouseLocation = e.Location;
                SelectedActivityIndex = getActivityIndexFromMousePosition(e.Location);
            }
        }

        private void activitiesPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {                
                // if cursor has been dragged less than 5 pixels up or down, ignore
                if(Math.Abs(e.Location.Y - InitialMouseLocation.Y) <= 5) { return; }

                // if cursor was pressed not pressed on an activity, ignore
                if(SelectedActivityIndex < 0) { return; }

                List<int> posList = getActivityPositionList(getActivities(CurrentLesson));                

                // if user dragged mouse UP and from an activity that has at least one other activity ABOVE it
                if(e.Location.Y < InitialMouseLocation.Y && SelectedActivityIndex > 0)
                {
                    int upperThreshold = posList[SelectedActivityIndex - 1] + (posList[SelectedActivityIndex + 1] - posList[SelectedActivityIndex]) / 2;                   
                    // if mouse has passed what would be the halfway point of the new activity position if it moved
                    if(e.Location.Y < upperThreshold)
                    {
                        swapActivities(SelectedActivityIndex, SelectedActivityIndex - 1);
                        Invalidate();

                        InitialMouseLocation = e.Location;
                        SelectedActivityIndex--;
                    }
                }
                // if user dragged mouse DOWN and from an activity that has at least one other activity BELOW it
                else if(e.Location.Y > InitialMouseLocation.Y && SelectedActivityIndex < posList.Count - 2)
                {
                    int lowerThreshold = posList[SelectedActivityIndex] + (posList[SelectedActivityIndex + 2] - posList[SelectedActivityIndex + 1]) + (posList[SelectedActivityIndex + 1] - posList[SelectedActivityIndex]) / 2;
                    // if mouse has passed what would be the halfway point of the new activity position if it moved
                    if (e.Location.Y > lowerThreshold)
                    {
                        swapActivities(SelectedActivityIndex, SelectedActivityIndex + 1);
                        Invalidate();

                        InitialMouseLocation = e.Location;
                        SelectedActivityIndex++;
                    }
                }
                
            }
        }

        private void activitiesPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int actIndex = getActivityIndexFromMousePosition(e.Location);

            // if area double clicked was not an activity, ignore
            if (actIndex < 0) { return; }

            JArray activities = getActivities(CurrentLesson);
            JObject act = (JObject)activities[actIndex];

            using (NewActivityPrompt prompt = new NewActivityPrompt(getName(act), getDescription(act), getTime(act), getColor(act), actIndex))
            {
                this.Enabled = false;
                prompt.ShowDialog();
                this.Enabled = true;

                // escape (do nothing) if user X'd out of Activity Editing prompt (activityTime returned 0)
                if (!prompt.isSaved()) { return; }

                // if activity is marked to be deleted, delete the activity and escape
                if (prompt.isDeleted())
                {
                    activities.RemoveAt(actIndex);
                }
                // otherwise, if input for new activity was valid:
                else
                {
                    // create a updated activity based on user input data from prompt
                    JObject updatedAct = new JObject(
                        new JProperty("name", prompt.getActivityName()),
                        new JProperty("description", prompt.getActivityDescription()),
                        new JProperty("time", prompt.getActivityTime()),
                        new JProperty("color", prompt.getActivityColor().ToArgb().ToString())
                    );

                    // update said activity in the activity list
                    activities[actIndex] = updatedAct;
                }
                
                // update current lesson data to reflect updated activity list
                CurrentLesson["activities"] = activities;

                // update JSON file for lesson to reflect updated lesson data
                saveCurrentLessonData();

                // update the panel to reflect changes
                Invalidate();

            }

        }

        // if dropdown value has changed, update lesson data
        private void selectLessonDropDown_TextChanged(object sender, EventArgs e)
        {
            if(selectLessonDropDown.Text.Length > 0)
            {
                CurrentLessonName = selectLessonDropDown.Text;
                loadCurrentLessonData();

                Invalidate();
            }           
        }


    }    
}
