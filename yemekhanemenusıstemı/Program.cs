using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace yemekhanemenusıstemı
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var connString = ConfigurationManager.ConnectionStrings["DefaultConnection"];
            if (connString == null)
            {
                MessageBox.Show(
                    "Connection string 'DefaultConnection' bulunamadı!\n\n" +
                    "Lütfen şunları kontrol edin:\n" +
                    "1. App.config dosyasında connectionStrings bölümü var mı?\n" +
                    "2. bin\\Debug\\yemekhanemenusıstemı.exe.config dosyasında connectionStrings var mı?\n" +
                    "3. Projeyi Clean ve Rebuild yaptınız mı?\n\n" +
                    "Çözüm: bin\\Debug klasöründeki .exe.config dosyasını silin ve projeyi yeniden derleyin.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Form1());
        }
    }
}
