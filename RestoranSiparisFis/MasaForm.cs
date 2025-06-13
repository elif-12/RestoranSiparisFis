using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RestoranSiparisFis
{
  
    public partial class MasaForm : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private AsciForm asciForm;
        private string seciliMasa;

        public MasaForm(AsciForm asci)
        {
            InitializeComponent();
            asciForm = asci;
            this.Load += MasaForm_Load;

            btnSil.Click += button1_Click;
            
            lvwSiparisler.View = View.Details;
            lvwSiparisler.FullRowSelect = true;
            lvwSiparisler.GridLines = true;
            lvwSiparisler.Columns.Add("Ürün", 100);
            lvwSiparisler.Columns.Add("Fiyat", 80);
        }

        public string SeciliMasa => seciliMasa;

        private void MasaForm_Load(object sender, EventArgs e)
        {
            flowMasalar.AutoScroll = true;
            flowMasalar.WrapContents = true;
            flowMasalar.FlowDirection = FlowDirection.LeftToRight;
            flowMasalar.Controls.Clear();

            for (int i = 1; i <= 10; i++)
            {
                Button masaBtn = new Button();
                masaBtn.Text = $"Masa {i}";
                masaBtn.Tag = $"Masa {i}";
                masaBtn.Name = $"btnMasa{i}";
                masaBtn.Width = 100;
                masaBtn.Height = 60;
                masaBtn.Margin = new Padding(10);
                masaBtn.FlatStyle = FlatStyle.Flat;
                masaBtn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                masaBtn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, masaBtn.Width, masaBtn.Height, 15, 15));

                if (SabitVeri.RezerveMasalar.Contains(i))
                    masaBtn.BackColor = Color.FromArgb(249, 215, 203);// rezerve masalar
                else if (SabitVeri.SiparisVeri.ContainsKey($"Masa {i}"))
                    masaBtn.BackColor = Color.FromArgb(229, 221, 231); // dolu masa rengi
                else
                    masaBtn.BackColor = Color.FromArgb(230, 210, 225); // boş masa rengi

                masaBtn.Click += MasaSecildi;
                flowMasalar.Controls.Add(masaBtn);
            }

            seciliMasa = "Masa 1";
            SiparisleriGoster(seciliMasa);
        }

        private void MasaSecildi(object sender, EventArgs e)
        {
            var btn = sender as Button;
            seciliMasa = btn.Tag.ToString();
            SiparisleriGoster(seciliMasa);
        }

        public void UrunEkle(string masa, Urun urun)
        {
            if (!SabitVeri.SiparisVeri.ContainsKey(masa))
                SabitVeri.SiparisVeri[masa] = new List<Urun>();

            SabitVeri.SiparisVeri[masa].Add(urun);

            SiparisleriGoster(masa);
        }

        private void SiparisleriGoster(string masa)
        {
            lvwSiparisler.Items.Clear();

            if (SabitVeri.SiparisVeri.ContainsKey(masa))
            {
                foreach (var urun in SabitVeri.SiparisVeri[masa])
                {
                    var satir = new ListViewItem(urun.Ad);
                    satir.SubItems.Add(urun.Fiyat.ToString("₺0"));
                    lvwSiparisler.Items.Add(satir);
                }

                decimal toplam = SabitVeri.SiparisVeri[masa].Sum(u => u.Fiyat);
                lblToplam.Text = $"Toplam: ₺{toplam}";
            }
            else
            {
                lblToplam.Text = "Toplam: ₺0";
            }
        }

        private void btnFisYazdir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(seciliMasa))
            {
                MessageBox.Show("Lütfen bir masa seçin.");
                return;
            }

            string masa = seciliMasa;

            if (!SabitVeri.SiparisVeri.ContainsKey(masa) || SabitVeri.SiparisVeri[masa].Count == 0)
            {
                MessageBox.Show("Bu masada sipariş bulunmuyor.");
                return;
            }

            var urunler = SabitVeri.SiparisVeri[masa];
            StringBuilder fis = new StringBuilder();

            fis.AppendLine("========== RESTORAN FİŞ ==========");
            fis.AppendLine($"Masa: {masa}");
            fis.AppendLine("Tarih: " + DateTime.Now.ToString("g"));
            fis.AppendLine("----------------------------------");

            decimal toplam = 0;
            foreach (var urun in urunler)
            {
                fis.AppendLine($"{urun.Ad} - ₺{urun.Fiyat}");
                toplam += urun.Fiyat;
            }

            fis.AppendLine("----------------------------------");
            fis.AppendLine($"Toplam: ₺{toplam}");
            fis.AppendLine("==================================");

            try
            {
                string dosyaAdi = $"Fis_{masa}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                string masaustuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string tamYol = Path.Combine(masaustuYolu, dosyaAdi);

                File.WriteAllText(tamYol, fis.ToString());

                MessageBox.Show($"Fiş başarıyla masaüstüne kaydedildi:\n{tamYol}", "Fiş Yazdırıldı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Masa butonunu kırmızıya çevir (dolu)
                foreach (Control ctrl in flowMasalar.Controls)
                {
                    if (ctrl is Button btn && btn.Tag.ToString() == masa)
                    {
                        btn.BackColor = Color.IndianRed;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fiş kaydedilirken bir hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblToplam_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e) // sipairşten ürün silme 
        {
            if (string.IsNullOrEmpty(seciliMasa) || lvwSiparisler.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen silmek için bir ürün seçin.");
                return;
            }

            string masa = seciliMasa;
            string silinecekUrunAdi = lvwSiparisler.SelectedItems[0].Text;

            if (SabitVeri.SiparisVeri.ContainsKey(masa))
            {
                var urunListesi = SabitVeri.SiparisVeri[masa];
                var silinecekUrun = urunListesi.FirstOrDefault(u => u.Ad == silinecekUrunAdi);
                if (silinecekUrun != null)
                {
                    urunListesi.Remove(silinecekUrun);
                    SiparisleriGoster(masa);
                    asciForm.GuncelleSiparisler();
                    lvwSiparisler.SelectedItems.Clear();

                    if (urunListesi.Count == 0)
                    {
                        foreach (Control ctrl in flowMasalar.Controls)
                        {
                            if (ctrl is Button btn && btn.Tag.ToString() == masa)
                            {
                                btn.BackColor = Color.LightGreen;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void lstSiparisler_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lvwSiparisler_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
