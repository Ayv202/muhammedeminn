using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLNStokTakip.Hangar;

namespace SLNStokTakip.Stok
{
    public partial class frmStokDurum : Form
    {

        DbStokDataContext _db = new DbStokDataContext();
        Mesajlar _m = new Mesajlar();
        Formlar _f = new Formlar();

        public bool Secim = false;
        public frmStokDurum()
        {
            InitializeComponent();
        }

        private void frmStokDurum_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            Liste.Rows.Clear();
            int i = 0;
            var lst = (from c in _db.stStokDurums
                       where c.UrunKodu.Contains(txtStokDurum.Text)
                       select c).ToList();

            foreach (var s in lst)
            {
                Liste.Rows.Add();
                Liste.Rows[i].Cells[0].Value = s.Id;
                Liste.Rows[i].Cells[1].Value = s.UrunKodu;
                Liste.Rows[i].Cells[2].Value = s.LotSeriNo;
                Liste.Rows[i].Cells[3].Value = s.Adet;
                Liste.Rows[i].Cells[4].Value = s.Aciklama;
                i++;
            }
            Liste.AllowUserToAddRows = false;
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void txtStokDurum_TextChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
