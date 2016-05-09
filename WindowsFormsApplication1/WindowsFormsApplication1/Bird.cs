using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormsApplication1
{
    class Bird
    {
        private Image birdImage;
        private Image currentImage;
        private Rectangle position;
        private Point point;
        private Size size;
        private int birdX;
        private int birdY;
        public int diff;
        private int angle;
        public bool intersect;

        public Bird(int x, int y)
        {
            birdImage = WindowsFormsApplication1.Properties.Resources.ActorNormalRes;
            size = new Size(50, 50);
            birdX = x / 2 - 50 / 2;
            birdY = y / 2 - 50 / 2;
            point = new Point(birdX, birdY);
            position = new Rectangle(point, size);
            angle = 0;
            currentImage = birdImage;
            intersect = false;
        }

        public void SetSize(Size newSIze)
        {
            size = newSIze;
        }

        public Point GetPoint()
        {
            return point;
        }

        public Size GetSize()
        {
            return size;
        }

        public Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(50, 50);
            Rectangle rec = new Rectangle(0, 0, 50, 50);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size

            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, rec);

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void Rotate(int degrees)
        {
            if(angle <= 90)
            birdImage = RotateImage(birdImage, degrees);
        }

        private void MoveUp()
        {
            birdY -= 8;

            birdImage = currentImage;
            Rotate(-30);

            diff = 0;
            angle = 0;
        }

        private void MoveDown()
        {
            birdY += 8;
            angle += 10;
            Rotate(10);
        }
        
        public void Move(bool direction)
        {
            if (direction) MoveUp();
            else MoveDown();
            point = new Point(birdX, birdY);
            position = new Rectangle(point, size);
        }


        public void Fly(Graphics g)
        {
            g.DrawImage(birdImage, position);
        }

        public Rectangle GetPosition()
        {
            return position;
        }

        public async void PowerUp(Image img)
        {
            currentImage = img;
            birdImage = currentImage;
            intersect = true;
            await Task.Delay(TimeSpan.FromSeconds(7));
            intersect = false;
            SetSize(new Size(50,50));
            currentImage = WindowsFormsApplication1.Properties.Resources.ActorNormalRes;
            birdImage = currentImage;
        }
        
                
         
    }
}
