using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rain
{
    public partial class GroupForming : Form
    {
        public GroupForming()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        public bool canChange = true;

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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
    }
}
