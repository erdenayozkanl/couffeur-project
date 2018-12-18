using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KUAFOR
{
    public partial class sifre2 : Form
    {
        public sifre2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text==textBox3.Text)
            {
                string komut = "UPDATE KULLANICI SET PASSWORD='" + textBox2.Text + "' WHERE USERNAME = '" + textBox1.Text + "' ";
                amele.Update(komut);
                MessageBox.Show("İşleminiz başarıyla gerçekleşmiştir!", "İşlem tamam!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(textBox2.Text!=textBox3.Text)
            {
                MessageBox.Show("Girdiğiniz şifreler uğuşmamakta!", "Uyarı  !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserLogin ul = new UserLogin();
            sifre2.ActiveForm.Close();
            ul.Show();
        }
    }
}
