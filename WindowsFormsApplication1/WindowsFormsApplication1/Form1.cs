using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public int X { get; set; }
        public int Y { get; set; }
        private bool direction;
        private int time1;
        private Scene scene;
        private bool pressed;

        public Form1()
        {
            InitializeComponent();
            X = Width;
            Y = Height;
            direction = true;
            scene = new Scene(Width, Height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Dead(e.Graphics);
            scene.DrawBird(e.Graphics);
            scene.DrawPowerUp(e.Graphics);
            scene.DrawPipe(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = time1;
            direction = false;
            if (time1 >= 30)
                time1 -= 10;
            timer2.Enabled = false;
            scene.MoveBird(direction);
            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer3.Enabled = PowerUps.timerEnabled;
            direction = true;
            scene.MoveBird(direction);
            Invalidate();
            timer1.Enabled = true;
            time1 = 90;
        }

        private void Dead(Graphics g)
        {
            if (scene.getY() + 100 >= Height)
            {
                timer1.Enabled = timer2.Enabled = timer3.Enabled = timer4.Enabled = false;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            scene.MovePowerUp();
            scene.Intersect();
            Invalidate();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            scene.MovePipe();
            Invalidate();
        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+' && !pressed)
            {
                timer4.Start();
                timer1.Enabled = false;
                timer2.Enabled = true;
                time1 = 80;
                pressed = !scene.SuperMan();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressed = false;
        }
    }
}
