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

        public int Rotate = 0;
        public CustomClock()
        {
            this.Paint += Draw;
            

            ArrowColor = Color.Black;
            OutlineColor = Color.Black;
            MainColor = Color.LightGray;

            Multiplier = 80;   
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
            var a = this.CreateGraphics();

            a.FillEllipse(new SolidBrush(OutlineColor), new Rectangle(0,0, Width, Height));
            a.FillEllipse(new SolidBrush(MainColor), new Rectangle(15, 15, Width-30, Height-30));
            a.FillRectangle(new SolidBrush(ArrowColor), new Rectangle(Width / 2, Height / 2, Width / Multiplier, Height - 10));

           //a.TranslateTransform(200, 0);
            a.RotateTransform(Rotate);
           
            //a.
            a.FillRegion(new SolidBrush(ArrowColor), new Region(new Rectangle(Width / 2, Height / 2, Width / Multiplier, Height - 10)));

           
        }
    }
}
