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
    public partial class Form13 : Form
    {
        DataTable data;
        public Form13()
        {
            InitializeComponent();
            AutoCompitTexbox2();
            label6.Visible = false;
        }
        void LoadText()
        {
            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlCommand com2 = new MySqlCommand("SELECT * FROM `employee_details` WHERE `NIC_Number` = '" + textBox2.Text + "'", conn);
            MySqlDataReader dr2 = com2.ExecuteReader();
            if (dr2.Read())
            {
                label6.Text = dr2["F_Name"].ToString() + " " + dr2["L_Name"].ToString();
            }
            else
            {
                MessageBox.Show("This " + textBox2.Text + " NIC nummber not found");
            }
        }
        void AutoCompitTexbox2()
        {
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection Coll = new AutoCompleteStringCollection();

            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlCommand com2 = new MySqlCommand("SELECT * FROM `employee_details`", conn);
            MySqlDataReader dr2 = com2.ExecuteReader();
            while (dr2.Read())
            {
                string collection;
                collection = dr2.GetString("NIC_Number");
                Coll.Add(collection);
            }
            textBox2.AutoCompleteCustomSource = Coll;
            textBox1.AutoCompleteCustomSource = Coll;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                string date1 = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                string con = "server=localhost;user id=root;database=weerodara";
                MySqlConnection conn = new MySqlConnection(con);
                conn.Open();
                string add = "INSERT INTO `payment`(`NIC_Number`, `Date`, `Amount`) VALUES ('" + textBox2.Text + "','" + date1 + "','" + textBox3.Text + "')";
                MySqlCommand camadd = new MySqlCommand(add, conn);
                MySqlDataReader mr;
                mr = camadd.ExecuteReader();
                MessageBox.Show("Rows infected");
                ClearForm();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please fill the requard filds");
            }
            
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            label6.Visible = true;
            if (e.KeyCode == Keys.Enter)
            {
                LoadText();
            }
        }
        void ClearForm()
        {
            textBox2.Text = "";
            label6.Text = "";
            textBox3.Text = "";
            dataGridView2.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string NIC_number;
            NIC_number = textBox1.Text;
            if(NIC_number!="")
            {
                string date1 = dateTimePicker2.Value.ToString("MM");
                string date2 = dateTimePicker2.Value.ToString("yyyy");
                string search_date = date1 + "/%%/" + date2;
                string con = "server=localhost;user id=root;database=weerodara";
                MySqlConnection conn = new MySqlConnection(con);
                conn.Open();
                MySqlDataAdapter sqlda = new MySqlDataAdapter("SELECT employee_details.NIC_Number AS 'NIC NUMBER', F_Name AS 'FIRST NAME',L_Name AS 'LAST NAME',Date AS 'DATE' ,Amount AS 'AMOUNT' FROM payment,employee_details WHERE payment.NIC_Number=employee_details.NIC_Number AND employee_details.NIC_Number='" + NIC_number + "'  AND payment.Date LIKE '" + search_date + "'", conn);
                data = new DataTable();
                sqlda.Fill(data);
                dataGridView2.DataSource = data;
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                dataGridView2.BackgroundColor = Color.White;

                dataGridView2.EnableHeadersVisualStyles = false;
                dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }
            else
            {
                MessageBox.Show("Please enter the NIC number");
            }
        }
    }
}
