﻿using System;
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
    public partial class EditStudents : Form
    {
        public string ClassName { get; set; }

        public EditStudents(string className)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            ClassName = className;
        }

        private void EditStudents_Load(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu(ClassName);
            menu.Show();
            this.Hide();
        }
    }
}
