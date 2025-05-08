using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    // Not: Bu sınıf sadece örnek görselleri oluşturmak için kullanılabilir.
    // Gerçek uygulamada gerek yoktur, çünkü görsel dosyaları projeye eklenmelidir.
    public class CopyImages
    {
        public static void CreateSampleImages()
        {
            try
            {
                // Adam As görselleri (man-xx.jpg)
                if (!AreImagesCreated("man-01.jpg", "man-10.jpg"))
                {
                    CreateSampleImage("man-01.jpg", Color.White, "Adam As - 1", 200, 200);
                    CreateSampleImage("man-02.jpg", Color.White, "Adam As - 2", 200, 200);
                    CreateSampleImage("man-03.jpg", Color.White, "Adam As - 3", 200, 200);
                    CreateSampleImage("man-04.jpg", Color.White, "Adam As - 4", 200, 200);
                    CreateSampleImage("man-05.jpg", Color.White, "Adam As - 5", 200, 200);
                    CreateSampleImage("man-06.jpg", Color.White, "Adam As - 6", 200, 200);
                    CreateSampleImage("man-07.jpg", Color.White, "Adam As - 7", 200, 200);
                    CreateSampleImage("man-08.jpg", Color.White, "Adam As - 8", 200, 200);
                    CreateSampleImage("man-09.jpg", Color.White, "Adam As - 9", 200, 200);
                    CreateSampleImage("man-10.jpg", Color.White, "Adam As - 10", 200, 200);
                }
                
                // Çöp Adam As görselleri (1.jpg, 2.jpg, ...)
                if (!AreImagesCreated("1.jpg", "8.jpg"))
                {
                    CreateSampleImage("1.jpg", Color.LightYellow, "Çöp Adam - 1", 200, 200);
                    CreateSampleImage("2.jpg", Color.LightYellow, "Çöp Adam - 2", 200, 200);
                    CreateSampleImage("3.jpg", Color.LightYellow, "Çöp Adam - 3", 200, 200);
                    CreateSampleImage("4.jpg", Color.LightYellow, "Çöp Adam - 4", 200, 200);
                    CreateSampleImage("5.jpg", Color.LightYellow, "Çöp Adam - 5", 200, 200);
                    CreateSampleImage("6.jpg", Color.LightYellow, "Çöp Adam - 6", 200, 200);
                    CreateSampleImage("7.jpg", Color.LightYellow, "Çöp Adam - 7", 200, 200);
                    CreateSampleImage("8.jpg", Color.LightYellow, "Çöp Adam - 8", 200, 200);
                }
                
                // Çiçek Koparma görselleri (cicek1.jpg - cicek12.jpg)
                if (!AreImagesCreated("cicek1.jpg", "cicek12.jpg"))
                {
                    CreateSampleImage("cicek1.jpg", Color.LightGreen, "Çiçek - 1", 200, 200);
                    CreateSampleImage("cicek2.jpg", Color.LightGreen, "Çiçek - 2", 200, 200);
                    CreateSampleImage("cicek3.jpg", Color.LightGreen, "Çiçek - 3", 200, 200);
                    CreateSampleImage("cicek4.jpg", Color.LightGreen, "Çiçek - 4", 200, 200);
                    CreateSampleImage("cicek5.jpg", Color.LightGreen, "Çiçek - 5", 200, 200);
                    CreateSampleImage("cicek6.jpg", Color.LightGreen, "Çiçek - 6", 200, 200);
                    CreateSampleImage("cicek7.jpg", Color.LightGreen, "Çiçek - 7", 200, 200);
                    CreateSampleImage("cicek8.jpg", Color.LightGreen, "Çiçek - 8", 200, 200);
                    CreateSampleImage("cicek9.jpg", Color.LightGreen, "Çiçek - 9", 200, 200);
                    CreateSampleImage("cicek10.jpg", Color.LightGreen, "Çiçek - 10", 200, 200);
                    CreateSampleImage("cicek11.jpg", Color.LightGreen, "Çiçek - 11", 200, 200);
                    CreateSampleImage("cicek12.jpg", Color.LightGreen, "Çiçek - 12", 200, 200);
                }
                
                MessageBox.Show("Örnek görsel dosyaları oluşturuldu.", "Bilgi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Örnek görsel oluşturulurken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // Belirtilen ilk ve son dosya varsa true döndür
        private static bool AreImagesCreated(string firstFile, string lastFile)
        {
            return File.Exists(firstFile) && File.Exists(lastFile);
        }
        
        public static void CreateSampleImage(string filename, Color bgColor, string text, int width, int height)
        {
            // Dosya zaten varsa oluşturma
            if (File.Exists(filename))
                return;
                
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // Arka planı boya
                    g.Clear(bgColor);
                    
                    // Yazıyı ortaya yerleştir
                    using (Font font = new Font("Arial", 16, FontStyle.Bold))
                    {
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        
                        Rectangle rect = new Rectangle(0, 0, width, height);
                        g.DrawString(text, font, Brushes.Black, rect, sf);
                        
                        // Kenarlık çiz
                        g.DrawRectangle(Pens.Black, 0, 0, width - 1, height - 1);
                    }
                }
                
                bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
} 