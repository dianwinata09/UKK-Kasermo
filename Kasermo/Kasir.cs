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
    public partial class Kasir : Form
    {
        public Kasir()
        {
            InitializeComponent();
            // Mengaitkan event handler untuk event BeginPrint
            printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(printDocument1_BeginPrint);

            // Juga mungkin Anda ingin mengaitkan event handler untuk event PrintPage
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "ID_PRODUK";
            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "NAMA BARANG";
            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "QTY";
            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "HARGA SATUAN";
            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            column5.HeaderText = "HARGA TOTAL";

            dgkasir.Columns.Add(column1);
            dgkasir.Columns.Add(column2);
            dgkasir.Columns.Add(column3);
            dgkasir.Columns.Add(column4);
            dgkasir.Columns.Add(column5);

            dgkasir.Columns[0].Width = 150;
            dgkasir.Columns[1].Width = 250;
            dgkasir.Columns[2].Width = 450;
            dgkasir.Columns[3].Width = 350;
            dgkasir.Columns[4].Width = 350;
        }
        Class2 function = new Class2();
        public static int IdTr = 0;
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=db-kasermo");
        void getTotal()
        {
            int total = 0;

            // Menghitung total nilai di kolom indeks 1 (kolom nilai)
            for (int i = 0; i < dgkasir.Rows.Count; i++)
            {
                total += Convert.ToInt32(dgkasir.Rows[i].Cells[4].Value);
            }

            // Menampilkan total pada label atau tempat yang sesuai
            totalharga.Text = $"{total:n0}";
        }
        private void UpdateProductQuantity(int productId, int quantity)
        {
            // Update the quantity of the purchased product in the database
            MySqlCommand updateQuantityCommand = new MySqlCommand("UPDATE produk SET stok = stok - @quantity WHERE id = @idProduk", conn);
            
            updateQuantityCommand.Parameters.AddWithValue("@quantity", quantity);
            updateQuantityCommand.Parameters.AddWithValue("@idProduk", productId);
            updateQuantityCommand.ExecuteNonQuery();
        }
        void getId()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select max(nomor_unik) as id from transaksi", conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int result = 0;
                int.TryParse(reader["id"].ToString(), out result);

                IdTr = result + 1;
            }

            reader.Close();
            conn.Close();
        }
        string GetHarga()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select harga_produk from produk where id like '" + idproduk.Text.Split('-')[0].Trim() + "%'", conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            string harga_satuan = "";

            if (reader.Read())
            {
                // Ambil nilai harga_produk dari database
                double hargaProduk;
                if (double.TryParse(reader["harga_produk"].ToString(), out hargaProduk))
                {
                    // Format nilai harga_produk dengan koma di belakang angka
                    harga_satuan = string.Format("{0:n2}", hargaProduk);
                }
            }

            conn.Close();
            reader.Close();

            return harga_satuan;

        }

        void clear()
        {
            namabarang.Text = string.Empty;
            jumlah.Text = string.Empty;
            idproduk.Text = string.Empty;
            hargasatuan.Text = string.Empty;
        }

        void combo()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=db-kasermo");
            string selectQuery = "SELECT * FROM produk";
            connection.Open();

            MySqlCommand command = new MySqlCommand(selectQuery, connection);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                namabarang.Items.Add(reader.GetString("nama_produk"));
            }

            connection.Close();
        }
        private void Kasir_Load(object sender, EventArgs e)
        {
            string query = "SELECT l.id_produk, u.nama_produk, u.harga_produk, l.qty,l.nama_pelanggan, l.nomor_unik, l.total_harga, l.uang_bayar, l.uang_kembali, l.created_at " +"FROM transaksi l " +"JOIN produk u ON l.id_produk = u.id";
            namabarang.Items.Clear();
            nomorunik.Text = new Random().Next(10000, 99999).ToString();
            function.showData(query, dgpro);
            combo();
            getId();
            getTotal();
        }
        private void GetProductInfo(string productName)
        {
            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=;database=db-kasermo");

            conn.Open();
            if (!string.IsNullOrEmpty(productName))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT id, harga_produk FROM produk WHERE nama_produk = @productName", conn);
                cmd.Parameters.AddWithValue("@productName", productName);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    idproduk.Text = reader["id"].ToString();
                    hargasatuan.Text = reader["harga_produk"].ToString();
                }

                conn.Close();
            }
            else
            {
                clear();
            }
        }
        private void tambah_Click_1(object sender, EventArgs e)
        {
            // Mengambil nilai dari TextBox
            string id = idproduk.Text;
            string barang = namabarang.Text;
            string haraga1 = hargasatuan.Text;

            double qty, harga;

            if (double.TryParse(jumlah.Text, out qty) && double.TryParse(hargasatuan.Text, out harga))
            {
                int idProduk = int.Parse(id);

                if (!IsStockAvailable(idProduk, qty))
                {
                    MessageBox.Show("Stok produk tidak mencukupi untuk transaksi ini. Stok saat ini: " + GetStockQuantity(idProduk), "Stok Tidak Cukup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Keluar dari metode jika stok tidak mencukupi
                }

                // Cek apakah produk dengan nama yang sama sudah ada dalam DataGridView
                bool produkDitemukan = false;

                foreach (DataGridViewRow row in dgkasir.Rows)
                {
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == barang)
                    {
                        // Jika nama produk sudah ada, tambahkan qty ke produk yang sudah ada
                        double existingQty = Convert.ToDouble(row.Cells[2].Value);
                        row.Cells[2].Value = existingQty + qty;

                        // Hitung total ulang
                        double total = Convert.ToDouble(row.Cells[4].Value) + (harga * qty);
                        row.Cells[4].Value = total;

                        produkDitemukan = true;
                        break;
                    }
                }

                if (!produkDitemukan)
                {
                    // Jika produk belum ada, tambahkan produk baru
                    dgkasir.Rows.Add(id, barang, qty, haraga1, harga * qty);
                }
            }

            getTotal();

        }
        private bool IsStockAvailable(int idProduk, double requestedQuantity)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=db-kasermo"))
            {
                connection.Open();
                string checkStockQuery = "SELECT stok FROM produk WHERE id = @idProduk";

                using (MySqlCommand checkStockCommand = new MySqlCommand(checkStockQuery, connection))
                {
                    checkStockCommand.Parameters.AddWithValue("@idProduk", idProduk);
                    object result = checkStockCommand.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int stock = Convert.ToInt32(result);
                        return (stock >= requestedQuantity); // Cek apakah stok mencukupi
                    }
                }
            }

            return false;
        }
        private int GetStockQuantity(int idProduk)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=db-kasermo"))
            {
                connection.Open();
                string getStockQuery = "SELECT stok FROM produk WHERE id = @idProduk";

                using (MySqlCommand getStockCommand = new MySqlCommand(getStockQuery, connection))
                {
                    getStockCommand.Parameters.AddWithValue("@idProduk", idProduk);
                    object result = getStockCommand.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }

            return 0;
        }
        private void bayarB_Click(object sender, EventArgs e)
        {
            
            function.command("insert into log (id_user, aktivity, created_at) VALUES ('" + Class2.id_user + "', 'Kasir Melakukan Transaksi', NOW())");

            // Mendapatkan nilai dari kontrol input
            string namaPelanggan = namapelanggan.Text;
            string namaProduk = namabarang.Text;
            decimal uangBayar;
            int quantity, nomorUnik;

            if (!decimal.TryParse(uangbayar.Text, out uangBayar) || !int.TryParse(jumlah.Text, out quantity))
            {
                MessageBox.Show("Input tidak valid.");
                return;
            }

            try
            {
                // Membuka koneksi ke database
                conn.Open();

                // Mendapatkan nomor unik secara acak
                Random random = new Random();
                nomorUnik = random.Next(10000, 99999);

                // Iterasi melalui setiap baris dalam DataGridView
                foreach (DataGridViewRow row in dgkasir.Rows)
                {
                    int idProduk = Convert.ToInt32(row.Cells[0].Value);
                    string namaPelanggann = namapelanggan.Text;
                    int qty = Convert.ToInt32(row.Cells[2].Value);
                    decimal uangb = Convert.ToDecimal(uangbayar.Text);
                    decimal totalh = Convert.ToDecimal(row.Cells[4].Value);
                    decimal uangkem = uangb - totalh;

                    // Menyimpan data transaksi ke tabel transaksi
                    MySqlCommand insertTransaksiCommand = new MySqlCommand("INSERT INTO transaksi (id_produk, nama_pelanggan, qty, uang_bayar, uang_kembali, total_harga, nomor_unik, created_at) VALUES (@idProduk, @namaPelanggan, @qty, @uangBayar, @uangKembali, @totalHarga, @nomorUnik, NOW())", conn);
                    insertTransaksiCommand.Parameters.AddWithValue("@idProduk", idProduk);
                    insertTransaksiCommand.Parameters.AddWithValue("@namaPelanggan", namaPelanggann);
                    insertTransaksiCommand.Parameters.AddWithValue("@qty", qty);
                    insertTransaksiCommand.Parameters.AddWithValue("@uangBayar", uangb);
                    insertTransaksiCommand.Parameters.AddWithValue("@uangKembali", uangkem);
                    insertTransaksiCommand.Parameters.AddWithValue("@totalHarga", totalh);
                    insertTransaksiCommand.Parameters.AddWithValue("@nomorUnik", nomorUnik);

                    // Update the quantity of the purchased product
                    UpdateProductQuantity(idProduk, quantity);

                    // Eksekusi perintah SQL
                    insertTransaksiCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Transaksi berhasil");
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Menutup koneksi setelah selesai
                conn.Close();
                Kasir_Load(null, EventArgs.Empty);
            }
            clear();
        }

        private void namabarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected product name
            string selectedProductName = namabarang.SelectedItem.ToString();

            // Retrieve product information based on the selected name
            GetProductInfo(selectedProductName);
            hargasatuan.Text = GetHarga();
        }

        private void uangbayar_TextChanged(object sender, EventArgs e)
        {
            // Lakukan konversi nilai uangbayar dan totalharga ke tipe data double
            double uangBayar, totalHarga;

            if (double.TryParse(uangbayar.Text, out uangBayar) && double.TryParse(totalharga.Text.Replace("Rp. ", ""), out totalHarga))
            {
                // Lakukan perhitungan kembalian
                double kembalianResult = uangBayar - totalHarga;

                // Menampilkan hasil kembalian pada label kembalian
                kembalian.Text =$"{kembalianResult:n0}";
            }
            else
            {
                // Tampilkan pesan kesalahan jika nilai tidak dapat diubah menjadi double
                kembalian.Text = " ";
            }
        }

        private void idproduk_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;port=3306;username=root;password=;database=db-kasermo");

            conn.Open();
            if (idproduk.Text != "")
            {
                MySqlCommand cmd = new MySqlCommand("SELECT nama_produk, harga_produk FROM produk WHERE id LIKE @id", conn);
                cmd.Parameters.AddWithValue("@id", double.Parse(idproduk.Text));
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    namabarang.Text = reader.GetString(0);
                    hargasatuan.Text = reader.GetValue(1).ToString();
                }
                conn.Close();

            }
            else
            {
                clear();
            }
        }

        private void kembalian_TextChanged(object sender, EventArgs e)
        {
        }

        private void keluar_Click(object sender, EventArgs e)
        {
            function.command("insert into log(id_user, aktivity, created_at) values ('" + Class2.id_user + "', 'logout',NOW() )");
            this.Hide();
            new Login().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new dataP().Show();
        }

        private void dgpro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dgpro.Rows[e.RowIndex];

            namabarang.Text = dr.Cells[1].Value.ToString();
            hargasatuan.Text = dr.Cells[2].Value.ToString();
            idproduk.Text = dr.Cells[0].Value.ToString();
            jumlah.Text = dr.Cells[3].Value.ToString();/*
            namapelanggan.Text = dr.Cells[4].Value.ToString();
            nomorunik.Text = dr.Cells[5].Value.ToString();
            totalharga.Text = dr.Cells[7].Value.ToString();
            uangbayar.Text = dr.Cells[7].Value.ToString();
            kembalian.Text = dr.Cells[7].Value.ToString();*/
        }

        private void bersih_Click(object sender, EventArgs e)
        {
            clear();
            dgkasir.Rows.Clear();
            uangbayar.Text = string.Empty;
            totalharga.Text = string.Empty;
            kembalian.Text = string.Empty;
            nomorunik.Text = string.Empty;
            namapelanggan.Text = string.Empty;
            nomorunik.Text = new Random().Next(10000, 99999).ToString();

        }
        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            // Mengubah ukuran halaman
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom Size", 192, 500);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Membuat objek Font untuk judul
            Font titleFont = new Font("Arial", 10, FontStyle.Bold);
            // Membuat objek Font untuk konten
            Font contentFont = new Font("Arial", 8, FontStyle.Regular);
            Font nama = new Font("Arial", 8, FontStyle.Regular);
            Font foot = new Font("Arial", 6, FontStyle.Regular);

            // Menentukan posisi awal pada kertas
            int yPos = 10;

            // Menentukan isi dokumen yang akan dicetak
            string title = "KASERMO WORKSHOP\n";
            string subTitle = "Struk Pembelian\n\n";

            // Menambahkan judul dan subjudul
            e.Graphics.DrawString(title, titleFont, Brushes.Black, new Point(10, yPos));
            yPos += (int)titleFont.GetHeight();

            // Menambahkan informasi waktu transaksi
            string transactionTime = $"Waktu Transaksi: {DateTime.Now.ToString("yyyy-MM-dd")}\n";
            string pelanggan = $"Pelanggan: {namapelanggan.Text}";
            string nounik = $"No Unik. {nomorunik.Text}\n";

            // Subtitle
            e.Graphics.DrawString(transactionTime, contentFont, Brushes.Black, new Point(10, yPos));
            yPos += 20;
            e.Graphics.DrawString(subTitle, contentFont, Brushes.Black, new Point(10, yPos + 10));
            yPos += 15;
            e.Graphics.DrawString(pelanggan, nama, Brushes.Black, new Point(10, yPos + 10));
            yPos += 15;
            e.Graphics.DrawString(nounik, contentFont, Brushes.Black, new Point(10, yPos + 10));

            // Menambahkan garis pemisah di bawah tanggal
            yPos += (int)contentFont.GetHeight() * 2;
            yPos += 10;

            string productHeader = "Produk".PadRight(30) + "Total Harga".PadRight(20);
            e.Graphics.DrawString(productHeader, contentFont, Brushes.Black, new Point(10, yPos));
            yPos += (int)contentFont.GetHeight();
            yPos += 10;

            // Menambahkan informasi produk dari DataGridView ke dalam isi dokumen
            foreach (DataGridViewRow dr in dgkasir.Rows)
            {
                if (dr.IsNewRow) continue;

                string productName = dr.Cells[1].Value?.ToString() ?? "";
                string quantity = dr.Cells[2].Value?.ToString() ?? "";
                string unitPrice = dr.Cells[3].Value?.ToString() ?? "";
                string totalPrice = dr.Cells[4].Value?.ToString() ?? "";

                // Menentukan panjang maksimum untuk total price
                int maxTotalPriceLength = 12;

                // Mengatur panjang sesuai dengan maksimum
                totalPrice = totalPrice.PadLeft(maxTotalPriceLength);

                // Menggabungkan informasi produk
                string productInfo = $"{productName,-25}\n";
                string total = $"{string.Format("{0:n0}", double.Parse(totalPrice)), 40}";

                string info = $"{quantity + "x"} {unitPrice.PadLeft(5)}\n";
                e.Graphics.DrawString(productInfo, contentFont, Brushes.Black, new Point(10, yPos));
                e.Graphics.DrawString(total, contentFont, Brushes.Black, new Point(30, yPos));
                yPos += (int)contentFont.GetHeight();
                e.Graphics.DrawString(info, foot, Brushes.Black, new Point(10, yPos));
                yPos += (int)contentFont.GetHeight();
            }

            // Menambahkan garis pemisah di bawah detail produk
            e.Graphics.DrawLine(new Pen(Brushes.Black), new Point(10, yPos), new Point(240, yPos));

            // Menambahkan informasi total harga, uang bayar, dan kembalian ke dalam isi dokumen
            string totalInfo = $"Total Harga: {string.Format("{0:n0}", double.Parse(totalharga.Text)), 29}\n";
            string bayarInfo = $"Uang Bayar: {string.Format("{0:n0}", double.Parse(uangbayar.Text)), 30}\n";
            string kembalianInfo = $"Kembalian: {string.Format("{0:n0}", double.Parse(kembalian.Text)), 30}\n";

            e.Graphics.DrawString(totalInfo, contentFont, Brushes.Black, new Point(10, yPos + 10));
            e.Graphics.DrawString(bayarInfo, contentFont, Brushes.Black, new Point(10, yPos + 20));
            e.Graphics.DrawString(kembalianInfo, contentFont, Brushes.Black, new Point(10, yPos + 30));

            // Menambahkan spasi antara informasi pembayaran dan ucapan terimakasih
            yPos += 80;

            // Menambahkan ucapan terimakasih dan alamat
            string thanks = "Terima Kasih atas Kunjungan Anda!\nKASERMO WORKSHOP\nAlamat: Jl.ottoiskandardinata No.19\n\n";
            StringFormat centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(thanks, foot, Brushes.Black, new Rectangle(10, yPos, 180, 150), centerFormat);

        }
    }
}
