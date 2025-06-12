namespace Cashary
{
    partial class CasharyPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CasharyPage));
            this.dgvCashary = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
<<<<<<< HEAD
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
=======
            this.dtpPage = new System.Windows.Forms.DateTimePicker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbFilterBy = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnTambahData = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();

            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();

            this.lblPageInfo = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashary)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCashary
            // 
            this.dgvCashary.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.dgvCashary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashary.Location = new System.Drawing.Point(60, 126);
            this.dgvCashary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvCashary.Name = "dgvCashary";
            this.dgvCashary.RowHeadersWidth = 62;
            this.dgvCashary.RowTemplate.Height = 28;
            this.dgvCashary.Size = new System.Drawing.Size(638, 306);
            this.dgvCashary.TabIndex = 0;
            // 
            // groupBox3
            // 
<<<<<<< HEAD
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
=======
            this.groupBox3.Controls.Add(this.dtpPage);
>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            this.groupBox3.Controls.Add(this.txtSearch);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Controls.Add(this.cmbFilterBy);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(60, 43);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(822, 70);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter";
            // 
<<<<<<< HEAD
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(689, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 33);
            this.button1.TabIndex = 15;
            this.button1.Text = "Cari";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.dateTimePicker1.Location = new System.Drawing.Point(187, 26);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(230, 26);
            this.dateTimePicker1.TabIndex = 14;
=======
            // dtpPage
            // 

            this.dtpPage.Location = new System.Drawing.Point(191, 28);
            this.dtpPage.Name = "dtpPage";
            this.dtpPage.Size = new System.Drawing.Size(200, 26);
            this.dtpPage.TabIndex = 14;
            this.dtpPage.ValueChanged += new System.EventHandler(this.dtpPage_ValueChanged);

>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            // 
            // cmbFilterBy
            // 
            this.cmbFilterBy.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cmbFilterBy.FormattingEnabled = true;
            this.cmbFilterBy.Items.AddRange(new object[] {
            "Judul",
            "Penulis",
            "Penerbit",
            "Tahun Terbit"});
            this.cmbFilterBy.Location = new System.Drawing.Point(38, 26);
            this.cmbFilterBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFilterBy.Name = "cmbFilterBy";
            this.cmbFilterBy.Size = new System.Drawing.Size(132, 28);
            this.cmbFilterBy.TabIndex = 11;
<<<<<<< HEAD
            this.cmbFilterBy.Text = "Pilih Kategori";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnReload);
            this.groupBox2.Controls.Add(this.btnHapus);
            this.groupBox2.Controls.Add(this.btnCetak);
            this.groupBox2.Controls.Add(this.btnTambahData);
            this.groupBox2.Location = new System.Drawing.Point(60, 482);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(822, 143);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Aksi";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(42, 99);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
=======
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(34, 60);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(585, 25);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Cari";
            this.btnSearch.UseVisualStyleBackColor = true;

            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(172, 598);

>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(287, 31);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnEdit
            // 
<<<<<<< HEAD
            this.btnEdit.Location = new System.Drawing.Point(42, 63);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
=======
            this.btnEdit.Location = new System.Drawing.Point(854, 570);

>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(74, 32);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnReload
            // 
<<<<<<< HEAD
            this.btnReload.Location = new System.Drawing.Point(243, 63);
            this.btnReload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
=======

            this.btnReload.Location = new System.Drawing.Point(1058, 570);

>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(86, 32);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // btnHapus
            // 
<<<<<<< HEAD
            this.btnHapus.Location = new System.Drawing.Point(141, 63);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
=======

            this.btnHapus.Location = new System.Drawing.Point(959, 579);

>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(76, 32);
            this.btnHapus.TabIndex = 6;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnCetak
            // 
            this.btnCetak.Location = new System.Drawing.Point(192, 18);
            this.btnCetak.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(137, 31);
            this.btnCetak.TabIndex = 15;
            this.btnCetak.Text = "Cetak Laporan Pengeluaran";
            this.btnCetak.UseVisualStyleBackColor = true;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // btnTambahData
            // 
            this.btnTambahData.Location = new System.Drawing.Point(42, 18);
            this.btnTambahData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTambahData.Name = "btnTambahData";
            this.btnTambahData.Size = new System.Drawing.Size(144, 31);
            this.btnTambahData.TabIndex = 4;
            this.btnTambahData.Text = "Tambah Data";
            this.btnTambahData.UseVisualStyleBackColor = true;
            this.btnTambahData.Click += new System.EventHandler(this.btnTambahData_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogOut.Location = new System.Drawing.Point(1018, 11);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(173, 40);
            this.btnLogOut.TabIndex = 16;
            this.btnLogOut.Text = "Keluar Akun";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
<<<<<<< HEAD
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(60, 438);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(97, 29);
            this.btnPrev.TabIndex = 17;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(129, 438);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(101, 29);
            this.btnNext.TabIndex = 18;
=======

            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(252, 521);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(137, 31);
            this.btnNext.TabIndex = 17;
>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(61, 521);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(137, 31);
            this.btnPrev.TabIndex = 18;

            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 

            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
<<<<<<< HEAD
            this.lblPageInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPageInfo.Location = new System.Drawing.Point(277, 434);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(129, 20);
=======
            this.lblPageInfo.Location = new System.Drawing.Point(702, 521);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(129, 20);

>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            this.lblPageInfo.TabIndex = 19;
            this.lblPageInfo.Text = "Halaman 1 dari 2";
            // 
            // txtSearch
            // 
            this.txtSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearch.Location = new System.Drawing.Point(428, 26);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(289, 26);
            this.txtSearch.TabIndex = 16;
            this.txtSearch.Text = "Deskripsi";
            // 
            // CasharyPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.BackgroundImage = global::Cashary.Properties.Resources.hoomepage_cashary;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1203, 650);
=======

            this.ClientSize = new System.Drawing.Size(1200, 701);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnHapus);
>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnClear);

            this.Controls.Add(this.btnLogOut);
<<<<<<< HEAD
            this.Controls.Add(this.groupBox2);
=======
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.btnTambahData);
>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvCashary);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CasharyPage";
<<<<<<< HEAD
            this.Text = "CashiaryPage";
            this.TopMost = true;
=======
            this.Text = "Cashary Page";
            this.Load += new System.EventHandler(this.CasharyPage_Load);
>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashary)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCashary;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbFilterBy;
<<<<<<< HEAD
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox2;
=======
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpPage;
>>>>>>> d23f04accb8c63c46bbd01029fc02248338ff81f
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTambahData;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;

        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSearch;
    }
}