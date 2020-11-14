using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KatalogBuku
{
    public partial class LoginStudent : Form
    {
        public LoginStudent()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection koneksi = new SqlConnection(@"data source = DESKTOP-5L26KM2;database=katalog;MultipleActiveResultSets=True;User ID=sa;Password=musafak93");
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from MAHASISWA where NIM = '" + textBox2.Text + "' and Nama_Mahasiswa = '" + textBox1.Text + "'", koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                SearchBook login = new SearchBook();
                login.Show();
                MessageBox.Show("Login Succes");
            }
            else
            {
                MessageBox.Show("mohon isi nama dan nim anda dengan benar !!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_closeHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage logout = new Homepage();
            logout.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void btn_registrasi_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrasiMahasiswa registrasi = new RegistrasiMahasiswa();
            registrasi.Show();
        }
    }
}
