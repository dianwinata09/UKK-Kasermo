using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasermo
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        Class2 function = new Class2();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AddUser addU = new Form_AddUser();
            addU.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AddProduct addP = new Form_AddProduct();
            addP.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            function.showDataU("select * user", dataGridView1);
            function.showData("select * produk", dataGridView2);
        }
    }
}
