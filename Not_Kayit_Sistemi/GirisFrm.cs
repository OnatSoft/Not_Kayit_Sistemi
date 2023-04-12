using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Not_Kayit_Sistemi
{
    public partial class GirisFrm : Form
    {
        public GirisFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciDetayFrm frm = new OgrenciDetayFrm();
            frm.numara = maskedTextBox1.Text;
            frm.Show();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "1111")
            {
                OgretmenDetayFrm ogretmenFrm = new OgretmenDetayFrm();
                ogretmenFrm.Show();
                maskedTextBox1.Text = "";
            }
        }

        private void GirisFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
