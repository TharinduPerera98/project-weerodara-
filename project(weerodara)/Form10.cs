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
    public partial class Form10 : Form
    {
        float Units_Cost, total, B_price, profit, change,f_profit;
        string item_no;
        int New_QTY;
        int Number1, Number2;
        Boolean Check = false, Stock = false, bill = false;

        private void button1_Click(object sender, EventArgs e)
        {
            int n, QTY;
            float price = 0;
            if (textBox3.Text != "" && textBox2.Text != "")
            {
                int.TryParse(textBox3.Text, out QTY);
                price = Units_Cost * QTY;
                profit = profit * QTY;
                if (Check == false)
                {
                    newValue();
                }
                if (Stock == false)
                {
                    f_profit += profit;
                    total += price;
                    n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = textBox2.Text;
                    dataGridView1.Rows[n].Cells[1].Value = label6.Text;
                    dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;
                    dataGridView1.Rows[n].Cells[3].Value = price.ToString();
                    string con = "server=localhost;user id=root;database=weerodara";
                    MySqlConnection conn = new MySqlConnection(con);
                    conn.Open();
                    string add1 = "INSERT INTO `Order_SET`( `Bill_No`, `Item_Number`, `QTY`, `Price`, `Date`, `Wholesale or Retail`, `Profits`) VALUES ('" + Bill_ID.ToString() + "','" + item_no.ToString() + "','" + textBox3.Text + "','" + price.ToString() + "','" + Bill_No1.ToString() + "', 'Wholesale', " + profit + ")";
                    MySqlCommand camadd1 = new MySqlCommand(add1, conn);
                    camadd1.ExecuteNonQuery();
                    string add = "UPDATE `stock_details` SET `Number_Of_Units`='" + New_QTY.ToString() + "' WHERE `Item_number`='" + item_no.ToString() + "'";
                    MySqlCommand camadd = new MySqlCommand(add, conn);
                    camadd.ExecuteNonQuery();
                    MessageBox.Show("Stock Table Updated & Orders Table rowa insert", "System Ditails");
                    formClear();
                    label13.Visible = true;
                    label13.Text = total.ToString();

                    conn.Close();
                }
            }
        }
        void oID()
        {
            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlCommand com2 = new MySqlCommand("SELECT* FROM bill_details ORDER BY bill_number DESC LIMIT 1", conn);
            MySqlDataReader dr2 = com2.ExecuteReader();
            if (dr2.Read())
            {
                pri_ID = dr2["bill_number"].ToString();
                Bill_ID = Int32.Parse(pri_ID);
                Bill_ID += 1;
            }
            else
            {
                Bill_ID = 1;
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadText();
            }
        }

        private void textBox3_ImeModeChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                newValue();
                Check = true;
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        string Bill_No1,pri_ID;

        void calculate()
        {
            label9.Visible = true;
            float cash = float.Parse(textBox1.Text);
            change = cash - total;
            label9.Text = change.ToString();

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calculate();
                Check = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calculate();
            if(change<0)
            {
                string con = "server=localhost;user id=root;database=weerodara";
                MySqlConnection conn = new MySqlConnection(con);
                conn.Open();
                string add = "INSERT INTO `bill_details`(`bill_number`, `arrear`, `Date`, `full_amount`, `full_Profits`) VALUES ('" + Bill_ID + "','" + change + "','" + Bill_No1.ToString() + "','" + total+"','"+ f_profit + "')";
                MySqlCommand camadd = new MySqlCommand(add, conn);
                camadd.ExecuteNonQuery();
                MessageBox.Show("Bill Creation successful");
                oID();
                formClear2();
            }
            else
            {
                string con = "server=localhost;user id=root;database=weerodara";
                MySqlConnection conn = new MySqlConnection(con);
                conn.Open();
                string add = "INSERT INTO `bill_details`(`bill_number`, `arrear`, `Date`, `full_amount`, `full_Profits`) VALUES ('" + Bill_ID + "','0','" + Bill_No1.ToString() + "','" + total + "','" + f_profit + "')";
                MySqlCommand camadd = new MySqlCommand(add, conn);
                camadd.ExecuteNonQuery();
                MessageBox.Show("Bill Creation successful");
                oID();
                formClear2();
            }
        }

        int Bill_ID;
        public Form10(string date)
        {
            InitializeComponent();
            AutoCompitTexbox2();
            label6.Visible = false;
            label8.Visible = false;
            label13.Visible = false;
            label9.Visible = false;
            Bill_No1 = date;
            oID();
        }
        void LoadText()
        {
            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlCommand com2 = new MySqlCommand("SELECT * FROM `stock_details` WHERE `Item_name` = '" + textBox2.Text + "'", conn);
            MySqlDataReader dr2 = com2.ExecuteReader();
            if (dr2.Read())
            {
                label8.Text = dr2["Number_Of_Units"].ToString();
                Units_Cost = float.Parse(dr2["R_Price"].ToString());
                B_price = float.Parse(dr2["Unit_Cost"].ToString());
                profit = Units_Cost - B_price;
                label6.Text = Units_Cost.ToString();
                item_no = dr2["Item_number"].ToString();
                label6.Visible = true;
                label8.Visible = true;

            }
        }
        void formClear2()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label6.Text = "";
            label8.Text = "";
            label13.Text = "";
            label9.Text = "";
            dataGridView1.Rows.Clear();
        }
        void AutoCompitTexbox2()
        {
            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection Coll = new AutoCompleteStringCollection();

            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlCommand com2 = new MySqlCommand("SELECT * FROM `stock_details`", conn);
            MySqlDataReader dr2 = com2.ExecuteReader();
            while (dr2.Read())
            {
                string collection;
                collection = dr2.GetString("Item_name");
                Coll.Add(collection);
            }
            textBox2.AutoCompleteCustomSource = Coll;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }
        void formClear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            label6.Text = "";
            label8.Text = "";
        }
        void newValue()
        {
            int.TryParse(label8.Text, out Number1);
            if (int.TryParse(textBox3.Text, out Number2))
            {
                if (Number1 >= Number2)
                {
                    New_QTY = Number1 - Number2;
                    label8.Text = (New_QTY).ToString();
                }
                else
                {
                    MessageBox.Show("No Stock Available", "Stock Details");
                    textBox3.Text = "";
                    Stock = true;
                }
            }
            else
                MessageBox.Show("Invalid Data type");
        }
    }
}
