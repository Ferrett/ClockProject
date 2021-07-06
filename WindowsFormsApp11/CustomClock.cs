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
            
            ArrowColor = Color.Black;
            OutlineColor = Color.Black;
            MainColor = Color.LightGray;

            RotationAngleSecondsArrow = 0;
            RotationAngleMinutesArrow = 0;
            RotationAngleHoursArrow = 0;

            DoubleBuffered = true;
        }

        public CustomClock(Color onColor, Color offColor, Color circleColor)
        {
            ArrowColor = onColor;
            OutlineColor = offColor;
            MainColor = circleColor;
        }

        public void Draw(object sender, PaintEventArgs e)
        {
            RotationAngleSecondsArrow+=0.1;
            RotationAngleMinutesArrow += 0.0016;
            RotationAngleHoursArrow += 0.000026;
            UpdateArrows(e.Graphics);
        }

        public void UpdateArrows(Graphics g)
        {
            g.FillEllipse(new SolidBrush(OutlineColor), new Rectangle(0, 0, Width, Height));
            g.FillEllipse(new SolidBrush(MainColor), new Rectangle(15, 15, Width - 30, Height - 30));

            g.TranslateTransform(Width / 2, Height / 2);

            g.RotateTransform((float)RotationAngleHoursArrow);
            g.FillRegion(new SolidBrush(ArrowColor), new Region(new Rectangle(0, 0, 10, 270)));

            g.RotateTransform((float)RotationAngleMinutesArrow);
            g.FillRegion(new SolidBrush(ArrowColor), new Region(new Rectangle(0,0,8,290)));

            g.RotateTransform((float)(RotationAngleSecondsArrow));
            g.FillRectangle(new SolidBrush(ArrowColor), new Rectangle(0,0, 5, 300));
        }
    }
}
