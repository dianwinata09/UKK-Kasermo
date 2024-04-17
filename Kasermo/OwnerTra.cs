using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;

namespace Kasermo
{
    public partial class OwnerTra : Form
    {
        public OwnerTra()
        {
            InitializeComponent();

        }
        Class2 f = new Class2();

        private void LoadData()
        {
            string query = "SELECT l.id, l.id_produk, u.nama_produk, u.harga_produk, l.qty,l.nama_pelanggan, l.total_harga, l.uang_bayar, l.uang_kembali, l.created_at " + "FROM transaksi l " + "JOIN produk u ON l.id_produk = u.id";
            f.showDataT(query, dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new owner().Show();
        }

        private void OwnerTra_Load(object sender, EventArgs e)
        {
            string query = "SELECT l.id, l.id_produk, u.nama_produk, u.harga_produk, l.qty,l.nama_pelanggan, l.total_harga, l.uang_bayar, l.uang_kembali, l.created_at " + "FROM transaksi l " + "JOIN produk u ON l.id_produk = u.id";

            f.showDataT(query, dataGridView1);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];

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
                        string baseQuery = "SELECT l.id, l.id_produk, u.nama_produk, u.harga_produk, l.qty, l.nama_pelanggan, l.total_harga, l.uang_bayar, l.uang_kembali, l.created_at " + "FROM transaksi l " + "JOIN produk u ON l.id_produk = u.id";

                        // Persiapkan parameter dan kondisi WHERE
                        List<MySqlParameter> parameters = new List<MySqlParameter>();
                        string whereCondition = "";

                        // Tambahkan kondisi tanggal jika dipilih
                        if (dtp1.Value != DateTime.Now && dtp2.Value != DateTime.Now)
                        {
                            whereCondition += " l.created_at BETWEEN @fromdate AND @todate";
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

        private void reset_Click(object sender, EventArgs e)
        {
            dtp1.Value = DateTime.Now;
            dtp2.Value = DateTime.Now;
            textBox1.Text = string.Empty;
            LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                        string baseQuery = "SELECT l.id, l.id_produk, u.nama_produk, u.harga_produk, l.qty, l.nama_pelanggan, l.total_harga, l.uang_bayar, l.uang_kembali, l.created_at " + "FROM transaksi l " + "JOIN produk u ON l.id_produk = u.id";

                        // Persiapkan parameter dan kondisi WHERE
                        List<MySqlParameter> parameters = new List<MySqlParameter>();
                        string whereCondition = "";

                        // Tambahkan kondisi search
                        if (!string.IsNullOrEmpty(textBox1.Text))
                        {
                            whereCondition += " l.nama_pelanggan LIKE @search";
                            parameters.Add(new MySqlParameter("@search", $"%{textBox1.Text}%"));
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

        // ... (kode lainnya)

        private void pdf_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "PDF (*.pdf)|*.pdf";
                    save.FileName = "Laporan Transaksi.pdf";

                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        int counter = 1;
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(save.FileName);
                        string fileExtension = Path.GetExtension(save.FileName);
                        string directory = Path.GetDirectoryName(save.FileName);
                        string newFileName = Path.Combine(directory, fileNameWithoutExtension + fileExtension);

                        while (File.Exists(newFileName))
                        {
                            newFileName = Path.Combine(directory, $"{fileNameWithoutExtension}_{counter}{fileExtension}");
                            counter++;
                        }

                        save.FileName = newFileName;

                        using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                        {
                            Document doc = new Document(PageSize.A4.Rotate(), 8f, 16f, 16f, 8f);
                            PdfWriter.GetInstance(doc, fileStream);
                            doc.Open();

                            iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
                            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12);

                            // Membuat objek paragraph dengan judul
                            Paragraph title = new Paragraph("Laporan Transaksi", fontTitle);
                            title.Alignment = Element.ALIGN_CENTER;
                            title.SpacingAfter = 20; // Ubah SpacingAfter menjadi 20
                            title.SpacingBefore = 20;

                            // Menambahkan informasi tanggal di cetak
                            Paragraph dateInfo = new Paragraph($"Tanggal Cetak: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}", font);
                            dateInfo.Alignment = Element.ALIGN_RIGHT;
                            dateInfo.SpacingAfter = 10;

                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                            float[] columnWidths = { 2f, 5f, 3f, 8f, 5f, 5f, 5f, 7f, 9f, 0f }; // Sesuaikan lebar kolom sesuai kebutuhan

                            pTable.SetWidths(columnWidths);

                            foreach (DataGridViewColumn kolom in dataGridView1.Columns)
                            {
                                PdfPCell headerCell = new PdfPCell(new Phrase(kolom.HeaderText.Trim()));
                                headerCell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                                headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                                headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                headerCell.Padding = 5;
                                headerCell.BorderWidth = 1;
                                headerCell.Phrase.Font.Size = 8;
                                pTable.AddCell(headerCell);
                            }

                            decimal totalHarga = 0;
                            // Lanjutan koding Anda...


                            // Menambahkan data dari DataGridView ke dalam table
                            foreach (DataGridViewRow baris in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell sel in baris.Cells)
                                {
                                    PdfPCell cell = new PdfPCell();
                                    if (sel.Value != null)
                                    {
                                        cell.Phrase = new Phrase(sel.Value.ToString());

                                        // Format currency pada kolom total_harga
                                        if (sel.OwningColumn.Name == "total_harga")
                                        {
                                            decimal harga = 0;
                                            if (decimal.TryParse(sel.Value.ToString(), out harga))
                                            {
                                                totalHarga += harga;
                                                cell.Phrase = new Phrase(harga.ToString("C"));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        cell.Phrase = new Phrase("");
                                    }

                                    cell.Padding = 5;
                                    cell.BorderWidth = 1;
                                    pTable.AddCell(cell);
                                }
                            }

                            // Menambahkan total pendapatan ke dalam table
                            PdfPCell totalHargaCell = new PdfPCell(new Phrase("Total Pendapatan: " + totalHarga.ToString("C")));
                            totalHargaCell.Colspan = dataGridView1.Columns.Count;
                            pTable.AddCell(totalHargaCell);

                            // Menambahkan informasi tanggal di cetak ke dalam dokumen
                            doc.Add(dateInfo);

                            // Menambahkan informasi header di bagian atas dokumen
                            doc.Add(title);

                            // Menambahkan table ke dalam dokumen
                            doc.Add(pTable);

                            doc.Close();
                            fileStream.Close();
                        }

                        MessageBox.Show("Ekspor Data Berhasil");

                        // Membuka file PDF setelah disimpan
                        Process.Start(save.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saat mengekspor data: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Tidak Ada Data Ditemukan");
            }
        }

    }
}
