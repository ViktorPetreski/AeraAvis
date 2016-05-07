using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;

namespace WindowsFormsApplication1
{
    class Scene
    {
        private Bird bird;
        private List<Image> poweredUpBird;
        private PowerUps powerUp;

        public Scene(int width, int height)
        {
            bird = new Bird(width, height);
            powerUp = new PowerUps(width, height);
            poweredUpBird = new List<Image>();
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

        public bool SuperMan()
        {
            return bird.intersect && powerUp.getIndex() == 1;
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

        public int getY()
        {
            return bird.GetSize().Height;
        }







}
}
