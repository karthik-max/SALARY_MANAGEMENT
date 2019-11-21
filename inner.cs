using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salary_management_final
{
    public partial class inner : Form
    {
        String emp_id;
        String prvg,Username;
        public inner(String prv,String id)
        {
            InitializeComponent();
            prvg = prv;
            Username = id;
          
            if (prv.Equals("user"))
            {
                button1.Enabled = false;
                button1.Visible = false;
                button5.Enabled = false;
                button5.Visible = false;
                button2.Enabled = false;
                button2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form edit  = new edit(this);
            edit.TopLevel = false;
            edit.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(edit);
            edit.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            homepage hp = new homepage();
            hp.Show();
        }

        private void inner_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form payment = new payment();
            payment.TopLevel = false;
            payment.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(payment);
            payment.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String query = "select empl_id from login where username='"+Username+"';";
            emp_id="no_emp";
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password=root; database=salary_management");
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query,con);         
            MySqlDataReader dr= cmd.ExecuteReader();
            while (dr.Read())
            {
                emp_id = dr["empl_id"].ToString();   
            }
          
           
            Form view1  = new view(emp_id);
            view1.TopLevel = false;
            view1.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Clear();
            this.flowLayoutPanel2.Controls.Add(view1);
            view1.Show();
            con.Close();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "select e.emp_id,e.emp_name,e.phone,ss.net_amount,ss.deductions,ss.remaining_sal,p.status from employee e,salary_struct ss,payment p where e.emp_id=ss.emp_id and e.emp_id=p.emp_id";

            MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password=root; database=salary_management");
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;          
            cmd.ExecuteNonQuery();
            con.Close();
            

            Form generate= new generate();
            generate.TopLevel = false;
            generate.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Clear();
            this.flowLayoutPanel2.Controls.Add(generate);
            generate.Show();     
        }
    }
}
