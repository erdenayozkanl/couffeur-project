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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            string sqlim = "SELECT  A.CUSTOMER_ID, A.CUSTOMER_ADI AS ADI, A.CUSTOMER_SOYADI AS SOYADI, A.CUSTOMER_NO AS TELEFONU, A.TARIH AS KAYDI  FROM CUSTOMER AS A";
            SqlDataAdapter da = new SqlDataAdapter(sqlim, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            MyConnection.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12();
            frm12.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string komut = "DELETE FROM CUSTOMER WHERE CUSTOMER_ID= '" + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) + "'";
                amele.sil(komut);
                button3.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && maskedTextBox1.Text != "")
            {
                button3.PerformClick();
                string komut = "INSERT INTO CUSTOMER  VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + maskedTextBox1.Text + "', SYSDATETIME())";
                amele.Ekle(komut);
            }
        }
    }
}
