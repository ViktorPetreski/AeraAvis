using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
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
                PipeImage = WindowsFormsApplication1.Properties.Resources.top_pillar1;
            }

            else if (type == 1)
                PipeImage = WindowsFormsApplication1.Properties.Resources.top_pillar2;
            else if (type == 2)
            {
                PipeImage = WindowsFormsApplication1.Properties.Resources.bottom_pillar1;
                WIDTH = 50;
            }

            else if (type == 3)
                PipeImage = WindowsFormsApplication1.Properties.Resources.bottom_pillar2;

            Position = position;
            Height = height;

        }

        public void Draw(Graphics g)
        {
             //  Brush br = new SolidBrush(Color.Red);
            r = new Rectangle(Position.X, Position.Y, WIDTH, Height);
            //    Bitmap bmp = new Bitmap(PipeImage);

        //    g.FillRectangle(br, r);
            g.DrawImage(PipeImage, r);
            //     br.Dispose();
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
