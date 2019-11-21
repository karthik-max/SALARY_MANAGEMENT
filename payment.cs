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
    public partial class payment : Form
    {
        public payment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           String q3;
            String emp_id = textBox1.Text ;
            //q1 = "select sum(amount)from payment where emp_id='" + emp_id + "';";

            //q2 = "select remaining_sal from salary_struct where emp_id='" + emp_id + "';";
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password=root; database=salary_management");
            con.Open();
            // MySqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = q1;
            //var paid_amt =cmd.ExecuteScalar();
            //MySqlCommand cm = con.CreateCommand();
            //cm.CommandType = CommandType.Text;
            //cm.CommandText = q2;
            //var salary = cm.ExecuteScalar();
            // String s = textBox3.Text;
            //int amt = int.Parse(paid_amt.ToString()) + int.Parse(s);

            //if (int.Parse(salary.ToString())==amt)
            // {
            /* String q = "select remaining_sal from salary_struct where emp_id='" + emp_id + "';";
             String p="";
             MySqlCommand cmd = new MySqlCommand(q, con);
             MySqlDataReader rd = cmd.ExecuteReader();
             while (rd.Read())
             {
                 if (rd["remaining_sal"].ToString() == "")
                 {
                     p = "unpaid";
                 }
                 else
                 {
                     p = "paid";
                 }
             }*/
            String q = "select count(*) from salary_struct where emp_id='" + emp_id + "';";
           // String p = "";
            MySqlCommand cmd = new MySqlCommand(q, con);
            MySqlDataReader rd = cmd.ExecuteReader();
            String z="";
            while (rd.Read())
            {
                z = rd["count(*)"].ToString();
            }
            con.Close();
            if (z== "0")
            {
                MessageBox.Show("insufficient details please enter the data");
            }
            else
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("enter the employee_id");
                    }
                    else
                    {
                        try
                        {

                            con.Open();
                            q3 = "insert into payment values('" + emp_id + "','" + dateTimePicker1.Text + "','paid')";
                            MySqlCommand cm1 = con.CreateCommand();
                            cm1.CommandType = CommandType.Text;
                            cm1.CommandText = q3;
                            cm1.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("amount Paid Successfully");
                        }
                        catch (MySqlException)
                        {
                            MessageBox.Show("already paid " + emp_id);
                        }
                    }
                }
            
                
           
                
           // }
          //  else
           // {
               // q3 = "insert into payment values('" + emp_id + "','" + dateTimePicker1.Text + "','" + textBox3.Text + "','unpaid')";
           // }
            

        }
    }
}
