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
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            String Emp_id = textBox1.Text;
            String newValue = textBox2.Text;
            String selected = comboBox1.GetItemText(comboBox1.SelectedItem);
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password=root; database=salary_management");
            con.Open();
            String query;
            query = "update employee set emp_address='" + newValue + "' where emp_id='" + Emp_id + "'";

            switch (selected)
            {
                case "Address":
                    query = "update employee set emp_address='"+newValue+"' where emp_id='"+Emp_id+"'" ;
                    MessageBox.Show("address updated"); break;

                case "Phone":
                    query = "update employee set phone='" + newValue + "' where emp_id='" + Emp_id + "'";
                    MessageBox.Show("Phone updated"); break;               

                case "Department":
                    query = "update employee set did='" + newValue + "' where emp_id='" + Emp_id + "'";
                    MessageBox.Show("Department updated"); break;

                case "Designation":
                    query = "update employee set designation='" + newValue + "' where emp_id='" + Emp_id + "'";
                    MessageBox.Show("Designation updated"); break;

                case "basic_salary":
                    query = "update salary set basic_pay='" + newValue + "' where emp_id='" + Emp_id + "'";
                    MessageBox.Show("basic_salary updated"); break;

                case "AGP":
                    query = "update salary set AGP='" + newValue + "' where emp_id='" + Emp_id + "'";
                    MessageBox.Show("AGP updated"); break;

                case "DA":
                    query = "update salary set DA='" + newValue + "' where emp_id='" + Emp_id + "'";
                    MessageBox.Show("DA updated"); break;

                case "HPA":
                    query = "update salary set HPA='" + newValue + "' where emp_id='" + Emp_id + "'";
                    MessageBox.Show("HPA updated"); break;

                case "other_allowances":
                    query = "update salary set other_allowance='" + newValue + "' where emp_id='" + Emp_id + "'";
                    MessageBox.Show("other_allowance updated"); break;
 
                case "EPF":
                    query = "update salary set EPF='" + newValue + "' where emp_id='" + Emp_id + "'";
                    MessageBox.Show("EPF updated"); break;

                case "PT":
                    query = "update salary set PT='" + newValue + "' where emp_id='" + Emp_id + "'";
                    MessageBox.Show("PT updated"); break;

                case "other_deductions":
                    query = "update salary set other_deductions='" + newValue + "' where emp_id='" + Emp_id + "'";
                    MessageBox.Show("other_deductions updated"); break;
            }
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
