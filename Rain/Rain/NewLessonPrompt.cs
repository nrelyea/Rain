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
    public partial class NewLessonPrompt : Form
    {
        public string ClassName;

        public NewLessonPrompt(string className)
        {
            InitializeComponent();
            this.CenterToScreen();

            ClassName = className;
        }

        private void NewLessonPrompt_Load(object sender, EventArgs e)
        {

        }
    }
}
