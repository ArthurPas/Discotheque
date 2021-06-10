
namespace AppliGrpR
{
    partial class AdministrateurAccueil
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
            this.ListeProlongementBox = new System.Windows.Forms.ListBox();
            this.top10liste = new System.Windows.Forms.ListBox();
            this.Retard10joursBox = new System.Windows.Forms.ListBox();
            this.nonEmprunté = new System.Windows.Forms.ListBox();
            this.nonEmpruntesLabel = new System.Windows.Forms.Label();
            this.Top10 = new System.Windows.Forms.Label();
            this.ListeProlongement = new System.Windows.Forms.Label();
            this.Retard10jours = new System.Windows.Forms.Label();
            this.ListeAbonnebox = new System.Windows.Forms.ListBox();
            this.ListeAbonne = new System.Windows.Forms.Label();
            this.déconnexion = new System.Windows.Forms.Button();
            this.PurgerAbonnes = new System.Windows.Forms.Button();
            this.LeftListButton = new System.Windows.Forms.Button();
            this.RightListButton = new System.Windows.Forms.Button();
            this.LeftNonEmprButton = new System.Windows.Forms.Button();
            this.RightNonEmprButton = new System.Windows.Forms.Button();
            this.ProloLeftButton = new System.Windows.Forms.Button();
            this.ProloRightButton = new System.Windows.Forms.Button();
            this.RetardLeftButton = new System.Windows.Forms.Button();
            this.RetardRightButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListeProlongementBox
            // 
            this.ListeProlongementBox.FormattingEnabled = true;
            this.ListeProlongementBox.Location = new System.Drawing.Point(32, 63);
            this.ListeProlongementBox.Name = "ListeProlongementBox";
            this.ListeProlongementBox.Size = new System.Drawing.Size(485, 121);
            this.ListeProlongementBox.TabIndex = 0;
            // 
            // top10liste
            // 
            this.top10liste.FormattingEnabled = true;
            this.top10liste.Location = new System.Drawing.Point(32, 452);
            this.top10liste.Name = "top10liste";
            this.top10liste.Size = new System.Drawing.Size(485, 147);
            this.top10liste.TabIndex = 1;
            // 
            // Retard10joursBox
            // 
            this.Retard10joursBox.FormattingEnabled = true;
            this.Retard10joursBox.Location = new System.Drawing.Point(32, 258);
            this.Retard10joursBox.Name = "Retard10joursBox";
            this.Retard10joursBox.Size = new System.Drawing.Size(485, 121);
            this.Retard10joursBox.TabIndex = 2;
            // 
            // nonEmprunté
            // 
            this.nonEmprunté.FormattingEnabled = true;
            this.nonEmprunté.Location = new System.Drawing.Point(782, 103);
            this.nonEmprunté.Name = "nonEmprunté";
            this.nonEmprunté.Size = new System.Drawing.Size(273, 407);
            this.nonEmprunté.TabIndex = 3;
            // 
            // nonEmpruntesLabel
            // 
            this.nonEmpruntesLabel.AutoSize = true;
            this.nonEmpruntesLabel.Location = new System.Drawing.Point(814, 87);
            this.nonEmpruntesLabel.Name = "nonEmpruntesLabel";
            this.nonEmpruntesLabel.Size = new System.Drawing.Size(211, 13);
            this.nonEmpruntesLabel.TabIndex = 4;
            this.nonEmpruntesLabel.Text = "Albums non empruntés depuis plus d\'un an ";
            // 
            // Top10
            // 
            this.Top10.AutoSize = true;
            this.Top10.Location = new System.Drawing.Point(29, 436);
            this.Top10.Name = "Top10";
            this.Top10.Size = new System.Drawing.Size(38, 13);
            this.Top10.TabIndex = 5;
            this.Top10.Text = "Top10";
            // 
            // ListeProlongement
            // 
            this.ListeProlongement.AutoSize = true;
            this.ListeProlongement.Location = new System.Drawing.Point(29, 47);
            this.ListeProlongement.Name = "ListeProlongement";
            this.ListeProlongement.Size = new System.Drawing.Size(97, 13);
            this.ListeProlongement.TabIndex = 6;
            this.ListeProlongement.Text = "Liste Prolongement";
            // 
            // Retard10jours
            // 
            this.Retard10jours.AutoSize = true;
            this.Retard10jours.Location = new System.Drawing.Point(29, 242);
            this.Retard10jours.Name = "Retard10jours";
            this.Retard10jours.Size = new System.Drawing.Size(79, 13);
            this.Retard10jours.TabIndex = 7;
            this.Retard10jours.Text = "Retard 10 jours";
            // 
            // ListeAbonnebox
            // 
            this.ListeAbonnebox.FormattingEnabled = true;
            this.ListeAbonnebox.Location = new System.Drawing.Point(587, 103);
            this.ListeAbonnebox.Name = "ListeAbonnebox";
            this.ListeAbonnebox.Size = new System.Drawing.Size(160, 407);
            this.ListeAbonnebox.TabIndex = 8;
            // 
            // ListeAbonne
            // 
            this.ListeAbonne.AutoSize = true;
            this.ListeAbonne.Location = new System.Drawing.Point(584, 87);
            this.ListeAbonne.Name = "ListeAbonne";
            this.ListeAbonne.Size = new System.Drawing.Size(74, 13);
            this.ListeAbonne.TabIndex = 9;
            this.ListeAbonne.Text = "Liste Abonnes";
            // 
            // déconnexion
            // 
            this.déconnexion.Location = new System.Drawing.Point(990, 12);
            this.déconnexion.Name = "déconnexion";
            this.déconnexion.Size = new System.Drawing.Size(82, 26);
            this.déconnexion.TabIndex = 10;
            this.déconnexion.Text = "Déconnexion";
            this.déconnexion.UseVisualStyleBackColor = true;
            this.déconnexion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Retour_MouseDown);
            // 
            // PurgerAbonnes
            // 
            this.PurgerAbonnes.Location = new System.Drawing.Point(757, 590);
            this.PurgerAbonnes.Name = "PurgerAbonnes";
            this.PurgerAbonnes.Size = new System.Drawing.Size(88, 23);
            this.PurgerAbonnes.TabIndex = 11;
            this.PurgerAbonnes.Text = "PurgerAbonnes";
            this.PurgerAbonnes.UseVisualStyleBackColor = true;
            this.PurgerAbonnes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PurgerAbonnes_MouseDown);
            // 
            // LeftListButton
            // 
            this.LeftListButton.Location = new System.Drawing.Point(587, 526);
            this.LeftListButton.Name = "LeftListButton";
            this.LeftListButton.Size = new System.Drawing.Size(75, 23);
            this.LeftListButton.TabIndex = 12;
            this.LeftListButton.Text = "<-";
            this.LeftListButton.UseVisualStyleBackColor = true;
            this.LeftListButton.Click += new System.EventHandler(this.LeftListButton_Click);
            // 
            // RightListButton
            // 
            this.RightListButton.Location = new System.Drawing.Point(668, 526);
            this.RightListButton.Name = "RightListButton";
            this.RightListButton.Size = new System.Drawing.Size(75, 23);
            this.RightListButton.TabIndex = 13;
            this.RightListButton.Text = "->";
            this.RightListButton.UseVisualStyleBackColor = true;
            this.RightListButton.Click += new System.EventHandler(this.RightListButton_Click);
            // 
            // LeftNonEmprButton
            // 
            this.LeftNonEmprButton.Location = new System.Drawing.Point(899, 526);
            this.LeftNonEmprButton.Name = "LeftNonEmprButton";
            this.LeftNonEmprButton.Size = new System.Drawing.Size(75, 23);
            this.LeftNonEmprButton.TabIndex = 14;
            this.LeftNonEmprButton.Text = "<-";
            this.LeftNonEmprButton.UseVisualStyleBackColor = true;
            this.LeftNonEmprButton.Click += new System.EventHandler(this.LeftNonEmprButton_Click);
            // 
            // RightNonEmprButton
            // 
            this.RightNonEmprButton.Location = new System.Drawing.Point(980, 526);
            this.RightNonEmprButton.Name = "RightNonEmprButton";
            this.RightNonEmprButton.Size = new System.Drawing.Size(75, 23);
            this.RightNonEmprButton.TabIndex = 15;
            this.RightNonEmprButton.Text = "->";
            this.RightNonEmprButton.UseVisualStyleBackColor = true;
            this.RightNonEmprButton.Click += new System.EventHandler(this.RightNonEmprButton_Click);
            // 
            // ProloLeftButton
            // 
            this.ProloLeftButton.Location = new System.Drawing.Point(361, 190);
            this.ProloLeftButton.Name = "ProloLeftButton";
            this.ProloLeftButton.Size = new System.Drawing.Size(75, 23);
            this.ProloLeftButton.TabIndex = 16;
            this.ProloLeftButton.Text = "<-";
            this.ProloLeftButton.UseVisualStyleBackColor = true;
            this.ProloLeftButton.Click += new System.EventHandler(this.ProloLeftButton_Click);
            // 
            // ProloRightButton
            // 
            this.ProloRightButton.Location = new System.Drawing.Point(442, 190);
            this.ProloRightButton.Name = "ProloRightButton";
            this.ProloRightButton.Size = new System.Drawing.Size(75, 23);
            this.ProloRightButton.TabIndex = 17;
            this.ProloRightButton.Text = "->";
            this.ProloRightButton.UseVisualStyleBackColor = true;
            this.ProloRightButton.Click += new System.EventHandler(this.ProloRightButton_Click);
            // 
            // RetardLeftButton
            // 
            this.RetardLeftButton.Location = new System.Drawing.Point(361, 385);
            this.RetardLeftButton.Name = "RetardLeftButton";
            this.RetardLeftButton.Size = new System.Drawing.Size(75, 23);
            this.RetardLeftButton.TabIndex = 18;
            this.RetardLeftButton.Text = "<-";
            this.RetardLeftButton.UseVisualStyleBackColor = true;
            this.RetardLeftButton.Click += new System.EventHandler(this.RetardLeftButton_Click);
            // 
            // RetardRightButton
            // 
            this.RetardRightButton.Location = new System.Drawing.Point(442, 385);
            this.RetardRightButton.Name = "RetardRightButton";
            this.RetardRightButton.Size = new System.Drawing.Size(75, 23);
            this.RetardRightButton.TabIndex = 19;
            this.RetardRightButton.Text = "->";
            this.RetardRightButton.UseVisualStyleBackColor = true;
            this.RetardRightButton.Click += new System.EventHandler(this.RetardRightButton_Click);
            // 
            // AdministrateurAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.RetardRightButton);
            this.Controls.Add(this.RetardLeftButton);
            this.Controls.Add(this.ProloRightButton);
            this.Controls.Add(this.ProloLeftButton);
            this.Controls.Add(this.RightNonEmprButton);
            this.Controls.Add(this.LeftNonEmprButton);
            this.Controls.Add(this.RightListButton);
            this.Controls.Add(this.LeftListButton);
            this.Controls.Add(this.PurgerAbonnes);
            this.Controls.Add(this.déconnexion);
            this.Controls.Add(this.ListeAbonne);
            this.Controls.Add(this.ListeAbonnebox);
            this.Controls.Add(this.Retard10jours);
            this.Controls.Add(this.ListeProlongement);
            this.Controls.Add(this.Top10);
            this.Controls.Add(this.nonEmpruntesLabel);
            this.Controls.Add(this.nonEmprunté);
            this.Controls.Add(this.Retard10joursBox);
            this.Controls.Add(this.top10liste);
            this.Controls.Add(this.ListeProlongementBox);
            this.Name = "AdministrateurAccueil";
            this.Text = "Administrateur-Accueil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListeProlongementBox;
        private System.Windows.Forms.ListBox top10liste;
        private System.Windows.Forms.ListBox Retard10joursBox;
        private System.Windows.Forms.ListBox nonEmprunté;
        private System.Windows.Forms.Label nonEmpruntesLabel;
        private System.Windows.Forms.Label Top10;
        private System.Windows.Forms.Label ListeProlongement;
        private System.Windows.Forms.Label Retard10jours;
        private System.Windows.Forms.ListBox ListeAbonnebox;
        private System.Windows.Forms.Label ListeAbonne;
        private System.Windows.Forms.Button déconnexion;
        private System.Windows.Forms.Button PurgerAbonnes;
        private System.Windows.Forms.Button LeftListButton;
        private System.Windows.Forms.Button RightListButton;
        private System.Windows.Forms.Button LeftNonEmprButton;
        private System.Windows.Forms.Button RightNonEmprButton;
        private System.Windows.Forms.Button ProloLeftButton;
        private System.Windows.Forms.Button ProloRightButton;
        private System.Windows.Forms.Button RetardLeftButton;
        private System.Windows.Forms.Button RetardRightButton;
    }
}