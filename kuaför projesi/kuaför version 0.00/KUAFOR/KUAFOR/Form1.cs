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

namespace KUAFOR
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();

            textBox1.Enabled = false;
            textBox2.Enabled = false;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

            if (!checkBox1.Checked)
            {
                Button btn = sender as Button;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                if (btn == button1)
                {
                    MisafirKullanici mu = new MisafirKullanici();
                    mu.Show();
                    this.Hide();
                }
            }

            if (count == 1 && checkBox1.Checked)
            {
                MainMenu du = new MainMenu();
                UserLogin.ActiveForm.Visible = false;
                du.Show();
            }
           else if (count==0 && checkBox1.Checked && textBox1.Text != "" && textBox2.Text != "")
            {
                MessageBox.Show("Lütfen kullanıcı adınız veya şifreniz hatalı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
            }
           

          else  if (checkBox1.Checked && textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcı adınızı ve şifrenizi giriniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox2.Clear();
            }
            else if (checkBox1.Checked && textBox1.Text == "")
            {
                MessageBox.Show("Kullanıcı adınızı giriniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (checkBox1.Checked && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen şifrenizi giriniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar)== 13)
            {
                button1.PerformClick();
            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = true;
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifre s = new sifre();
            s.Show();
            this.Hide();

        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Kullanıcı_ekle kul = new Kullanıcı_ekle();
            kul.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
