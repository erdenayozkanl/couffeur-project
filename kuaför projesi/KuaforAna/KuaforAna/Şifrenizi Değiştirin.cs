using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuaforAna
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                string komut = "UPDATE KULLANICI SET PASSWORD='" + textBox2.Text + "' WHERE USERNAME = '" + textBox1.Text + "' ";
                amele.Update(komut);
                MessageBox.Show("İşleminiz başarıyla gerçekleşmiştir!", "İşlem tamam!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Girdiğiniz şifreler uğuşmamakta!", "Uyarı  !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
