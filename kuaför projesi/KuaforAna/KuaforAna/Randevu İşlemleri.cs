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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            string sqlim = "SELECT * FROM CUSTOMER";
            SqlDataAdapter da = new SqlDataAdapter(sqlim, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            MyConnection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12();
            frm12.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            string sqlim = "SELECT A.CUSTOMER_ID AS ID, B.RANDEVU_SAATI,A.CUSTOMER_ADI AS ADI,CUSTOMER_SOYADI AS SOYADI,B.RANDEVU_GUNU AS RANDEVUSU FROM CUSTOMER AS A,RANDEVU AS B WHERE A.CUSTOMER_ID=B.CUSTOMER_ID";
            SqlDataAdapter da = new SqlDataAdapter(sqlim, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            MyConnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string komut = "DELETE FROM RANDEVU WHERE CUSTOMER_ID= '" + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) + "'";
                amele.sil(komut);
                button2.PerformClick();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Today && dateTimePicker2.Value<DateTime.Now)
            {
                MessageBox.Show("Geçmişten bir gün seçemezsiniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen bir ID numarası girin.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button2.PerformClick();
            }

            if (textBox1.Text != "")
            {
                if (dateTimePicker1.Value > DateTime.Today && dateTimePicker2.Value > DateTime.Now)
                {
                    button1.Enabled = true;
                    string muscek = "SELECT A.CUSTOMER_ID AS ID FROM CUSTOMER AS A WHERE A.CUSTOMER_ID='" + textBox1.Text + "'";
                    string rancek = "SELECT A.CUSTOMER_ID AS ID FROM RANDEVU AS A WHERE A.CUSTOMER_ID='" + textBox1.Text + "'";
                    DataTable da = amele.BilgiGetir(muscek);

                    DataTable dt = amele.BilgiGetir(rancek);
                    if (da.Rows.Count > 0)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Bu ID'li müşterinin zaten randevusu var.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Clear();
                        }
                        else
                        {
                            string komut = "INSERT INTO RANDEVU VALUES ('" + textBox1.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + dateTimePicker2.Value.ToString("hh:mm") + "')";
                            amele.Ekle(komut);
                            button2.PerformClick();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Girilen ID'ye ait birisi bulunamamıştır!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                    }
                }

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }
    }
}
