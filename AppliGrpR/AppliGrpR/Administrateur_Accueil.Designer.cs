
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
            this.Retour = new System.Windows.Forms.Button();
            this.PurgerAbonnes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListeProlongementBox
            // 
            this.ListeProlongementBox.FormattingEnabled = true;
            this.ListeProlongementBox.Location = new System.Drawing.Point(32, 63);
            this.ListeProlongementBox.Name = "ListeProlongementBox";
            this.ListeProlongementBox.Size = new System.Drawing.Size(407, 121);
            this.ListeProlongementBox.TabIndex = 0;
            // 
            // top10liste
            // 
            this.top10liste.FormattingEnabled = true;
            this.top10liste.Location = new System.Drawing.Point(32, 452);
            this.top10liste.Name = "top10liste";
            this.top10liste.Size = new System.Drawing.Size(407, 121);
            this.top10liste.TabIndex = 1;
            // 
            // Retard10joursBox
            // 
            this.Retard10joursBox.FormattingEnabled = true;
            this.Retard10joursBox.Location = new System.Drawing.Point(32, 258);
            this.Retard10joursBox.Name = "Retard10joursBox";
            this.Retard10joursBox.Size = new System.Drawing.Size(407, 121);
            this.Retard10joursBox.TabIndex = 2;
            // 
            // nonEmprunté
            // 
            this.nonEmprunté.FormattingEnabled = true;
            this.nonEmprunté.Location = new System.Drawing.Point(817, 103);
            this.nonEmprunté.Name = "nonEmprunté";
            this.nonEmprunté.Size = new System.Drawing.Size(238, 407);
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
            this.ListeAbonnebox.Location = new System.Drawing.Point(518, 103);
            this.ListeAbonnebox.Name = "ListeAbonnebox";
            this.ListeAbonnebox.Size = new System.Drawing.Size(201, 407);
            this.ListeAbonnebox.TabIndex = 8;
            // 
            // ListeAbonne
            // 
            this.ListeAbonne.AutoSize = true;
            this.ListeAbonne.Location = new System.Drawing.Point(515, 87);
            this.ListeAbonne.Name = "ListeAbonne";
            this.ListeAbonne.Size = new System.Drawing.Size(74, 13);
            this.ListeAbonne.TabIndex = 9;
            this.ListeAbonne.Text = "Liste Abonnes";
            // 
            // Retour
            // 
            this.Retour.Location = new System.Drawing.Point(997, 12);
            this.Retour.Name = "Retour";
            this.Retour.Size = new System.Drawing.Size(75, 23);
            this.Retour.TabIndex = 10;
            this.Retour.Text = "Retour";
            this.Retour.UseVisualStyleBackColor = true;
            this.Retour.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Retour_MouseDown);
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
            // AdministrateurAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.PurgerAbonnes);
            this.Controls.Add(this.Retour);
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
        private System.Windows.Forms.Button Retour;
        private System.Windows.Forms.Button PurgerAbonnes;
    }
}