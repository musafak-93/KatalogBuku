using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace KatalogBuku
{
    public partial class SearchBook : Form
    {
        SqlConnection koneksi = new SqlConnection(@"data source = DESKTOP-5L26KM2;database=katalog;MultipleActiveResultSets=True;User ID=sa;Password=musafak93");

        public SearchBook()
        {
            InitializeComponent();
        }

        string Status;
        string imglocation = "";
        SqlCommand cmd;

        private void pictureBox_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginStudent login = new LoginStudent();
            login.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [BUKU] where Judul_buku = '" + textBox1.Text + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                koneksi.Close();
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show(" Buku Tidak Ada");
            }
        }


        public void display_data()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [BUKU]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            koneksi.Close();
        }

        private void button_daftarbuku_Click(object sender, EventArgs e)
        {
            display_data();
        }
    }
}
