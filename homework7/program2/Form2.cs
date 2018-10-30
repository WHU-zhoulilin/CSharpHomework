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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
         
        }

        //添加
        private void button1_Click(object sender, EventArgs e)
        {
            object obj = this.listBox1.SelectedItem;
            int i = (int)this.numericUpDown1.Value;
            
            if (obj != null&&listBox2.Items.Contains(obj))
            {
                int index = listBox2.Items.IndexOf(obj);
                this.listBox3.Items[index] = (int)this.listBox3.Items[index] + i;
            }
            else if(obj != null)
            {
                this.listBox2.Items.Add(obj);
                this.listBox3.Items.Add(i);
            }
        }

        //删除
        private void button2_Click(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection ids = this.listBox2.SelectedIndices;
            this.listBox2.BeginUpdate();
            for (int i = ids.Count - 1; i >= 0; i--)
            {
                int index = ids[i];
                this.listBox2.Items.RemoveAt(ids[i]);
                this.listBox3.Items.RemoveAt(index);

            }
            this.listBox2.EndUpdate();

        }

        //提交
        private void button3_Click(object sender, EventArgs e)
        {
            program1.Customer customer=new program1.Customer(textBox1.Text);
            program1.Goods goods;
            program1.OrderDetails orderDetails = new program1.OrderDetails(customer); 
            for(int i=0;i<listBox2.Items.Count;i++)
            {
                goods = new program1.Goods((string)listBox2.Items[i], (int)listBox3.Items[i]);
                orderDetails.AddOrderDetails(goods);
            }
            Form1.orderlist.Add(new program1.Order(orderDetails));
            
            this.Dispose();
        }
    }
    
}
