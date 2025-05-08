using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Önce görselleri kopyala
            CopyImagesToOutputDirectory();

            // Kategorileri combobox'a ekle
            cmbCategory.Items.Clear();
            foreach (var category in WordDatabase.Instance.GetCategories())
            {
                cmbCategory.Items.Add(category);
            }
            
            // Varsayılan kategoriyi seç
            cmbCategory.SelectedItem = Settings.Instance.SelectedCategory;

            // Ana sayfada görsel yükle
            try
            {
                LoadAndDisplayImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Görsel yüklenirken hata oluştu: {ex.Message}", 
                    "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyImagesToOutputDirectory()
        {
            try
            {
                string outputDir = Application.StartupPath;
                string[] imagePatterns = { "*.jpg", "man-*.jpg", "cicek*.jpg" };
                
                // Görselleri kopyala
                string currentDir = Directory.GetCurrentDirectory();
                Console.WriteLine($"Uygulama klasörü: {currentDir}");
                Console.WriteLine($"Çıktı klasörü: {outputDir}");
                
                // Önce proje kök dizinindeki tüm jpg dosyalarını ara
                foreach (string pattern in imagePatterns)
                {
                    foreach (string sourceFile in Directory.GetFiles(currentDir, pattern))
                    {
                        string fileName = Path.GetFileName(sourceFile);
                        string destFile = Path.Combine(outputDir, fileName);
                        
                        // Dosya hedefte yoksa veya kaynaktaki daha yeniyse kopyala
                        if (!File.Exists(destFile) || 
                            File.GetLastWriteTime(sourceFile) > File.GetLastWriteTime(destFile))
                        {
                            Console.WriteLine($"Kopyalanıyor: {sourceFile} -> {destFile}");
                            File.Copy(sourceFile, destFile, true);
                        }
                    }
                }
                
                // Bin dizinindeki dosyaları listele
                Console.WriteLine("Çıktı klasöründeki dosyalar:");
                foreach (string file in Directory.GetFiles(outputDir, "*.jpg"))
                {
                    Console.WriteLine($" - {file}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Görselleri kopyalarken hata: {ex.Message}");
            }
        }

        // Görsel dosyasını yükleyip gösterme metodu
        private void LoadAndDisplayImage()
        {
            // Tüm olası görsel dosya adlarını dene
            string[] possibleImageFiles = {
                "man-01.jpg",
                "1.jpg",
                "cicek1.jpg",
                Application.StartupPath + "\\man-01.jpg",
                Application.StartupPath + "\\1.jpg",
                Application.StartupPath + "\\cicek1.jpg"
            };

            foreach (string imagePath in possibleImageFiles)
            {
                try
                {
                    if (File.Exists(imagePath))
                    {
                        pictureBox1.Image = new Bitmap(imagePath);
                        Console.WriteLine($"Görsel başarıyla yüklendi: {imagePath}");
                        return;
                    }
                }
                catch { /* Bir sonraki dosyayı dene */ }
            }

            // Hiçbir görsel dosyası bulunamadıysa, dosyaları çıktı klasörüne kopyala ve tekrar dene
            try
            {
                string debugDir = Path.Combine(Application.StartupPath);
                
                // Eğer görsel dosyaları mevcutsa, bunları çıktı klasörüne kopyala
                string[] imageFiles = Directory.GetFiles(".", "*.jpg");
                foreach (string file in imageFiles)
                {
                    string fileName = Path.GetFileName(file);
                    string destFile = Path.Combine(debugDir, fileName);
                    
                    if (!File.Exists(destFile))
                    {
                        File.Copy(file, destFile, true);
                        Console.WriteLine($"Dosya kopyalandı: {fileName} -> {destFile}");
                    }
                }
                
                // Tekrar görsel yüklemeyi dene
                if (File.Exists(Path.Combine(debugDir, "man-01.jpg")))
                {
                    pictureBox1.Image = new Bitmap(Path.Combine(debugDir, "man-01.jpg"));
                    Console.WriteLine("Görsel kopyalandıktan sonra yüklendi: man-01.jpg");
                }
                else if (File.Exists(Path.Combine(debugDir, "1.jpg")))
                {
                    pictureBox1.Image = new Bitmap(Path.Combine(debugDir, "1.jpg"));
                    Console.WriteLine("Görsel kopyalandıktan sonra yüklendi: 1.jpg");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Görselleri kopyalarken hata: {ex.Message}");
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Ayarlar formunu aç
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kategori seçin.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen kategoriyi ayarlara kaydet
            Settings.Instance.SelectedCategory = cmbCategory.SelectedItem.ToString();

            // Oyun formunu aç
            GameForm gameForm = new GameForm();
            gameForm.Show();
            this.Hide();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
} 