﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rain
{
    public partial class GroupForming : Form
    {
        public List<string> students;
        public GroupForming()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            outputLabel.Hide();

            string json = File.ReadAllText(@"c:../../students.json");
            students = JsonConvert.DeserializeObject<List<string>>(json);
        }

        public bool canChange = true;

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void biggerGroupsRadio_Click(object sender, EventArgs e)
        {
            biggerGroupsRadio.Checked = true;
            smallerGroupsRadio.Checked = false;
        }

        private void smallerGroupsRadio_Click(object sender, EventArgs e)
        {
            smallerGroupsRadio.Checked = true;
            biggerGroupsRadio.Checked = false;
        }

        private void groupTextBox_TextChanged(object sender, EventArgs e)
        {
            if (canChange)
            {
                string txt = groupTextBox.Text;
                if (txt.Length > 0 && !Char.IsDigit(txt[txt.Length - 1]))
                {
                    groupTextBox.Text = txt.Substring(0, txt.Length - 1);
                }
                canChange = false;
                studentTextBox.Text = "";
                canChange = true;
            }
        }

        private void studentTextBox_TextChanged(object sender, EventArgs e)
        {
            if (canChange)
            {
                string txt = studentTextBox.Text;
                if (txt.Length > 0 && !Char.IsDigit(txt[txt.Length - 1]))
                {
                    studentTextBox.Text = txt.Substring(0, txt.Length - 1);                 
                }
                canChange = false;
                groupTextBox.Text = "";
                canChange = true;
            }
        }

        bool validInputs()
        {
            if(groupTextBox.Text.Length == 0 && studentTextBox.Text.Length == 0)
            {
                outputLabel.Text = "ERROR: Entry fields empty";
                return false;
            }
            else if((groupTextBox.Text.Length > 0 && Int32.Parse(groupTextBox.Text) == 0) | (studentTextBox.Text.Length > 0 && Int32.Parse(studentTextBox.Text) == 0))
            {
                outputLabel.Text = "ERROR: Group / Student Count cannot be 0";
                return false;
            }
            else if(groupTextBox.Text.Length > 0 && Int32.Parse(groupTextBox.Text) > students.Count)
            {
                outputLabel.Text = "ERROR: Group count higher than number of students";
                return false;
            }
            else if(studentTextBox.Text.Length > 0 && Int32.Parse(studentTextBox.Text) > students.Count)
            {
                outputLabel.Text = "ERROR: Number of students per group higher than total number of students";
                return false;
            }
            return true;
        }

        private void createGroupsButton_Click(object sender, EventArgs e)
        {
            // if inputs are valid, begin forming groups
            if (validInputs())
            {
                // set up deep copy for students list to help with group forming
                List<string> studentsCopy = new List<string> { };

                // set up empty list of groups
                List<List<string>> groups = new List<List<string>> { };

                for(int i = 0; i < students.Count; i++)
                {
                    studentsCopy.Add(students[i]);
                }               

                // User is using # of groups as limiter
                if (groupTextBox.Text.Length > 0)
                {
                    int groupCount = Int32.Parse(groupTextBox.Text);
                   
                    // set up empty groups by making n empty lists where n is the number of groups
                    for(int i = 0; i < groupCount; i++)
                    {
                        groups.Add(new List<string> { });
                    }

                    // build groups by adding one student to each group, one at a time
                    int groupIndex = 0;
                    while(studentsCopy.Count > 0)
                    {
                        // add a random student from remaining pool of students to a group
                        Random rnd = new Random();
                        int pickedStudent = rnd.Next(0, studentsCopy.Count);
                        //Console.WriteLine("picked " + studentsCopy[pickedStudent] + " for group " + (groupIndex + 1));
                        groups[groupIndex].Add(studentsCopy[pickedStudent]);
                        studentsCopy.RemoveAt(pickedStudent);
                        
                        // increment group, and if necessary, reset index to 0
                        groupIndex++;
                        if(groupIndex == groupCount) { groupIndex = 0; }

                    }                   


                }
                else if (studentTextBox.Text.Length > 0)
                {
                    outputLabel.Text = "student";
                }

                // format output based on formed groups list
                string output = "";
                for(int i = 0; i < groups.Count; i++)
                {
                    int lineIndex = 0;
                    output += "GROUP " + (i + 1) + ":    | ";
                    for (int j = 0; j < groups[i].Count; j++)
                    {
                        if (lineIndex > 3)
                        {
                            output += "\n                     | ";
                            lineIndex = 0;
                        }
                        output += groups[i][j] + " | ";
                        lineIndex++;                        
                    }
                    output += "\n\n";
                }
                outputLabel.Text = output;

            }         
            outputLabel.Show();
        }
    }
}