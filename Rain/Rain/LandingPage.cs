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

            updateDropDownFields();
        }

        private void updateDropDownFields()
        {
            var directories = Directory.GetDirectories("Classes");

            selectClassDropDown.Items.Clear();

            // for each directory found in the Classes folder, identify its name and add it to dropdown menu
            for(int i = 0; i < directories.Length; i++)
            {
                directories[i] = directories[i].Substring(8);
                selectClassDropDown.Items.Add(directories[i]);
            }

            // set text shown in drop down by default to first class in folder
            if (directories.Length > 0)
            {
                selectClassDropDown.Text = directories[0];
            }
        }

        private void LandingPage_Load(object sender, EventArgs e)
        {

        }

        private void loadClassButton_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu(selectClassDropDown.Text);
            menu.Show();
            this.Hide();
        }

        private void newClassButton_Click(object sender, EventArgs e)
        {
            string defaultString = "";

            while (true)
            {
                // prompt user to enter a name for their new class
                string newClass = Interaction.InputBox("Create a new class!\n\nUse the space below to name your new class.", 
                                                       "Class Creation", defaultString);

                // if a class name was entered, begin processing it
                if (newClass.Length > 0)
                {
                    // if class name is valid, proceed
                    if (validClassName(newClass))
                    {
                        // if class name is already taken, let the user know, and then again present them with 
                        //the option to change the class name to make it valid and retry
                        if (classAlreadyExists(newClass))
                        {
                            MessageBox.Show("ERROR: Invalid Class Name!\n\n " +
                                        "The class name you have entered already exists!\n\n" +
                                        "Either enter a different class name, or first delete the current class that shares this name");
                            defaultString = newClass;
                        }
                        // otherwise, create the new class
                        else
                        {
                            Directory.CreateDirectory("Classes\\" + newClass);
                            updateDropDownFields();

                            DialogResult dialogResult = MessageBox.Show("Your new class '" + newClass + "' has been created!\n\n" +
                                "Would you like to start setting up this class now?", "'"+ newClass + "' created!", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                MainMenu menu = new MainMenu(newClass);
                                menu.Show();
                                this.Hide();
                            }

                            Console.WriteLine("Created New Class: " + newClass);
                            break;
                        }                       
                    }
                    // if class name is invalid, let the user know, and then again present them with 
                    //the option to change the class name to make it valid and retry
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
            // list of special characters that are allowed in a class name
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

        private bool classAlreadyExists(string name)
        {
            for (int i = 0; i < selectClassDropDown.Items.Count; i++)
            {
                if(name == selectClassDropDown.GetItemText(selectClassDropDown.Items[i])){
                    return true;
                }
            }

            return false;
        }

        private void deleteClassButton_Click(object sender, EventArgs e)
        {
            string classToDelete = selectClassDropDown.Text;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete '" 
                + classToDelete + "' and all of its contents?", 
                "Confirm Deletion of " + classToDelete, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                while (true)
                {
                    string enteredName = Interaction.InputBox("\nUse the box below to type '" + classToDelete +
                    "' to confirm the deletion of this class", "Confirm Deletion of " + classToDelete, "");
                    if(enteredName.Length > 0)
                    {
                        if (enteredName != classToDelete)
                        {
                            MessageBox.Show("The class name you just typed did not match the name of the class" +
                                " you are trying to delete.\n\nPlease re-enter the class name");
                        }
                        else
                        {
                            Directory.Delete("Classes\\" + classToDelete, true);
                            updateDropDownFields();

                            MessageBox.Show("The class '" + classToDelete + "' has been deleted.");

                            Console.WriteLine(classToDelete + " has been deleted");
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
    }
}
