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
        readonly Color SmallCircleColor;

        readonly int Multiplier;

        public double RotationAngle = 0;
        public CustomClock()
        {
            this.Paint += Draw;
            

            ArrowColor = Color.Black;
            OutlineColor = Color.Black;
            MainColor = Color.LightGray;

            Multiplier = 80;
            DoubleBuffered = true;
        }

        public CustomClock(bool turnedOn, Color backColor, Color onColor, Color offColor, Color circleColor)
        {
            
            BackColor = backColor;
            ArrowColor = onColor;
            OutlineColor = offColor;
            MainColor = circleColor;
        }

        public void Draw(object sender, PaintEventArgs e)
        {
            RotationAngle+=0.1;
            UpdateArrows(e.Graphics);
        }
        public void UpdateArrows(Graphics g)
        {
            g.FillEllipse(new SolidBrush(OutlineColor), new Rectangle(0, 0, Width, Height));
            g.FillEllipse(new SolidBrush(MainColor), new Rectangle(15, 15, Width - 30, Height - 30));
            g.FillRectangle(new SolidBrush(ArrowColor), new Rectangle(Width / 2, Height / 2, Width / Multiplier, Height - 10));

            g.TranslateTransform(Width / 2, Height / 2);
            g.RotateTransform((float)RotationAngle);
            g.FillRegion(new SolidBrush(ArrowColor), new Region(new Rectangle(0,0,10,300)));
        }
    }
}
