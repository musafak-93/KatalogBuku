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
    public partial class Katalog : Form
    {

        SqlConnection koneksi = new SqlConnection(@"data source = DESKTOP-5L26KM2;database=katalog;MultipleActiveResultSets=True;User ID=sa;Password=musafak93");
        //string connectionString = "data source = DESKTOP-5L26KM2;database= katalog;MultipleActiveResultSets= True;user ID= sa;password= musafak93;";
        public Katalog()
        {
            InitializeComponent();
        }

        string Status;
        string imglocation = "";
        SqlCommand cmd;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Pengarang_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void pictureBox_close_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginEmployee logout = new LoginEmployee();
            logout.Show();
        }*/

        private void pictureBox_close_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            LoginEmployee logout = new LoginEmployee();
            logout.Show();
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                pictureBox2.ImageLocation = imglocation;
            }
        }

        private void btn_input_Click(object sender, EventArgs e)
        {
            if (textBox_kodeBuku.Text != "" && textBox_judulBuku.Text != "" && textBox_Pengarang.Text != "" && textBox_Penerbit.Text != "" && textBox_TahunTerbit.Text != "" && textBox_kategori.Text != "" && comboBox1.Text != "")
            {
                byte[] images = null;
                FileStream streem = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(streem);
                images = brs.ReadBytes((int)streem.Length);
                koneksi.Open();
                SqlCommand cmd = koneksi.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [BUKU](Kode_Buku,Judul_Buku,Pengarang,Penerbit,Tahun_Terbit,Kategori,ID_Rak,Gambar) values ('" + textBox_kodeBuku.Text + "','" + textBox_judulBuku.Text + "','" + textBox_Pengarang.Text + "','" + textBox_Penerbit.Text + "','" + textBox_TahunTerbit.Text + "','" + textBox_kategori.Text + "','" + comboBox1.Text + "',@images)";
                cmd.Parameters.Add(new SqlParameter("@images", images));
                cmd.ExecuteNonQuery();
                koneksi.Close();
                //untuk membuat textbox kosong ketika input data
                textBox_kodeBuku.Text = "";
                textBox_judulBuku.Text = "";
                textBox_Pengarang.Text = "";
                textBox_Penerbit.Text = "";
                comboBox1.Text = "";
                textBox_TahunTerbit.Text = "";
                textBox_kategori.Text = "";
                pictureBox2.ImageLocation = null;
                display_data();
                MessageBox.Show("Data insert Successfully");
            }
            else
            {
                MessageBox.Show("Isi Data yang kosong");
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

        private void btn_display_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [BUKU] where Kode_Buku = '" + textBox_kodeBuku.Text + "'";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            textBox_kodeBuku.Text = "";
            display_data();
            MessageBox.Show(" Data delete successfully");
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            //untuk membuat textbox kosong ketika input data
            textBox_kodeBuku.Text = "";
            textBox_judulBuku.Text = "";
            textBox_Pengarang.Text = "";
            textBox_Penerbit.Text = "";
            textBox_TahunTerbit.Text = "";
            textBox_kategori.Text = "";
            pictureBox2.ImageLocation = null;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") {

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
            }else
            {
                MessageBox.Show(" Buku Tidak Ada");
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {

            /*SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;

            //string sql = "SELECT * FROM Mendata";
            //SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            //SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            //DataSet ds = new DataSet("Mendata");

            if (textBox_kodeBuku.Text != "")
            {
                byte[] images = null;
                FileStream streem = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(streem); images = brs.ReadBytes((int)streem.Length);
                cmd = new SqlCommand("update BUKU set Judul_Buku=@judul, Pengarang=@pengarang, Penerbit=@penerbit, Tahun_Terbit=@tahun, Kategori=@kategori, ID_Rak=@rak where Kode_Buku=@kode", connection);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                connection.Open();
                cmd.Parameters.AddWithValue("@kode", textBox_kodeBuku.Text);
                cmd.Parameters.AddWithValue("@judul", textBox_judulBuku.Text);
                cmd.Parameters.AddWithValue("@pengarang", textBox_Pengarang.Text);
                cmd.Parameters.AddWithValue("@penerbit", textBox_Penerbit.Text);
                cmd.Parameters.AddWithValue("@tahun", textBox_TahunTerbit.Text);
                cmd.Parameters.AddWithValue("@kategori", textBox_kategori.Text);
                cmd.Parameters.AddWithValue("@rak", comboBox1.Text);
                cmd.Parameters.AddWithValue("@gambar", pictureBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                connection.Close();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }*/

             byte[] images = null;
             FileStream streem = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
             BinaryReader brs = new BinaryReader(streem); images = brs.ReadBytes((int)streem.Length);
             koneksi.Open();
             SqlCommand cmd = koneksi.CreateCommand();
             cmd.CommandType = CommandType.Text;
             cmd.CommandText = " update [BUKU] set Kode_Buku='" + this.textBox_kodeBuku.Text + "',Judul_Buku='" + this.textBox_judulBuku.Text + "',Pengarang='" + this.textBox_Pengarang.Text + "',Penerbit='" + this.textBox_Penerbit.Text + "',Tahun_Terbit='" + this.textBox_TahunTerbit.Text + "',Kategori='" + this.textBox_kategori.Text + "',ID_Rak='" + this.comboBox1.Text + "',Gambar=@images where Kode_Buku='" + this.textBox_kodeBuku.Text + "'";
             cmd.Parameters.Add(new SqlParameter("@images", images));
             cmd.ExecuteNonQuery();
             koneksi.Close();
             //untuk membuat textbox kosong ketika input data
             textBox_kodeBuku.Text = "";
             textBox_judulBuku.Text = "";
             textBox_Pengarang.Text = "";
             textBox_Penerbit.Text = "";
             textBox_TahunTerbit.Text = "";
             textBox_kategori.Text = "";
             comboBox1.Text = "";
             pictureBox2.ImageLocation = null;
             display_data();
             MessageBox.Show("Data update Successfully");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Katalog_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("R001");
            comboBox1.Items.Add("R002");
            comboBox1.Items.Add("R003");
            comboBox1.Items.Add("R004");
            comboBox1.Items.Add("R005");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
