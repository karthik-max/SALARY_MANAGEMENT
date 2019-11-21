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

namespace salary_management_final
{
    public partial class salary1 : Form
    {
        public salary1()
        {
            InitializeComponent();
        }


        private void payment_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
            {

            }          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            salary1 s = new salary1();

        }

        private void next_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password=root; database=salary_management");
            con.Open();
            String query = "insert into salary values ('" + textBox9.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox1.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";
            MySqlCommand cm = new MySqlCommand(query, con);
            cm.CommandType = CommandType.Text;
            cm.CommandText = query;
            cm.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("salary added successfully");
        }
    }
}
