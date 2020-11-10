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
    public partial class Form5 : Form
    {
        DataTable data;
        int Units;
        string item_no;
        public Form5()
        {
            InitializeComponent();
            LoadDataGrid();
            label7.Visible = false;
            AutoCompitTexbox();
        }
        void AutoCompitTexbox()
        {
            textBox7.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox7.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection Coll = new AutoCompleteStringCollection();

            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlCommand com2 = new MySqlCommand("SELECT * FROM `stock_details`", conn);
            MySqlDataReader dr2 = com2.ExecuteReader();
            while(dr2.Read())
            {
                string collection;
                collection = dr2.GetString("Item_name");
                Coll.Add(collection);
            }
            textBox7.AutoCompleteCustomSource = Coll;

        }
        public void LoadDataGrid()
        {
            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlDataAdapter sqlda = new MySqlDataAdapter("SELECT `Item_number` AS 'Item Number', `Item_name` AS 'Item Name', `Number_Of_Units` AS 'Number Of Units', `W_Price` AS 'Wholesale Price (Rs:)', `R_Price` AS 'Retail Price (Rs:)' FROM `Stock_Details`", conn);
            data = new DataTable();
            sqlda.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        void ClearText2()
        {
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            label7.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            label7.Visible = false;
        }

        public void clearText()
        {
            textBox6.Text = "";
            textBox9.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        public int validationForm()
        {
            if (textBox9.Text != "" && textBox6.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                return 1;
            }
            MessageBox.Show("Fill the requerd filds");
            return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (validationForm() == 1)
            {
                string con = "server=localhost;user id=root;database=weerodara";
                MySqlConnection conn = new MySqlConnection(con);
                conn.Open();
                string add = "INSERT INTO `Stock_Details`(  `Item_name`, `Unit_Cost`, `Number_Of_Units`, `W_Price`, `R_Price`) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox9.Text + "','" + textBox6.Text + "')";
                MySqlCommand camadd = new MySqlCommand(add, conn);
                MySqlDataReader mr;
                mr = camadd.ExecuteReader();
                MessageBox.Show("New Iteam Added");
                LoadDataGrid();
                clearText();
                AutoCompitTexbox();
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        void LoadText()
        {
            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlCommand com2 = new MySqlCommand("SELECT * FROM `stock_details` WHERE `Item_name` = '" + textBox7.Text + "'", conn);
            MySqlDataReader dr2 = com2.ExecuteReader();
            if (dr2.Read())
            {
                textBox8.Text = dr2["Unit_Cost"].ToString();
                textBox11.Text = dr2["W_Price"].ToString();
                textBox10.Text = dr2["R_Price"].ToString();
                Units = Int32.Parse(dr2["Number_Of_Units"].ToString());
                label7.Text = Units.ToString();
                item_no = dr2["Item_number"].ToString();
                label7.Visible = true;
               
            }
            else
                MessageBox.Show("No Record Found");

            conn.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoadText();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearText2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int N_Units;
            int.TryParse(textBox5.Text, out N_Units);
            if (textBox8.Text != "" && textBox7.Text != "")
            {
                Units = Units + N_Units;

                string con = "server=localhost;user id=root;database=weerodara";
                MySqlConnection conn = new MySqlConnection(con);
                conn.Open();
                string add = "UPDATE `stock_details` SET `Unit_Cost`='" + textBox8.Text + "',`Number_Of_Units`='" + Units.ToString() + "' WHERE `Item_number`='" + item_no + "'";
                MySqlCommand camadd = new MySqlCommand(add, conn);
                MySqlDataReader mr;
                mr = camadd.ExecuteReader();
                MessageBox.Show("row update");
                LoadDataGrid();
                AutoCompitTexbox();
                ClearText2();
                conn.Close();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int N_Units;
            int.TryParse(textBox5.Text, out N_Units);
            if (textBox8.Text != "" && textBox7.Text != "")
            {
                Units = Units + N_Units;

                string con = "server=localhost;user id=root;database=weerodara";
                MySqlConnection conn = new MySqlConnection(con);
                conn.Open();
                string add = "DELETE FROM `stock_details` WHERE `Item_number`='" + item_no + "'";
                MySqlCommand camadd = new MySqlCommand(add, conn);
                MySqlDataReader mr;
                mr = camadd.ExecuteReader();
                LoadDataGrid();
                ClearText2();
                AutoCompitTexbox();
                conn.Close();
            }
        }
    }
}
