using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Timers;

namespace WindowsFormsApplication1
{
    class Scene
    {
        private Bird bird;
        private List<Image> poweredUpBird;
        private PowerUps powerUp;
        public int height = 300;
        public int vel = 200;
        public int h;
        public readonly int MAX_HEIGHT = 815;
        public readonly int MAX_WIDTH = 625;
        public List<Pipe> pipes;
        public Scene(int width, int height)
        {
            bird = new Bird(width, height);
            powerUp = new PowerUps(width, height);
            poweredUpBird = new List<Image>();
            pipes = new List<Pipe>();
            Init();
        }

        private void Init()
        {
            poweredUpBird.Add(WindowsFormsApplication1.Properties.Resources.PowerUp1);
            poweredUpBird.Add(WindowsFormsApplication1.Properties.Resources.ActorSuper);
            poweredUpBird.Add(WindowsFormsApplication1.Properties.Resources.PowerUp3);
            Image tmp = WindowsFormsApplication1.Properties.Resources.ActorNormalRes;
            poweredUpBird.Add(tmp);
            poweredUpBird.Add(tmp);

            PipesGeneration();
        }
        public void DrawBird(Graphics g)
        {
            bird.Fly(g);
        }

        public void MoveBird(bool dir)
        {
            if (Reverse() && bird.intersect)
                dir = !dir;
            bird.Move(dir);
        }

        public void MovePowerUp()
        {
            powerUp.Move();
        }

        public void DrawPowerUp(Graphics g)
        {
            powerUp.Draw(g);
        }

        private Image PickPowerUp(int index)
        {
            switch (index)
            {
                case 3:
                    bird.SetSize(new Size(80, 80));
                    break;
                case 4:
                    bird.SetSize(new Size(30, 30));
                    break;
            }
            return poweredUpBird[index];
        }


        public void Intersect()
        {
            if (bird.GetPosition().IntersectsWith(powerUp.getPosition()))
            {
                powerUp.getPower();
                bird.PowerUp(PickPowerUp(powerUp.getIndex()));
            }
        }

        public bool Reverse()
        {
            return powerUp.CheckReversed();
        }

        public bool SuperMan()
        {
            return bird.intersect && powerUp.getIndex() == 1;
        }

        public int getY()
        {
            return bird.GetSize().Height;
        }

        public void MovePipe()
        {
            foreach (Pipe p in pipes)
            {
                p.Move();
            }
            if (pipes.Last().Position.X < 250)
            {

                PipesGeneration();
                pipes.RemoveAt(0);
                pipes.RemoveAt(1);
                pipes.RemoveAt(2);
            }
            //  Invalidate();
        }

        public void PipesGeneration(int t = 0)
        {
            Random r = new Random();

            for (int i = 0; i < 5; i++)
            {
                h = r.Next(200, 450);
                //  vel = r.Next(100, 200);
                //   height = h + vel;
                int x = 400 + i * 150;
                Pipe p1 = new Pipe(new Point(x, 0), h, 0);
                Pipe p2 = new Pipe(new Point(x, h + 100), MAX_HEIGHT - (h + 100) - 100, 1);
                pipes.Add(p1);
                pipes.Add(p2);
            }

        }

        public void DrawPipe(Graphics g)
        {
            foreach (Pipe p in pipes)
                p.Draw(g);
        }
    }
}
