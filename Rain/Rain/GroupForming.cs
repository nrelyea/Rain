using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Rain
{
    public partial class GroupForming : Form
    {
        public string ClassName { get; set; }

        public List<string> students;
        public GroupForming(string className)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            outputLabel.Hide();

            ClassName = className;

            string json = File.ReadAllText(@"students.json");
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
                outputLabel.Text = "ERROR: Group count higher than total number of students";
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

                // User is using # of groups as limiter OR if bigger groups are allowed when grouping by student
                if (groupTextBox.Text.Length > 0 || (studentTextBox.Text.Length > 0 && biggerGroupsRadio.Checked))
                {
                    int groupCount = 0;
                    if (groupTextBox.Text.Length > 0)
                    {
                        groupCount = Int32.Parse(groupTextBox.Text);
                    }
                    else
                    {
                        groupCount = students.Count / Int32.Parse(studentTextBox.Text);
                    }
                                     
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
                        int pickedStudent = RandomNumber.Between(0, studentsCopy.Count - 1);
                        //Console.WriteLine("picked " + studentsCopy[pickedStudent] + " for group " + (groupIndex + 1));
                        groups[groupIndex].Add(correctName(studentsCopy[pickedStudent],students));
                        studentsCopy.RemoveAt(pickedStudent);
                        
                        // increment group, and if necessary, reset index to 0
                        groupIndex++;
                        if(groupIndex == groupCount) { groupIndex = 0; }

                    }                   


                }
                // user is using number of students as limiter (ONLY WHEN ALLOWING SMALLER GROUPS)
                else if (studentTextBox.Text.Length > 0)
                {
                    int studentsPerGroup = Int32.Parse(studentTextBox.Text);
                    int groupCount = students.Count / studentsPerGroup;
                    if (students.Count % studentsPerGroup > 0)
                    {
                        groupCount++;
                    }

                    // set up empty groups by making n empty lists where n is the number of groups
                    for (int i = 0; i < groupCount; i++)
                    {
                        groups.Add(new List<string> { });
                    }

                    // build groups by adding one student to each group, one at a time
                    int groupIndex = 0;
                    int studentIndex = 0;
                    while (studentsCopy.Count > 0)
                    {
                        int pickedStudent = RandomNumber.Between(0, studentsCopy.Count - 1);
                        //Console.WriteLine("picked " + studentsCopy[pickedStudent] + " for group " + (groupIndex + 1));
                        groups[groupIndex].Add(correctName(studentsCopy[pickedStudent], students));
                        studentsCopy.RemoveAt(pickedStudent);

                        // increment group, and if necessary, reset index to 0
                        studentIndex++;
                        if (studentIndex == studentsPerGroup) {
                            studentIndex = 0;
                            groupIndex++;
                        }

                    }
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
            
            // Display result
            outputLabel.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu(ClassName);
            menu.Show();
            this.Hide();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(outputLabel.Text);
            System.Windows.Forms.MessageBox.Show("Groups have been copied to Clipboard!");
        }

        private string correctName(string name, List<string> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (firstName(name) == firstName(students[i]) && name != students[i])
                {
                    return firstNameLastInitial(name);
                }
            }
            return firstName(name);
        }

        private string firstName(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    return str.Substring(0, i);
                }
            }
            return str;
        }

        private string firstNameLastInitial(string str)
        {
            for(int i = 0; i < str.Length; i++)
            {
                if(str[i] == ' ')
                {
                    return str.Substring(0, i+2);
                }
            }
            return str;
        }
    }

    public static class RandomNumber
    {
        private static readonly RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();

        public static int Between(int minimumValue, int maximumValue)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

            // We are using Math.Max, and substracting 0.00000000001, 
            // to ensure "multiplier" will always be between 0.0 and .99999999999
            // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

            // We need to add one to the range, to allow for the rounding done with Math.Floor
            int range = maximumValue - minimumValue + 1;

            double randomValueInRange = Math.Floor(multiplier * range);

            return (int)(minimumValue + randomValueInRange);
        }
    }
}
