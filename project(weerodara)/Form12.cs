using MySql.Data.MySqlClient;
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
    public partial class Form12 : Form
    {
        float salary;
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }
        public void ClearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        public int Validation()
        {
            errorProvider1.Clear();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""  && textBox5.Text != "" && textBox6.Text != "")
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("Please Select the Gender");
                    return 0;
                }
                else
                {
                    if (float.TryParse(textBox6.Text, out salary))
                    {
                        return 1;
                    }
                    else
                    {
                        errorProvider1.SetError(textBox6, "Error - Invalid Payment");
                        return 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill the requerd fildes");
                return 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Gender;
            if (radioButton1.Checked == true)
            {
                Gender = "Male";
            }
            else
            {
                Gender = "Female";
            }
            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            if (Validation() == 1)
            {
                string add = "INSERT INTO `employee_details`(`NIC_Number`, `F_Name`, `L_Name`, `Address`, `Salary`, `Gender`) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + Gender + "')";
                MySqlCommand camadd = new MySqlCommand(add, conn);
                MySqlDataReader mr;
                mr = camadd.ExecuteReader();
                MessageBox.Show("Rows infected");
                ClearForm();
                conn.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
