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
    public partial class Frmgiris : MaterialForm
    {
        public Frmgiris()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE);
        }
        SqlConnection baglanti = new SqlConnection("Data Source=MIKAILPC\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void BtnGirisyap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where Kullaniciad=@p1 and sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",TxtKullaniciad.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaform frm = new FrmAnaform();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı Yada Hatalı");
            }
            baglanti.Close();

        }
    }
}
