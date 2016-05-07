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
        public readonly int WIDTH = 90;

        public Pipe(Point position, int height, int type)
        {
            Type = type;
            if (type == 0)
                PipeImage = WindowsFormsApplication1.Properties.Resources.top_pillar;
            else if (type == 1)
                PipeImage = WindowsFormsApplication1.Properties.Resources.bottom_pillar2;

            Position = position;
            Height = height;

        }

        public void Draw(Graphics g)
        {
            //  Brush br = new SolidBrush(Color.Red);
            Rectangle r = new Rectangle(Position.X, Position.Y, WIDTH, Height);
            //   g.FillRectangle(br, r);
            g.DrawImage(PipeImage, r);
            //   br.Dispose();
        }

        public void Move()
        {
            int x = Position.X;
            int y = Position.Y;
            Point p = new Point(x - 2, y);
            Position = p;
        }
    }
    

}
