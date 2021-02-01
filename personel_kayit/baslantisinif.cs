using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
   
namespace personel_kayit
{
    class baslantisinif
    {

        public string Adress = System.IO.File.ReadAllText(@"C:\Users\asus\Desktop\C#\Adresim.txt");
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(Adress);
            baglan.Open();//baglan nesnenin adı
            return baglan;
        }
        
       
    }
}
