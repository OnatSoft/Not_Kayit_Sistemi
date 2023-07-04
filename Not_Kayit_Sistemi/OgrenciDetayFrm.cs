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
    public partial class OgrenciDetayFrm : Form
    {
        public OgrenciDetayFrm()
        {
            InitializeComponent();
        }

        public string numara;

        SqlConnection connection = new SqlConnection(@"");

        private void OgrenciDetayFrm_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;

            connection.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLDERS where OGRNUMARA=@p1", connection);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                LblSinav1.Text = dr[4].ToString();
                LblSinav2.Text = dr[5].ToString();
                LblPerf.Text = dr[6].ToString();
                LblOrtalama.Text = dr[7].ToString();
                LblDurum.Text = dr[8].ToString();
            }
            connection.Close();

            if (LblDurum.Text == "True")
            {
                LblDurum.Text = "Geçti";
            }
            else
            {
                LblDurum.Text = "Kaldı";
            }
        }
    }
}
