﻿namespace Rain
{
    partial class LandingPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.deleteClassButton = new System.Windows.Forms.Button();
            this.editClassButton = new System.Windows.Forms.Button();
            this.newClassButton = new System.Windows.Forms.Button();
            this.loadClassButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.selectClassDropDown = new System.Windows.Forms.ComboBox();
            this.selectClassLabel = new System.Windows.Forms.Label();
            this.logoPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.logoPicBox);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.deleteClassButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.editClassButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.newClassButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.loadClassButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // deleteClassButton
            // 
            this.deleteClassButton.BackColor = System.Drawing.Color.Honeydew;
            this.deleteClassButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteClassButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteClassButton.Location = new System.Drawing.Point(3, 403);
            this.deleteClassButton.Name = "deleteClassButton";
            this.deleteClassButton.Size = new System.Drawing.Size(258, 44);
            this.deleteClassButton.TabIndex = 5;
            this.deleteClassButton.Text = "Delete Class";
            this.deleteClassButton.UseVisualStyleBackColor = false;
            this.deleteClassButton.Click += new System.EventHandler(this.deleteClassButton_Click);
            // 
            // editClassButton
            // 
            this.editClassButton.BackColor = System.Drawing.Color.Honeydew;
            this.editClassButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editClassButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editClassButton.Location = new System.Drawing.Point(3, 353);
            this.editClassButton.Name = "editClassButton";
            this.editClassButton.Size = new System.Drawing.Size(258, 44);
            this.editClassButton.TabIndex = 4;
            this.editClassButton.Text = "Edit Class Name";
            this.editClassButton.UseVisualStyleBackColor = false;
            this.editClassButton.Click += new System.EventHandler(this.editClassButton_Click);
            // 
            // newClassButton
            // 
            this.newClassButton.BackColor = System.Drawing.Color.Honeydew;
            this.newClassButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newClassButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newClassButton.Location = new System.Drawing.Point(3, 303);
            this.newClassButton.Name = "newClassButton";
            this.newClassButton.Size = new System.Drawing.Size(258, 44);
            this.newClassButton.TabIndex = 3;
            this.newClassButton.Text = "New Class";
            this.newClassButton.UseVisualStyleBackColor = false;
            this.newClassButton.Click += new System.EventHandler(this.newClassButton_Click);
            // 
            // loadClassButton
            // 
            this.loadClassButton.BackColor = System.Drawing.Color.Thistle;
            this.loadClassButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadClassButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadClassButton.Location = new System.Drawing.Point(3, 153);
            this.loadClassButton.Name = "loadClassButton";
            this.loadClassButton.Size = new System.Drawing.Size(258, 144);
            this.loadClassButton.TabIndex = 0;
            this.loadClassButton.Text = "Load Class";
            this.loadClassButton.UseVisualStyleBackColor = false;
            this.loadClassButton.Click += new System.EventHandler(this.loadClassButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Honeydew;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.selectClassDropDown, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.selectClassLabel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(258, 144);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // selectClassDropDown
            // 
            this.selectClassDropDown.BackColor = System.Drawing.Color.White;
            this.selectClassDropDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.selectClassDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectClassDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectClassDropDown.FormattingEnabled = true;
            this.selectClassDropDown.Location = new System.Drawing.Point(3, 118);
            this.selectClassDropDown.Name = "selectClassDropDown";
            this.selectClassDropDown.Size = new System.Drawing.Size(252, 45);
            this.selectClassDropDown.TabIndex = 1;
            // 
            // selectClassLabel
            // 
            this.selectClassLabel.BackColor = System.Drawing.Color.Honeydew;
            this.selectClassLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectClassLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectClassLabel.Location = new System.Drawing.Point(3, 0);
            this.selectClassLabel.Name = "selectClassLabel";
            this.selectClassLabel.Size = new System.Drawing.Size(252, 115);
            this.selectClassLabel.TabIndex = 2;
            this.selectClassLabel.Text = "Select a Class\r\n↓\r\n\r\n";
            this.selectClassLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // logoPicBox
            // 
            this.logoPicBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPicBox.ImageLocation = "";
            this.logoPicBox.Location = new System.Drawing.Point(0, 0);
            this.logoPicBox.Margin = new System.Windows.Forms.Padding(0);
            this.logoPicBox.Name = "logoPicBox";
            this.logoPicBox.Size = new System.Drawing.Size(100, 100);
            this.logoPicBox.TabIndex = 0;
            this.logoPicBox.TabStop = false;
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LandingPage";
            this.Text = "Rain";
            this.Load += new System.EventHandler(this.LandingPage_Load);
            this.Resize += new System.EventHandler(this.LandingPage_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button loadClassButton;
        private System.Windows.Forms.ComboBox selectClassDropDown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label selectClassLabel;
        private System.Windows.Forms.Button editClassButton;
        private System.Windows.Forms.Button newClassButton;
        private System.Windows.Forms.PictureBox logoPicBox;
        private System.Windows.Forms.Button deleteClassButton;
    }
}