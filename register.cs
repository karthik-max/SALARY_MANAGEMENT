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
    
   
    public partial class register : Form
    {

        void show()

        {

            System.Threading.Thread.Sleep(3000);



        }
        Form f3;
        public register(Form f)
        {

            InitializeComponent();

            f3 = f;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password=root; database=salary_management");
            con.Open();
            String id,mk,emk="";
            id = textBox4.Text;
            mk = textBox5.Text;
          
            String s = "select password from employee where emp_id='" + id + "';";
            MySqlCommand cm = new MySqlCommand(s, con);
            MySqlDataReader mr = cm.ExecuteReader();
            while(mr.Read())
            {
              //  eid = mr["emp_id"].ToString();
                emk = mr["password"].ToString();
                
            }
            if (mk != emk)
            {
                MessageBox.Show("invalid master key");
            }
            else
            {
                con.Close();
                String password = textBox3.Text;
                String confirm = textBox2.Text;
                String username = textBox1.Text;
                String query = "insert into login values ('" + username + "','" + password + "','user','"+id+"')";

                if (password.Equals(confirm) && password != "" && confirm != "" && username != "")
                {
                    try
                    {
                        con.Open();
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        Close();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                        label5.Visible = true;
                    }

                }
                else
                {
                    int i = 0;
                    while (i != 3000)
                    {
                        label4.Show();
                        i++;
                    }
                    /*System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(show));

                    thread.IsBackground = true;

                    thread.Start();
                    label4.Visible = false;*/

                }
            }

          
            
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
