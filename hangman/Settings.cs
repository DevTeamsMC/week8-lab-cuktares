using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    public class Settings
    {
        // Singleton örneği
        private static Settings _instance;
        
        // Kategori seçimi
        public string SelectedCategory { get; set; } = "Genel Kültür";
        
        // Zorluk seviyesi
        public enum DifficultyLevel
        {
            Kolay,
            Orta,
            Zor
        }
        public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Orta;
        
        // Oyun süresi (saniye cinsinden)
        public int GameTime { get; set; } = 60;
        
        // Görsel tipi
        public enum ImageType
        {
            AdamAs,
            CopAdamAs,
            CicekYapraklariKopar
        }
        public ImageType SelectedImageType { get; set; } = ImageType.AdamAs;
        
        // Singleton örneğini alma metodu
        public static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Settings();
                }
                return _instance;
            }
        }
        
        // Private constructor (singleton pattern için)
        private Settings()
        {
        }
    }
} 