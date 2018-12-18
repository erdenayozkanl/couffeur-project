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
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                string komut = "INSERT INTO CUSTOMER  VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', SYSDATETIME())";
                amele.Ekle(komut);
                button2.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            string sqlim = "SELECT A.CUSTOMER_ADI AS ADI, A.CUSTOMER_SOYADI AS SOYADI, A.CUSTOMER_NO AS TELEFONU, A.TARIH AS KAYDI  FROM CUSTOMER AS A";
            SqlDataAdapter da = new SqlDataAdapter(sqlim, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            MyConnection.Close();

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string komut = "DELETE FROM customer WHERE customer_id= '" + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) + "'";
                amele.sil(komut);
                button2.PerformClick();
            }

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MainMenu ma = new MainMenu();
            Musteri.ActiveForm.Close();
            ma.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
