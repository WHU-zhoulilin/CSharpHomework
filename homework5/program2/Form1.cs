using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Graphics graphics;
       
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        double k = 0.5;
        int color = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
            {
                graphics = this.CreateGraphics();
            }
            try
            {
                th1=Convert.ToDouble(numericUpDown4.Text) * Math.PI / 180;
                th2 = Convert.ToDouble(numericUpDown5.Text) * Math.PI / 180;
                per1 = Convert.ToDouble(numericUpDown3.Text);
                per2 = Convert.ToDouble(numericUpDown2.Text);
                k = Convert.ToDouble(numericUpDown1.Text);
            }
            catch
            {
                MessageBox.Show("你的输入有误！");
            }
            DrawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }
        void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
            {
                return;
            }
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + leng * k * Math.Cos(th);
            double y2 = y0 + leng * k * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            switch(color)
            {
                case 0:
                    graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 1:
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case 2:
                    graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graphics.Clear(this.BackColor);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "黑色")
            {
                color = 0;
            }
            else if (comboBox1.SelectedItem.ToString() == "蓝色")
            {
                color = 1;
            }
            else
            {
                color = 2;
            }
        }
    }
}
