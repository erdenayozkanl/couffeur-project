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
    public partial class Kullanıcı_ekle : Form
    {
        public Kullanıcı_ekle()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;

        }
        public int count = 3;
        private void button1_Click(object sender, EventArgs e)
        { if(textBox1.Text!="" && textBox2.Text != "" &&  textBox3.Text !="" && textBox4.Text !="")
            {
                if (textBox2.Text == textBox3.Text)
                {
                    string komut = "INSERT INTO KULLANICI VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "' , '" + textBox3.Text + "')";
                    amele.Ekle(komut);
                  
                }
                else
                {
                    MessageBox.Show("Şifreler uğuşmamakta");
                    textBox3.Clear();
                    textBox2.Clear();
                }
               
            }
            else
            {
                MessageBox.Show("Lütfen gerekli yerleri doldurun!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UserLogin ul = new UserLogin();
            Kullanıcı_ekle.ActiveForm.Close();
            ul.Show();
        }

        private void Kullanıcı_ekle_Load(object sender, EventArgs e)
        {
        }
    }
}
