using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBall
{
    public partial class Form1 : Form
    {

        
        List<Circle> circles = new List<Circle>();
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            MouseEventArgs e_mouse = (MouseEventArgs)e;
            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            int radius = random.Next(10,30);
            Circle newCircle = new Circle(new Point(e_mouse.X, e_mouse.Y), radius, 3, 3, randomColor);
            newCircle.Paint(g);

            circles.Add(newCircle);

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            int BoundaryY = Height;
            int BoundaryX = Width;
            base.OnPaint(e);
            for (int i = 0; i < circles.Count; i++)
            {
                Circle c_i = circles[i];
                for (int j = i + 1; j < circles.Count; j++)
                {

                    Circle c_j = circles[j];
                    if (c_i.overlaps(c_j) == true)
                    {
                        c_i.Vx *= -1;
                        c_i.Vy *= -1;
                        c_j.Vx *= -1;
                        c_j.Vy *= -1;
                    }

                }
                c_i.Move(BoundaryX, BoundaryY);
                c_i.Paint(e.Graphics);
            }
        }
        private void Time_Tick(object sender, EventArgs e)
        {
            
            this.Invalidate();
        }



        
    }
}
