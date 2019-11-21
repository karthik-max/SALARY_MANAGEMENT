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
    public partial class delete : Form
    {
        MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password=root; database=salary_management");
        
        public delete()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {


            con.Open();
            String prvgpass = "";
            
            String query = "select password from login where privilege='admin'";
            MySqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandText = query;
            var result = cmd2.ExecuteReader();
          

                if (result.HasRows)
                {
                    result.Read();

                    prvgpass = result.GetString(0);
                }
                result.Close();
                var eid = textBox1.Text;
                var password = textBox2.Text;
                if (password.Equals(prvgpass))
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from employee where emp_id='" + textBox1.Text + "'";

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Incorrect Admin password");
                }
                result.Close();
                con.Close();
                Close();
            MessageBox.Show(eid + " deleted successfully");
           
          
        }
    }
}
