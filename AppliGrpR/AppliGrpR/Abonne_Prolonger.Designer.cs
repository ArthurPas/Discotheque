
namespace AppliGrpR
{
    partial class Abonne_Prolonger
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
            this.Retour = new System.Windows.Forms.Button();
            this.AlbumsProlongeables = new System.Windows.Forms.ListBox();
            this.Connexion = new System.Windows.Forms.Label();
            this.Albums_Prolongeables = new System.Windows.Forms.Label();
            this.ProlongerButton = new System.Windows.Forms.Button();
            this.Pronlonger_tout_bouton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Retour
            // 
            this.Retour.BackColor = System.Drawing.Color.DarkRed;
            this.Retour.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Retour.Location = new System.Drawing.Point(713, 12);
            this.Retour.Name = "Retour";
            this.Retour.Size = new System.Drawing.Size(75, 23);
            this.Retour.TabIndex = 6;
            this.Retour.Text = "Retour";
            this.Retour.UseVisualStyleBackColor = false;
            this.Retour.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Retour_MouseDown);
            // 
            // AlbumsProlongeables
            // 
            this.AlbumsProlongeables.FormattingEnabled = true;
            this.AlbumsProlongeables.Location = new System.Drawing.Point(139, 101);
            this.AlbumsProlongeables.Name = "AlbumsProlongeables";
            this.AlbumsProlongeables.Size = new System.Drawing.Size(491, 199);
            this.AlbumsProlongeables.TabIndex = 7;
            this.AlbumsProlongeables.SelectedIndexChanged += new System.EventHandler(this.AlbumsProlongeables_SelectedIndexChanged);
            // 
            // Connexion
            // 
            this.Connexion.AutoSize = true;
            this.Connexion.Location = new System.Drawing.Point(136, 85);
            this.Connexion.Name = "Connexion";
            this.Connexion.Size = new System.Drawing.Size(0, 13);
            this.Connexion.TabIndex = 8;
            // 
            // Albums_Prolongeables
            // 
            this.Albums_Prolongeables.AutoSize = true;
            this.Albums_Prolongeables.Location = new System.Drawing.Point(136, 85);
            this.Albums_Prolongeables.Name = "Albums_Prolongeables";
            this.Albums_Prolongeables.Size = new System.Drawing.Size(111, 13);
            this.Albums_Prolongeables.TabIndex = 9;
            this.Albums_Prolongeables.Text = "Albums Prolongeables";
            // 
            // ProlongerButton
            // 
            this.ProlongerButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ProlongerButton.Location = new System.Drawing.Point(235, 328);
            this.ProlongerButton.Name = "ProlongerButton";
            this.ProlongerButton.Size = new System.Drawing.Size(75, 23);
            this.ProlongerButton.TabIndex = 34;
            this.ProlongerButton.Text = "Prolonger";
            this.ProlongerButton.UseVisualStyleBackColor = false;
            this.ProlongerButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProlongerButton_MouseDown);
            // 
            // Pronlonger_tout_bouton
            // 
            this.Pronlonger_tout_bouton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Pronlonger_tout_bouton.Location = new System.Drawing.Point(463, 328);
            this.Pronlonger_tout_bouton.Name = "Pronlonger_tout_bouton";
            this.Pronlonger_tout_bouton.Size = new System.Drawing.Size(88, 23);
            this.Pronlonger_tout_bouton.TabIndex = 35;
            this.Pronlonger_tout_bouton.Text = "Prolonger tout";
            this.Pronlonger_tout_bouton.UseVisualStyleBackColor = false;
            this.Pronlonger_tout_bouton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pronlonger_tout_bouton_MouseDown);
            // 
            // Abonne_Prolonger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Pronlonger_tout_bouton);
            this.Controls.Add(this.ProlongerButton);
            this.Controls.Add(this.Albums_Prolongeables);
            this.Controls.Add(this.Connexion);
            this.Controls.Add(this.AlbumsProlongeables);
            this.Controls.Add(this.Retour);
            this.Name = "Abonne_Prolonger";
            this.Text = "Abonne_Prolonger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Retour;
        private System.Windows.Forms.ListBox AlbumsProlongeables;
        private System.Windows.Forms.Label Connexion;
        private System.Windows.Forms.Label Albums_Prolongeables;
        private System.Windows.Forms.Button ProlongerButton;
        private System.Windows.Forms.Button Pronlonger_tout_bouton;
    }
}