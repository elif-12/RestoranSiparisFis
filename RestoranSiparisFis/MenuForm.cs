using RestoranSiparisFis;
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


    public partial class MenuForm : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private MasaForm masaForm;
        private AsciForm asciForm;

        public MenuForm(MasaForm masa, AsciForm asci)
        {
            InitializeComponent();
            masaForm = masa;
            asciForm = asci;

            this.Load += MenuForm_Load;
        }

        public string SeciliMasa => masaForm.SeciliMasa;

        private void MenuForm_Load(object sender, EventArgs e)
        {
            var kategoriler = SabitVeri.TumUrunler
                .Select(u => u.Kategori)
                .Distinct()
                .ToList();

            flowKategoriler.Controls.Clear();

            foreach (var kategori in kategoriler)
            {
                Button kategoriBtn = new Button();
                kategoriBtn.Text = kategori;
                kategoriBtn.Width = 110;
                kategoriBtn.Height = 50;
                kategoriBtn.Margin = new Padding(80, 10, 0, 10);
                kategoriBtn.BackColor = Color.FromArgb(240, 230, 220); // ketegorilerin rengi

                kategoriBtn.FlatStyle = FlatStyle.Flat;
                kategoriBtn.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                kategoriBtn.Click += (s, ev) => KategoriSecildi(kategori);
                flowKategoriler.Controls.Add(kategoriBtn);
            }

            if (kategoriler.Count > 0)
                KategoriSecildi(kategoriler[0]);
        }

        private void KategoriSecildi(string kategori)
        {
            flowUrunler.Controls.Clear();

            var urunler = SabitVeri.TumUrunler
                .Where(u => u.Kategori == kategori)
                .ToList();

            foreach (var urun in urunler)
            {
                urun.ResimYolu = Path.Combine(Application.StartupPath, "resimler", urun.Ad.ToLower().Replace(" ", "_") + ".jpg");
                Panel kart = new Panel();
                kart.Width = 200;
                kart.Height = 150;
                kart.BackColor = Color.WhiteSmoke;
                kart.Margin = new Padding(10);
                kart.BorderStyle = BorderStyle.FixedSingle;

                kart.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, kart.Width, kart.Height, 15, 15));


                kart.Paint += (s, e) =>
                {
                    ControlPaint.DrawBorder(e.Graphics, kart.ClientRectangle,
                        Color.Gray, 2, ButtonBorderStyle.Solid,
                        Color.Gray, 2, ButtonBorderStyle.Solid,
                        Color.Gray, 2, ButtonBorderStyle.Solid,
                        Color.Gray, 2, ButtonBorderStyle.Solid);
                        kart.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, kart.Width, kart.Height, 15, 15));

                };

                PictureBox pic = new PictureBox();
                if (!string.IsNullOrEmpty(urun.ResimYolu) && File.Exists(urun.ResimYolu))
                {
                    pic.Image = Image.FromFile(urun.ResimYolu);
                }
                else
                {
                    pic.Image = SystemIcons.Question.ToBitmap();
                }
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Location = new Point(10, 10);
                pic.Size = new Size(60, 60);

                Label lblAd = new Label
                {
                    Text = urun.Ad,
                    Location = new Point(80, 10),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    AutoSize = true
                };

                Label lblFiyat = new Label
                {
                    Text = $"₺{urun.Fiyat}",
                    Location = new Point(80, 35),
                    AutoSize = true
                };

                Button btnEkle = new Button
                {
                    Text = "+ Ekle",
                    Location = new Point(80, 60),
                    Width = 100,
                    Tag = urun
                };

                btnEkle.Click += (s, e) =>
                {
                    Button tiklanan = s as Button;
                    Urun secilenUrun = tiklanan.Tag as Urun;

                    string masa = SeciliMasa;
                    masaForm.UrunEkle(masa, secilenUrun);
                    asciForm.GuncelleSiparisler();
                    MessageBox.Show($"{masa} için {secilenUrun.Ad} eklendi.");
                };

                kart.Controls.Add(pic);
                kart.Controls.Add(lblAd);
                kart.Controls.Add(lblFiyat);
                kart.Controls.Add(btnEkle);
                flowUrunler.Controls.Add(kart);
            }
        }

        private void flowKategoriler_Paint(object sender, PaintEventArgs e)
        {
           
        }

    }
}
    

