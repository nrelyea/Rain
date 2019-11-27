using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rain
{
    public partial class NewActivityPrompt : Form
    {
        public string ActivityName;
        public string ActivityDescription;
        public double ActivityTime = 0;
        public Color ActivityColor;

        public NewActivityPrompt(string name, string desc, double time, Color clr)
        {
            InitializeComponent();

        ActivityName = name;
        ActivityDescription = desc;
        ActivityTime = time;
        ActivityColor = clr;
    }

        private void NewActivityPrompt_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            updateColor(ActivityColor);

            if (ActivityTime > 0) 
            {
                nameTextBox.Text = ActivityName;
                descriptionTextBox.Text = ActivityDescription;
                timeTextBox.Text = ActivityTime.ToString(); 
            }
            colorDialog.Color = ActivityColor;

        }

        private void saveActivityButton_Click(object sender, EventArgs e)
        {
            if (validTime(timeTextBox.Text))
            {
                ActivityName = nameTextBox.Text;
                ActivityDescription = descriptionTextBox.Text;
                ActivityTime = Convert.ToDouble(timeTextBox.Text);

                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR: Invalid Activity Time!\n\n " +
                                        "Make sure your activity time is a number between 0.5 and 180");
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                updateColor(colorDialog.Color);
            }
        }

        private void updateColor(Color c)
        {
            ActivityColor = c;
            colorButton.BackColor = c;
        }

        private bool validTime(string timeStr)
        {
            try
            {
                double time = Convert.ToDouble(timeStr);
                if (time < 0.5)
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

        public string getActivityName() { return ActivityName; }
        public string getActivityDescription() { return ActivityDescription; }
        public double getActivityTime() { return ActivityTime; }
        public Color getActivityColor() { return ActivityColor; }

        
    }
}
