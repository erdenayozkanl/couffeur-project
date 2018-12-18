using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuaforAna
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// Random image = new Random();
            //Form1.ActiveForm.BackgroundImage = new Bitmap("C:\\Users\\By Rdv\\documents\\visual studio 2015\\Projects\\KuaforAna\\KuaforAna\\images\\b1.jpg");
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM KULLANICI WHERE USERNAME= '" + textBox1.Text + "' AND PASSWORD= '" + textBox2.Text + "'");
            SqlDataReader dr;
            komut.Connection = MyConnection;
            dr = komut.ExecuteReader();
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }
            if (count == 1)
            {
                Form12 du = new Form12();
                Form2.ActiveForm.Visible = false;
                du.Show();
            }
            else if (count == 0 && textBox1.Text != "" && textBox2.Text != "")
            {
                MessageBox.Show("Lütfen kullanıcı adınız veya şifreniz hatalı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
            }


            else if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcı adınızı ve şifrenizi giriniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox2.Clear();
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Kullanıcı adınızı giriniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen şifrenizi giriniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form10 mu = new Form10();
            mu.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
    }
}
