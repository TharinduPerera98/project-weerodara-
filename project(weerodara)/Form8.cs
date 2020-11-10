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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        void dataclear()
        {
            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox5.Text != "" && textBox6.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                string con = "server=localhost;user id=root;database=weerodara";
                string date1 = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                string date2 = dateTimePicker2.Value.ToString("MM/dd/yyyy");
                MySqlConnection conn = new MySqlConnection(con);
                conn.Open();
                string add = "INSERT INTO `cheque_details`(`cheque_no`, `bank_name`, `customer`, `cheque_type`, `cheque_amount`, `cashing_date`, `issued_date`) VALUES ('" + textBox2.Text + "','" +comboBox1.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "','" + textBox6.Text + "','" + date1 + "','" + date2 + "')";
                MySqlCommand camadd = new MySqlCommand(add, conn);
                MySqlDataReader mr;
                mr = camadd.ExecuteReader();
                MessageBox.Show("Rows infected");
                dataclear();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please fill the requerd fildes");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataclear();
        }
    }
}
