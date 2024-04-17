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
    public partial class OwnerPro : Form
    {
        public OwnerPro()
        {
            InitializeComponent();
        }
        Class2 f = new Class2();

        private void LoadData()
        {
            string query = "SELECT * form produk";
            f.showData(query, dataGridView1);
        }

        private void kembali_Click(object sender, EventArgs e)
        {
            this.Hide();
            new owner().Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];
        }

        private void OwnerPro_Load(object sender, EventArgs e)
        {
            f.showData("Select * from produk", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Handle the selected index change event of rolecombo
            cari.Text = string.Empty;
            dtp1.Value = DateTime.Now;
            dtp2.Value = DateTime.Now;

            // Menggunakan status filter awal
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=db-kasermo");
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    using (DataTable dt = new DataTable("log"))
                    {
                        // Query dasar
                        string baseQuery = "SELECT id, nama_produk, stok, harga_produk, created_at, update_at " + "FROM produk ";

                        // Persiapkan parameter dan kondisi WHERE
                        List<MySqlParameter> parameters = new List<MySqlParameter>();
                        string whereCondition = "";

                        // Tambahkan kondisi tanggal jika dipilih
                        if (dtp1.Value != DateTime.Now && dtp2.Value != DateTime.Now)
                        {
                            whereCondition += " created_at BETWEEN @fromdate AND @todate";
                            parameters.Add(new MySqlParameter("@fromdate", dtp1.Value.ToString("yyy-MM-dd")));
                            parameters.Add(new MySqlParameter("@todate", dtp2.Value.AddDays(1).ToString("yyyy-MM-dd"))); // Tambah 1 hari agar mencakup hingga akhir hari yang dipilih
                        }

                        // Gabungkan semua kondisi menjadi satu query
                        string fullQuery = baseQuery;
                        if (!string.IsNullOrEmpty(whereCondition))
                            fullQuery += " WHERE" + whereCondition;

                        // Eksekusi query
                        using (MySqlCommand cmd = new MySqlCommand(fullQuery, conn))
                        {
                            foreach (MySqlParameter parameter in parameters)
                                cmd.Parameters.Add(parameter);

                            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                            mySqlDataAdapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PerformSearch()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=db-kasermo");
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    using (DataTable dt = new DataTable("log"))
                    {
                        // Query dasar
                        string baseQuery = "SELECT id, nama_produk, stok, harga_produk, created_at, update_at " + "FROM produk ";

                        // Persiapkan parameter dan kondisi WHERE
                        List<MySqlParameter> parameters = new List<MySqlParameter>();
                        string whereCondition = "";

                        // Tambahkan kondisi search
                        if (!string.IsNullOrEmpty(cari.Text))
                        {
                            whereCondition += " nama_produk LIKE @search";
                            parameters.Add(new MySqlParameter("@search", $"%{cari.Text}%"));
                        }

                        // Gabungkan semua kondisi menjadi satu query
                        string fullQuery = baseQuery;
                        if (!string.IsNullOrEmpty(whereCondition))
                            fullQuery += " WHERE" + whereCondition;

                        // Eksekusi query
                        using (MySqlCommand cmd = new MySqlCommand(fullQuery, conn))
                        {
                            foreach (MySqlParameter parameter in parameters)
                                cmd.Parameters.Add(parameter);

                            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                            mySqlDataAdapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cari_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
        }
    }
}
