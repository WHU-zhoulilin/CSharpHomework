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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.label3.DataBindings.Add("Text", Form1.SelectedOrder, "Ordernumber");
            this.label4.DataBindings.Add("Text", Form1.SelectedOrder.orderDetails.Customer, "Name");
            this.dataGridView1.DataSource = Form1.SelectedOrder.orderDetails.goodslist;
            this.dataGridView2.DataSource = Form1.SelectedOrder.orderDetails.goodslist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.dataGridView2.DataSource = Form1.SelectedOrder.orderDetails.goodslist;
            
            this.Dispose();
        }
    }
}
