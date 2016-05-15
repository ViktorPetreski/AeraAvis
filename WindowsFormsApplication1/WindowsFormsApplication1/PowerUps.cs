using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormsApplication1
{
    class PowerUps
    {
        private List<Image> powerUps;
        private Rectangle position;
        private Point Point;
        private Size Size;
        private int currIndeks;
        private Timer t1;
        private int height;
        private int width;
        private int X;
        private int Y;
        private Random rand;
        public static bool timerEnabled = true;

        public PowerUps(int width, int height)
        {
            rand = new Random();
            powerUps = new List<Image>();
            Size = new Size(35, 35);
            this.width = width;
            X = width;
            this.height = height;
            Init();
            currIndeks =  rand.Next(0, powerUps.Count);
            position = new Rectangle(Point, Size);
        }

        public bool CheckReversed()
        {
            return currIndeks == 2;
        }

        private void ChoosePosition()
        {            
         //   if (rand.Next(1, 5000) % 3 == 1)
                Y = rand.Next(250,450);
        //    else Y = height - 200;
            Point = new Point(X, Y);
        }

        private void Init()
        {
            powerUps.Add(WindowsFormsApplication1.Properties.Resources.PowerUp1);
            powerUps.Add(WindowsFormsApplication1.Properties.Resources.PowerUp2);
            powerUps.Add(WindowsFormsApplication1.Properties.Resources.PowerUp3);
            powerUps.Add(WindowsFormsApplication1.Properties.Resources.PowerUp4);
            powerUps.Add(WindowsFormsApplication1.Properties.Resources.PowerUp5);
            SetTimer();
            ChoosePosition();
        }

        private void SetTimer()
        {
            t1 = new Timer(13000);
            t1.Enabled = true;
            t1.Elapsed += DrawPowerUp;
        }
        
        public void Draw(Graphics g)
        {
            g.DrawImage(powerUps[currIndeks], position);
        }

        private void DrawPowerUp(Object source, ElapsedEventArgs e)
        {
            currIndeks = 0;// rand.Next(0, powerUps.Count);
            ChoosePosition();
            position = new Rectangle(Point, Size);
            timerEnabled = true;
        }

        public void Move()
        {
            X -= 2;
            Point = new Point(X, Y);
            position = new Rectangle(Point, Size);
            if(X < -40)
            {
                X = width;
                timerEnabled = false;
            }
        }

        public Rectangle getPosition()
        {
            return position;
        }
        
        public void getPower()
        {
            timerEnabled = false;
            X = width;
            Point = new Point(X, Y);
            position = new Rectangle(Point ,Size);
        }

        public int getIndex()
        {
            return currIndeks;
        }

    }
}
