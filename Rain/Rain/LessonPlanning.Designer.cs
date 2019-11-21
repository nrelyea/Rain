namespace Rain
{
    partial class LessonPlanning
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
            this.deleteLessonButton = new System.Windows.Forms.Button();
            this.newLessonButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.selectLessonDropDown = new System.Windows.Forms.ComboBox();
            this.selectLessonLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.newActivityButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.activitiesPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.deleteLessonButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.newLessonButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // deleteLessonButton
            // 
            this.deleteLessonButton.BackColor = System.Drawing.Color.Honeydew;
            this.deleteLessonButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteLessonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteLessonButton.Location = new System.Drawing.Point(3, 401);
            this.deleteLessonButton.Name = "deleteLessonButton";
            this.deleteLessonButton.Size = new System.Drawing.Size(258, 46);
            this.deleteLessonButton.TabIndex = 4;
            this.deleteLessonButton.Text = "Delete Lesson";
            this.deleteLessonButton.UseVisualStyleBackColor = false;
            this.deleteLessonButton.Click += new System.EventHandler(this.deleteLessonButton_Click);
            // 
            // newLessonButton
            // 
            this.newLessonButton.BackColor = System.Drawing.Color.Honeydew;
            this.newLessonButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newLessonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newLessonButton.Location = new System.Drawing.Point(3, 351);
            this.newLessonButton.Name = "newLessonButton";
            this.newLessonButton.Size = new System.Drawing.Size(258, 44);
            this.newLessonButton.TabIndex = 3;
            this.newLessonButton.Text = "New Lesson";
            this.newLessonButton.UseVisualStyleBackColor = false;
            this.newLessonButton.Click += new System.EventHandler(this.newLessonButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Honeydew;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.selectLessonDropDown, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.selectLessonLabel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(258, 95);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // selectLessonDropDown
            // 
            this.selectLessonDropDown.BackColor = System.Drawing.Color.White;
            this.selectLessonDropDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.selectLessonDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectLessonDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectLessonDropDown.FormattingEnabled = true;
            this.selectLessonDropDown.Location = new System.Drawing.Point(3, 66);
            this.selectLessonDropDown.Name = "selectLessonDropDown";
            this.selectLessonDropDown.Size = new System.Drawing.Size(252, 45);
            this.selectLessonDropDown.TabIndex = 1;
            // 
            // selectLessonLabel
            // 
            this.selectLessonLabel.BackColor = System.Drawing.Color.Honeydew;
            this.selectLessonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectLessonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectLessonLabel.Location = new System.Drawing.Point(3, 0);
            this.selectLessonLabel.Name = "selectLessonLabel";
            this.selectLessonLabel.Size = new System.Drawing.Size(252, 63);
            this.selectLessonLabel.TabIndex = 2;
            this.selectLessonLabel.Text = "Select a Lesson\r\n↓";
            this.selectLessonLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.activitiesPanel, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(532, 450);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.newActivityButton, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.backButton, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(455, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(74, 444);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // newActivityButton
            // 
            this.newActivityButton.BackColor = System.Drawing.Color.Honeydew;
            this.newActivityButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.newActivityButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newActivityButton.Location = new System.Drawing.Point(25, 265);
            this.newActivityButton.Margin = new System.Windows.Forms.Padding(25);
            this.newActivityButton.Name = "newActivityButton";
            this.newActivityButton.Size = new System.Drawing.Size(24, 154);
            this.newActivityButton.TabIndex = 3;
            this.newActivityButton.Text = "New Activity";
            this.newActivityButton.UseVisualStyleBackColor = false;
            this.newActivityButton.Click += new System.EventHandler(this.newActivityButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Honeydew;
            this.backButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(25, 25);
            this.backButton.Margin = new System.Windows.Forms.Padding(25);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(24, 60);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // activitiesPanel
            // 
            this.activitiesPanel.BackColor = System.Drawing.Color.LightSkyBlue;
            this.activitiesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activitiesPanel.Location = new System.Drawing.Point(10, 10);
            this.activitiesPanel.Margin = new System.Windows.Forms.Padding(10);
            this.activitiesPanel.Name = "activitiesPanel";
            this.activitiesPanel.Size = new System.Drawing.Size(432, 430);
            this.activitiesPanel.TabIndex = 3;
            this.activitiesPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.activitiesPanel_MouseDown);
            this.activitiesPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.activitiesPanel_MouseMove);
            // 
            // LessonPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LessonPlanning";
            this.Text = "LessonPlanning";
            this.Load += new System.EventHandler(this.LessonPlanning_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button newActivityButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button deleteLessonButton;
        private System.Windows.Forms.Button newLessonButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox selectLessonDropDown;
        private System.Windows.Forms.Label selectLessonLabel;
        private System.Windows.Forms.Panel activitiesPanel;
    }
}