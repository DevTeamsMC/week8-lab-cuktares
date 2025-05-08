using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
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
            
            try
            {
                // Eksik görsel dosyaları için örnek görseller oluştur
                CopyImages.CreateSampleImages();
                
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Uygulama başlatılırken bir hata oluştu: " + ex.Message, 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
