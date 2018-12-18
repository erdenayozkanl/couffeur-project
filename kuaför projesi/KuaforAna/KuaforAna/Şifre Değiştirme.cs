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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm12 = new Form2();
            frm12.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string somut1 = "SELECT A.USERNAME,A.GIZLISORU FROM KULLANICI AS A WHERE A.USERNAME='" + textBox1.Text + "' AND A.GIZLISORU ='" + textBox2.Text + "'";
            DataTable veri = amele.BilgiGetir(somut1);
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcı adınızı ve gizli sorunuzu giriniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcı adınızı giriniz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen gizli cevabınızı giriniz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


            else if (veri.Rows.Count != 1)
            {
                MessageBox.Show("Kullanıcı adı veya gizli cevabınız yanlış!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (textBox1.Text != null && textBox2.Text != null)
            {

                string somut = "SELECT A.USERNAME,A.GIZLISORU FROM KULLANICI AS A WHERE A.USERNAME='" + textBox1.Text + "' AND A.GIZLISORU ='" + textBox2.Text + "'";
                DataTable dt = amele.BilgiGetir(somut);
                if (dt.Rows.Count == 1)
                {
                    Form5 s = new Form5();
                    Form3.ActiveForm.Close();
                    s.Show();
                }
            }


      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            string komut = "SELECT A.USERNAME AS Kullanıcılar FROM KULLANICI AS A ";
            SqlDataAdapter da = new SqlDataAdapter(komut, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            MyConnection.Close();
        }
    }
}
