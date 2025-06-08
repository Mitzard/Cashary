using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cashary
{
    public partial class CasharyForm: Form
    {
        String strDisplay;
        private bool isEditMode = false;
        private int editingTransaksiId = 0;
        public CasharyForm()
        {
            InitializeComponent();
            this.Text = "Tambah Transaksi Baru";
            strDisplay = "";
        }
        public CasharyForm(int transaksiId)
        {
            InitializeComponent();
            this.isEditMode = true;
            this.editingTransaksiId = transaksiId;
            this.Text = "Edit Transaksi";
            btnSimpan.Text = "Update";
            strDisplay = "";
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (strDisplay.Length > 0)
            {
                strDisplay = strDisplay.Substring(0, strDisplay.Length - 1);
            }
            txtDisplay.Text = strDisplay;
            if (strDisplay == "")
            {
                txtDisplay.Text = "0";
            }
        }

        private void LoadKategori()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM kategori";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow row = dt.NewRow();
                    row["id"] = 0;
                    row["nama_kategori"] = "-- Pilih Kategori Pengeluaran Kamu --";
                    dt.Rows.InsertAt(row, 0);

                    cmbKategori.DataSource = dt;
                    cmbKategori.DisplayMember = "nama_kategori"; // yang ditampilkan di dropdown
                    cmbKategori.ValueMember = "id";     // yang digunakan untuk disimpan ke DB
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat kategori: " + ex.Message);
                }
            }
        }

        private void CasharyForm_Load(object sender, EventArgs e)
        {
            LoadKategori();
            if (this.isEditMode)
            {
                LoadTransaksi();
            }
        }

        private void LoadTransaksi()
        {
            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM transaksi WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", this.editingTransaksiId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Isi semua kontrol di form dengan data dari database
                            cmbKategori.SelectedValue = reader.GetInt32("kategori_id");
                            txtDeskripsi.Text = reader.GetString("deskripsi");
                            txtDisplay.Text = reader.GetDecimal("jumlah").ToString();
                            strDisplay = txtDisplay.Text;
                            dtpForm.Value = reader.GetDateTime("waktu");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat data untuk diedit: " + ex.Message);
                    this.Close();
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidasiInput()) return;
            int idKategori = Convert.ToInt32(cmbKategori.SelectedValue);
            string deskripsi = txtDeskripsi.Text.Trim();
            DateTime waktu = dtpForm.Value;
            decimal jumlah = decimal.Parse(txtDisplay.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture);

            int currentUserId = UserSession.LoggedInUserId;
            if (currentUserId == 0)
            {
                // Jika sesi kosong, tampilkan pesan ini dan hentikan proses.
                // Ini akan mencegah error foreign key di database.
                MessageBox.Show("Sesi pengguna tidak ditemukan atau tidak valid. Silakan login ulang.", "Error Sesi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();
                    string query;
                    MySqlCommand cmd;
                    if (this.isEditMode)
                    {
                        query = @"UPDATE transaksi SET 
                                      kategori_id = @kategori_id, 
                                      deskripsi = @deskripsi, 
                                      jumlah = @jumlah, 
                                      waktu = @waktu 
                                  WHERE id = @id AND user_id = @user_id";
                        cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", this.editingTransaksiId);
                    }
                    else
                    {
                        query = "INSERT INTO transaksi (user_id, kategori_id, deskripsi, jumlah, waktu) " +
                                       "VALUES (@user_id, @kategori_id, @deskripsi, @jumlah, @waktu)";
                        cmd = new MySqlCommand(query, conn);
                    }

                    cmd.Parameters.AddWithValue("@user_id", currentUserId);
                    cmd.Parameters.AddWithValue("@kategori_id", idKategori);
                    cmd.Parameters.AddWithValue("@deskripsi", deskripsi);
                    cmd.Parameters.AddWithValue("@jumlah", jumlah);
                    cmd.Parameters.AddWithValue("@waktu", waktu);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(this.isEditMode ? "Data berhasil di-update!" : "Transaksi berhasil disimpan!", "Sukses");

                    // Buka halaman CasharyPage dan tutup form ini
                    CasharyPage cashary = new CasharyPage();
                    this.Hide();    
                    cashary.Show();
                }
                catch (Exception ex)
                {
                    // Untuk menangkap error umum non-database
                    MessageBox.Show("Gagal simpan (Error Umum): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //private void ResetForm()
        //{
        //    strDisplay = "";
        //    txtDisplay.Text = "0";
        //    txtDeskripsi.Clear();
        //    cmbKategori.SelectedIndex = 0;
        //    dtpForm.Value = DateTime.Now;
        //}
        private bool ValidasiInput()
        {
            if (cmbKategori.SelectedIndex <= 0)
            {
                MessageBox.Show("Kategori wajib dipilih!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbKategori.Focus(); // Fokuskan ke ComboBox kategori
                return false; // Hentikan proses dan kembalikan 'false'
            }

            if (!decimal.TryParse(txtDisplay.Text.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal jumlah) || jumlah <= 0)
            {
                MessageBox.Show("Jumlah pengeluaran harus angka dan lebih dari nol!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDisplay.Focus(); // Fokuskan ke display jumlah
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDeskripsi.Text))
            {
                MessageBox.Show("Deskripsi wajib diisi!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeskripsi.Focus(); // Fokuskan ke TextBox deskripsi
                return false;
            }

            if (dtpForm.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Tanggal transaksi tidak boleh di masa depan!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpForm.Focus(); // Fokuskan ke DateTimePicker
                return false;
            }

            return true;
        }

        private void btnAngka_Click(object sender, EventArgs e)
        {
            Button tombolAngka = sender as Button;
            if (tombolAngka == null) return;

            if (txtDisplay.Text == "0" || strDisplay == "")
            {
                strDisplay = tombolAngka.Text;
            }
            else
            {
                strDisplay += tombolAngka.Text;
            }

            txtDisplay.Text = strDisplay;
        }

    }
}
