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
    public partial class Form4 : Form
    {
        DataTable data;
        public Form4()
        {
            InitializeComponent();
            LoadDataGrid();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        public void clearText()
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadDataGrid()
        {
            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlDataAdapter sqlda = new MySqlDataAdapter("SELECT `cheque_no` AS 'Cheque Number', `bank_name` AS 'Bank Name', `customer` AS 'Receiver Name', `cheque_amount` AS 'Amount (Rs:)', `cashing_date` AS 'Cashing Date', `issued_date` AS 'Issued Date' FROM `cheque_details` WHERE cheque_type ='Received Cheque'", conn);
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
