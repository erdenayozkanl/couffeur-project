using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KUAFOR
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen işlem yapılmasını istediğiniz miktarı giriniz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            if (textBox1.Text != "")
            {
                string cekme = "SELECT A.URUN_ID FROM PRODUCT AS A WHERE URUN_ID='" + textBox1.Text + "'";
                DataTable dt = amele.BilgiGetir(cekme);
                if(dt.Rows.Count>0)
                {
                    MessageBox.Show("Bu ürün zaten bulunmakta.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    string komut = "INSERT INTO PRODUCT VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "' , '" + textBox3.Text + "', '" + textBox7.Text + "')";
                    amele.Ekle(komut);
                    button3.PerformClick();
                }
                
            }
           
        }
     
        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            string cekme = "SELECT Count(URUN_ID) FROM Product";
            SqlDataAdapter da = new SqlDataAdapter(cekme, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            label10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            MyConnection.Close();

            SqlConnection My = new SqlConnection();
            My.ConnectionString = ConnectionClass.Connection_Path();
            My.Open();
            string sqlim = "SELECT * FROM PRODUCT";
            SqlDataAdapter d = new SqlDataAdapter(sqlim, MyConnection);
            DataTable dte = new DataTable();
            d.Fill(dte);
            dataGridView1.DataSource = dte;
            MyConnection.Close();
          
        }

        private void Product_Load(object sender, EventArgs e)
        {
           



            button3.PerformClick();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string komut = "DELETE FROM PRODUCT WHERE URUN_ID= '" + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) + "'";
                amele.sil(komut);
                button3.PerformClick();


            }
         }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 43)
            {
                e.Handled = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MainMenu ma = new MainMenu();
            Product.ActiveForm.Close();
            ma.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen işlem yapılmasını istediğiniz miktarı giriniz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            if (textBox4.Text!="")
            {
                button5.PerformClick();

                int sum = Convert.ToInt32(textBox5.Text) - Convert.ToInt32(textBox4.Text);
                if (sum >= 0)
                {
                    textBox6.Text = sum.ToString();
                    string komut = "UPDATE PRODUCT SET STOK= '" + textBox6.Text + "' WHERE STOK='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value + "' AND URUN_ID='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value + "'";
                    amele.Update(komut);
                    button3.PerformClick();
                }
                else
                {
                    MessageBox.Show("Stok sayısı negatif olamaz", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
           
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button5.PerformClick();

            if (textBox4.Text=="")
            {
                MessageBox.Show("Lütfen işlem yapılmasını istediğiniz miktarı giriniz.", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                int sum = Convert.ToInt32(textBox5.Text) + Convert.ToInt32(textBox4.Text);
                textBox6.Text = sum.ToString();
                string komut = "UPDATE PRODUCT SET STOK= '" + textBox6.Text + "' WHERE STOK='" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value + "'";
                amele.Ekle(komut);
                button3.PerformClick();
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection urun = new AutoCompleteStringCollection();
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            SqlCommand cmd = MyConnection.CreateCommand();
            cmd.CommandText = "SELECT A.URUN_ADI FROM PRODUCT AS A";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                while (dr.Read())
                {
                    urun.Add(dr["URUN_ADI"].ToString());
                }
            }
            else
            {
                //MessageBox.Show("");
            }
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteCustomSource = urun;
            }


        }
    }

