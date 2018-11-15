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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dataGridView2.CurrentCell.Value != null)
                {
                    comboBox1.Text = dataGridView2.CurrentCell.Value.ToString();  //对combobox赋值 
                }

                Rectangle R = dataGridView2.GetCellDisplayRectangle(
                                    dataGridView2.CurrentCell.ColumnIndex,
                                    dataGridView2.CurrentCell.RowIndex, false);

                comboBox1.Location = new Point(dataGridView2.Location.X + R.X,
                    dataGridView2.Location.Y + R.Y);

                comboBox1.Width = R.Width;
                comboBox1.Height = R.Height;
                comboBox1.Visible = true;
            }
            else
            {
                comboBox1.Visible = false;

            }

            if (e.ColumnIndex == 1)
            {
                if (dataGridView2.CurrentCell.Value != null)
                {
                    numericUpDown1.Value = (int)dataGridView2.CurrentCell.Value;  //对combobox赋值 
                }

                Rectangle R = dataGridView2.GetCellDisplayRectangle(
                                    dataGridView2.CurrentCell.ColumnIndex,
                                    dataGridView2.CurrentCell.RowIndex, false);

                numericUpDown1.Location = new Point(dataGridView2.Location.X + R.X,
                    dataGridView2.Location.Y + R.Y);

                numericUpDown1.Width = R.Width;
                numericUpDown1.Height = R.Height;
                numericUpDown1.Visible = true;
            }
            else
            {
                numericUpDown1.Visible = false;
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell.Value = comboBox2.Text;
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            comboBox2.Visible = false;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell.Value = comboBox1.Text;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell.Value = numericUpDown1.Value;
        }
    }
}
