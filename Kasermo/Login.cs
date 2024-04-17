using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kasermo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Class2 function = new Class2();
        public void login()
        {
            string Mysqlcon = "server=localhost;user=root;database=db-kasermo;password=;";
            MySqlConnection mySqlConnection = new MySqlConnection(Mysqlcon);

            mySqlConnection.Open();
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * from user where username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'", mySqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Class1.typeuser = dr["role"].ToString();
                    Class2.id_user = dr["id"].ToString();

                    if (Class1.typeuser == "admin")
                    {
                        MessageBox.Show("Anda login sebagai Admin", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        function.command("insert into log(id_user, aktivity, created_at) values ('" + Class2.id_user + "', 'Login',NOW() )");

                        this.Hide();
                        new Admin().Show();
                    }
                    else if (Class1.typeuser == "kasir")
                    {
                        MessageBox.Show("Anda Login sebagai kasir", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        function.command("insert into log(id_user, aktivity, created_at) values ('" + Class2.id_user + "', 'Login',NOW() )");

                        this.Hide();
                        new Kasir().Show();
                    }
                    else if (Class1.typeuser == "owner")
                    {
                        MessageBox.Show("Anda Login sebagai owner", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        new owner().Show();
                    }
                    else
                    {
                        MessageBox.Show("akun Tidak di temukan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("username/password salah", "perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void buttonMasuk_Click_1(object sender, EventArgs e)
        {
            login();
        }
    }
}
