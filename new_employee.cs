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
    public partial class new_employee : Form
    {
        
        public new_employee()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String c="",id;
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password=root; database=salary_management");
            con.Open();
            
            String selected = department.GetItemText(department.SelectedItem);
            String did="d01"; 
            switch(selected)
            {
                case  "Computer Science" : did = "d01";
                    break;

                case "Mechanical": did = "d02";
                    break;

                case "Civil": did = "d03";
                    break;

                case "Electronics": did = "d04";
                    break;

                case "Information Science" : did = "d05"; break;

            }
            String q = "select count(*) as num from employee;";

            MySqlCommand cd = new MySqlCommand(q,con);
            MySqlDataReader mySqlDataReader = cd.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                c = mySqlDataReader["num"].ToString();
            }

            con.Close();
            int x = (int.Parse(c) + 1);
            
              id = "emp" + x ;
            String query= "insert into employee values('"+id+"','"+employee_name.Text + "','" +city.Text+ "','" + phone.Text + "','" +did+"','" + designation.Text + "','"+textBox1.Text+"')";          
            try
            {

                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                con.Close();
                Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show(id);
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(phone.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                phone.Text = phone.Text.Remove(phone.Text.Length - 1);
            }
        }

        private void department_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void new_employee_Load(object sender, EventArgs e)
        {

        }

        private void employee_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void employee_name_TextChanged(object sender, EventArgs e)
        {

            if ((System.Text.RegularExpressions.Regex.IsMatch(employee_name.Text, "[^A-Z][^a-z]"))) 
            {
                MessageBox.Show("Please enter only alphabets.");
                employee_name.Text = employee_name.Text.Remove(employee_name.Text.Length - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            salary1 s = new salary1();
            s.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void designation_TextChanged(object sender, EventArgs e)
        {
            if ((System.Text.RegularExpressions.Regex.IsMatch(designation.Text, "[^A-Z][^a-z][^-]")))
            {
                MessageBox.Show("Please enter only alphabets.");
                designation.Text = designation.Text.Remove(designation.Text.Length - 1);
            }
        }

        private void city_TextChanged(object sender, EventArgs e)
        {
            if ((System.Text.RegularExpressions.Regex.IsMatch(city.Text, "[^A-Z][^a-z]")))
            {
                MessageBox.Show("Please enter only alphabets.");
                city.Text = city.Text.Remove(city.Text.Length - 1);
            }
        }
    }
}
