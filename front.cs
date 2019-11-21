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
    public partial class front : Form
    {
        //Panel p = new Panel();
        public front()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            register r = new register();
            r.TopLevel = false;
            panel1.Controls.Add(r);
            r.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            login l = new login();
            l.TopLevel = false;
            panel1.Controls.Add(l);
            l.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void front_Load(object sender, EventArgs e)
        {

        }
    }
    public static void Main()
    {

    }
}
