using Microsoft.VisualBasic;
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
    public partial class LandingPage : Form
    {
        public LandingPage()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            assignDropDownFields();
        }

        private void assignDropDownFields()
        {
            var directories = Directory.GetDirectories("Classes");           

            // for each directory found in the Classes folder, identify its name and add it to dropdown menu
            for(int i = 0; i < directories.Length; i++)
            {
                directories[i] = directories[i].Substring(8);
                chooseClassDropDown.Items.Add(directories[i]);
            }

            // set text shown in drop down by default to first class in folder
            if (directories.Length > 0)
            {
                chooseClassDropDown.Text = directories[0];
            }
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {

        }

        private void loadClassButton_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu(chooseClassDropDown.Text);
            menu.Show();
            this.Hide();
        }

        private void newClassButton_Click(object sender, EventArgs e)
        {
            string defaultString = "";

            while (true)
            {
                string newClass = Interaction.InputBox("Create a new class!\n\nUse the space below to name your new class.", 
                                                       "Class Creation", defaultString);
                if (newClass.Length > 0)
                {
                    if (validClassName(newClass))
                    {
                        Console.WriteLine("Created New Class: " + newClass);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Invalid Class Name!\n\n " +
                                        "Please only use letters, numbers, and spaces\n" +
                                        "The following characters are also allowed:  '  _  - ");
                        defaultString = newClass;
                    }
                }
                else
                {
                    break;
                }
            }
            
        }

        // determines of class name user has entered is valid, as it will be the name of a folder
        private bool validClassName(string name)
        {
            List<char> validChars = new List<char> { ' ', '_', '-', '\''};

            for(int i = 0; i < name.Length; i++)
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
    }
}
