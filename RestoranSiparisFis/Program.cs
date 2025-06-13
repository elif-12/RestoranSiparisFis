using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RestoranSiparisFis
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            // 🟣 3. AsciForm'u oluştur ve göster
            AsciForm asciForm = new AsciForm();
            asciForm.Show();

            // 🟢 1. MasaForm'u oluştur ve göster
            MasaForm masaForm = new MasaForm(asciForm);
            masaForm.Show();

            // 🔵 2. MenuForm'u oluştur, masaForm'u parametreyle gönder
            MenuForm menuForm = new MenuForm (masaForm,asciForm);
            menuForm.Show();

           

            // Uygulama açık kalsın
            Application.Run();
        }
    }
}
