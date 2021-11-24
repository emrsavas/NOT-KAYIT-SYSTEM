using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOT_KAYIT_SİSTEMİ
{
    public partial class FRMGİRİS : Form
    {
        public FRMGİRİS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmogrdetay frm = new frmogrdetay();
            frm.numara = maskedTextBox1.Text;
            frm.Show();

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "1111")
            {
                FRMOGRETMANDETAY fr = new FRMOGRETMANDETAY();
                fr.Show();

            }

        }
    }
}
