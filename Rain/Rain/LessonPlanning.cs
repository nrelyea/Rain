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

                button1.Margin = new Padding(newX, newY, 0, 0);
            }         
        }

        private void newClassButton_Click(object sender, EventArgs e)
        {
            //string defaultString = "";
            //string newLesson = Interaction.InputBox("Create a new lesson!\n\nUse the space below to name your new lesson.",
            //                                           "Lesson Creation", defaultString);

            testCreateLesson();

            NewLessonPrompt prompt = new NewLessonPrompt(ClassName);
            prompt.Show();
            //this.Hide();
        }






        private void testCreateLesson()
        {
            string lessonName = "lesson 1";
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
                //new JProperty("name", (string)lessonName),
                new JProperty("timeLimit", (int)timeLimit),
                new JProperty("activities", activities)
            );

            File.WriteAllText(@"Classes\\" + ClassName + "\\Lessons\\" + lessonName + ".json", lesson.ToString());
        }





        /*
        private void AddRowToPanel(string txt)
        {
            //get a reference to the previous existent row
            RowStyle temp = planPanel.RowStyles[planPanel.RowCount - 1];
            //increase panel rows count by one
            planPanel.RowCount++;
            //add a new RowStyle as a copy of the previous one
            planPanel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            //define label
            Label newLabel = new Label() {
                Text = txt,
                Anchor = AnchorStyles.None
            };
            //add the control
            planPanel.Controls.Add(newLabel, 0, planPanel.RowCount - 1);           
        }

        private void appendPlanEnding()
        {
            //get a reference to the previous existent row
            RowStyle temp = planPanel.RowStyles[planPanel.RowCount - 1];
            //increase panel rows count by one
            planPanel.RowCount++;
            //add a new RowStyle as a copy of the previous one
            planPanel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            //define button
            Button filler = new Button();
            filler.Dock = DockStyle.Fill;
            filler.BackColor = Color.Black;
            //add button to panel
            planPanel.Controls.Add(filler, 0, planPanel.RowCount);
        }
        */
    }
}
