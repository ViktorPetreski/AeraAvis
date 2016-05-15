using System;
using System.Media;
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
        private bool isStarted = false;
        private bool stop;
        private SoundPlayer fly;
        StartupForm sf;
        private EndOfGame eof;

        public Form1()
        {
            InitializeComponent();
            X = Width;
            Y = Height;
            direction = true;
            scene = new Scene(Width, Height);
            stop = false;
            fly = new SoundPlayer(WindowsFormsApplication1.Properties.Resources.Up);
            DoubleBuffered = true;
            sf = new StartupForm();
            eof = new EndOfGame();
            sf.ShowDialog();
        }

        private void isDead()
        {
            if (scene.ShouldDie())
            {
                Dead();
                stop = true;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.DrawPipe(e.Graphics);
            scene.DrawPowerUp(e.Graphics);
            scene.DrawBird(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            isDead();
            timer1.Interval = time1;
            direction = false;
            if (time1 >= 30)
                time1 -= 5;
            timer2.Enabled = false;
            scene.MoveBird(direction);
            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            isDead();
            direction = true;
            scene.MoveBird(direction);
            Invalidate();
            timer1.Enabled = true;
            time1 = 65;
            timer3.Enabled = PowerUps.timerEnabled;
        }

        private void Dead()
        {
            timer2.Enabled = timer3.Enabled = timer4.Enabled = false;
            if (scene.stopTimer)
            {
                timer1.Enabled = false;
                scene.stopTimer = false;
                eof.ShowDialog();
            }
            eof.UpdateCurrentScore(label1.Text);

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            isDead();
            scene.MovePowerUp();
            scene.Intersect();
            Invalidate();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            isDead();
            scene.MovePipe();
            scene.Check();
            label1.Text = scene.PipePassed(label1.Text);
            Invalidate();
        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (stop) return;
            if (e.KeyChar == '+' && !pressed)
            {
                label2.Hide();
                label3.Hide();
                fly.Play();
                if (!isStarted)
                {
                    timer4.Start();
                    isStarted = true;
                }
                timer1.Enabled = false;
                timer2.Enabled = true;
                time1 = 65;
                pressed = !scene.SuperMan();
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressed = false;
        }
    }
}
