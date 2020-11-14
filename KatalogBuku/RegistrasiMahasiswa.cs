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
    public partial class RegistrasiMahasiswa : Form
    {
        SqlConnection koneksi = new SqlConnection(@"data source = DESKTOP-5L26KM2;database=katalog;MultipleActiveResultSets=True;User ID=sa;Password=musafak93");
        public RegistrasiMahasiswa()
        {
            InitializeComponent();
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginStudent logout = new LoginStudent();
            logout.Show();
        }

        private void btn_loginstudent_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [MAHASISWA](NIM,Nama_Mahasiswa,Alamat,No_Hp,Jenis_Kelamin) values ('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','"+textBox4.Text+"','"+comboBox1.Text+"')";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            //untuk membuat textbox kosong ketika input data
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            MessageBox.Show("Registrasi Successfully");
            this.Hide();
            LoginStudent login = new LoginStudent();
            login.Show();
        }

        private void RegistrasiMahasiswa_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("L");
            comboBox1.Items.Add("P");
        }
    }
}
