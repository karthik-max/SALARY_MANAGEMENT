using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salary_management_final
{
    public partial class generate : Form
    {
        DataTable table = new DataTable();
        public generate()
        {
            InitializeComponent();
            using (var connection = new MySqlConnection("Data Source = localhost; Initial Catalog=salary_management; User Id= root; Password =root"))
            {
                
                String query = "select * from generate";
                connection.Open();
                var command = new MySqlCommand(query, connection);
                MySqlDataAdapter a = new MySqlDataAdapter();
                a.SelectCommand = command;
                a.Fill(table);
                BindingSource bs = new BindingSource();
                bs.DataSource = table;
                dataGridView1.DataSource = bs;
                a.Update(table);
                generate_rep();



                connection.Close();
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void generate_Load(object sender, EventArgs e)
        {
            
        }
        public void generate_rep()
        {
            //String ss = "";
            
            String s="\n";
            s += "emp_id |" + " emp_name |" + " phone_no |" + " net_amount |" + " deductions_done |" + " remaining_amount |" +"status \n";
            foreach (DataRow rows in table.Rows)
            {
                String id = rows["emp_id"].ToString();
                String name = rows["emp_name"].ToString();
                String phone_no = rows["phone"].ToString();
                String net = rows["net_amount"].ToString();
                String deduction = rows["deductions"].ToString();
                String remaining = rows["remaining_sal"].ToString();
                String status = rows["status"].ToString();
               // s += "\n";
                s +=  id + "|\t" + name + "|\t" + phone_no + "|\t" + net + "|\t" + deduction + "|\t" + remaining + "|\t" + status + "\n";
                //s += "\n";
                
            }


            System.IO.File.WriteAllText(@"D:\report\report.doc", s);
            Process.Start(@"D:\report\report.doc");
        }
    }
}
