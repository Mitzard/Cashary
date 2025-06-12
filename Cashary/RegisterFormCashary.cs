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
using BCrypt.Net;

namespace Cashary
{
    public partial class RegisterFormCashary: Form
    {
        public RegisterFormCashary()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string konfirmasi = txtConfirmPassword.Text;

            // Validasi input kosong
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(konfirmasi))
            {
                MessageBox.Show("Semua field wajib diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi kecocokan password
            if (password != konfirmasi)
            {
                MessageBox.Show("Password dan konfirmasi tidak cocok!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hash password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();

                    // Cek username apakah sudah ada
                    string cekQuery = "SELECT COUNT(*) FROM pengguna WHERE username = @username";
                    MySqlCommand cekCmd = new MySqlCommand(cekQuery, conn);
                    cekCmd.Parameters.AddWithValue("@username", username);
                    long userExists = (long)cekCmd.ExecuteScalar();

                    if (userExists > 0)
                    {
                        MessageBox.Show("Username sudah terdaftar, silakan pilih username lain.", "Registrasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Simpan ke database
                    string query = "INSERT INTO pengguna (username, email, password) VALUES (@username, @email, @password)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Registrasi berhasil! Silakan login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Arahkan ke Form Login
                    this.Hide();
                    LoginFormCashary formLogin = new LoginFormCashary();
                    formLogin.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void llblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
