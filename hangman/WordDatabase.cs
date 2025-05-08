using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    public class WordDatabase
    {
        private static WordDatabase _instance;
        
        // Soru sınıfı
        public class Word
        {
            public string Text { get; set; }
            public Settings.DifficultyLevel Difficulty { get; set; }
            public string Hint { get; set; }

            public Word(string text, Settings.DifficultyLevel difficulty, string hint = "")
            {
                Text = text;
                Difficulty = difficulty;
                Hint = hint;
            }
        }

        // Kategorili kelime listeleri
        private Dictionary<string, List<Word>> _wordsByCategory;

        // Singleton instance alma
        public static WordDatabase Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WordDatabase();
                }
                return _instance;
            }
        }

        // Yapıcı metod
        private WordDatabase()
        {
            InitializeWords();
        }

        // İstediğiniz kategoride ve zorlukta rastgele bir soru döndürür
        public Word GetRandomWord(string category, Settings.DifficultyLevel difficulty)
        {
            if (!_wordsByCategory.ContainsKey(category))
                return null;

            var wordsInCategoryAndDifficulty = _wordsByCategory[category]
                .Where(w => w.Difficulty == difficulty)
                .ToList();

            if (wordsInCategoryAndDifficulty.Count == 0)
                return null;

            Random rnd = new Random();
            int index = rnd.Next(wordsInCategoryAndDifficulty.Count);
            return wordsInCategoryAndDifficulty[index];
        }

        // Kategori listesini döndürür
        public List<string> GetCategories()
        {
            return _wordsByCategory.Keys.ToList();
        }

        // Kelime veritabanını başlatma
        private void InitializeWords()
        {
            _wordsByCategory = new Dictionary<string, List<Word>>();

            // Tarih kategorisi
            _wordsByCategory["Tarih"] = new List<Word>
            {
                new Word("İSTANBUL", Settings.DifficultyLevel.Kolay, "1453 yılında fethedilen şehir"),
                new Word("ATATÜRK", Settings.DifficultyLevel.Kolay, "Türkiye Cumhuriyeti'nin kurucusu"),
                new Word("CUMHURİYET", Settings.DifficultyLevel.Kolay, "29 Ekim 1923'te ilan edilmiştir"),
                new Word("MEŞRUTİYET", Settings.DifficultyLevel.Kolay, "Osmanlı'da ilan edilen yönetim şekli"),
                new Word("ENDERUN", Settings.DifficultyLevel.Orta, "Osmanlı saray okulu"),
                new Word("REFORM", Settings.DifficultyLevel.Orta, "Değişiklik, iyileştirme, düzeltme"),
                new Word("KURTULUŞ", Settings.DifficultyLevel.Orta, "19 Mayıs 1919'da başlayan süreç"),
                new Word("DOLMABAHÇE", Settings.DifficultyLevel.Orta, "Atatürk'ün vefat ettiği saray"),
                new Word("KANUNİ", Settings.DifficultyLevel.Zor, "Osmanlı'nın en uzun süre tahtta kalan padişahı"),
                new Word("LOZAN", Settings.DifficultyLevel.Zor, "Türkiye Cumhuriyeti'nin kuruluş belgesi sayılan antlaşma"),
                new Word("KAPİTÜLASYON", Settings.DifficultyLevel.Zor, "Osmanlı'yı zor duruma düşüren ayrıcalıklar"),
                new Word("ANADOLU", Settings.DifficultyLevel.Zor, "Türkiye'nin Asya kıtasındaki toprakları"),
                new Word("İNKILAP", Settings.DifficultyLevel.Kolay, "Köklü değişiklikler"),
                new Word("MEDENİYET", Settings.DifficultyLevel.Kolay, "Uygarlık"),
                new Word("MONDROS", Settings.DifficultyLevel.Orta, "30 Ekim 1918'de imzalanan ateşkes"),
                new Word("SEVR", Settings.DifficultyLevel.Orta, "Uygulanamayan antlaşma"),
                new Word("ÇANAKKALE", Settings.DifficultyLevel.Orta, "Önemli bir zafer kazanılan boğaz"),
                new Word("SANCAK", Settings.DifficultyLevel.Zor, "Osmanlı'da idari birim"),
                new Word("HATAY", Settings.DifficultyLevel.Zor, "1939'da anavatana katılan il"),
                new Word("HANEDAN", Settings.DifficultyLevel.Zor, "Osmanlı ailesinin adı")
            };

            // Coğrafya kategorisi
            _wordsByCategory["Coğrafya"] = new List<Word>
            {
                new Word("AKDENIZ", Settings.DifficultyLevel.Kolay, "Türkiye'nin güneyindeki deniz"),
                new Word("KARADENIZ", Settings.DifficultyLevel.Kolay, "Türkiye'nin kuzeyindeki deniz"),
                new Word("EVEREST", Settings.DifficultyLevel.Kolay, "Dünyanın en yüksek dağı"),
                new Word("EGE", Settings.DifficultyLevel.Kolay, "İzmir'in bulunduğu bölge"),
                new Word("FIRAT", Settings.DifficultyLevel.Orta, "Türkiye'den doğan önemli nehir"),
                new Word("AĞRI", Settings.DifficultyLevel.Orta, "Türkiye'nin en yüksek dağı"),
                new Word("MARMARA", Settings.DifficultyLevel.Orta, "İstanbul'un bulunduğu bölge"),
                new Word("HAZAR", Settings.DifficultyLevel.Orta, "Dünyanın en büyük gölü"),
                new Word("ADAPAZARI", Settings.DifficultyLevel.Zor, "Sakarya'nın merkezi"),
                new Word("AMAZON", Settings.DifficultyLevel.Zor, "Dünyanın en uzun nehri"),
                new Word("ENDONEZYA", Settings.DifficultyLevel.Zor, "Dünyanın en çok adaya sahip ülkesi"),
                new Word("PAMUKKALE", Settings.DifficultyLevel.Zor, "Denizli'deki traverten"),
                new Word("KAPADOKYA", Settings.DifficultyLevel.Kolay, "Peri bacalarıyla ünlü bölge"),
                new Word("KITA", Settings.DifficultyLevel.Kolay, "Büyük kara parçası"),
                new Word("İSTANBUL", Settings.DifficultyLevel.Kolay, "Türkiye'nin en kalabalık şehri"),
                new Word("ULUDAĞ", Settings.DifficultyLevel.Orta, "Kış turizmi merkezi"),
                new Word("VAN", Settings.DifficultyLevel.Orta, "Türkiye'nin en büyük gölünün adı"),
                new Word("KÜRESEL", Settings.DifficultyLevel.Zor, "Dünya çapında olan"),
                new Word("EKVATOR", Settings.DifficultyLevel.Zor, "Dünyayı ortadan ikiye bölen hayali çizgi"),
                new Word("KOORDİNAT", Settings.DifficultyLevel.Zor, "Bir yerin konumunu belirleyen değer")
            };

            // Matematik kategorisi
            _wordsByCategory["Matematik"] = new List<Word>
            {
                new Word("TOPLAMA", Settings.DifficultyLevel.Kolay, "Matematik işlemi"),
                new Word("ÇIKARMA", Settings.DifficultyLevel.Kolay, "Matematik işlemi"),
                new Word("BÖLME", Settings.DifficultyLevel.Kolay, "Matematik işlemi"),
                new Word("ÇARPMA", Settings.DifficultyLevel.Kolay, "Matematik işlemi"),
                new Word("KARE", Settings.DifficultyLevel.Kolay, "Dört kenarı eşit geometrik şekil"),
                new Word("PİSAGOR", Settings.DifficultyLevel.Orta, "Ünlü matematik teoremi"),
                new Word("TÜREV", Settings.DifficultyLevel.Orta, "Değişim oranını gösteren matematiksel işlem"),
                new Word("İNTEGRAL", Settings.DifficultyLevel.Orta, "Eğri altında kalan alan hesabı"),
                new Word("LOGARİTMA", Settings.DifficultyLevel.Orta, "Bir sayının üssü anlamındaki değer"),
                new Word("PASCAL", Settings.DifficultyLevel.Zor, "Ünlü matematikçi ve üçgen"),
                new Word("KOMBİNASYON", Settings.DifficultyLevel.Zor, "Grup oluşturma hesabı"),
                new Word("DETERMİNANT", Settings.DifficultyLevel.Zor, "Matris değeri"),
                new Word("PARABOL", Settings.DifficultyLevel.Kolay, "İkinci derece fonksiyonun grafiği"),
                new Word("ÜÇGEN", Settings.DifficultyLevel.Kolay, "Üç kenarlı şekil"),
                new Word("TEĞET", Settings.DifficultyLevel.Orta, "Bir noktada çembere dokunan doğru"),
                new Word("MATRİS", Settings.DifficultyLevel.Orta, "Satır ve sütunlardan oluşan sayı dizisi"),
                new Word("HİPOTENÜS", Settings.DifficultyLevel.Orta, "Dik üçgenin en uzun kenarı"),
                new Word("FAKTÖRIYEL", Settings.DifficultyLevel.Zor, "n! işlemi"),
                new Word("TANJANT", Settings.DifficultyLevel.Zor, "Sinüs bölü kosinüs"),
                new Word("KOORDİNAT", Settings.DifficultyLevel.Zor, "x,y noktaları")
            };

            // Genel Kültür kategorisi
            _wordsByCategory["Genel Kültür"] = new List<Word>
            {
                new Word("NOBEL", Settings.DifficultyLevel.Kolay, "Prestijli bir ödül"),
                new Word("MOZART", Settings.DifficultyLevel.Kolay, "Ünlü besteci"),
                new Word("KEDİ", Settings.DifficultyLevel.Kolay, "Popüler evcil hayvan"),
                new Word("İNTERNET", Settings.DifficultyLevel.Kolay, "Küresel ağ"),
                new Word("MİKROSKOP", Settings.DifficultyLevel.Orta, "Küçük cisimleri gösterme aracı"),
                new Word("TELEFON", Settings.DifficultyLevel.Orta, "İletişim aracı"),
                new Word("ORKESTRA", Settings.DifficultyLevel.Orta, "Müzik topluluğu"),
                new Word("BAĞIŞIKLIK", Settings.DifficultyLevel.Orta, "Hastalıklara karşı direnç"),
                new Word("ELEKTROMANYETİK", Settings.DifficultyLevel.Zor, "Fizikteki bir alan türü"),
                new Word("KRİPTOLOJİ", Settings.DifficultyLevel.Zor, "Şifre bilimi"),
                new Word("MİTOLOJİ", Settings.DifficultyLevel.Zor, "Efsaneler bilimi"),
                new Word("KALİGRAFİ", Settings.DifficultyLevel.Zor, "Güzel yazı sanatı"),
                new Word("HEYKEL", Settings.DifficultyLevel.Kolay, "Üç boyutlu sanat eseri"),
                new Word("ROMAN", Settings.DifficultyLevel.Kolay, "Uzun edebi eser"),
                new Word("SİNEMA", Settings.DifficultyLevel.Kolay, "Film gösterilen yer"),
                new Word("DÜRBÜN", Settings.DifficultyLevel.Orta, "Uzağı görme aracı"),
                new Word("FUTBOL", Settings.DifficultyLevel.Orta, "Popüler spor"),
                new Word("RADYASYON", Settings.DifficultyLevel.Zor, "Enerji yayılımı"),
                new Word("EPİDEMİYOLOJİ", Settings.DifficultyLevel.Zor, "Hastalık yayılımını inceleyen bilim"),
                new Word("ENTOMOLOJI", Settings.DifficultyLevel.Zor, "Böcek bilimi")
            };

            // Karma kategorisi (Tüm kategorilerden karışık seçilir)
            _wordsByCategory["Karma"] = new List<Word>();
            
            // Karma kategorisini doldur
            foreach (var category in _wordsByCategory.Keys.Where(c => c != "Karma"))
            {
                _wordsByCategory["Karma"].AddRange(_wordsByCategory[category]);
            }
        }
    }
} 