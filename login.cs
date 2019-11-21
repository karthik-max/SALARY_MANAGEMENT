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
    
    public partial class login : Form
    {
        MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password=root; database=salary_management");
        int i;
        Form f1;

        public login(Form f)
        {
            InitializeComponent();
            f1 = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String id = textBox2.Text;
            i = 0;
            con.Open();
            String prvg="";
            String query= "select privilege from login where username='" + textBox2.Text + "' and password='" + textBox1.Text + "'";
            MySqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandText = query;
            var result = cmd2.ExecuteScalar();
            if (result != null)
                prvg = Convert.ToString(result);



            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from login where username='" + textBox2.Text + "' and password='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            
            if (i == 0)
            {
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("Invalid");

            }
            else
            {

                
                f1.Hide();
        
                inner inn = new inner(prvg,id);
                inn.Show();

            }

            con.Close();
            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
