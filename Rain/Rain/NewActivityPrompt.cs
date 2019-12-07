using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rain
{
    public partial class NewActivityPrompt : Form
    {
        public string ActivityName;
        public string ActivityDescription;
        public double ActivityTime = 0;
        public Color ActivityColor;

        public int ActivityIndex;

        public bool Saved = false;
        public bool Deleted = false;

        public NewActivityPrompt(string name, string desc, double time, Color clr, int index)
        {
            InitializeComponent();

            ActivityName = name;
            ActivityDescription = desc;
            ActivityTime = time;
            ActivityColor = clr;

            ActivityIndex = index;
        }

        private void NewActivityPrompt_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            updateColor(ActivityColor);

            // if this prompt is being loaded from an existing activity
            if (ActivityIndex > -1) 
            {
                this.Text = "Edit Activity: " + ActivityName;

                nameTextBox.Text = ActivityName;
                descriptionTextBox.Text = ActivityDescription;
                timeTextBox.Text = ActivityTime.ToString();

                // load delete option & icon
                Image deleteImage = ResizeImage(Image.FromFile("Assets/TrashCan.png"), deletePicBox.Width, deletePicBox.Height);
                deletePicBox.Image = deleteImage;
                deletePicBox.Show();
            }

            colorDialog.Color = ActivityColor;

            

        }

        private void saveActivityButton_Click(object sender, EventArgs e)
        {
            if (validTime(timeTextBox.Text))
            {
                ActivityName = nameTextBox.Text;
                ActivityDescription = descriptionTextBox.Text;
                ActivityTime = Convert.ToDouble(timeTextBox.Text);

                Saved = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("ERROR: Invalid Activity Time!\n\n " +
                                        "Make sure your activity time is a number between 0.5 and 180");
            }
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                updateColor(colorDialog.Color);
            }
        }

        private void updateColor(Color c)
        {
            ActivityColor = c;
            colorButton.BackColor = c;
        }

        private bool validTime(string timeStr)
        {
            try
            {
                double time = Convert.ToDouble(timeStr);
                if (time < 0.5)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        // resizes an image to a given width and height
        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void deletePicBox_Click(object sender, EventArgs e)
        {
            string nameSnippet = "";
            if (ActivityName.Length > 0)
            {
                nameSnippet = " (" + ActivityName + ")";
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this activity?" + nameSnippet,
                "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Saved = true;
                Deleted = true;
                this.Close();
            }
        }

        public string getActivityName() { return ActivityName; }
        public string getActivityDescription() { return ActivityDescription; }
        public double getActivityTime() { return ActivityTime; }
        public Color getActivityColor() { return ActivityColor; }

        public bool isSaved() { return Saved; }
        public bool isDeleted() { return Deleted; }

        
    }
}
