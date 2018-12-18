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
    public partial class sifre : Form
    {
        public sifre()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            UserLogin ul = new UserLogin();
            sifre.ActiveForm.Close();
            ul.Show();
        }

        private void sifre_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kUAFORDataSet4.GIZLISEY' table. You can move, or remove it, as needed.
            this.gIZLISEYTableAdapter.Fill(this.kUAFORDataSet4.GIZLISEY);
            comboBox1.SelectedIndex = 1;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            string somut1 = "SELECT A.USERNAME,A.GIZLISORU FROM KULLANICI AS A WHERE A.USERNAME='" + textBox2.Text + "' AND A.GIZLISORU ='" + textBox3.Text + "'";
            DataTable veri = amele.BilgiGetir(somut1);
            if (textBox2.Text == "" && textBox3.Text=="")
            {
                MessageBox.Show("Lütfen kullanıcı adınızı ve gizli sorunuzu giriniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen kullanıcı adınızı giriniz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning); 

            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Lütfen gizli cevabınızı giriniz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            
            else if (veri.Rows.Count!=1)
            {
                MessageBox.Show("Kullanıcı adı veya gizli cevabınız yanlış!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

            if (textBox2.Text != null && textBox3.Text != null)
            {

                string somut = "SELECT A.USERNAME,A.GIZLISORU FROM KULLANICI AS A WHERE A.USERNAME='" + textBox2.Text + "' AND A.GIZLISORU ='" + textBox3.Text + "'";
               DataTable dt = amele.BilgiGetir(somut);
                if (dt.Rows.Count==1)
                {
                    sifre2 s = new sifre2();
                    sifre.ActiveForm.Close();
                    s.Show();
                }                
            }

        

        }

        private void button2_Click(object sender, EventArgs e)
        {
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
}