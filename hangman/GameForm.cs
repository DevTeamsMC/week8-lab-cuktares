using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    public partial class GameForm : Form
    {
        private WordDatabase.Word _currentWord;
        private char[] _wordAsChars;
        private char[] _displayedWord;
        private List<char> _usedLetters;
        private int _wrongGuesses;
        private int _remainingTime;
        private Timer _gameTimer;
        
        public GameForm()
        {
            InitializeComponent();
            _gameTimer = new Timer();
            _gameTimer.Interval = 1000; // 1 saniye
            _gameTimer.Tick += GameTimer_Tick;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            // Ayarları göster
            lblSettings.Text = $"Süre: {Settings.Instance.GameTime} saniye - Kategori: {Settings.Instance.SelectedCategory} - Seviye: {Settings.Instance.Difficulty}";
            
            // Harfler için butonları oluştur
            CreateLetterButtons();
            
            // Yeni oyun başlat
            StartNewGame();
        }
        
        private void CreateLetterButtons()
        {
            // Türkçe alfabe
            string alphabet = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
            
            flowLayoutPanelLetters.Controls.Clear();
            
            for (int i = 0; i < alphabet.Length; i++)
            {
                Button btn = new Button();
                btn.Text = alphabet[i].ToString();
                btn.Name = "btnLetter" + alphabet[i];
                btn.Size = new Size(36, 36);
                btn.Margin = new Padding(5);
                btn.Font = new Font("Arial", 12, FontStyle.Bold);
                btn.Click += BtnLetter_Click;
                
                flowLayoutPanelLetters.Controls.Add(btn);
            }
        }
        
        private void BtnLetter_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            char guessedLetter = btn.Text[0];
            
            btn.Enabled = false;
            MakeGuess(guessedLetter);
        }
        
        private void MakeGuess(char letter)
        {
            // Daha önce kullanılan harf mi kontrol et
            if (_usedLetters.Contains(letter))
                return;
                
            _usedLetters.Add(letter);
            
            bool isCorrectGuess = false;
            
            // Doğru tahmin mi kontrol et
            for (int i = 0; i < _wordAsChars.Length; i++)
            {
                if (_wordAsChars[i] == letter)
                {
                    _displayedWord[i] = letter;
                    isCorrectGuess = true;
                }
            }
            
            // Tahmin sonucunu işle
            if (isCorrectGuess)
            {
                UpdateWordDisplay();
                
                // Kelime tamamen bulundu mu kontrol et
                if (!_displayedWord.Contains('_'))
                {
                    GameWon();
                }
            }
            else
            {
                _wrongGuesses++;
                UpdateHangmanImage();
                
                // Oyun kaybedildi mi kontrol et
                int maxWrongGuesses = GameImages.Instance.GetMaxSteps(Settings.Instance.SelectedImageType) - 1;
                if (_wrongGuesses >= maxWrongGuesses)
                {
                    GameLost();
                }
            }
        }
        
        private void UpdateHangmanImage()
        {
            pictureBoxHangman.Image = GameImages.Instance.GetImage(Settings.Instance.SelectedImageType, _wrongGuesses);
        }
        
        private void UpdateWordDisplay()
        {
            lblWord.Text = new string(_displayedWord);
        }
        
        private void StartNewGame()
        {
            // Yeni bir kelime seç
            _currentWord = WordDatabase.Instance.GetRandomWord(
                Settings.Instance.SelectedCategory,
                Settings.Instance.Difficulty);
                
            if (_currentWord == null)
            {
                MessageBox.Show("Seçilen kategoride kelime bulunamadı!", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            
            // Kelimeyi hazırla
            _wordAsChars = _currentWord.Text.ToUpper().ToCharArray();
            _displayedWord = new char[_wordAsChars.Length];
            
            // Görüntülenecek kelimeyi hazırla (_ ile doldur)
            for (int i = 0; i < _displayedWord.Length; i++)
            {
                _displayedWord[i] = '_';
            }
            
            // Diğer değişkenleri sıfırla
            _usedLetters = new List<char>();
            _wrongGuesses = 0;
            
            // Kelimeyi göster
            UpdateWordDisplay();
            
            // İpucu göster
            lblHint.Text = "İpucu: " + _currentWord.Hint;
            
            // Tüm harf butonlarını etkinleştir
            foreach (Button btn in flowLayoutPanelLetters.Controls)
            {
                btn.Enabled = true;
            }
            
            // Adam asmaca resmini sıfırla
            UpdateHangmanImage();
            
            // Zamanlayıcıyı başlat
            _remainingTime = Settings.Instance.GameTime;
            lblTime.Text = _remainingTime.ToString();
            _gameTimer.Start();
        }
        
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            _remainingTime--;
            lblTime.Text = _remainingTime.ToString();
            
            if (_remainingTime <= 0)
            {
                _gameTimer.Stop();
                GameLost();
            }
        }
        
        private void GameWon()
        {
            _gameTimer.Stop();
            MessageBox.Show("Tebrikler! Kelimeyi doğru tahmin ettiniz: " + _currentWord.Text,
                "Kazandınız", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            AskToPlayAgain();
        }
        
        private void GameLost()
        {
            _gameTimer.Stop();
            MessageBox.Show("Üzgünüm, kaybettiniz! Doğru kelime: " + _currentWord.Text,
                "Kaybettiniz", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            AskToPlayAgain();
        }
        
        private void AskToPlayAgain()
        {
            DialogResult result = MessageBox.Show("Tekrar oynamak ister misiniz?",
                "Oyun Bitti", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                StartNewGame();
            }
            else
            {
                this.Close();
            }
        }
        
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            _gameTimer.Stop();
            this.Close();
        }
        
        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _gameTimer.Stop();
            // Ana menüyü göster
            foreach (Form form in Application.OpenForms)
            {
                if (form is MainForm)
                {
                    form.Show();
                    break;
                }
            }
        }
    }
} 