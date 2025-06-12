using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashary
{
    public partial class CasharyPage: Form
    {
        private int selectedId = -1;
        int pageSize = 10;
        int currentPage = 1;
        int totalPages = 1;
        int totalRecords = 0;



        bool isFiltered = false;

        public CasharyPage()
        {
            InitializeComponent();
            LoadData();
            LoadKategori();
            CasharyPageLoad();
        }

        private void LoadKategori()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT id, nama_kategori FROM kategori", conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbFilterBy.DataSource = dt;
                    cmbFilterBy.DisplayMember = "nama_kategori";
                    cmbFilterBy.ValueMember = "id";
                    cmbFilterBy.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat kategori: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
        }

        private void CasharyPageLoad()
        {
            // Set DateTimePicker agar tampak kosong saat pertama kali
            dtpPage.Format = DateTimePickerFormat.Custom;
            dtpPage.CustomFormat = " ";  // kosongkan tampilannya
            dtpPage.ValueChanged += dtpPage_ValueChanged;
        }   

        private void Filtered()
        {
            string waktu = dtpPage.Value.ToString("yyyy-MM-dd"); // ambil hanya tanggal
            string kategoriId = cmbFilterBy.SelectedValue?.ToString();
            string deskripsi = txtSearch.Text.Trim();

            string query = @"
            SELECT transaksi.id, waktu, kategori.nama_kategori AS kategori, jumlah, deskripsi
            FROM transaksi
            JOIN kategori ON transaksi.kategori_id = kategori.id
            WHERE 1=1";

            // parameter builder
            MySqlCommand cmd = new MySqlCommand();
            if (!string.IsNullOrEmpty(waktu))
            {
                query += " AND DATE(waktu) = @waktu";
                cmd.Parameters.AddWithValue("@waktu", waktu);
            }

            if (!string.IsNullOrEmpty(kategoriId))
            {
                query += " AND kategori_id = @kategori_id";
                cmd.Parameters.AddWithValue("@kategori_id", kategoriId);
            }

            if (!string.IsNullOrEmpty(deskripsi))
            {
                query += " AND LOWER(IFNULL(deskripsi, '')) LIKE @deskripsi";
                cmd.Parameters.AddWithValue("@deskripsi", "%" + deskripsi.ToLower() + "%");
            }

            cmd.CommandText = query;

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
                try
                {
                    cmd.Connection = conn;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCashary.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Filter gagal: " + ex.Message);
                }
        }



        private void btnTambahData_Click(object sender, EventArgs e)
        {
            CasharyForm cf = new CasharyForm();
            this.Hide();
            cf.Show();

            LoadData();
        }

        private void LoadData()
        {
            int currentUserId = UserSession.LoggedInUserId;

            if (currentUserId == 0)
            {
                MessageBox.Show("Sesi pengguna tidak valid. Silakan login ulang.", "Error Sesi");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();


                    // Hitung total records

                    string countQuery = "SELECT COUNT(*) FROM transaksi WHERE user_id = @userId";
                    MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                    countCmd.Parameters.AddWithValue("@userId", currentUserId);
                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());

                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (currentPage > totalPages) currentPage = totalPages;
                    if (currentPage < 1) currentPage = 1;

                    int offset = (currentPage - 1) * pageSize;

                    string query = @"SELECT
                                t.id, 
                                t.waktu,
                                k.nama_kategori,
                                t.jumlah,
                                t.deskripsi
                            FROM transaksi t
                            INNER JOIN kategori k ON t.kategori_id = k.id 
                            WHERE t.user_id = @userId 
                            ORDER BY t.waktu DESC
                            LIMIT @limit OFFSET @offset";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", currentUserId);
                    cmd.Parameters.AddWithValue("@limit", pageSize);
                    cmd.Parameters.AddWithValue("@offset", offset);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCashary.DataSource = dt;

                    if (dgvCashary.Rows.Count > 0)
                    {
                        dgvCashary.Columns["id"].Visible = false;
                        dgvCashary.Columns["waktu"].HeaderText = "Waktu";
                        dgvCashary.Columns["nama_kategori"].HeaderText = "Kategori";
                        dgvCashary.Columns["jumlah"].HeaderText = "Jumlah";
                        dgvCashary.Columns["deskripsi"].HeaderText = "Deskripsi";

                        dgvCashary.Columns["jumlah"].DefaultCellStyle.Format = "C";
                        dgvCashary.Columns["jumlah"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID");
                        dgvCashary.Columns["jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        dgvCashary.Columns["deskripsi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    lblPageInfo.Text = $"Halaman {currentPage} dari {totalPages}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnCetak_Click(object sender, EventArgs e)
        {
            CasharyReport cr = new CasharyReport();
            cr.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCashary.CurrentRow == null)
            {
                MessageBox.Show("Silakan pilih data yang ingin di-edit.", "Peringatan");
                return;
            }
            int transaksiId = Convert.ToInt32(dgvCashary.CurrentRow.Cells["id"].Value);
            using (CasharyForm editForm = new CasharyForm(transaksiId))
            {
                editForm.ShowDialog(); // Tampilkan form edit dan tunggu sampai ditutup.
            }
            LoadData();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi ini?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                UserSession.EndSession();
                LoginFormCashary loginForm = new LoginFormCashary();
                loginForm.Show();
                this.Close();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvCashary.CurrentRow == null)
            {
                MessageBox.Show("Silakan pilih data yang ingin dihapus terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin ingin menghapus transaksi ini? Data yang sudah dihapus tidak bisa dikembalikan.", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                try
                {
                    int transaksiId = Convert.ToInt32(dgvCashary.CurrentRow.Cells["id"].Value);

                    int currentUserId = UserSession.LoggedInUserId;

                    using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
                    {
                        conn.Open();

                        string query = "DELETE FROM transaksi WHERE id = @id AND user_id = @userId";
                        MySqlCommand cmd = new MySqlCommand(query, conn);

                        cmd.Parameters.AddWithValue("@id", transaksiId);
                        cmd.Parameters.AddWithValue("@userId", currentUserId);

                        // ExecuteNonQuery() akan mengembalikan jumlah baris yang terpengaruh.
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Ini jarang terjadi, tapi sebagai pengaman jika data tidak ditemukan.
                            MessageBox.Show("Data tidak ditemukan atau Anda tidak memiliki hak untuk menghapusnya.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat menghapus data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    LoadData();
                }

            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }

        private void CasharyPage_Load(object sender, EventArgs e)
        {
            btnSearch.BackColor = System.Drawing.ColorTranslator.FromHtml("#4CAF50");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Filtered();
        }

        private void dtpPage_ValueChanged(object sender, EventArgs e)
        {
            dtpPage.Format = DateTimePickerFormat.Long;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();                
            cmbFilterBy.SelectedIndex = -1;   
            dtpPage.CustomFormat = " ";       
            dtpPage.Format = DateTimePickerFormat.Custom;

            LoadData();
        }

    }
}
