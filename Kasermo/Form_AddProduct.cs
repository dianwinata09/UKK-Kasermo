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
    public partial class Form_AddProduct : Form
    {
        public Form_AddProduct()
        {
            InitializeComponent();
        }
        Class2 function = new Class2();

        void clear()
        {
            id.Text = string.Empty;
            nama_produk.Text = string.Empty;
            harga_produk.Text = string.Empty;
            jumlah.Text = string.Empty;
            function.showData("select * produk", dataGridView2);
        }
        


        private void Form_AddProduct_Load(object sender, EventArgs e)
        {
            function.showData("select * produk", dataGridView2);
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tambah_Click(object sender, EventArgs e)
        {
            if (nama_produk.Text == string.Empty || harga_produk.Text == string.Empty || jumlah.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Apakah anda yakin?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    function.command("insert into produk( nama_produk, harga_produk, stok) values ('" + nama_produk.Text + "', '" + harga_produk.Text + "', '" + jumlah.Text + "')");
                    clear();
                    function.command("insert into log(id_user, aktivity, created_at) values ('" + Class2.id_user + "', 'Admin Melakukan Penambahan Produk',NOW() )");
                    tambah.Enabled = true;
                    if (tambah.Enabled == true)
                    {
                        tambah.BackColor = Color.White;
                    }
                    MessageBox.Show("Data Berhasil di Tambahkan");
                }
                    
            }

        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (nama_produk.Text == string.Empty || harga_produk.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Apakah anda yakin?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    function.command("update produk set nama_produk = '" + nama_produk.Text + "', harga_produk = '" + harga_produk.Text + "', stok = '" + jumlah.Text + "', update_at = NOW() where id = '" + id.Text + "'");
                    MessageBox.Show("update berhasil");
                    clear();
                    function.command("insert into log(id_user, aktivity, created_at) values ('" + Class2.id_user + "', 'Admin Melakukan Pengeditan Produk',NOW() )");
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

        private void hapus_Click(object sender, EventArgs e)
        {
            if (nama_produk.Text == string.Empty || harga_produk.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                DialogResult d;
                d = MessageBox.Show("Apakah anda yakin?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    function.command("delete from produk where id = '" + id.Text + "'");
                    function.command("insert into log(id_user, aktivity, created_at) values ('" + Class2.id_user + "', 'Admin Melakukan Penghapusan Produk',NOW() )");
                    clear();
                    MessageBox.Show("data berhasil di hapus");
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

        private void user_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_AddUser addU = new Form_AddUser();
            addU.Show();
        }

        private void keluar_Click(object sender, EventArgs e)
        {
            function.command("insert into log(id_user, aktivity, created_at) values ('" + Class2.id_user + "', 'Logout',NOW() )");
            this.Hide();
            new Admin().Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView2.Rows[e.RowIndex];

            nama_produk.Text = dr.Cells[1].Value.ToString();
            harga_produk.Text = dr.Cells[3].Value.ToString();
            id.Text = dr.Cells[0].Value.ToString();
            jumlah.Text = dr.Cells[2].Value.ToString();
            tambah.Enabled = false;
            edit.Enabled = true;
            hapus.Enabled = true;
            if (tambah.Enabled == false && edit.Enabled == true && hapus.Enabled == true)
            {
                tambah.BackColor = Color.Gray;
                edit.BackColor = Color.White;
                hapus.BackColor = Color.White;
            }
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=;database=db-kasermo");

            conn.Open();
            if (id.Text != "")
            {
                MySqlCommand cmd = new MySqlCommand("SELECT nama_produk, harga_produk FROM produk WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(id.Text));
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    nama_produk.Text = reader.GetString(0);
                    harga_produk.Text = reader.GetValue(1).ToString();

                }
                conn.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void produk_Click(object sender, EventArgs e)
        {

        }
    }
}
