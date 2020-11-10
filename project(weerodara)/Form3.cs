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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        public void ClearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        public int Validation()
        {
            errorProvider1.Clear();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                if(radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("Please Select the Gender");
                    return 0;
                }
                else
                {
                    if((textBox6.Text).Equals(textBox7.Text))
                    {
                        return 1;
                    }
                    else
                    {
                        errorProvider1.SetError(textBox6, "Password not match");
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
            if(radioButton1.Checked == true)
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
            if(Validation()==1)
            {
                string add = "INSERT INTO `staff_details`(`NIC_Number`, `F_Name`, `L_Name`, `Address`, `Email_Address`, `Password`, `User_Type`, `Gender`) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','User','" + Gender + "')";
                MySqlCommand camadd = new MySqlCommand(add, conn);
                MySqlDataReader mr;
                mr = camadd.ExecuteReader();
                MessageBox.Show("Rows infected");
                ClearForm();
                conn.Close();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
