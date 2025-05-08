namespace hangman
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSettings = new System.Windows.Forms.Label();
            this.pictureBoxHangman = new System.Windows.Forms.PictureBox();
            this.lblWord = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.flowLayoutPanelLetters = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTimeLabel = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnMainMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHangman)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSettings.Location = new System.Drawing.Point(12, 9);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(59, 18);
            this.lblSettings.TabIndex = 0;
            this.lblSettings.Text = "Ayarlar:";
            // 
            // pictureBoxHangman
            // 
            this.pictureBoxHangman.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHangman.Location = new System.Drawing.Point(15, 47);
            this.pictureBoxHangman.Name = "pictureBoxHangman";
            this.pictureBoxHangman.Size = new System.Drawing.Size(233, 222);
            this.pictureBoxHangman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxHangman.TabIndex = 1;
            this.pictureBoxHangman.TabStop = false;
            // 
            // lblWord
            // 
            this.lblWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWord.Location = new System.Drawing.Point(254, 82);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(534, 58);
            this.lblWord.TabIndex = 2;
            this.lblWord.Text = "_ _ _ _ _";
            this.lblWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHint
            // 
            this.lblHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHint.Location = new System.Drawing.Point(255, 151);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(533, 51);
            this.lblHint.TabIndex = 3;
            this.lblHint.Text = "İpucu:";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelLetters
            // 
            this.flowLayoutPanelLetters.Location = new System.Drawing.Point(15, 295);
            this.flowLayoutPanelLetters.Name = "flowLayoutPanelLetters";
            this.flowLayoutPanelLetters.Size = new System.Drawing.Size(773, 143);
            this.flowLayoutPanelLetters.TabIndex = 4;
            // 
            // lblTimeLabel
            // 
            this.lblTimeLabel.AutoSize = true;
            this.lblTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTimeLabel.Location = new System.Drawing.Point(673, 47);
            this.lblTimeLabel.Name = "lblTimeLabel";
            this.lblTimeLabel.Size = new System.Drawing.Size(53, 20);
            this.lblTimeLabel.TabIndex = 5;
            this.lblTimeLabel.Text = "Süre:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTime.Location = new System.Drawing.Point(732, 47);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(29, 20);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "60";
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMainMenu.Location = new System.Drawing.Point(641, 222);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(132, 47);
            this.btnMainMenu.TabIndex = 7;
            this.btnMainMenu.Text = "Ana Menü";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTimeLabel);
            this.Controls.Add(this.flowLayoutPanelLetters);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblWord);
            this.Controls.Add(this.pictureBoxHangman);
            this.Controls.Add(this.lblSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adam Asmaca - Oyun";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHangman)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.PictureBox pictureBoxHangman;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLetters;
        private System.Windows.Forms.Label lblTimeLabel;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnMainMenu;
    }
} 