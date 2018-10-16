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
            Doit Do = new Doit();
            Do.Down += new Doit.EventHandler(show);
            Do.DOIT();
            


        }

        void show(object sender, chanshu e)
        {
            double x, y;
            x = Convert.ToDouble(textBox1.Text);
            y = Convert.ToDouble(textBox2.Text);
            label3.Text = ("" + (x * y));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double x, y;
            try
            {
                x = Convert.ToDouble(textBox1.Text);
                y = Convert.ToDouble(textBox2.Text);
                label3.Text = ("" + (x * y));
            }
            catch
            {
                MessageBox.Show("你的输入有误！");
            }
        }
    }
    public class Doit
    {
        public delegate void EventHandler(object sender, chanshu e);
        public event EventHandler Down;
        chanshu e = new chanshu(5);
        public void DOIT()
        {
            Down(this, e);
        }
        
    }
    public class chanshu
    {
        int e;
        public chanshu(int e)
        {
            this.e = e;
        }
    }
   
}
