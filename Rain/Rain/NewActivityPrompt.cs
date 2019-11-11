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
        public string ClassName;

        public string ActivityName;
        public string ActivityDescription;
        public double ActivityTime = 0;
        public Color ActivityColor;

        public NewActivityPrompt(string className)
        {
            InitializeComponent();

            ClassName = className;
        }

        private void NewActivityPrompt_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            updateColor(Color.Yellow);

        }

        private void saveActivityButton_Click(object sender, EventArgs e)
        {

        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Color chosen: " + colorDialog.Color.Name);
                updateColor(colorDialog.Color);
            }
        }

        private void updateColor(Color c)
        {
            ActivityColor = c;
            colorButton.BackColor = c;
        }

        public string getActivityName() { return ActivityName; }
        public string getActivityDescription() { return ActivityDescription; }
        public double getActivityTime() { return ActivityTime; }
        public Color getActivityColor() { return ActivityColor; }

        
    }
}
