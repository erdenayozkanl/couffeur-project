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
    public partial class Kullanıcı_sil : Form
    {
        public Kullanıcı_sil()
        {
            InitializeComponent();
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MainMenu ma = new MainMenu();
            Kullanıcı_sil.ActiveForm.Close();
            ma.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istediğinizden emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string komut = "DELETE FROM KULLANICI WHERE ID= '" + Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value) + "'";
                amele.sil(komut);
                button2.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = ConnectionClass.Connection_Path();
            MyConnection.Open();
            string somut = "SELECT A.ID,A.USERNAME FROM KULLANICI AS A ";
            SqlDataAdapter da = new SqlDataAdapter(somut, MyConnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            MyConnection.Close();
        }
    }
}
