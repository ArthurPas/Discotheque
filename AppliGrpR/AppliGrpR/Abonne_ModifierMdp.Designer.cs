
namespace AppliGrpR
{
    partial class Abonne_ModifierMdp
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
            this.mdp_box = new System.Windows.Forms.TextBox();
            this.newMdp_box = new System.Windows.Forms.TextBox();
            this.newMdpConfirm_box = new System.Windows.Forms.TextBox();
            this.titre = new System.Windows.Forms.Label();
            this.mdp = new System.Windows.Forms.Label();
            this.newMdp = new System.Windows.Forms.Label();
            this.confirmNewMdp = new System.Windows.Forms.Label();
            this.errorMdpNotEqual = new System.Windows.Forms.Label();
            this.errorNewMdp = new System.Windows.Forms.Label();
            this.errrorNewMdpConfirm = new System.Windows.Forms.Label();
            this.modifierMdp = new System.Windows.Forms.Button();
            this.retour = new System.Windows.Forms.Button();
            this.errorConfirmNewMdp = new System.Windows.Forms.Label();
            this.errorMdp = new System.Windows.Forms.Label();
            this.errorSameMdp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mdp_box
            // 
            this.mdp_box.Location = new System.Drawing.Point(397, 239);
            this.mdp_box.Name = "mdp_box";
            this.mdp_box.Size = new System.Drawing.Size(319, 20);
            this.mdp_box.TabIndex = 0;
            // 
            // newMdp_box
            // 
            this.newMdp_box.Location = new System.Drawing.Point(397, 325);
            this.newMdp_box.Name = "newMdp_box";
            this.newMdp_box.Size = new System.Drawing.Size(319, 20);
            this.newMdp_box.TabIndex = 1;
            // 
            // newMdpConfirm_box
            // 
            this.newMdpConfirm_box.Location = new System.Drawing.Point(397, 401);
            this.newMdpConfirm_box.Name = "newMdpConfirm_box";
            this.newMdpConfirm_box.Size = new System.Drawing.Size(319, 20);
            this.newMdpConfirm_box.TabIndex = 2;
            // 
            // titre
            // 
            this.titre.AutoSize = true;
            this.titre.Location = new System.Drawing.Point(476, 179);
            this.titre.Name = "titre";
            this.titre.Size = new System.Drawing.Size(152, 13);
            this.titre.TabIndex = 3;
            this.titre.Text = "Modifification de Mot de Passe";
            // 
            // mdp
            // 
            this.mdp.AutoSize = true;
            this.mdp.Location = new System.Drawing.Point(213, 242);
            this.mdp.Name = "mdp";
            this.mdp.Size = new System.Drawing.Size(170, 13);
            this.mdp.TabIndex = 4;
            this.mdp.Text = "Entrer Votre Mot de Passe Actuel :";
            // 
            // newMdp
            // 
            this.newMdp.AutoSize = true;
            this.newMdp.Location = new System.Drawing.Point(207, 328);
            this.newMdp.Name = "newMdp";
            this.newMdp.Size = new System.Drawing.Size(184, 13);
            this.newMdp.TabIndex = 5;
            this.newMdp.Text = "Entrer Votre Nouveau Mot de Passe :";
            // 
            // confirmNewMdp
            // 
            this.confirmNewMdp.AutoSize = true;
            this.confirmNewMdp.Location = new System.Drawing.Point(193, 404);
            this.confirmNewMdp.Name = "confirmNewMdp";
            this.confirmNewMdp.Size = new System.Drawing.Size(198, 13);
            this.confirmNewMdp.TabIndex = 6;
            this.confirmNewMdp.Text = "Confirmer Votre nouveau Mot de Passe :";
            // 
            // errorMdpNotEqual
            // 
            this.errorMdpNotEqual.AutoSize = true;
            this.errorMdpNotEqual.ForeColor = System.Drawing.Color.Red;
            this.errorMdpNotEqual.Location = new System.Drawing.Point(394, 271);
            this.errorMdpNotEqual.Name = "errorMdpNotEqual";
            this.errorMdpNotEqual.Size = new System.Drawing.Size(317, 13);
            this.errorMdpNotEqual.TabIndex = 7;
            this.errorMdpNotEqual.Text = "! Le mot de passe ne correspond pas à votre mot de Passe actuel";
            // 
            // errorNewMdp
            // 
            this.errorNewMdp.AutoSize = true;
            this.errorNewMdp.ForeColor = System.Drawing.Color.Red;
            this.errorNewMdp.Location = new System.Drawing.Point(394, 358);
            this.errorNewMdp.Name = "errorNewMdp";
            this.errorNewMdp.Size = new System.Drawing.Size(194, 13);
            this.errorNewMdp.TabIndex = 8;
            this.errorNewMdp.Text = "! Saisissez votre nouveau mot de passe";
            // 
            // errrorNewMdpConfirm
            // 
            this.errrorNewMdpConfirm.AutoSize = true;
            this.errrorNewMdpConfirm.ForeColor = System.Drawing.Color.Red;
            this.errrorNewMdpConfirm.Location = new System.Drawing.Point(394, 437);
            this.errrorNewMdpConfirm.Name = "errrorNewMdpConfirm";
            this.errrorNewMdpConfirm.Size = new System.Drawing.Size(304, 13);
            this.errrorNewMdpConfirm.TabIndex = 9;
            this.errrorNewMdpConfirm.Text = "! le mot de passe ne correspond pas au nouveau mot de passe";
            // 
            // modifierMdp
            // 
            this.modifierMdp.Location = new System.Drawing.Point(479, 493);
            this.modifierMdp.Name = "modifierMdp";
            this.modifierMdp.Size = new System.Drawing.Size(149, 35);
            this.modifierMdp.TabIndex = 10;
            this.modifierMdp.Text = "Modifier Mot de Passe";
            this.modifierMdp.UseVisualStyleBackColor = true;
            this.modifierMdp.Click += new System.EventHandler(this.modifierMdp_Click);
            // 
            // retour
            // 
            this.retour.Location = new System.Drawing.Point(997, 25);
            this.retour.Name = "retour";
            this.retour.Size = new System.Drawing.Size(75, 23);
            this.retour.TabIndex = 11;
            this.retour.Text = "Retour";
            this.retour.UseVisualStyleBackColor = true;
            this.retour.Click += new System.EventHandler(this.retour_Click);
            // 
            // errorConfirmNewMdp
            // 
            this.errorConfirmNewMdp.AutoSize = true;
            this.errorConfirmNewMdp.ForeColor = System.Drawing.Color.Red;
            this.errorConfirmNewMdp.Location = new System.Drawing.Point(394, 437);
            this.errorConfirmNewMdp.Name = "errorConfirmNewMdp";
            this.errorConfirmNewMdp.Size = new System.Drawing.Size(197, 13);
            this.errorConfirmNewMdp.TabIndex = 12;
            this.errorConfirmNewMdp.Text = "! Confirmez votre nouveau mot de passe";
            // 
            // errorMdp
            // 
            this.errorMdp.AutoSize = true;
            this.errorMdp.ForeColor = System.Drawing.Color.Red;
            this.errorMdp.Location = new System.Drawing.Point(397, 271);
            this.errorMdp.Name = "errorMdp";
            this.errorMdp.Size = new System.Drawing.Size(181, 13);
            this.errorMdp.TabIndex = 13;
            this.errorMdp.Text = "! Saisissez votre mot de passe actuel";
            // 
            // errorSameMdp
            // 
            this.errorSameMdp.AutoSize = true;
            this.errorSameMdp.ForeColor = System.Drawing.Color.Red;
            this.errorSameMdp.Location = new System.Drawing.Point(397, 358);
            this.errorSameMdp.Name = "errorSameMdp";
            this.errorSameMdp.Size = new System.Drawing.Size(358, 13);
            this.errorSameMdp.TabIndex = 14;
            this.errorSameMdp.Text = "! Votre Nouveau Mot de Passe est le même que votre mot de passe actuel";
            // 
            // Abonne_ModifierMdp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.errorSameMdp);
            this.Controls.Add(this.errorMdp);
            this.Controls.Add(this.errorConfirmNewMdp);
            this.Controls.Add(this.retour);
            this.Controls.Add(this.modifierMdp);
            this.Controls.Add(this.errrorNewMdpConfirm);
            this.Controls.Add(this.errorNewMdp);
            this.Controls.Add(this.errorMdpNotEqual);
            this.Controls.Add(this.confirmNewMdp);
            this.Controls.Add(this.newMdp);
            this.Controls.Add(this.mdp);
            this.Controls.Add(this.titre);
            this.Controls.Add(this.newMdpConfirm_box);
            this.Controls.Add(this.newMdp_box);
            this.Controls.Add(this.mdp_box);
            this.Name = "Abonne_ModifierMdp";
            this.Text = "Abonne_ModifierMdp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mdp_box;
        private System.Windows.Forms.TextBox newMdp_box;
        private System.Windows.Forms.TextBox newMdpConfirm_box;
        private System.Windows.Forms.Label titre;
        private System.Windows.Forms.Label mdp;
        private System.Windows.Forms.Label newMdp;
        private System.Windows.Forms.Label confirmNewMdp;
        private System.Windows.Forms.Label errorMdpNotEqual;
        private System.Windows.Forms.Label errorNewMdp;
        private System.Windows.Forms.Label errrorNewMdpConfirm;
        private System.Windows.Forms.Button modifierMdp;
        private System.Windows.Forms.Button retour;
        private System.Windows.Forms.Label errorConfirmNewMdp;
        private System.Windows.Forms.Label errorMdp;
        private System.Windows.Forms.Label errorSameMdp;
    }
}