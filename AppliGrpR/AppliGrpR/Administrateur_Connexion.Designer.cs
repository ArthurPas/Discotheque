
namespace AppliGrpR
{
    partial class Administrateur_Connexion
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
            this.Connexion = new System.Windows.Forms.Label();
            this.pseudoTextBox = new System.Windows.Forms.TextBox();
            this.motdepassetextbox = new System.Windows.Forms.TextBox();
            this.Utilisateur = new System.Windows.Forms.Label();
            this.MotDePasse = new System.Windows.Forms.Label();
            this.Retour = new System.Windows.Forms.Button();
            this.SeConnecter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Connexion
            // 
            this.Connexion.AutoSize = true;
            this.Connexion.Location = new System.Drawing.Point(481, 48);
            this.Connexion.Name = "Connexion";
            this.Connexion.Size = new System.Drawing.Size(103, 13);
            this.Connexion.TabIndex = 0;
            this.Connexion.Text = "Connexion en admin";
            // 
            // pseudoTextBox
            // 
            this.pseudoTextBox.Location = new System.Drawing.Point(464, 195);
            this.pseudoTextBox.Name = "pseudoTextBox";
            this.pseudoTextBox.Size = new System.Drawing.Size(133, 20);
            this.pseudoTextBox.TabIndex = 1;
            // 
            // motdepassetextbox
            // 
            this.motdepassetextbox.Location = new System.Drawing.Point(464, 297);
            this.motdepassetextbox.Name = "motdepassetextbox";
            this.motdepassetextbox.Size = new System.Drawing.Size(133, 20);
            this.motdepassetextbox.TabIndex = 2;
            // 
            // Utilisateur
            // 
            this.Utilisateur.AutoSize = true;
            this.Utilisateur.Location = new System.Drawing.Point(381, 198);
            this.Utilisateur.Name = "Utilisateur";
            this.Utilisateur.Size = new System.Drawing.Size(53, 13);
            this.Utilisateur.TabIndex = 3;
            this.Utilisateur.Text = "Utilisateur";
            // 
            // MotDePasse
            // 
            this.MotDePasse.AutoSize = true;
            this.MotDePasse.Location = new System.Drawing.Point(381, 300);
            this.MotDePasse.Name = "MotDePasse";
            this.MotDePasse.Size = new System.Drawing.Size(74, 13);
            this.MotDePasse.TabIndex = 4;
            this.MotDePasse.Text = "Mot De Passe";
            // 
            // Retour
            // 
            this.Retour.BackColor = System.Drawing.Color.Navy;
            this.Retour.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Retour.Location = new System.Drawing.Point(997, 12);
            this.Retour.Name = "Retour";
            this.Retour.Size = new System.Drawing.Size(75, 23);
            this.Retour.TabIndex = 5;
            this.Retour.Text = "Retour";
            this.Retour.UseVisualStyleBackColor = false;
            this.Retour.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Retour_MouseDown);
            // 
            // SeConnecter
            // 
            this.SeConnecter.BackColor = System.Drawing.Color.DarkOrange;
            this.SeConnecter.Location = new System.Drawing.Point(484, 405);
            this.SeConnecter.Name = "SeConnecter";
            this.SeConnecter.Size = new System.Drawing.Size(100, 23);
            this.SeConnecter.TabIndex = 6;
            this.SeConnecter.Text = "Se connecter";
            this.SeConnecter.UseVisualStyleBackColor = false;
            this.SeConnecter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SeConnecter_MouseDown);
            // 
            // Administrateur_Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.SeConnecter);
            this.Controls.Add(this.Retour);
            this.Controls.Add(this.MotDePasse);
            this.Controls.Add(this.Utilisateur);
            this.Controls.Add(this.motdepassetextbox);
            this.Controls.Add(this.pseudoTextBox);
            this.Controls.Add(this.Connexion);
            this.Name = "Administrateur_Connexion";
            this.Text = "Administrateur_Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Connexion;
        private System.Windows.Forms.TextBox pseudoTextBox;
        private System.Windows.Forms.TextBox motdepassetextbox;
        private System.Windows.Forms.Label Utilisateur;
        private System.Windows.Forms.Label MotDePasse;
        private System.Windows.Forms.Button Retour;
        private System.Windows.Forms.Button SeConnecter;
    }
}