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
using MaterialSkin;
using MaterialSkin.Controls;

namespace personel_kayit
{
    public partial class FrmAnaform : MaterialForm
    {
       
        public FrmAnaform()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
           
            TxtAd.Focus();

        }
        baslantisinif bgl = new baslantisinif();
        

        void temizle()
        {
            TxtPersonelid.Clear();
            TxtAd.Clear();
            TxtSoyad.Clear();
            TxtMeslek.Clear();
            MskMaas.Clear();
            CmbSehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtAd.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            
            SqlCommand komutcb = new SqlCommand("Select distinct(Persehir) from Tbl_Personel", bgl.baglanti());
            SqlDataReader datar = komutcb.ExecuteReader();
            while (datar.Read())
            {
                CmbSehir.Items.Add(datar[0]);
            }
            bgl.baglanti().Close();

            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,persehir,permaas,permeslek,perdurum) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);//verilen parametreleri textboxdan atanır
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", MskMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtMeslek.Text);
            if (radioButton1.Checked==true)
            {
                komut.Parameters.AddWithValue("@p6", "True");
                label2.Text = "True";
            }
            if (radioButton2.Checked == true)
            {
                komut.Parameters.AddWithValue("@p6","False");
                label2.Text = "False";
            }
            komut.ExecuteNonQuery();//sorguyu çalıştır
            bgl.baglanti().Close();
            MessageBox.Show("Personel Eklendi");
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtPersonelid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskMaas.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

           
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            if (label2.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label2.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Personel Where Perid=@k1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@k1", TxtPersonelid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi");
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);


        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
          
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set perad=@a1,persoyad=@a2,persehir=@a3,permaas=@a4,perdurum=@a5,permeslek=@a6 where perid=@a7", bgl.baglanti());
            komutguncelle.Parameters.AddWithValue("@a1", TxtAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2", TxtSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", CmbSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", MskMaas.Text);
            if (radioButton1.Checked == true)
            {
                label2.Text = "True";
            }
            if (radioButton2.Checked == true)
            {
                label2.Text = "false";
            }
            komutguncelle.Parameters.AddWithValue("@a5", label2.Text);
            komutguncelle.Parameters.AddWithValue("@a6", TxtMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", TxtPersonelid.Text);
            komutguncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Bilgi Güncellendi");
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);


        }

        private void Btnİstatistik_Click(object sender, EventArgs e)
        {
            Frmİstatistik fr = new Frmİstatistik();
            fr.Show();

        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            FrmRaporlar fr = new FrmRaporlar();
            fr.Show();
        }
    }
}
