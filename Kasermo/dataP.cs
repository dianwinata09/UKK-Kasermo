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
    public partial class dataP : Form
    {
        public dataP()
        {
            InitializeComponent();
        }
        Class2 p = new Class2();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataP_Load(object sender, EventArgs e)
        {
            p.showData("select * produk", dataGridView1);
        }
    }
}
