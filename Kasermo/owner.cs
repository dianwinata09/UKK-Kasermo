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
    public partial class owner : Form
    {

        private string defaultQuery;
        public owner()
        {
            InitializeComponent();
            defaultQuery = "SELECT l.id, l.id_user, u.nama, u.role, l.aktivity, l.created_at FROM log l JOIN user u ON l.id_user = u.id";

        }
        Class2 function = new Class2();
        private string initialFilter;

        private void LoadData(string query = null)
        {
            query = query ?? defaultQuery;
            function.showDataL(query, dataGridView1);

        }
        void data()
        {
            cbrole.Items.Add("admin");
            cbrole.Items.Add("kasir");
        }

        private void owner_Load(object sender, EventArgs e)
        {
            initialFilter = defaultQuery;
            string query = "SELECT l.id, l.id_user, u.nama, u.role, l.aktivity, l.created_at FROM log l JOIN user u ON l.id_user = u.id";
            function.showDataL(query, dataGridView1);
            data();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda Yakin Akan Keluar?", "Keluar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                new Login().Show();
            }
            else if (result == DialogResult.No)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new OwnerPro().Show();
        }

        private void cbrole_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new OwnerTra().Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil nilai dari ComboBox dan DateTimePicker
                string selectedRole = cbrole.SelectedItem?.ToString();
                DateTime fromDate = dtp1.Value;
                DateTime toDate = dtp2.Value;

                // Query dasar
                string baseQuery = "SELECT l.id, l.id_user, u.nama, u.role, l.aktivity, l.created_at " + "FROM log l " + "JOIN user u ON l.id_user = u.id";

                // Persiapkan parameter dan kondisi WHERE
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                string whereCondition = "";

                // Tambahkan kondisi role jika dipilih
                if (!string.IsNullOrEmpty(selectedRole))
                {
                    whereCondition += " u.role = @role";
                    parameters.Add(new MySqlParameter("@role", selectedRole));
                }

                // Tambahkan kondisi tanggal jika dipilih
                if (fromDate != DateTime.Now && toDate != DateTime.Now)
                {
                    if (!string.IsNullOrEmpty(whereCondition))
                        whereCondition += " AND";

                    whereCondition += " DATE(l.created_at) BETWEEN @fromdate AND @todate";
                    parameters.Add(new MySqlParameter("@fromdate", fromDate.ToString("yyyy-MM-dd")));
                    parameters.Add(new MySqlParameter("@todate", toDate.AddDays(0).ToString("yyyy-MM-dd"))); // Tambah 1 hari agar mencakup hingga akhir hari yang dipilih

                }

                // Gabungkan semua kondisi menjadi satu query
                string fullQuery = baseQuery;
                if (!string.IsNullOrEmpty(whereCondition))
                    fullQuery += " WHERE" + whereCondition;

                // Eksekusi query
                using (MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=db-kasermo"))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    using (DataTable dt = new DataTable("log"))
                    {
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

        private void button5_Click(object sender, EventArgs e)
        {
            // Handle the selected index change event of rolecombo
            cbrole.SelectedIndex = -1;
            cari.Text = "";
            dtp1.Value = DateTime.Now;
            dtp2.Value = DateTime.Now;

            // Menggunakan status filter awal
            LoadData(initialFilter);
        }

        private void cari_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
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
                        string baseQuery = "SELECT l.id, l.id_user, u.nama, u.role, l.aktivity, l.created_at " + "FROM log l " + "JOIN user u ON l.id_user = u.id";

                        // Persiapkan parameter dan kondisi WHERE
                        List<MySqlParameter> parameters = new List<MySqlParameter>();
                        string whereCondition = "";

                        // Tambahkan kondisi search
                        if (!string.IsNullOrEmpty(cari.Text))
                        {
                            whereCondition += " u.nama LIKE @search OR u.role LIKE @search";
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
    }
}
