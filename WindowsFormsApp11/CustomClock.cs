using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public class CustomClock : Control
    {
        readonly Color ArrowColor;
        readonly Color OutlineColor;
        readonly Color MainColor;

        public double RotationAngleSecondsArrow { get; set; } 
        public double RotationAngleMinutesArrow { get; set; }
        public double RotationAngleHoursArrow { get; set; }
        public CustomClock()
        {
            this.Paint += Draw;

            DateTime time = DateTime.Now;

            ArrowColor = Color.Black;
            OutlineColor = Color.Black;
            MainColor = Color.LightGray;

            RotationAngleSecondsArrow = time.Second * 6 + 180;
            RotationAngleMinutesArrow =55 * 6 + 180;
            RotationAngleHoursArrow = time.Hour * 30 + 180 + (time.Minute /2); 
           
            DoubleBuffered = true;
        }

        public CustomClock(DateTime time)
        {
            this.Paint += Draw;

            ArrowColor = Color.Black;
            OutlineColor = Color.Black;
            MainColor = Color.LightGray;

            RotationAngleSecondsArrow = time.Second * 6 + 180;
            RotationAngleMinutesArrow = 55 * 6 + 180;
            RotationAngleHoursArrow = time.Hour * 30 + 180 + (time.Minute / 2);

            DoubleBuffered = true;
        }

        public void Draw(object sender, PaintEventArgs e)
        {
            RotationAngleSecondsArrow+=0.1;
            RotationAngleMinutesArrow += 0.0016;
            RotationAngleHoursArrow += 0.000026;
            UpdateArrows(e.Graphics);
        }
        public void DrawNumbers(Graphics g)
        {
           
            g.DrawString("12", new Font("Times New Roman", 50), new SolidBrush(Color.Black), Width/2-40, 20);
            g.DrawString("1", new Font("Times New Roman", 50), new SolidBrush(Color.Black), Width / 2 + 115, 65);
            g.DrawString("2", new Font("Times New Roman", 50), new SolidBrush(Color.Black), Width / 2 + 220, 170);
            g.DrawString("3", new Font("Times New Roman", 50), new SolidBrush(Color.Black), Width  - 80, Height/2-40);
            g.DrawString("4", new Font("Times New Roman", 50), new SolidBrush(Color.Black), Width - 120, Height / 2 + 90);
            g.DrawString("5", new Font("Times New Roman", 50), new SolidBrush(Color.Black), Width - 220, Height / 2 + 200);
            g.DrawString("6", new Font("Times New Roman", 50), new SolidBrush(Color.Black), Width /2-20, Height -100);
            g.DrawString("7", new Font("Times New Roman", 50), new SolidBrush(Color.Black), Width / 2 -180, Height - 145);
            g.DrawString("8", new Font("Times New Roman", 50), new SolidBrush(Color.Black), Width / 2 - 280, Height - 250);
            g.DrawString("9", new Font("Times New Roman", 50), new SolidBrush(Color.Black), 30, Height /2-40);
            g.DrawString("10", new Font("Times New Roman", 50), new SolidBrush(Color.Black), 60, 175);
            g.DrawString("11", new Font("Times New Roman", 50), new SolidBrush(Color.Black), 160, 60);
        }
        

        public void UpdateArrows(Graphics g)
        {
 

            g.FillEllipse(new SolidBrush(OutlineColor), new Rectangle(0, 0, Width, Height));
            g.FillEllipse(new SolidBrush(MainColor), new Rectangle(15, 15, Width - 30, Height - 30));

            DrawNumbers(g);
            g.TranslateTransform(Width / 2, Height / 2);

            g.RotateTransform((float)RotationAngleHoursArrow);
            g.FillRegion(new SolidBrush(ArrowColor), new Region(new Rectangle(0, 0, 10, 270)));

            g.RotateTransform((float)RotationAngleMinutesArrow - (float)RotationAngleHoursArrow%360);
            g.FillRegion(new SolidBrush(ArrowColor), new Region(new Rectangle(0,0,8, 290)));


            g.RotateTransform((float)(RotationAngleSecondsArrow));
            g.FillRectangle(new SolidBrush(ArrowColor), new Rectangle(0,0, 5, 300));


           
            

        }
    }
}
