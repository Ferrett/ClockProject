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
        readonly Color aboba;
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
            RotationAngleMinutesArrow =time.Minute * 6 + 180;
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
            RotationAngleMinutesArrow = time.Minute * 6 + 180;
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

            g.DrawString("12", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), Width / 2 - (int)(Width / 17.5), Width / 35);
            g.DrawString("1", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), Width / 2 + Width / 6, (int)(Width / 10.7));
            g.DrawString("2", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), Width / 2 + (int)(Width / 3.1), (int)(Width / 4.1));
            g.DrawString("3", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), Width - (int)(Width / 8.75), Height / 2 - (int)(Width / 17));
            g.DrawString("4", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), Width - (int)(Width / 5.8), Height / 2 + (int)(Width / 7.77));
            g.DrawString("5", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), Width - (int)(Width / 3.1), Height / 2 + (int)(Width / 3.5));
            g.DrawString("6", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), Width / 2 - Width / 35, Height - Width / 7);
            g.DrawString("7", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), Width / 2 - (int)(Width / 3.88), Height - (int)(Width / 4.8));
            g.DrawString("8", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), Width / 2 - (int)(Width / 2.5), Height - (int)(Width / 2.8));
            g.DrawString("9", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), (int)(Width / 23.3), Height / 2 - (int)(Width / 17.5));
            g.DrawString("10", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), (int)(Width / 11.6), Width / 4);
            g.DrawString("11", new Font("Times New Roman", Width / 14), new SolidBrush(Color.Black), (int)(Width / 4.37), (int)(Width / 11.6));
        }


        public void UpdateArrows(Graphics g)
        {
            g.FillEllipse(new SolidBrush(OutlineColor), new Rectangle(0, 0, Width, Height));
            g.FillEllipse(new SolidBrush(MainColor), new Rectangle(Width/46, Width / 46, Width - Width / 23, Height - Width / 23));

            DrawNumbers(g);
           
            g.TranslateTransform(Width / 2, Height / 2);


            g.RotateTransform((float)RotationAngleHoursArrow);
            g.FillRegion(new SolidBrush(ArrowColor), new Region(new Rectangle(0, 0, (int)(Width / 53.8), Width / 2 - Width / 7)));

            g.RotateTransform((float)RotationAngleMinutesArrow - (float)RotationAngleHoursArrow % 360);
            g.FillRegion(new SolidBrush(ArrowColor), new Region(new Rectangle(0, 0, (int)(Width / 87.5), Width / 2 - Width / 9)));


            g.RotateTransform((float)(RotationAngleSecondsArrow));
            g.FillRectangle(new SolidBrush(ArrowColor), new Rectangle(0, 0, Width / 140, Width / 2 - Width / 10));

        }
    }
}
