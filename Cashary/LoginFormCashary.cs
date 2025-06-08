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
    public partial class LoginFormCashary: Form
    {
        public LoginFormCashary()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.Trim(); // Bisa username atau email
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username/email dan password harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(DBConfig.ConnStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, username, password FROM pengguna WHERE username = @input OR email = @input";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@input", input);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string hashFromDb = reader.GetString("password");
                        bool isValid = BCrypt.Net.BCrypt.Verify(password, hashFromDb);

                        if (isValid)
                        {
                            int userId = reader.GetInt32("id");
                            string username = reader.GetString("username");
                            reader.Close();
                            UserSession.StartSession(userId, username);

                            // login sukses
                            MessageBox.Show($"Login berhasil! Selamat datang, {username}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CasharyPage cp = new CasharyPage();
                            this.Hide();
                            cp.Show();
                        }
                        else
                        {
                            MessageBox.Show("Password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username atau email tidak ditemukan!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan koneksi:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void llblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterFormCashary rfc = new RegisterFormCashary();
            this.Hide();
            rfc.Show();
        }
    }
}
