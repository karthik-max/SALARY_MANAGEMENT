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
    public partial class edit : Form
    {
        Form f2;
        public edit(Form f)
        {
            InitializeComponent();
            f2 = f;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edit ed = new edit(this);
            ed.Hide();
            new_employee emp = new new_employee();
            emp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            edit ed = new edit(this);
            ed.Hide();
            delete d = new delete();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            edit ed = new edit(this);
            ed.Hide();
            update u = new update();
            u.Show();
        }

        private void edit_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            salary1 s = new salary1();
            s.Show();
        }
    }
}
