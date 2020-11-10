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
    public partial class Form11 : Form
    {
        DataTable data;
        public Form11(string date)
        {
            InitializeComponent();
            LoadDataGrid(date);
        }
        public void LoadDataGrid(string date)
        {
            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlDataAdapter sqlda = new MySqlDataAdapter("SELECT `bill_number` AS 'BILL NUMBER', `arrear` AS 'ARREARS( Rs: )', `full_amount` AS 'FULL AMOUNT PER ORDER( Rs: )', `full_Profits` AS 'FULL PROFIT PER ORDER( Rs: )' FROM `bill_details` WHERE Date ='"+date+"'", conn);
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

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date1 = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlDataAdapter sqlda = new MySqlDataAdapter("SELECT `bill_number` AS 'BILL NUMBER', `arrear` AS 'ARREARS( Rs: )', `full_amount` AS 'FULL AMOUNT PER ORDER( Rs: )', `full_Profits` AS 'FULL PROFIT PER ORDER( Rs: )' FROM `bill_details` WHERE Date ='" + date1 + "'", conn);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string bill_number;
            bill_number = textBox1.Text;
            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlDataAdapter sqlda = new MySqlDataAdapter("SELECT `Item_name` AS 'ITEM NUMBER', `QTY` AS 'QUANTITY',`Price` AS 'PRICE',`Wholesale or Retail` AS 'WHOLESALE OR RETAIL' FROM order_set,stock_details WHERE order_set.Item_Number = stock_details.Item_number AND order_set.Bill_No = '" + bill_number + "'", conn);
            data = new DataTable();
            sqlda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
