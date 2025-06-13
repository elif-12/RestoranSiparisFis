using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranSiparisFis
{
    public static class SabitVeri
    {
        public static List<Urun> TumUrunler = new List<Urun>
    {
        new Urun { Ad = "Mercimek", Fiyat = 50, Kategori = "Çorba" },
        new Urun { Ad = "Yayla", Fiyat = 50, Kategori = "Çorba" },
        new Urun { Ad = "Domates", Fiyat = 50, Kategori = "Çorba" },
        new Urun { Ad = "Ezogelin", Fiyat = 50, Kategori = "Çorba" },
        new Urun { Ad = "Tavuk Suyu", Fiyat = 50, Kategori = "Çorba" },

        new Urun { Ad = "Kebap", Fiyat = 250, Kategori = "Ana Yemek" },
        new Urun { Ad = "Tavuk Şiş", Fiyat = 200, Kategori = "Ana Yemek" },
        new Urun { Ad = "Ciğer", Fiyat = 230, Kategori = "Ana Yemek" },
        new Urun { Ad = "Kuru Fasulye", Fiyat = 250, Kategori = "Ana Yemek" },
        new Urun { Ad = "Beyti", Fiyat = 260, Kategori = "Ana Yemek" },
        new Urun { Ad = "Pilav", Fiyat = 70, Kategori = "Ana Yemek" },
        new Urun { Ad = "Lahmacun", Fiyat = 70, Kategori = "Ana Yemek" },

        new Urun{ Ad = "Cacık", Fiyat = 30, Kategori = "Meze" },
        new Urun{ Ad = "Salata", Fiyat = 30, Kategori = "Meze" },
        new Urun{ Ad = "Acılı Ezme", Fiyat = 30, Kategori = "Meze" },
        new Urun{ Ad = "Haydari", Fiyat = 30, Kategori = "Meze" },
        new Urun{ Ad = "Çiğ Köfte", Fiyat = 30, Kategori = "Meze" },

        new Urun { Ad = "Ayran", Fiyat = 35, Kategori = "İçecek" },
        new Urun { Ad = "Kola", Fiyat = 40, Kategori = "İçecek" },
        new Urun { Ad = "Gazoz", Fiyat = 40, Kategori = "İçecek" },
        new Urun { Ad = "Maden Suyu", Fiyat = 40, Kategori = "İçecek" },
        new Urun { Ad = "Çay", Fiyat = 20, Kategori = "İçecek" },
        new Urun { Ad = "Meyve Suyu", Fiyat = 30, Kategori = "İçecek" },

        new Urun { Ad = "Baklava", Fiyat = 100, Kategori = "Tatlı" },
        new Urun { Ad = "Supangle", Fiyat = 60, Kategori = "Tatlı" },
        new Urun { Ad = "Magnolia", Fiyat = 60, Kategori = "Tatlı" },
        new Urun { Ad = "Muhallebi", Fiyat = 60, Kategori = "Tatlı" },
        new Urun { Ad = "Sütlaç", Fiyat = 60, Kategori = "Tatlı" }
    };
        public static Dictionary<string, List<Urun>> SiparisVeri = new Dictionary<string, List<Urun>>();
        public static List<int> RezerveMasalar = new List<int> { 4, 9 }; // Örnek: 4 ve 9 numaralı masalar rezerve
    }

}
