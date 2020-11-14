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
    public partial class LoginEmployee : Form
    {
        public LoginEmployee()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_closeEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage logout = new Homepage();
            logout.Show();
        }

        private void btn_loginstudent_Click(object sender, EventArgs e)
        {

            SqlConnection koneksi = new SqlConnection(@"data source = DESKTOP-5L26KM2;database=katalog;MultipleActiveResultSets=True;User ID=sa;Password=musafak93");
            SqlDataAdapter sda = new SqlDataAdapter("select count (*) from Admin where Username = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'",koneksi);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Katalog login = new Katalog();
                login.Show();
                MessageBox.Show("Login Succes");
            }
            else
            {
                MessageBox.Show("mohon isi username dan password anda dengan benar !!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            RegistrasiEmployee registrasi = new RegistrasiEmployee();
            registrasi.Show();
        }
    }
}
