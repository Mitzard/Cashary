using MySql.Data.MySqlClient;
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
        public CasharyPage()
        {
            InitializeComponent();
            LoadData();
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
                    string query = @"SELECT
                                t.id, 
                                t.waktu,
                                k.nama_kategori,
                                t.jumlah,
                                t.deskripsi
                            FROM transaksi t
                            INNER JOIN kategori k ON t.kategori_id = k.id 
                            WHERE t.user_id = @userId 
                            ORDER BY t.waktu DESC";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@userId", currentUserId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCashary.DataSource = dt;

                    if (dgvCashary.Rows.Count > 0)
                    {
                        // Sembunyikan kolom ID dari pengguna
                        dgvCashary.Columns["id"].Visible = false;

                        // Atur Header Teks
                        dgvCashary.Columns["waktu"].HeaderText = "Waktu";
                        dgvCashary.Columns["nama_kategori"].HeaderText = "Kategori";
                        dgvCashary.Columns["jumlah"].HeaderText = "Jumlah";
                        dgvCashary.Columns["deskripsi"].HeaderText = "Deskripsi";

                        // Atur formatting kolom Jumlah sebagai mata uang
                        dgvCashary.Columns["jumlah"].DefaultCellStyle.Format = "C";
                        dgvCashary.Columns["jumlah"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID"); // Format Rupiah
                        dgvCashary.Columns["jumlah"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Rata kanan

                        // Atur lebar kolom agar proporsional
                        dgvCashary.Columns["deskripsi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
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
    }
}
