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
    public class GameImages
    {
        private static GameImages _instance;
        
        // Görsel tipleri için dosya isimleri
        private Dictionary<Settings.ImageType, List<string>> _imageFilenamesByType;
        
        // Görsel dosyaları
        private Dictionary<string, Image> _imageCache;
        
        // Singleton örneği
        public static GameImages Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameImages();
                }
                return _instance;
            }
        }
        
        // Yapıcı metod
        private GameImages()
        {
            InitializeImageFilenames();
            _imageCache = new Dictionary<string, Image>();
        }
        
        // Görsel tipine göre adım numarasına uygun resmi döndürür
        public Image GetImage(Settings.ImageType imageType, int step)
        {
            if (!_imageFilenamesByType.ContainsKey(imageType))
                return null;
                
            var imageFilenames = _imageFilenamesByType[imageType];
            
            // Adım sayısını geçerli bir indeks yap
            step = Math.Max(0, Math.Min(step, imageFilenames.Count - 1));
            
            string baseFilename = imageFilenames[step];
            
            // Tüm olası yolları dene
            string[] possiblePaths = {
                baseFilename, // Doğrudan dosya adı
                Path.Combine(Application.StartupPath, baseFilename), // Uygulama klasörü 
                Path.GetFullPath(baseFilename), // Tam yol
                Path.Combine(Directory.GetCurrentDirectory(), baseFilename), // Geçerli klasör
                Path.Combine(Application.StartupPath, "bin", "Debug", baseFilename), // Debug klasörü
                Path.Combine(Application.StartupPath, "bin", "Release", baseFilename) // Release klasörü
            };
            
            string filename = null;
            
            // İlk var olan dosyayı bul
            foreach (string path in possiblePaths)
            {
                if (File.Exists(path))
                {
                    filename = path;
                    Console.WriteLine($"Görsel bulundu: {filename}");
                    break;
                }
            }
            
            // Hala bulunamadıysa hata ver
            if (filename == null)
            {
                Console.WriteLine($"Görsel bulunamadı: {baseFilename}");
                
                // Debug bilgisi
                Console.WriteLine($"Aranan yollar:");
                foreach (string path in possiblePaths)
                {
                    Console.WriteLine($" - {path} (Var mı: {File.Exists(path)})");
                }
                
                // Örnek görsel oluştur
                try
                {
                    CopyImages.CreateSampleImage(baseFilename, 
                        Color.White, 
                        $"{imageType} - {step+1}", 
                        200, 200);
                        
                    if (File.Exists(baseFilename))
                    {
                        filename = baseFilename;
                        Console.WriteLine($"Örnek görsel oluşturuldu: {filename}");
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Örnek görsel oluşturulamadı: {ex.Message}");
                    return null;
                }
            }
            
            // Önbellekte varsa oradan al
            if (_imageCache.ContainsKey(filename))
                return _imageCache[filename];
                
            try
            {
                // Dosyadan yükle
                Image image = Image.FromFile(filename);
                _imageCache[filename] = image;
                return image;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Resim yüklenirken hata oluştu: {ex.Message}\nDosya: {filename}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        
        // Bir görsel türü için maksimum adım sayısını döndürür
        public int GetMaxSteps(Settings.ImageType imageType)
        {
            if (!_imageFilenamesByType.ContainsKey(imageType))
                return 0;
                
            return _imageFilenamesByType[imageType].Count;
        }
        
        // Görsel türlerini döndür
        public List<Settings.ImageType> GetImageTypes()
        {
            return _imageFilenamesByType.Keys.ToList();
        }
        
        // Görsel dosya isimlerini başlat
        private void InitializeImageFilenames()
        {
            _imageFilenamesByType = new Dictionary<Settings.ImageType, List<string>>();
            
            // Adam As görselleri
            _imageFilenamesByType[Settings.ImageType.AdamAs] = new List<string>
            {
                "man-01.jpg", // 0 yanlış 
                "man-02.jpg", // 1 yanlış
                "man-03.jpg", // 2 yanlış
                "man-04.jpg", // 3 yanlış
                "man-05.jpg", // 4 yanlış
                "man-06.jpg", // 5 yanlış
                "man-07.jpg", // 6 yanlış
                "man-08.jpg", // 7 yanlış
                "man-09.jpg", // 8 yanlış
                "man-10.jpg", // 9 yanlış - oyun kaybedildi
            };
            
            // Çöp Adam As görselleri 
            _imageFilenamesByType[Settings.ImageType.CopAdamAs] = new List<string>
            {
                "1.jpg",  // 0 yanlış
                "2.jpg",  // 1 yanlış
                "3.jpg",  // 2 yanlış
                "4.jpg",  // 3 yanlış
                "5.jpg",  // 4 yanlış
                "6.jpg",  // 5 yanlış
                "7.jpg",  // 6 yanlış
                "8.jpg"   // 7 yanlış - oyun kaybedildi
            };
            
            // Çiçek Yapraklarını Kopar görselleri
            _imageFilenamesByType[Settings.ImageType.CicekYapraklariKopar] = new List<string>
            {
                "cicek1.jpg",  // 0 yanlış
                "cicek2.jpg",  // 1 yanlış
                "cicek3.jpg",  // 2 yanlış
                "cicek4.jpg",  // 3 yanlış
                "cicek5.jpg",  // 4 yanlış
                "cicek6.jpg",  // 5 yanlış
                "cicek7.jpg",  // 6 yanlış
                "cicek8.jpg",  // 7 yanlış
                "cicek9.jpg",  // 8 yanlış
                "cicek10.jpg", // 9 yanlış
                "cicek11.jpg", // 10 yanlış
                "cicek12.jpg"  // 11 yanlış - oyun kaybedildi
            };
        }
    }
} 