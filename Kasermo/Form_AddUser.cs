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
    public partial class Form_AddUser : Form
    {
        public Form_AddUser()
        {
            InitializeComponent();
        }
        Class2 function = new Class2();
        void clear()
        {
            namatxt.Text = string.Empty;
            usernametxt.Text = string.Empty;
            passwordtxt.Text = string.Empty;
            idtxt.Text = string.Empty;
            roletxt.Text = string.Empty;
            function.showDataU("select * user", dataGridView1);
        }

        void data()
        {
            roletxt.Items.Add("admin");
            roletxt.Items.Add("kasir");
            roletxt.Items.Add("owner");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AddProduct addP = new Form_AddProduct();
            addP.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login Login = new Login();
            Login.Show();
        }

        private void Form_AddUser_Load(object sender, EventArgs e)
        {
            function.showDataU("select * user", dataGridView1);
            data();
            tambah.Enabled = true;
            edit.Enabled = false;
            hapus.Enabled = false;
            if (edit.Enabled == false && hapus.Enabled == false && tambah.Enabled == true)
            {
                edit.BackColor = Color.Gray;
                hapus.BackColor = Color.Gray;
                tambah.BackColor = Color.White;
            }
        }

        private void tambah_Click(object sender, EventArgs e)
        {
            if (namatxt.Text == string.Empty || usernametxt.Text == string.Empty || passwordtxt.Text == string.Empty || roletxt.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
               
                DialogResult d;
                d = MessageBox.Show("Apakah anda yakin?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    function.command("insert into user( nama, username, password, role) values ('" + namatxt.Text + "', '" + usernametxt.Text + "', '" + passwordtxt.Text + "', '" + roletxt.Text + "')");
                    clear();
                    function.command("insert into log(id_user, aktivity, created_at) values ('" + Class2.id_user + "', 'Admin Melakukan Penambahan User',NOW() )");
                    tambah.Enabled = true;
                    if (tambah.Enabled == true)
                    {
                        tambah.BackColor = Color.White;
                    }
                    MessageBox.Show("Data Berhasil di Tambahkan");
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];

            namatxt.Text = dr.Cells[3].Value.ToString();
            usernametxt.Text = dr.Cells[1].Value.ToString();
            passwordtxt.Text = dr.Cells[2].Value.ToString();
            roletxt.Text = dr.Cells[4].Value.ToString();
            idtxt.Text = dr.Cells[0].Value.ToString();
            tambah.Enabled = false;
            edit.Enabled = true;
            hapus.Enabled = true;
            if(tambah.Enabled == false && edit.Enabled == true && hapus.Enabled == true)
            {
                tambah.BackColor = Color.Gray;
                edit.BackColor = Color.White;
                hapus.BackColor = Color.White;
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (namatxt.Text == string.Empty || usernametxt.Text == string.Empty || passwordtxt.Text == string.Empty || roletxt.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Apakah anda yakin?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    function.command("update user set nama = '" + namatxt.Text + "', username = '" + usernametxt.Text + "', password = '" + passwordtxt.Text + "',role = '" + roletxt.Text + "', update_at = NOW() where id = '" + idtxt.Text + "'");
                    clear();
                    function.command("insert into log(id_user, aktivity, created_at) values ('" + Class2.id_user + "', 'Admin Melakukan Pengeditan User',NOW() )");
                    tambah.Enabled = true;
                    edit.Enabled = false;
                    hapus.Enabled = false;
                    if (edit.Enabled == false && hapus.Enabled == false && tambah.Enabled == true)
                    {
                        edit.BackColor = Color.Gray;
                        hapus.BackColor = Color.Gray;
                        tambah.BackColor = Color.White;
                    }
                }
            }
        }

        private void keluar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin admin = new Admin();
            admin.Show();
        }

        private void hapus_Click(object sender, EventArgs e)
        {
            if (namatxt.Text == string.Empty || usernametxt.Text == string.Empty || passwordtxt.Text == string.Empty || roletxt.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Apakah anda yakin?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    function.command("delete from user where id = '" + idtxt.Text + "'");
                    clear();
                    function.command("insert into log(id_user, aktivity, created_at) values ('" + Class2.id_user + "', 'Admin Melakukan Penghapusan/Non-akfifkan User',NOW() )");
                    tambah.Enabled = true;
                    edit.Enabled = false;
                    hapus.Enabled = false;
                    if (edit.Enabled == false && hapus.Enabled == false && tambah.Enabled == true)
                    {
                        edit.BackColor = Color.Gray;
                        hapus.BackColor = Color.Gray;
                        tambah.BackColor = Color.White;
                    }
                }
                
                
            }

        }

        private void produk_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form_AddProduct().Show();
        }

        private void idtxt_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=;database=db-kasermo");

            conn.Open();
            if (idtxt.Text != "")
            {
                MySqlCommand cmd = new MySqlCommand("SELECT username, password, nama, role FROM user WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(idtxt.Text));
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    namatxt.Text = reader.GetString(2);
                    usernametxt.Text = reader.GetValue(0).ToString();
                    passwordtxt.Text = reader.GetValue(1).ToString();
                    roletxt.Text = reader.GetValue(3).ToString();

                }
                conn.Close();

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            clear();
            tambah.Enabled = true;
            edit.Enabled = false;
            hapus.Enabled = false;
            if (edit.Enabled == false && hapus.Enabled == false && tambah.Enabled == true)
            {
                edit.BackColor = Color.Gray;
                hapus.BackColor = Color.Gray;
                tambah.BackColor = Color.White;
            }
        }
    }
}
