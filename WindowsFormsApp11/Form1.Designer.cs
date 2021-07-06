
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Name = "Form1";
            this.Text = "ClockApp";
            this.ResumeLayout(false);
            //this.Paint += Form1_Paint;

            
            this.clock = new CustomClock();
            this.clock.Size = new Size(700, 700);
            this.clock.Location = new Point(150,150);


            Controls.Add(this.clock);
            DoubleBuffered = true;
           
        }

        private void Test2(Graphics g)
        {
            g.TranslateTransform(Width / 2, Height / 2);
            g.RotateTransform(Rotate);
            g.FillRegion(new SolidBrush(Color.Black), new Region(new Rectangle(0, 0, 10, 300)));
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
             Test2(e.Graphics);

        }
        int Rotate = 0;
       

        CustomClock clock;
        
        #endregion
    }
}

