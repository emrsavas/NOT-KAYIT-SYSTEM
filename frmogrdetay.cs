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


namespace NOT_KAYIT_SİSTEMİ
{
    public partial class frmogrdetay : Form
    {
        public frmogrdetay()
        {
            InitializeComponent();
        }

        //
        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NUIFV6S\SQLEXPRESS;Initial Catalog=
DBNOTKAYIT;Integrated Security=True");
        private void frmogrdetay_Load(object sender, EventArgs e)
        {
            LBNUMARA.Text = numara;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLDERS where OGRNUMARA=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                LNADSOYAD.Text = dr[2].ToString() + "" + dr[3].ToString();
                LBSINAV1.Text = dr[4].ToString();
                LBSINA2.Text = dr[5].ToString();
                LBSINA3.Text = dr[6].ToString();
                LBORT.Text = dr[7].ToString();
                LBDURUM.Text = dr[8].ToString();

            }
            baglanti.Close();
                
        }
    }
}
