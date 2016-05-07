using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{

    class Pipes
    {
        public Point topPipe;
        public Point bottomPipe;
        public int Movement { get; set; }

        public Pipes()
        {
            topPipe = new Point();
            bottomPipe = new Point();
            Movement = 400;
        }

        public void Draw(Graphics g, int x, int y)
        {             
            SolidBrush sb = new SolidBrush(Color.DarkCyan);
            topPipe = new Point(Movement, 0);
            bottomPipe = new Point(Movement, y);
            Size size = new Size(50, 200);
            Rectangle r = new Rectangle(topPipe, size);
            Rectangle r1 = new Rectangle(bottomPipe, size);
            Rectangle[] rect = new Rectangle[2];
            rect[1] = r1;
            rect[0] = r;
            g.FillRectangles(sb, rect);
            Pen pn = new Pen(Color.Black, 1);
            g.DrawRectangles(pn, rect);
            pn.Dispose();
            sb.Dispose();
        }
    }

   
}
