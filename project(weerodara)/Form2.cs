using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_weerodara_
{
    public partial class Form2 : Form
    {
        string Date;
        public Form2( string UserType,string user_Name, string First_Name, string Last_Name)
        {
            InitializeComponent();
            Date = DateTime.Now.ToString("MM/dd/yyy");
            label1.Text = Date;
            label4.Text = "WELCOME " + First_Name+" "+ Last_Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form3 F3 = new Form3();
            F3.TopLevel = false;
            panel2.Controls.Add(F3);
            F3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form4 F4 = new Form4();
            F4.TopLevel = false;
            panel2.Controls.Add(F4);
            F4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form5 F5 = new Form5();
            F5.TopLevel = false;
            panel2.Controls.Add(F5);
            F5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form9 F4 = new Form9();
            F4.TopLevel = false;
            panel2.Controls.Add(F4);
            F4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 F2 = new Form1();
            this.Hide();
            F2.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form7 F6 = new Form7(Date);
            F6.TopLevel = false;
            panel2.Controls.Add(F6);
            F6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form8 F6 = new Form8();
            F6.TopLevel = false;
            panel2.Controls.Add(F6);
            F6.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form10 F6 = new Form10(Date);
            F6.TopLevel = false;
            panel2.Controls.Add(F6);
            F6.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form11 F6 = new Form11(Date);
            F6.TopLevel = false;
            panel2.Controls.Add(F6);
            F6.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form12 F6 = new Form12();
            F6.TopLevel = false;
            panel2.Controls.Add(F6);
            F6.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Form13 F6 = new Form13();
            F6.TopLevel = false;
            panel2.Controls.Add(F6);
            F6.Show();
        }
    }
}
