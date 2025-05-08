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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            // Zorluk seviyelerini combo box'a ekle
            cmbDifficulty.Items.Clear();
            foreach (var difficulty in Enum.GetValues(typeof(Settings.DifficultyLevel)))
            {
                cmbDifficulty.Items.Add(difficulty);
            }
            
            // Görsel tiplerini combo box'a ekle
            cmbImageType.Items.Clear();
            foreach (var imageType in Enum.GetValues(typeof(Settings.ImageType)))
            {
                cmbImageType.Items.Add(imageType);
            }
            
            // Mevcut ayarları seç
            cmbDifficulty.SelectedItem = Settings.Instance.Difficulty;
            numGameTime.Value = Settings.Instance.GameTime;
            cmbImageType.SelectedItem = Settings.Instance.SelectedImageType;
            
            // Seçilen görsel tipini göster
            ShowSelectedImagePreview();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbDifficulty.SelectedItem == null)
            {
                MessageBox.Show("Lütfen zorluk seviyesi seçin.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (cmbImageType.SelectedItem == null)
            {
                MessageBox.Show("Lütfen görsel tipi seçin.", "Uyarı", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Ayarları kaydet
            Settings.Instance.Difficulty = (Settings.DifficultyLevel)cmbDifficulty.SelectedItem;
            Settings.Instance.GameTime = (int)numGameTime.Value;
            Settings.Instance.SelectedImageType = (Settings.ImageType)cmbImageType.SelectedItem;
            
            MessageBox.Show("Ayarlar kaydedildi.", "Bilgi", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowSelectedImagePreview();
        }
        
        private void ShowSelectedImagePreview()
        {
            if (cmbImageType.SelectedItem == null)
                return;
                
            // Seçilen görsel tipine göre ilk resmi göster
            Settings.ImageType selectedImageType = (Settings.ImageType)cmbImageType.SelectedItem;
            Image image = GameImages.Instance.GetImage(selectedImageType, 0);
            
            if (image != null)
            {
                pictureBoxPreview.Image = image;
            }
        }
    }
} 