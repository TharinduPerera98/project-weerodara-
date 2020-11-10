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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Visible = false;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM `staff_details` WHERE `NIC_Number` = '"+textBox1.Text+ "' AND `Password` = '" + textBox2.Text + "'";
            string con = "server=localhost;user id=root;database=weerodara";
            MySqlConnection conn = new MySqlConnection(con);
            conn.Open();
            MySqlCommand com2 = new MySqlCommand(sql, conn);
            MySqlDataReader dr2 = com2.ExecuteReader();
            if (dr2.Read())
            {
                Form2 F2 = new Form2(dr2["User_Type"].ToString(),textBox1.Text,dr2["F_Name"].ToString(), dr2["L_Name"].ToString());
                this.Hide();
                F2.ShowDialog();
                this.Close();

            }
            else
            {
                label4.Visible = true;
                this.label4.Text = "Invalid user name or password";
            }

        }
    }
}
