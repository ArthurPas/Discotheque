
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
            this.Accueil = new System.Windows.Forms.Label();
            this.Retour = new System.Windows.Forms.Button();
            this.Prolonger_un_emprunt = new System.Windows.Forms.Button();
            this.Emprunter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AlbumsConseillés
            // 
            this.AlbumsConseillés.FormattingEnabled = true;
            this.AlbumsConseillés.Location = new System.Drawing.Point(147, 245);
            this.AlbumsConseillés.Name = "AlbumsConseillés";
            this.AlbumsConseillés.Size = new System.Drawing.Size(793, 121);
            this.AlbumsConseillés.TabIndex = 1;
            // 
            // AlbumsEmpruntes
            // 
            this.AlbumsEmpruntes.FormattingEnabled = true;
            this.AlbumsEmpruntes.Location = new System.Drawing.Point(147, 74);
            this.AlbumsEmpruntes.Name = "AlbumsEmpruntes";
            this.AlbumsEmpruntes.Size = new System.Drawing.Size(793, 121);
            this.AlbumsEmpruntes.TabIndex = 2;
            // 
            // TousLesAlbums
            // 
            this.TousLesAlbums.FormattingEnabled = true;
            this.TousLesAlbums.Location = new System.Drawing.Point(147, 455);
            this.TousLesAlbums.Name = "TousLesAlbums";
            this.TousLesAlbums.Size = new System.Drawing.Size(793, 160);
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
            this.Tous_Les_Albums.Location = new System.Drawing.Point(148, 402);
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
            // Accueil
            // 
            this.Accueil.AutoSize = true;
            this.Accueil.Location = new System.Drawing.Point(512, 39);
            this.Accueil.Name = "Accueil";
            this.Accueil.Size = new System.Drawing.Size(42, 13);
            this.Accueil.TabIndex = 46;
            this.Accueil.Text = "Accueil";
            // 
            // Retour
            // 
            this.Retour.Location = new System.Drawing.Point(997, 12);
            this.Retour.Name = "Retour";
            this.Retour.Size = new System.Drawing.Size(75, 23);
            this.Retour.TabIndex = 47;
            this.Retour.Text = "Retour";
            this.Retour.UseVisualStyleBackColor = true;
            this.Retour.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Retour_MouseDown);
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
            // Abonne_Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.Emprunter);
            this.Controls.Add(this.Prolonger_un_emprunt);
            this.Controls.Add(this.Retour);
            this.Controls.Add(this.Accueil);
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
        private System.Windows.Forms.Label Accueil;
        private System.Windows.Forms.Button Retour;
        private System.Windows.Forms.Button Prolonger_un_emprunt;
        private System.Windows.Forms.Button Emprunter;
    }
}