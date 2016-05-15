using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading;
using System.Timers;

namespace WindowsFormsApplication1
{
    class Scene
    {
        private Bird bird;
        private List<Image> poweredUpBird;
        private PowerUps powerUp;
        public int height = 300;
      
        public int h;
        public readonly int MAX_HEIGHT = 607;
        public readonly int MAX_WIDTH = 470;
        public List<Pipe> pipes;
        Random r;
        public bool stopTimer;
        private SoundPlayer grujo;



        public Scene(int width, int height)
        {
            bird = new Bird(width, height);
            powerUp = new PowerUps(width, height);
            poweredUpBird = new List<Image>();
            pipes = new List<Pipe>();
            stopTimer = false;
            grujo = new SoundPlayer(WindowsFormsApplication1.Properties.Resources.Grujo);
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
      //      poweredUpBird.Add(WindowsFormsApplication1.Properties.Resources.PowerUp1);
            r = new Random();
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

            if (Grujo())
            {
                grujo.PlayLooping();
                PipesGeneration(3);
            }
        }



        public bool ShouldDie()
        {
            foreach (Pipe p in pipes)
            {
                
                Point point = new Point(bird.GetPoint().X + 3, bird.GetPoint().Y + 7);
                Size size = new Size(bird.GetSize().Width - 7, bird.GetSize().Height - 14);
            //        Brush br = new SolidBrush(Color.Green);

                Rectangle c = new Rectangle(point, size);
                //          g.FillRectangle(br, c);

                if (bird.GetPoint().Y + bird.GetSize().Height >= 600)
                    stopTimer = true;

                if (c.IntersectsWith(p.r) || bird.GetPoint().Y + 7 <= 0 || bird.GetPoint().Y + bird.GetSize().Height - 14 >= 603)
                {
                    return true;
                }

            }
            return false;
        }
        public bool Reverse()
        {
            return powerUp.CheckReversed();
        }
        public bool Grujo()
        {
            return bird.intersect && powerUp.getIndex() == 0;
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
            if (pipes.Last().Position.X < 400)
            {

                PipesGeneration(2);

            }

        }


        public void PipesGeneration(int t = 0)
        {
           int vel = 150;
           if(t == 3)
            {
                pipes.Clear();
                vel = 400;
            }
            for (int i = 0; i < 5; i++)
            {

              
                if(t == 3)
                {
                    h = r.Next(40, 70);
            
                }
                else
                {
                    h = r.Next(150, 350);
                  
                }
              
                int x;
                if (t == 2)
                {
                    x = 550 + i * 150;
                }              
                else 
                {
                    x = 400 + i * 150;
                }

                Pipe p0 = new Pipe(new Point(x + 19, 40), h, 0);
                Pipe p1 = new Pipe(new Point(x, 0), 40, 1);
                Pipe p2 = new Pipe(new Point(x + 19, h + vel), MAX_HEIGHT - (h + vel), 2);
                Pipe p3 = new Pipe(new Point(x, MAX_HEIGHT - 30), 30, 3);
                pipes.Add(p1);
                pipes.Add(p2);
                pipes.Add(p0);
                pipes.Add(p3);
            }

        }

        public void DrawPipe(Graphics g)
        {
            foreach (Pipe p in pipes)
                p.Draw(g);
        }

        public void Check()
        {
            for (int i = pipes.Count - 1; i >= 0; i--)
            {
                if (pipes[i].Position.X < -90)
                {
                    pipes.RemoveAt(i);
                }
            }
        }

        public bool Neso()
        {
            foreach (Pipe p in pipes)
            {
                int x1 = p.Position.X + 25;
                int x2 = bird.GetPoint().X;
                if (x1 == x2)
                {
                    return true;
                }
            }
                return false;
        }
    }
}
