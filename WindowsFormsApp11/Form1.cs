using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        Timer timer;

        public Form1()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 10;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            clock.Rotate++;
            clock.Invalidate();
        }
    }
}
