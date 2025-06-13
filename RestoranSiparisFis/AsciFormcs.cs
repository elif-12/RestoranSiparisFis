using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoranSiparisFis
{
    public partial class AsciForm : Form
    {
        public AsciForm()
        {
            InitializeComponent();
            this.Load += AsciFormcs_Load;

            lvwAsciSiparisler.View = View.Details;
            lvwAsciSiparisler.FullRowSelect = true;
            lvwAsciSiparisler.GridLines = true;

            lvwAsciSiparisler.Columns.Add("Masa", 100);
            lvwAsciSiparisler.Columns.Add("Ürün", 150);
            lvwAsciSiparisler.Columns.Add("Fiyat", 80);
        }

        private void AsciFormcs_Load(object sender, EventArgs e)
        {
            GuncelleSiparisler();

        }
        public void GuncelleSiparisler()
        {
            lvwAsciSiparisler.Items.Clear();

            foreach (var masa in SabitVeri.SiparisVeri)
            {
                foreach (var urun in masa.Value)
                {
                    var item = new ListViewItem(masa.Key);
                    item.SubItems.Add(urun.Ad);
                    item.SubItems.Add(urun.Fiyat.ToString("C"));

                    lvwAsciSiparisler.Items.Add(item);
                }
            }
        }

        private void lvwAsciSiparisler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
