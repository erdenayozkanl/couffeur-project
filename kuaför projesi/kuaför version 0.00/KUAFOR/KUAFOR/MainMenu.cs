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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            comboBox1.Enabled=false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            label12.Visible =false;
            label13.Visible =false;
            label14.Visible =false;
            label15.Visible =false;
            label16.Visible =false;
           
        }


        private void addProductToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void deleteProductToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product pr = new Product();
            MainMenu.ActiveForm.Close();
            pr.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Musteri yeni = new Musteri();
            MainMenu.ActiveForm.Close();
            yeni.Show();
            
            

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {


            this.eLEMEGITableAdapter6.Fill(this.kUAFORD5.ELEMEGI);
            this.eLEMEGITableAdapter5.Fill(this.kUAFORD4.ELEMEGI);
            this.eLEMEGITableAdapter4.Fill(this.kUAFORD3.ELEMEGI);
            this.eLEMEGITableAdapter3.Fill(this.kUAFORD2.ELEMEGI);
            this.eLEMEGITableAdapter2.Fill(this.kUAFORDataSet2.ELEMEGI);
            this.eLEMEGITableAdapter1.Fill(this.kUAFORDataSet1.ELEMEGI);
            this.eLEMEGITableAdapter.Fill(this.kUAFORDataSet.ELEMEGI);

        }   

        private void button1_Click(object sender, EventArgs e)
        {

            label12.Text = comboBox1.SelectedValue.ToString();
            label13.Text = comboBox2.SelectedValue.ToString();
            label14.Text = comboBox3.SelectedValue.ToString();
            label15.Text = comboBox4.SelectedValue.ToString();
            label16.Text = comboBox5.SelectedValue.ToString();

            int toplam = 0;
            if (checkBox1.Checked)
                toplam = Convert.ToInt32(label12.Text);
            if(checkBox2.Checked)
                toplam = Convert.ToInt32(label13.Text);
            if (checkBox3.Checked)
                toplam = Convert.ToInt32(label14.Text);
            if (checkBox4.Checked)
                toplam = Convert.ToInt32(label15.Text);
            if (checkBox5.Checked)
                toplam = Convert.ToInt32(label16.Text);
            if (checkBox1.Checked && checkBox2.Checked)
                toplam = Convert.ToInt32(label12.Text) + Convert.ToInt32(label13.Text);
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
                toplam = Convert.ToInt32(label12.Text) + Convert.ToInt32(label13.Text)+ Convert.ToInt32(label14.Text);
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked)
                toplam = Convert.ToInt32(label12.Text) + Convert.ToInt32(label13.Text) + Convert.ToInt32(label14.Text) + Convert.ToInt32(label15.Text);
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked && checkBox4.Checked && checkBox5.Checked)
                toplam = Convert.ToInt32(label12.Text) + Convert.ToInt32(label13.Text) + Convert.ToInt32(label14.Text) + Convert.ToInt32(label15.Text) + Convert.ToInt32(label16.Text);
                textBox6.Text = toplam.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void randevuAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Randevucs yeni = new Randevucs();
            MainMenu.ActiveForm.Close();
            yeni.Show();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void comboBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

      
        private void programdanÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMenu.ActiveForm.Close();
            Application.Exit();
        
        }

        private void kullanıcıDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogin ma = new UserLogin();
            MainMenu.ActiveForm.Close();
            ma.Show();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            if (checkBox1.Checked)
            {

                comboBox1.Enabled = true;

                label12.Visible = true;
            }
            else
            {

                comboBox1.Enabled = false;

                label12.Visible = false;

            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            comboBox2.SelectedIndex = 0;

            if (checkBox2.Checked)
            {

                comboBox2.Enabled = true;

                label13.Visible = true;
            }
            else
            {

                comboBox2.Enabled = false;

                label13.Visible = false;

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            comboBox3.SelectedIndex = 0;

            if (checkBox3.Checked)
            {

                comboBox3.Enabled = true;

                label14.Visible = true;
            }
            else
            {

                comboBox3.Enabled = false;

                label14.Visible = false;

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

            comboBox4.SelectedIndex = 0;

            if (checkBox4.Checked)
            {

                comboBox4.Enabled = true;

                label15.Visible = true;
            }
            else
            {

                comboBox4.Enabled = false;

                label15.Visible = false;

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

            comboBox5.SelectedIndex = 0;

            if (checkBox5.Checked)
            {

                comboBox5.Enabled = true;

                label16.Visible = true;
            }
            else
            {

                comboBox5.Enabled = false;

                label16.Visible = false;

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void kullanıcıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kullanıcı_sil ks = new Kullanıcı_sil();
            ks.Show();
            this.Hide();
        }
    }
}
