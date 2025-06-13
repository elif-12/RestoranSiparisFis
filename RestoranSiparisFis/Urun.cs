using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranSiparisFis
{
    public class Urun : IYemek, IYazdirilabilir
    {
        public string ResimYolu { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public string Kategori { get; set; }

        public string Yazdir()
        {
            return $"{Ad} - ₺{Fiyat}";
        }

        public override string ToString()
        {
            return Yazdir(); // ListBox'ta düzgün görünmesi için
        }
    }
}
