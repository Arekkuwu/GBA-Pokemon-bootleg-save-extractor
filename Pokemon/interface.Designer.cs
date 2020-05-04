namespace Pokemon
{
    partial class Software
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Software));
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.Button_Load_Rom = new System.Windows.Forms.Button();
            this.label_path = new System.Windows.Forms.Label();
            this.checkedListBox_Games = new System.Windows.Forms.CheckedListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label_selected_game = new System.Windows.Forms.Label();
            this.label_adress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Button_Load_Rom
            // 
            this.Button_Load_Rom.AllowDrop = true;
            this.Button_Load_Rom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Button_Load_Rom.Location = new System.Drawing.Point(118, 12);
            this.Button_Load_Rom.Name = "Button_Load_Rom";
            this.Button_Load_Rom.Size = new System.Drawing.Size(92, 46);
            this.Button_Load_Rom.TabIndex = 1;
            this.Button_Load_Rom.Text = "Load Rom";
            this.Button_Load_Rom.UseVisualStyleBackColor = true;
            this.Button_Load_Rom.Click += new System.EventHandler(this.Button_Load_Rom_Click);
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_path.Location = new System.Drawing.Point(9, 90);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(0, 17);
            this.label_path.TabIndex = 3;
            // 
            // checkedListBox_Games
            // 
            this.checkedListBox_Games.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkedListBox_Games.FormattingEnabled = true;
            this.checkedListBox_Games.Items.AddRange(new object[] {
            "Emerald",
            "FireRed"});
            this.checkedListBox_Games.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox_Games.Name = "checkedListBox_Games";
            this.checkedListBox_Games.Size = new System.Drawing.Size(92, 46);
            this.checkedListBox_Games.TabIndex = 4;
            this.checkedListBox_Games.ThreeDCheckBoxes = true;
            this.checkedListBox_Games.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBox_Games_ItemCheck);
            // 
            // label_selected_game
            // 
            this.label_selected_game.AutoSize = true;
            this.label_selected_game.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_selected_game.Location = new System.Drawing.Point(9, 70);
            this.label_selected_game.Name = "label_selected_game";
            this.label_selected_game.Size = new System.Drawing.Size(0, 17);
            this.label_selected_game.TabIndex = 5;
            // 
            // label_adress
            // 
            this.label_adress.AutoSize = true;
            this.label_adress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_adress.Location = new System.Drawing.Point(216, 26);
            this.label_adress.Name = "label_adress";
            this.label_adress.Size = new System.Drawing.Size(0, 17);
            this.label_adress.TabIndex = 6;
            // 
            // Software
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 121);
            this.Controls.Add(this.label_adress);
            this.Controls.Add(this.label_selected_game);
            this.Controls.Add(this.checkedListBox_Games);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.Button_Load_Rom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Software";
            this.Text = "GBA Pokemon bootleg save extractor";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button Button_Load_Rom;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.CheckedListBox checkedListBox_Games;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label_selected_game;
        private System.Windows.Forms.Label label_adress;
    }
}

