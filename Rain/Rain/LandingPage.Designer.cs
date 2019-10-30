namespace Rain
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
            this.loadClassButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadClassButton
            // 
            this.loadClassButton.Location = new System.Drawing.Point(12, 12);
            this.loadClassButton.Name = "loadClassButton";
            this.loadClassButton.Size = new System.Drawing.Size(184, 95);
            this.loadClassButton.TabIndex = 0;
            this.loadClassButton.Text = "Load Class";
            this.loadClassButton.UseVisualStyleBackColor = true;
            this.loadClassButton.Click += new System.EventHandler(this.loadClassButton_Click);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loadClassButton);
            this.Name = "LandingPage";
            this.Text = "Rain";
            this.Load += new System.EventHandler(this.LandingPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadClassButton;
    }
}