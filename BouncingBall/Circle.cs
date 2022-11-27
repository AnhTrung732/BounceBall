using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BouncingBall
{
    internal class Circle
    {
        private int vx = 3;
        private int vy = 3;
        private Point location;
        private int radius;
        private Color color = Color.Green;
        private SolidBrush brush;


        public Circle(Point location, int radius, int vx, int vy, Color color)
        {
            this.location = location;
            this.radius = radius;
            this.vx = vx;
            this.vy = vy;
            this.color = color;
        }

        public Point Location { get => location; set => location = value; }
        public int Radius { get => radius; set => radius = value; }
        public Color Color { get => color; set => color = value; }
        public int Vx { get => vx; set => vx = value; }
        public int Vy { get => vy; set => vy = value; }

        public void Paint(Graphics g)
        {
            Rectangle rect = new Rectangle(Location.X - Radius, Location.Y - Radius, Radius * 2, Radius * 2);
            SolidBrush brushColor = new SolidBrush(this.color);
            g.FillEllipse(brushColor, rect);
        }
        public Boolean overlaps(Circle circle)
        {
            //Use distance formula to check if a circle overlaps with another circle.
            double distance = Math.Sqrt(Math.Pow(circle.location.X + circle.radius - this.location.X -this.radius, 2) + (Math.Pow(circle.location.Y + circle.radius - this.location.Y - this.radius, 2)));
            return distance <= (this.radius + circle.radius) && distance >= Math.Abs(this.radius - circle.radius);
        }
        public void Move(int boundaryX, int boundaryY)
        {
            
            //Console.WriteLine((this.location.X, this.location.Y, boundaryX, boundaryY).ToString());
            this.location.X += this.vx;
            this.location.Y += this.vy;
            if (this.location.X - radius <= 0 || this.location.X + radius * 2 >= boundaryX)
            {
                this.vx *= -1;
            }

            if (this.location.Y - radius <= 0 || this.location.Y + radius * 3 >= boundaryY)
            {
                this.vy *= -1;
            }
        }
    }
}
