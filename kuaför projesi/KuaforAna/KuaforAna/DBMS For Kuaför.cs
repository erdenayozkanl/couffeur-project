using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuaforAna
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();

            Form2 frm2 = new Form2();
            //    Form3 frm3 = new Form3();
            //    Form4 frm4 = new Form4();
            //    Form5 frm5 = new Form5();
            //    Form6 frm6 = new Form6();
            //    Form7 frm7 = new Form7();
            //    Form8 frm8 = new Form8();
            //    Form9 frm9 = new Form9();
            //    Form10 frm10 = new Form10();
            //    Form11 frm11 = new Form11();
            //    Form12 frm12 = new Form12();
            //    Form13 frm13 = new Form13();

            frm2.MdiParent = frm1;
            frm2.Show();
        }

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
