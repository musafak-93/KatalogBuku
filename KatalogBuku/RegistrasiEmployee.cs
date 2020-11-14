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
using System.IO;

namespace KatalogBuku
{
    public partial class RegistrasiEmployee : Form
    {
        SqlConnection koneksi = new SqlConnection(@"data source = DESKTOP-5L26KM2;database=katalog;MultipleActiveResultSets=True;User ID=sa;Password=musafak93");
        public RegistrasiEmployee()
        {
            InitializeComponent();
        }
        SqlCommand cmd;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginEmployee logout = new LoginEmployee();
            logout.Show();
        }

        //Registrasi
        private void btn_loginstudent_Click(object sender, EventArgs e)
        {
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [Admin](Username, Nama, Password) values ('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "')";
                cmd.ExecuteNonQuery();
                koneksi.Close();
                //untuk membuat textbox kosong ketika input data
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                MessageBox.Show("Registrasi Successfully");
                this.Hide();
                LoginEmployee login = new LoginEmployee();
                login.Show();

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }
    }
}
