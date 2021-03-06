﻿namespace Rain
{
    partial class EditStudents
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
            this.helpLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.saveButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.textHoldingPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.textHoldingPanel.SuspendLayout();
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
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel7);
            this.splitContainer1.Size = new System.Drawing.Size(1105, 677);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.helpLabel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(366, 677);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // helpLabel
            // 
            this.helpLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.helpLabel.AutoSize = true;
            this.helpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.Location = new System.Drawing.Point(27, 92);
            this.helpLabel.Margin = new System.Windows.Forms.Padding(25);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(312, 491);
            this.helpLabel.TabIndex = 0;
            this.helpLabel.Text = "Use the area to the right to enter the full names of each student enrolled in thi" +
    "s class!\r\n\r\nWrite each student\'s name on a separate line";
            this.helpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.textHoldingPanel, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(735, 677);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.saveButton, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(627, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(105, 671);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Honeydew;
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(25, 492);
            this.saveButton.Margin = new System.Windows.Forms.Padding(25);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(55, 154);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save Student List";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Honeydew;
            this.backButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(25, 25);
            this.backButton.Margin = new System.Windows.Forms.Padding(25);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(55, 60);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // textHoldingPanel
            // 
            this.textHoldingPanel.BackColor = System.Drawing.Color.White;
            this.textHoldingPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.textHoldingPanel.ColumnCount = 1;
            this.textHoldingPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.textHoldingPanel.Controls.Add(this.mainTextBox, 0, 0);
            this.textHoldingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textHoldingPanel.Location = new System.Drawing.Point(30, 30);
            this.textHoldingPanel.Margin = new System.Windows.Forms.Padding(30);
            this.textHoldingPanel.Name = "textHoldingPanel";
            this.textHoldingPanel.RowCount = 1;
            this.textHoldingPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.textHoldingPanel.Size = new System.Drawing.Size(564, 617);
            this.textHoldingPanel.TabIndex = 2;
            // 
            // mainTextBox
            // 
            this.mainTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTextBox.Location = new System.Drawing.Point(11, 11);
            this.mainTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.Size = new System.Drawing.Size(542, 595);
            this.mainTextBox.TabIndex = 0;
            this.mainTextBox.Text = "";
            // 
            // EditStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 677);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EditStudents";
            this.Text = "Rain | Edit Students";
            this.Load += new System.EventHandler(this.EditStudents_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.textHoldingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TableLayoutPanel textHoldingPanel;
        private System.Windows.Forms.RichTextBox mainTextBox;
        private System.Windows.Forms.Label helpLabel;
    }
}