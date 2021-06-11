
namespace AppliGrpR
{
    partial class Client_Inscription
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
            this.ajouterAbonné = new System.Windows.Forms.Label();
            this.Mot_de_passe = new System.Windows.Forms.Label();
            this.Identifiant = new System.Windows.Forms.Label();
            this.Prénom = new System.Windows.Forms.Label();
            this.Nom = new System.Windows.Forms.Label();
            this.Nationalité = new System.Windows.Forms.Label();
            this.inscription = new System.Windows.Forms.Button();
            this.mdp_box = new System.Windows.Forms.TextBox();
            this.id_box = new System.Windows.Forms.TextBox();
            this.prénom_box = new System.Windows.Forms.TextBox();
            this.nom_box = new System.Windows.Forms.TextBox();
            this.retour_button = new System.Windows.Forms.Button();
            this.nationalité_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.erreur_prénom = new System.Windows.Forms.Label();
            this.erreur_nationalité = new System.Windows.Forms.Label();
            this.erreur_mdp = new System.Windows.Forms.Label();
            this.erreur_id = new System.Windows.Forms.Label();
            this.erreur_nom = new System.Windows.Forms.Label();
            this.ConfirmationMdpTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfirmationMdpLabel = new System.Windows.Forms.Label();
            this.viewMdp = new System.Windows.Forms.Button();
            this.viewConfirmMdp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ajouterAbonné
            // 
            this.ajouterAbonné.AutoSize = true;
            this.ajouterAbonné.Location = new System.Drawing.Point(512, 125);
            this.ajouterAbonné.Name = "ajouterAbonné";
            this.ajouterAbonné.Size = new System.Drawing.Size(84, 13);
            this.ajouterAbonné.TabIndex = 39;
            this.ajouterAbonné.Text = "Inscription Client";
            // 
            // Mot_de_passe
            // 
            this.Mot_de_passe.AutoSize = true;
            this.Mot_de_passe.Location = new System.Drawing.Point(365, 396);
            this.Mot_de_passe.Name = "Mot_de_passe";
            this.Mot_de_passe.Size = new System.Drawing.Size(71, 13);
            this.Mot_de_passe.TabIndex = 37;
            this.Mot_de_passe.Text = "Mot de passe";
            // 
            // Identifiant
            // 
            this.Identifiant.AutoSize = true;
            this.Identifiant.Location = new System.Drawing.Point(383, 336);
            this.Identifiant.Name = "Identifiant";
            this.Identifiant.Size = new System.Drawing.Size(53, 13);
            this.Identifiant.TabIndex = 36;
            this.Identifiant.Text = "Identifiant";
            // 
            // Prénom
            // 
            this.Prénom.AutoSize = true;
            this.Prénom.Location = new System.Drawing.Point(393, 223);
            this.Prénom.Name = "Prénom";
            this.Prénom.Size = new System.Drawing.Size(43, 13);
            this.Prénom.TabIndex = 35;
            this.Prénom.Text = "Prénom";
            // 
            // Nom
            // 
            this.Nom.AutoSize = true;
            this.Nom.Location = new System.Drawing.Point(407, 163);
            this.Nom.Name = "Nom";
            this.Nom.Size = new System.Drawing.Size(29, 13);
            this.Nom.TabIndex = 34;
            this.Nom.Text = "Nom";
            // 
            // Nationalité
            // 
            this.Nationalité.AutoSize = true;
            this.Nationalité.Location = new System.Drawing.Point(379, 280);
            this.Nationalité.Name = "Nationalité";
            this.Nationalité.Size = new System.Drawing.Size(57, 13);
            this.Nationalité.TabIndex = 33;
            this.Nationalité.Text = "Nationalité";
            // 
            // inscription
            // 
            this.inscription.BackColor = System.Drawing.Color.LightSkyBlue;
            this.inscription.ForeColor = System.Drawing.Color.Black;
            this.inscription.Location = new System.Drawing.Point(470, 516);
            this.inscription.Name = "inscription";
            this.inscription.Size = new System.Drawing.Size(168, 39);
            this.inscription.TabIndex = 34;
            this.inscription.Text = "Inscription";
            this.inscription.UseVisualStyleBackColor = false;
            this.inscription.Click += new System.EventHandler(this.inscription_Click);
            // 
            // mdp_box
            // 
            this.mdp_box.Location = new System.Drawing.Point(442, 393);
            this.mdp_box.MaxLength = 32;
            this.mdp_box.Name = "mdp_box";
            this.mdp_box.Size = new System.Drawing.Size(219, 20);
            this.mdp_box.TabIndex = 32;
            this.mdp_box.UseSystemPasswordChar = true;
            // 
            // id_box
            // 
            this.id_box.ForeColor = System.Drawing.Color.Black;
            this.id_box.Location = new System.Drawing.Point(442, 333);
            this.id_box.MaxLength = 32;
            this.id_box.Name = "id_box";
            this.id_box.Size = new System.Drawing.Size(219, 20);
            this.id_box.TabIndex = 31;
            // 
            // prénom_box
            // 
            this.prénom_box.Location = new System.Drawing.Point(442, 220);
            this.prénom_box.MaxLength = 32;
            this.prénom_box.Name = "prénom_box";
            this.prénom_box.Size = new System.Drawing.Size(219, 20);
            this.prénom_box.TabIndex = 29;
            // 
            // nom_box
            // 
            this.nom_box.Location = new System.Drawing.Point(442, 160);
            this.nom_box.MaxLength = 32;
            this.nom_box.Name = "nom_box";
            this.nom_box.Size = new System.Drawing.Size(219, 20);
            this.nom_box.TabIndex = 28;
            // 
            // retour_button
            // 
            this.retour_button.BackColor = System.Drawing.Color.DarkRed;
            this.retour_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.retour_button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.retour_button.Location = new System.Drawing.Point(997, 12);
            this.retour_button.Name = "retour_button";
            this.retour_button.Size = new System.Drawing.Size(75, 29);
            this.retour_button.TabIndex = 35;
            this.retour_button.Text = "Retour";
            this.retour_button.UseVisualStyleBackColor = false;
            this.retour_button.Click += new System.EventHandler(this.retour_button_Click);
            // 
            // nationalité_comboBox
            // 
            this.nationalité_comboBox.FormattingEnabled = true;
            this.nationalité_comboBox.Location = new System.Drawing.Point(442, 277);
            this.nationalité_comboBox.Name = "nationalité_comboBox";
            this.nationalité_comboBox.Size = new System.Drawing.Size(219, 21);
            this.nationalité_comboBox.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(442, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 43;
            // 
            // erreur_prénom
            // 
            this.erreur_prénom.AutoSize = true;
            this.erreur_prénom.ForeColor = System.Drawing.Color.Red;
            this.erreur_prénom.Location = new System.Drawing.Point(445, 247);
            this.erreur_prénom.Name = "erreur_prénom";
            this.erreur_prénom.Size = new System.Drawing.Size(125, 13);
            this.erreur_prénom.TabIndex = 44;
            this.erreur_prénom.Tag = "erreur";
            this.erreur_prénom.Text = "! Saisissez votre  Prénom";
            // 
            // erreur_nationalité
            // 
            this.erreur_nationalité.AutoSize = true;
            this.erreur_nationalité.ForeColor = System.Drawing.Color.Red;
            this.erreur_nationalité.Location = new System.Drawing.Point(445, 301);
            this.erreur_nationalité.Name = "erreur_nationalité";
            this.erreur_nationalité.Size = new System.Drawing.Size(139, 13);
            this.erreur_nationalité.TabIndex = 45;
            this.erreur_nationalité.Tag = "erreur";
            this.erreur_nationalité.Text = "! Saisissez votre  Nationalité";
            // 
            // erreur_mdp
            // 
            this.erreur_mdp.AutoSize = true;
            this.erreur_mdp.ForeColor = System.Drawing.Color.Red;
            this.erreur_mdp.Location = new System.Drawing.Point(445, 416);
            this.erreur_mdp.Name = "erreur_mdp";
            this.erreur_mdp.Size = new System.Drawing.Size(151, 13);
            this.erreur_mdp.TabIndex = 46;
            this.erreur_mdp.Tag = "erreur";
            this.erreur_mdp.Text = "! Saisissez votre Mot de Passe";
            // 
            // erreur_id
            // 
            this.erreur_id.AutoSize = true;
            this.erreur_id.ForeColor = System.Drawing.Color.Red;
            this.erreur_id.Location = new System.Drawing.Point(445, 356);
            this.erreur_id.Name = "erreur_id";
            this.erreur_id.Size = new System.Drawing.Size(135, 13);
            this.erreur_id.TabIndex = 47;
            this.erreur_id.Tag = "erreur";
            this.erreur_id.Text = "! Saisissez votre  Identifiant";
            // 
            // erreur_nom
            // 
            this.erreur_nom.AutoSize = true;
            this.erreur_nom.ForeColor = System.Drawing.Color.Red;
            this.erreur_nom.Location = new System.Drawing.Point(445, 187);
            this.erreur_nom.Name = "erreur_nom";
            this.erreur_nom.Size = new System.Drawing.Size(111, 13);
            this.erreur_nom.TabIndex = 48;
            this.erreur_nom.Tag = "erreur";
            this.erreur_nom.Text = "! Saisissez votre  Nom";
            // 
            // ConfirmationMdpTextBox
            // 
            this.ConfirmationMdpTextBox.Location = new System.Drawing.Point(442, 449);
            this.ConfirmationMdpTextBox.MaxLength = 32;
            this.ConfirmationMdpTextBox.Name = "ConfirmationMdpTextBox";
            this.ConfirmationMdpTextBox.Size = new System.Drawing.Size(219, 20);
            this.ConfirmationMdpTextBox.TabIndex = 33;
            this.ConfirmationMdpTextBox.UseSystemPasswordChar = true;
            this.ConfirmationMdpTextBox.TextChanged += new System.EventHandler(this.ConfirmationMdpTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(325, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Confirmer mot de passe";
            // 
            // ConfirmationMdpLabel
            // 
            this.ConfirmationMdpLabel.AutoSize = true;
            this.ConfirmationMdpLabel.ForeColor = System.Drawing.Color.Red;
            this.ConfirmationMdpLabel.Location = new System.Drawing.Point(445, 472);
            this.ConfirmationMdpLabel.Name = "ConfirmationMdpLabel";
            this.ConfirmationMdpLabel.Size = new System.Drawing.Size(175, 13);
            this.ConfirmationMdpLabel.TabIndex = 51;
            this.ConfirmationMdpLabel.Tag = "erreur";
            this.ConfirmationMdpLabel.Text = "! Saisissez le même le mot de passe";
            // 
            // viewMdp
            // 
            this.viewMdp.Location = new System.Drawing.Point(678, 393);
            this.viewMdp.Name = "viewMdp";
            this.viewMdp.Size = new System.Drawing.Size(27, 23);
            this.viewMdp.TabIndex = 36;
            this.viewMdp.Text = "o";
            this.viewMdp.UseVisualStyleBackColor = true;
            this.viewMdp.Click += new System.EventHandler(this.viewMdp_Click);
            // 
            // viewConfirmMdp
            // 
            this.viewConfirmMdp.Location = new System.Drawing.Point(678, 447);
            this.viewConfirmMdp.Name = "viewConfirmMdp";
            this.viewConfirmMdp.Size = new System.Drawing.Size(27, 23);
            this.viewConfirmMdp.TabIndex = 37;
            this.viewConfirmMdp.Text = "o";
            this.viewConfirmMdp.UseVisualStyleBackColor = true;
            this.viewConfirmMdp.Click += new System.EventHandler(this.viewConfirmMdp_Click);
            // 
            // Client_Inscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.viewConfirmMdp);
            this.Controls.Add(this.viewMdp);
            this.Controls.Add(this.ConfirmationMdpLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConfirmationMdpTextBox);
            this.Controls.Add(this.erreur_nom);
            this.Controls.Add(this.erreur_id);
            this.Controls.Add(this.erreur_mdp);
            this.Controls.Add(this.erreur_nationalité);
            this.Controls.Add(this.erreur_prénom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nationalité_comboBox);
            this.Controls.Add(this.retour_button);
            this.Controls.Add(this.ajouterAbonné);
            this.Controls.Add(this.Mot_de_passe);
            this.Controls.Add(this.Identifiant);
            this.Controls.Add(this.Prénom);
            this.Controls.Add(this.Nom);
            this.Controls.Add(this.Nationalité);
            this.Controls.Add(this.inscription);
            this.Controls.Add(this.mdp_box);
            this.Controls.Add(this.id_box);
            this.Controls.Add(this.prénom_box);
            this.Controls.Add(this.nom_box);
            this.Name = "Client_Inscription";
            this.Text = "Client_Inscription";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ajouterAbonné;
        private System.Windows.Forms.Label Mot_de_passe;
        private System.Windows.Forms.Label Identifiant;
        private System.Windows.Forms.Label Prénom;
        private System.Windows.Forms.Label Nom;
        private System.Windows.Forms.Label Nationalité;
        private System.Windows.Forms.Button inscription;
        private System.Windows.Forms.TextBox mdp_box;
        private System.Windows.Forms.TextBox id_box;
        private System.Windows.Forms.TextBox prénom_box;
        private System.Windows.Forms.TextBox nom_box;
        private System.Windows.Forms.Button retour_button;
        private System.Windows.Forms.ComboBox nationalité_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label erreur_prénom;
        private System.Windows.Forms.Label erreur_nationalité;
        private System.Windows.Forms.Label erreur_mdp;
        private System.Windows.Forms.Label erreur_id;
        private System.Windows.Forms.Label erreur_nom;
        private System.Windows.Forms.TextBox ConfirmationMdpTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ConfirmationMdpLabel;
        private System.Windows.Forms.Button viewMdp;
        private System.Windows.Forms.Button viewConfirmMdp;
    }
}