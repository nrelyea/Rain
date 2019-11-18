 private Point MouseDownLocation;

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int newX = e.X + button1.Left - MouseDownLocation.X;
                int newY = e.Y + button1.Top - MouseDownLocation.Y;

                //button1.Margin = new Padding(newX, newY, 0, 0);
                button1.Location = new Point(newX, newY);
            }
        }