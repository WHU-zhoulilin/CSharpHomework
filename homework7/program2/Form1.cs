using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace program2
{
    public partial class Form1 : Form
    {
       
        static program1.OrderService orderService = new program1.OrderService();
        public static BindingList<program1.Order> orderlist = new BindingList<program1.Order>(orderService.OrderList);
        public static program1.Order SelectedOrder;
        public Form1()
        {
            InitializeComponent();
            program1.Goods.InitGoods();
            this.orderBindingSource.DataSource = orderlist;
            this.timer1.Enabled = true;
            
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
           
            form2.Visible = true;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                if (MessageBox.Show("确定删除?", "删除订单", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    orderlist.RemoveAt(this.dataGridView1.CurrentRow.Index);
                    
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                SelectedOrder = orderlist[this.dataGridView1.CurrentRow.Index];
                if (SelectedOrder != null)
                {
                    Form3 form3 = new Form3();
                    form3.Visible = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if(radioButton1.Checked)
            {
                var result = orderlist.Where(order =>
                   order.orderDetails.Customer.Name==textBox1.Text    
               );
                this.orderBindingSource.DataSource  = new List<program1.Order>(result.ToList<program1.Order>());
            }
            else if(radioButton2.Checked)
            {
                var result = orderlist.Where(order =>
                    order.orderDetails.goodslist.Where(d => d.Name == textBox2.Text)
                    .Count() > 0
                );
                this.orderBindingSource.DataSource = new BindingList<program1.Order>(result.ToList<program1.Order>());
            }
            else
            {
                try
                {
                    var result = orderlist.Where(order => order.Ordernumber == Convert.ToInt32(textBox3.Text));
                    this.dataGridView1.DataSource = new BindingList<program1.Order>(result.ToList<program1.Order>());
                }
                catch
                {
                    MessageBox.Show("你的输入有误，请检查!");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = orderlist;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            program1.OrderService orderService = new program1.OrderService();
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                orderService.XmlSerializeExport(fileName,orderlist.ToList<program1.Order>());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            program1.OrderService orderService = new program1.OrderService();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                orderService.XmlSerializeImport(fileName);
                List<program1.Order> templist = orderService.XmlSerializeImport(fileName);
                foreach(program1.Order order in templist)
                {
                    orderlist.Add(order);
                    program1.Order.ordernumber++;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load(@".\order1.xsl");
            trans.Transform(@".\order1.xml", "out.html");
        }
    }
}
