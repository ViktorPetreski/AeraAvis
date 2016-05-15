
using System.Drawing;

namespace AeraAvis
{

    class Pipe
    {
        public Point Position { get; set; }
        private int Type { get; set; }
        public Image PipeImage;
        private int Height { get; set; }
        private int WIDTH = 90;
        public Rectangle r { get; set; }
        public Pipe(Point position, int height, int type)
        {
            Type = type;
            if (type == 0)
            {
                WIDTH = 50;
                PipeImage = Properties.Resources.top_pillar1;
            }
            else if (type == 1)
                PipeImage = Properties.Resources.top_pillar2;
            else if (type == 2)
            {
                PipeImage = Properties.Resources.bottom_pillar1;
                WIDTH = 50;
            }
            else if (type == 3)
                PipeImage = Properties.Resources.bottom_pillar2;

            Position = position;
            Height = height;

        }

        public void Draw(Graphics g)
        {
         
            r = new Rectangle(Position.X, Position.Y, WIDTH, Height);
          

   
            g.DrawImage(PipeImage, r);
           
        }

        public void Move()
        {
            int x = Position.X;
            int y = Position.Y;
            Point p = new Point(x - 3, y);
            Position = p;

        }

       
    }


}
