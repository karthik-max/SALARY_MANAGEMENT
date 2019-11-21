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
    public partial class view : Form
    {
        public view(String id)  
        {
            InitializeComponent();
         
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password=root; database=salary_management");
            con.Open();
            DataTable table = new DataTable();
            String query = "select * from view_emp where emp_id='"+id+"';";
            var command = new MySqlCommand(query, con);
            MySqlDataAdapter a = new MySqlDataAdapter();
            a.SelectCommand = command;
            a.Fill(table);
            BindingSource bs = new BindingSource();
            bs.DataSource = table;
            dataGridView1.DataSource = bs;
            a.Update(table);
            con.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void view_Load(object sender, EventArgs e)
        {

        }
    }
}
