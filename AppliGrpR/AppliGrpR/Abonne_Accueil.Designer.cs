
namespace AppliGrpR
{
    partial class Abonne_Accueil
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
            this.AlbumsConseillés = new System.Windows.Forms.ListBox();
            this.AlbumsEmpruntes = new System.Windows.Forms.ListBox();
            this.TousLesAlbums = new System.Windows.Forms.ListBox();
            this.AlbumsEmpruntés = new System.Windows.Forms.Label();
            this.RechercherTextBox = new System.Windows.Forms.TextBox();
            this.RechercherAlbum = new System.Windows.Forms.Label();
            this.Tous_Les_Albums = new System.Windows.Forms.Label();
            this.Albums_Conseillés = new System.Windows.Forms.Label();
            this.accueil = new System.Windows.Forms.Label();
            this.déconnexion = new System.Windows.Forms.Button();
            this.Prolonger_un_emprunt = new System.Windows.Forms.Button();
            this.Emprunter = new System.Windows.Forms.Button();
            this.ButtonRightEmprunt = new System.Windows.Forms.Button();
            this.ButtonLeftEmprunt = new System.Windows.Forms.Button();
            this.ToutLeftButton = new System.Windows.Forms.Button();
            this.ToutRightButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pageEmprunté = new System.Windows.Forms.Label();
            this.pageAlbum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AlbumsConseillés
            // 
            this.AlbumsConseillés.FormattingEnabled = true;
            this.AlbumsConseillés.Location = new System.Drawing.Point(147, 245);
            this.AlbumsConseillés.Name = "AlbumsConseillés";
            this.AlbumsConseillés.Size = new System.Drawing.Size(793, 160);
            this.AlbumsConseillés.TabIndex = 1;
            // 
            // AlbumsEmpruntes
            // 
            this.AlbumsEmpruntes.FormattingEnabled = true;
            this.AlbumsEmpruntes.Location = new System.Drawing.Point(147, 74);
            this.AlbumsEmpruntes.Name = "AlbumsEmpruntes";
            this.AlbumsEmpruntes.Size = new System.Drawing.Size(793, 134);
            this.AlbumsEmpruntes.TabIndex = 2;
            // 
            // TousLesAlbums
            // 
            this.TousLesAlbums.FormattingEnabled = true;
            this.TousLesAlbums.Location = new System.Drawing.Point(147, 455);
            this.TousLesAlbums.Name = "TousLesAlbums";
            this.TousLesAlbums.Size = new System.Drawing.Size(416, 134);
            this.TousLesAlbums.TabIndex = 3;
            this.TousLesAlbums.SelectedIndexChanged += new System.EventHandler(this.TousLesAlbums_SelectedIndexChanged);
            // 
            // AlbumsEmpruntés
            // 
            this.AlbumsEmpruntés.AutoSize = true;
            this.AlbumsEmpruntés.Location = new System.Drawing.Point(144, 58);
            this.AlbumsEmpruntés.Name = "AlbumsEmpruntés";
            this.AlbumsEmpruntés.Size = new System.Drawing.Size(94, 13);
            this.AlbumsEmpruntés.TabIndex = 4;
            this.AlbumsEmpruntés.Text = "Albums Empruntés";
            // 
            // RechercherTextBox
            // 
            this.RechercherTextBox.Location = new System.Drawing.Point(228, 430);
            this.RechercherTextBox.Name = "RechercherTextBox";
            this.RechercherTextBox.Size = new System.Drawing.Size(100, 20);
            this.RechercherTextBox.TabIndex = 42;
            this.RechercherTextBox.TextChanged += new System.EventHandler(this.RechercherTextBox_TextChanged);
            // 
            // RechercherAlbum
            // 
            this.RechercherAlbum.AutoSize = true;
            this.RechercherAlbum.Location = new System.Drawing.Point(148, 434);
            this.RechercherAlbum.Name = "RechercherAlbum";
            this.RechercherAlbum.Size = new System.Drawing.Size(69, 13);
            this.RechercherAlbum.TabIndex = 43;
            this.RechercherAlbum.Text = "Rechercher :";
            // 
            // Tous_Les_Albums
            // 
            this.Tous_Les_Albums.AutoSize = true;
            this.Tous_Les_Albums.Location = new System.Drawing.Point(144, 414);
            this.Tous_Les_Albums.Name = "Tous_Les_Albums";
            this.Tous_Les_Albums.Size = new System.Drawing.Size(88, 13);
            this.Tous_Les_Albums.TabIndex = 44;
            this.Tous_Les_Albums.Text = "Tous Les Albums";
            // 
            // Albums_Conseillés
            // 
            this.Albums_Conseillés.AutoSize = true;
            this.Albums_Conseillés.Location = new System.Drawing.Point(144, 229);
            this.Albums_Conseillés.Name = "Albums_Conseillés";
            this.Albums_Conseillés.Size = new System.Drawing.Size(91, 13);
            this.Albums_Conseillés.TabIndex = 45;
            this.Albums_Conseillés.Text = "Albums Conseillés";
            // 
            // accueil
            // 
            this.accueil.AutoSize = true;
            this.accueil.Location = new System.Drawing.Point(512, 39);
            this.accueil.Name = "accueil";
            this.accueil.Size = new System.Drawing.Size(42, 13);
            this.accueil.TabIndex = 46;
            this.accueil.Text = "Accueil";
            // 
            // déconnexion
            // 
            this.déconnexion.Location = new System.Drawing.Point(985, 12);
            this.déconnexion.Name = "déconnexion";
            this.déconnexion.Size = new System.Drawing.Size(87, 23);
            this.déconnexion.TabIndex = 47;
            this.déconnexion.Text = "Déconnexion";
            this.déconnexion.UseVisualStyleBackColor = true;
            this.déconnexion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Retour_MouseDown);
            // 
            // Prolonger_un_emprunt
            // 
            this.Prolonger_un_emprunt.Location = new System.Drawing.Point(974, 120);
            this.Prolonger_un_emprunt.Name = "Prolonger_un_emprunt";
            this.Prolonger_un_emprunt.Size = new System.Drawing.Size(73, 38);
            this.Prolonger_un_emprunt.TabIndex = 48;
            this.Prolonger_un_emprunt.Text = "Prolonger un emprunt";
            this.Prolonger_un_emprunt.UseVisualStyleBackColor = true;
            this.Prolonger_un_emprunt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Prolonger_un_emprunt_MouseDown);
            // 
            // Emprunter
            // 
            this.Emprunter.Location = new System.Drawing.Point(974, 531);
            this.Emprunter.Name = "Emprunter";
            this.Emprunter.Size = new System.Drawing.Size(73, 38);
            this.Emprunter.TabIndex = 49;
            this.Emprunter.Text = "Emprunter";
            this.Emprunter.UseVisualStyleBackColor = true;
            this.Emprunter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Emprunter_MouseDown);
            // 
            // ButtonRightEmprunt
            // 
            this.ButtonRightEmprunt.Location = new System.Drawing.Point(864, 216);
            this.ButtonRightEmprunt.Name = "ButtonRightEmprunt";
            this.ButtonRightEmprunt.Size = new System.Drawing.Size(75, 23);
            this.ButtonRightEmprunt.TabIndex = 50;
            this.ButtonRightEmprunt.Text = "->";
            this.ButtonRightEmprunt.UseVisualStyleBackColor = true;
            this.ButtonRightEmprunt.Click += new System.EventHandler(this.ButtonRightEmprunt_Click);
            // 
            // ButtonLeftEmprunt
            // 
            this.ButtonLeftEmprunt.Location = new System.Drawing.Point(783, 216);
            this.ButtonLeftEmprunt.Name = "ButtonLeftEmprunt";
            this.ButtonLeftEmprunt.Size = new System.Drawing.Size(75, 23);
            this.ButtonLeftEmprunt.TabIndex = 51;
            this.ButtonLeftEmprunt.Text = "<-";
            this.ButtonLeftEmprunt.UseVisualStyleBackColor = true;
            this.ButtonLeftEmprunt.Click += new System.EventHandler(this.ButtonLeftEmprunt_Click);
            // 
            // ToutLeftButton
            // 
            this.ToutLeftButton.Location = new System.Drawing.Point(407, 595);
            this.ToutLeftButton.Name = "ToutLeftButton";
            this.ToutLeftButton.Size = new System.Drawing.Size(75, 23);
            this.ToutLeftButton.TabIndex = 54;
            this.ToutLeftButton.Text = "<-";
            this.ToutLeftButton.UseVisualStyleBackColor = true;
            this.ToutLeftButton.Click += new System.EventHandler(this.ToutLeftButton_Click);
            // 
            // ToutRightButton
            // 
            this.ToutRightButton.Location = new System.Drawing.Point(488, 595);
            this.ToutRightButton.Name = "ToutRightButton";
            this.ToutRightButton.Size = new System.Drawing.Size(75, 23);
            this.ToutRightButton.TabIndex = 55;
            this.ToutRightButton.Text = "->";
            this.ToutRightButton.UseVisualStyleBackColor = true;
            this.ToutRightButton.Click += new System.EventHandler(this.ToutRightButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = global::AppliGrpR.Properties.Resources.pochetteAlbum;
            this.pictureBox1.Location = new System.Drawing.Point(694, 418);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 56;
            this.pictureBox1.TabStop = false;
            // 
            // pageEmprunté
            // 
            this.pageEmprunté.AutoSize = true;
            this.pageEmprunté.Location = new System.Drawing.Point(905, 186);
            this.pageEmprunté.Name = "pageEmprunté";
            this.pageEmprunté.Size = new System.Drawing.Size(35, 13);
            this.pageEmprunté.TabIndex = 57;
            this.pageEmprunté.Text = "label1";
            // 
            // pageAlbum
            // 
            this.pageAlbum.AutoSize = true;
            this.pageAlbum.Location = new System.Drawing.Point(495, 566);
            this.pageAlbum.Name = "pageAlbum";
            this.pageAlbum.Size = new System.Drawing.Size(35, 13);
            this.pageAlbum.TabIndex = 58;
            this.pageAlbum.Text = "label2";
            // 
            // Abonne_Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.pageAlbum);
            this.Controls.Add(this.pageEmprunté);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ToutRightButton);
            this.Controls.Add(this.ToutLeftButton);
            this.Controls.Add(this.ButtonLeftEmprunt);
            this.Controls.Add(this.ButtonRightEmprunt);
            this.Controls.Add(this.Emprunter);
            this.Controls.Add(this.Prolonger_un_emprunt);
            this.Controls.Add(this.déconnexion);
            this.Controls.Add(this.accueil);
            this.Controls.Add(this.Albums_Conseillés);
            this.Controls.Add(this.Tous_Les_Albums);
            this.Controls.Add(this.RechercherAlbum);
            this.Controls.Add(this.RechercherTextBox);
            this.Controls.Add(this.AlbumsEmpruntés);
            this.Controls.Add(this.TousLesAlbums);
            this.Controls.Add(this.AlbumsEmpruntes);
            this.Controls.Add(this.AlbumsConseillés);
            this.Name = "Abonne_Accueil";
            this.Text = "Abonne_Accueil";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AlbumsConseillés;
        private System.Windows.Forms.ListBox AlbumsEmpruntes;
        private System.Windows.Forms.ListBox TousLesAlbums;
        private System.Windows.Forms.Label AlbumsEmpruntés;
        private System.Windows.Forms.TextBox RechercherTextBox;
        private System.Windows.Forms.Label RechercherAlbum;
        private System.Windows.Forms.Label Tous_Les_Albums;
        private System.Windows.Forms.Label Albums_Conseillés;
        private System.Windows.Forms.Label accueil;
        private System.Windows.Forms.Button déconnexion;
        private System.Windows.Forms.Button Prolonger_un_emprunt;
        private System.Windows.Forms.Button Emprunter;
        private System.Windows.Forms.Button ButtonRightEmprunt;
        private System.Windows.Forms.Button ButtonLeftEmprunt;
        private System.Windows.Forms.Button ToutLeftButton;
        private System.Windows.Forms.Button ToutRightButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label pageEmprunté;
        private System.Windows.Forms.Label pageAlbum;
    }
}