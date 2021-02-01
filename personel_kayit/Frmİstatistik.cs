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

namespace personel_kayit
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=MIKAILPC\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select count(*) From Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) From Tbl_Personel Where perdurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevliper.Text = dr2[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select count(*) From Tbl_Personel Where perdurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekarPer.Text = dr3[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count(distinct(PerSehir)) From Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblSehirSayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select sum(permaas) From Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblToplamMaas.Text = dr5[0] + " ₺";
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select avg(permaas) From Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblOrtMaas.Text = dr6[0]+" ₺";
            }
            baglanti.Close();

        }
    }
}
