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
    public partial class FRMOGRETMANDETAY : Form
    {
        public FRMOGRETMANDETAY()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-NUIFV6S\SQLEXPRESS;Initial Catalog=
DBNOTKAYIT;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FRMOGRETMANDETAY_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBNOTKAYITDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dBNOTKAYITDataSet.TBLDERS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@P1,@P2,@P3)",baglanti);
            komut.Parameters.AddWithValue("@P1", msknumara.Text);
            komut.Parameters.AddWithValue("@P2", txtad.Text);
            komut.Parameters.AddWithValue("@P3", txtsoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ogr eklendi.");
            this.tBLDERSTableAdapter.Fill(this.dBNOTKAYITDataSet.TBLDERS);




        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            msknumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtsınav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtsınav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(txtsınav1.Text);
            s2 = Convert.ToDouble(txtsınav2.Text);
            s3 = Convert.ToDouble(txtsınav3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            lbort.Text = ortalama.ToString();
            if(ortalama>=50)
            {
                durum = "True";
            }
            false
                {
                durum = "False";
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update TBLDERS set OGRS1=@P1,OGRS2=@P2, OGRS3=@P3, ORTALAMA=@P4, DURUM=@P5 WHERE OGRNUMARA=@P6 ",baglanti);
            komut.Parameters.AddWithValue("@P1", txtsınav1.Text);
            komut.Parameters.AddWithValue("@P2", txtsınav2.Text);
            komut.Parameters.AddWithValue("@P3", txtsınav3.Text);
            komut.Parameters.AddWithValue("@P4", decimal.Parse(lbort.Text));
            komut.Parameters.AddWithValue("@P5", durum);
            komut.Parameters.AddWithValue("@P6", msknumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("ögrenbi not güncellendi");
            this.tBLDERSTableAdapter.Fill(this.dBNOTKAYITDataSet.TBLDERS);







        }
    }
}
