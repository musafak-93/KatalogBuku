using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KatalogBuku
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_closeHome_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //jika user admin
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginEmployee login = new LoginEmployee();
            login.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //Jika user mahasiswa
        private void pictureBox_student_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginStudent login = new LoginStudent();
            login.Show();
        }
    }
}
