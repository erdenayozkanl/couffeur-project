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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            button2.PerformClick();

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 frm8 = new Form12();
            frm8.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kulbak = "SELECT A.USERNAME FROM KULLANICI AS A WHERE USERNAME='"+textBox1.Text +"'";
            DataTable kb = amele.BilgiGetir(kulbak);
            if (kb.Rows.Count > 0)
            {
                MessageBox.Show("Bu Kullanıcı Adı Zaten Alınmuştır!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

            }
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                if (textBox2.Text == textBox3.Text)
                {
                    string komut = "INSERT INTO KULLANICI VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "' , '" + textBox4.Text + "')";
                    amele.Ekle(komut);
                    button2.PerformClick();
                    MessageBox.Show("İşleminiz Başarıyla Gerçekleşmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            string sqlim = "SELECT A.USERNAME AS 'Kullanıcı Adı' FROM KULLANICI AS A";
            SqlDataAdapter da = new SqlDataAdapter(sqlim, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            MyConnection.Close();
        }
    }
}
