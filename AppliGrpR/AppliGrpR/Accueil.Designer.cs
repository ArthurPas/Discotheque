
namespace AppliGrpR
{
    partial class Accueil
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
            this.inscription = new System.Windows.Forms.Button();
            this.connexion_user = new System.Windows.Forms.Button();
            this.connexion_admin = new System.Windows.Forms.Button();
            this.quitter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // inscription
            // 
            this.inscription.Location = new System.Drawing.Point(447, 180);
            this.inscription.Name = "inscription";
            this.inscription.Size = new System.Drawing.Size(210, 52);
            this.inscription.TabIndex = 3;
            this.inscription.Text = "Inscription";
            this.inscription.UseVisualStyleBackColor = true;
            this.inscription.Click += new System.EventHandler(this.inscription_Click);
            // 
            // connexion_user
            // 
            this.connexion_user.Location = new System.Drawing.Point(373, 303);
            this.connexion_user.Name = "connexion_user";
            this.connexion_user.Size = new System.Drawing.Size(359, 52);
            this.connexion_user.TabIndex = 4;
            this.connexion_user.Text = "Connexion en tant qu\'utilisateur";
            this.connexion_user.UseVisualStyleBackColor = true;
            this.connexion_user.Click += new System.EventHandler(this.connexion_user_Click);
            // 
            // connexion_admin
            // 
            this.connexion_admin.Location = new System.Drawing.Point(373, 428);
            this.connexion_admin.Name = "connexion_admin";
            this.connexion_admin.Size = new System.Drawing.Size(359, 52);
            this.connexion_admin.TabIndex = 5;
            this.connexion_admin.Text = "Connexion en tant qu\'administatreur";
            this.connexion_admin.UseVisualStyleBackColor = true;
            this.connexion_admin.Click += new System.EventHandler(this.connexion_admin_Click);
            // 
            // quitter
            // 
            this.quitter.Location = new System.Drawing.Point(12, 614);
            this.quitter.Name = "quitter";
            this.quitter.Size = new System.Drawing.Size(116, 35);
            this.quitter.TabIndex = 6;
            this.quitter.Text = "Quitter";
            this.quitter.UseVisualStyleBackColor = true;
            this.quitter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.quitter_MouseDown);
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.quitter);
            this.Controls.Add(this.connexion_admin);
            this.Controls.Add(this.connexion_user);
            this.Controls.Add(this.inscription);
            this.Name = "Accueil";
            this.Text = "Accueil";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button inscription;
        private System.Windows.Forms.Button connexion_user;
        private System.Windows.Forms.Button connexion_admin;
        private System.Windows.Forms.Button quitter;
    }
}