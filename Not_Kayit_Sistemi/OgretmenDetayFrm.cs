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

namespace Not_Kayit_Sistemi
{
    public partial class OgretmenDetayFrm : Form
    {
        public OgretmenDetayFrm()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-ONATSOFT\ONATSOFT;Initial Catalog=NotKayitDB;Integrated Security=True");

        private void OgretmenDetayFrm_Load(object sender, EventArgs e)
        {
            this.tBLDERSTableAdapter.Fill(this.notKayitDBDataSet.TBLDERS);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS (OGRNUMARA, OGRAD, OGRSOYAD) values (@P1, @P2, @P3)", connection);
            komut.Parameters.AddWithValue("@P1", MaskedTxtNumara.Text);
            komut.Parameters.AddWithValue("@P2", TxtAd.Text);
            komut.Parameters.AddWithValue("@P3", TxtSoyad.Text);

            if (MaskedTxtNumara.Text != "" && TxtAd.Text != "" && TxtSoyad.Text != "")
            {
                komut.ExecuteNonQuery();
                MessageBox.Show("Öğrenci başarıyla tabloya kaydedildi.", "Öğrenci Ekle");
            }

            this.tBLDERSTableAdapter.Fill(this.notKayitDBDataSet.TBLDERS);
            connection.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatir = dataGridView1.SelectedCells[0].RowIndex;

            MaskedTxtNumara.Text = dataGridView1.Rows[secilensatir].Cells[1].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilensatir].Cells[2].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilensatir].Cells[3].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[secilensatir].Cells[4].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[secilensatir].Cells[5].Value.ToString();
            TxtPerf.Text = dataGridView1.Rows[secilensatir].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(TxtSinav1.Text);
            s2 = Convert.ToDouble(TxtSinav2.Text);
            s3 = Convert.ToDouble(TxtPerf.Text);
            ortalama = (s1 + s2 + s3) / 3;
            LblOrtalama.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            connection.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set SİNAV1=@P1, SİNAV2=@P2, PERFORMANS=@P3, ORTALAMA=@P4, DURUM=@P5 where OGRNUMARA=@P6", connection);
            komut.Parameters.AddWithValue("@P1", TxtSinav1.Text);
            komut.Parameters.AddWithValue("@P2", TxtSinav2.Text);
            komut.Parameters.AddWithValue("@P3", TxtPerf.Text);
            komut.Parameters.AddWithValue("@P4", decimal.Parse(LblOrtalama.Text));
            komut.Parameters.AddWithValue("@P5", durum);
            komut.Parameters.AddWithValue("@P6", MaskedTxtNumara.Text);
            komut.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Öğrenci notları başarıyla güncellendi.", "Not Girişi");
            this.tBLDERSTableAdapter.Fill(this.notKayitDBDataSet.TBLDERS);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(TxtSinav1.Text);
            s2 = Convert.ToDouble(TxtSinav2.Text);
            s3 = Convert.ToDouble(TxtPerf.Text);
            ortalama = (s1 + s2 + s3) / 3;
            LblOrtalama.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                LblDurum.Text = "Geçiyor.";
                LblDurum.BackColor = Color.LimeGreen;
            }
            else
            {
                LblDurum.Text = "Kalıyor.";
                LblDurum.BackColor = Color.Red;
            }
        }
    }
}
