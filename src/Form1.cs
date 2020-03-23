using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace src
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Clear();
            }
            
            display.Text = display.Text + "1";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Clear();
            }
            display.Text = display.Text + "7";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void display_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Clear();
            }
            
            display.Text = display.Text + "8";
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Clear();
            }
           
            display.Text = display.Text + "0";
        }

        private void btn_dot_Click(object sender, EventArgs e)
        {
           
            
            display.Text = display.Text + ".";
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Clear();
            }
            
            display.Text = display.Text + "3";
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Clear();
            }
            
            display.Text = display.Text + "2";
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Clear();
            }
            
            display.Text = display.Text + "6";
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Clear();
            }
            
            display.Text = display.Text + "5";
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Clear();
            }
            
            display.Text = display.Text + "4";
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            if (display.Text == "0")
            {
                display.Clear();
            }
            
            display.Text = display.Text + "9";
        }

        private void btn_ac_Click(object sender, EventArgs e)
        {
            display.Clear();
            display.Text = "0";
        }
    }
}
