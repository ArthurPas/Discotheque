
namespace AppliGrpR
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Numero_Abonne = new System.Windows.Forms.Label();
            this.Consulter = new System.Windows.Forms.Button();
            this.ListButton = new System.Windows.Forms.Button();
            this.buttonTOP10 = new System.Windows.Forms.Button();
            this.Suppression = new System.Windows.Forms.Button();
            this.Recomandation = new System.Windows.Forms.Button();
            this.Nationalité = new System.Windows.Forms.Label();
            this.Nom = new System.Windows.Forms.Label();
            this.Prénom = new System.Windows.Forms.Label();
            this.Identifiant = new System.Windows.Forms.Label();
            this.Mot_de_passe = new System.Windows.Forms.Label();
            this.nationalite = new System.Windows.Forms.ListBox();
            this.ajouterAbonné = new System.Windows.Forms.Label();
            this.Affichage = new System.Windows.Forms.Label();
            this.Partie_abonne = new System.Windows.Forms.Label();
            this.Partie_admin = new System.Windows.Forms.Label();
            this.US2 = new System.Windows.Forms.Label();
            this.US4 = new System.Windows.Forms.Label();
            this.US10 = new System.Windows.Forms.Label();
            this.US7 = new System.Windows.Forms.Label();
            this.US1 = new System.Windows.Forms.Label();
            this.US6 = new System.Windows.Forms.Label();
            this.ListeAbonne = new System.Windows.Forms.ListBox();
            this.numeroAbonne = new System.Windows.Forms.TextBox();
            this.Liste_Abonne = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(122, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(122, 123);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(122, 166);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(122, 208);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 4;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(135, 245);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Ajouter";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(632, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(384, 251);
            this.listBox1.TabIndex = 6;
            // 
            // Numero_Abonne
            // 
            this.Numero_Abonne.AutoSize = true;
            this.Numero_Abonne.Location = new System.Drawing.Point(932, 434);
            this.Numero_Abonne.Name = "Numero_Abonne";
            this.Numero_Abonne.Size = new System.Drawing.Size(84, 13);
            this.Numero_Abonne.TabIndex = 7;
            this.Numero_Abonne.Text = "Numero Abonne";
            // 
            // Consulter
            // 
            this.Consulter.Location = new System.Drawing.Point(939, 498);
            this.Consulter.Name = "Consulter";
            this.Consulter.Size = new System.Drawing.Size(75, 39);
            this.Consulter.TabIndex = 9;
            this.Consulter.Text = "Consulter emprunt";
            this.Consulter.UseVisualStyleBackColor = true;
            this.Consulter.Click += new System.EventHandler(this.Consulter_Click);
            // 
            // ListButton
            // 
            this.ListButton.Location = new System.Drawing.Point(106, 461);
            this.ListButton.Name = "ListButton";
            this.ListButton.Size = new System.Drawing.Size(86, 38);
            this.ListButton.TabIndex = 0;
            this.ListButton.Text = "Liste prolongé";
            // 
            // buttonTOP10
            // 
            this.buttonTOP10.Location = new System.Drawing.Point(226, 461);
            this.buttonTOP10.Name = "buttonTOP10";
            this.buttonTOP10.Size = new System.Drawing.Size(120, 38);
            this.buttonTOP10.TabIndex = 10;
            this.buttonTOP10.Text = "Afficher TOP10";
            this.buttonTOP10.UseVisualStyleBackColor = true;
            this.buttonTOP10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonTOP10_MouseDown_1);
            // 
            // Suppression
            // 
            this.Suppression.Location = new System.Drawing.Point(395, 461);
            this.Suppression.Name = "Suppression";
            this.Suppression.Size = new System.Drawing.Size(86, 38);
            this.Suppression.TabIndex = 11;
            this.Suppression.Text = "Suppression plus 1 an";
            this.Suppression.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Suppression_MouseDown);
            // 
            // Recomandation
            // 
            this.Recomandation.Location = new System.Drawing.Point(672, 469);
            this.Recomandation.Name = "Recomandation";
            this.Recomandation.Size = new System.Drawing.Size(75, 23);
            this.Recomandation.TabIndex = 12;
            this.Recomandation.Text = "recommandations";
            this.Recomandation.UseVisualStyleBackColor = true;
            this.Recomandation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Recomandation_MouseDown);
            // 
            // Nationalité
            // 
            this.Nationalité.AutoSize = true;
            this.Nationalité.Location = new System.Drawing.Point(19, 48);
            this.Nationalité.Name = "Nationalité";
            this.Nationalité.Size = new System.Drawing.Size(57, 13);
            this.Nationalité.TabIndex = 12;
            this.Nationalité.Text = "Nationalité";
            // 
            // Nom
            // 
            this.Nom.AutoSize = true;
            this.Nom.Location = new System.Drawing.Point(19, 88);
            this.Nom.Name = "Nom";
            this.Nom.Size = new System.Drawing.Size(29, 13);
            this.Nom.TabIndex = 13;
            this.Nom.Text = "Nom";
            // 
            // Prénom
            // 
            this.Prénom.AutoSize = true;
            this.Prénom.Location = new System.Drawing.Point(19, 126);
            this.Prénom.Name = "Prénom";
            this.Prénom.Size = new System.Drawing.Size(43, 13);
            this.Prénom.TabIndex = 14;
            this.Prénom.Text = "Prénom";
            // 
            // Identifiant
            // 
            this.Identifiant.AutoSize = true;
            this.Identifiant.Location = new System.Drawing.Point(19, 169);
            this.Identifiant.Name = "Identifiant";
            this.Identifiant.Size = new System.Drawing.Size(53, 13);
            this.Identifiant.TabIndex = 15;
            this.Identifiant.Text = "Identifiant";
            // 
            // Mot_de_passe
            // 
            this.Mot_de_passe.AutoSize = true;
            this.Mot_de_passe.Location = new System.Drawing.Point(19, 211);
            this.Mot_de_passe.Name = "Mot_de_passe";
            this.Mot_de_passe.Size = new System.Drawing.Size(71, 13);
            this.Mot_de_passe.TabIndex = 16;
            this.Mot_de_passe.Text = "Mot de passe";
            // 
            // nationalite
            // 
            this.nationalite.FormattingEnabled = true;
            this.nationalite.Location = new System.Drawing.Point(239, 48);
            this.nationalite.Name = "nationalite";
            this.nationalite.Size = new System.Drawing.Size(120, 186);
            this.nationalite.TabIndex = 17;
            this.nationalite.SelectedIndexChanged += new System.EventHandler(this.nationalite_SelectedIndexChanged);
            // 
            // ajouterAbonné
            // 
            this.ajouterAbonné.AutoSize = true;
            this.ajouterAbonné.Location = new System.Drawing.Point(135, 13);
            this.ajouterAbonné.Name = "ajouterAbonné";
            this.ajouterAbonné.Size = new System.Drawing.Size(74, 13);
            this.ajouterAbonné.TabIndex = 18;
            this.ajouterAbonné.Text = "Ajouter Aboné";
            // 
            // Affichage
            // 
            this.Affichage.AutoSize = true;
            this.Affichage.Location = new System.Drawing.Point(695, 9);
            this.Affichage.Name = "Affichage";
            this.Affichage.Size = new System.Drawing.Size(52, 13);
            this.Affichage.TabIndex = 19;
            this.Affichage.Text = "Affichage";
            // 
            // Partie_abonne
            // 
            this.Partie_abonne.AutoSize = true;
            this.Partie_abonne.Location = new System.Drawing.Point(735, 308);
            this.Partie_abonne.Name = "Partie_abonne";
            this.Partie_abonne.Size = new System.Drawing.Size(73, 13);
            this.Partie_abonne.TabIndex = 20;
            this.Partie_abonne.Text = "Partie abonne";
            // 
            // Partie_admin
            // 
            this.Partie_admin.AutoSize = true;
            this.Partie_admin.Location = new System.Drawing.Point(281, 308);
            this.Partie_admin.Name = "Partie_admin";
            this.Partie_admin.Size = new System.Drawing.Size(65, 13);
            this.Partie_admin.TabIndex = 21;
            this.Partie_admin.Text = "Partie admin";
            // 
            // US2
            // 
            this.US2.AutoSize = true;
            this.US2.Location = new System.Drawing.Point(961, 474);
            this.US2.Name = "US2";
            this.US2.Size = new System.Drawing.Size(28, 13);
            this.US2.TabIndex = 22;
            this.US2.Text = "US2";
            // 
            // US4
            // 
            this.US4.AutoSize = true;
            this.US4.Location = new System.Drawing.Point(132, 445);
            this.US4.Name = "US4";
            this.US4.Size = new System.Drawing.Size(28, 13);
            this.US4.TabIndex = 23;
            this.US4.Text = "US4";
            // 
            // US10
            // 
            this.US10.AutoSize = true;
            this.US10.Location = new System.Drawing.Point(695, 453);
            this.US10.Name = "US10";
            this.US10.Size = new System.Drawing.Size(34, 13);
            this.US10.TabIndex = 24;
            this.US10.Text = "US10";
            // 
            // US7
            // 
            this.US7.AutoSize = true;
            this.US7.Location = new System.Drawing.Point(271, 445);
            this.US7.Name = "US7";
            this.US7.Size = new System.Drawing.Size(28, 13);
            this.US7.TabIndex = 25;
            this.US7.Text = "US7";
            // 
            // US1
            // 
            this.US1.AutoSize = true;
            this.US1.Location = new System.Drawing.Point(157, 32);
            this.US1.Name = "US1";
            this.US1.Size = new System.Drawing.Size(28, 13);
            this.US1.TabIndex = 26;
            this.US1.Text = "US1";
            // 
            // US6
            // 
            this.US6.AutoSize = true;
            this.US6.Location = new System.Drawing.Point(421, 445);
            this.US6.Name = "US6";
            this.US6.Size = new System.Drawing.Size(28, 13);
            this.US6.TabIndex = 27;
            this.US6.Text = "US6";
            // 
            // ListeAbonne
            // 
            this.ListeAbonne.FormattingEnabled = true;
            this.ListeAbonne.Location = new System.Drawing.Point(783, 450);
            this.ListeAbonne.Name = "ListeAbonne";
            this.ListeAbonne.Size = new System.Drawing.Size(120, 82);
            this.ListeAbonne.TabIndex = 28;
            this.ListeAbonne.SelectedIndexChanged += new System.EventHandler(this.ListeAbonne_SelectedIndexChanged);
            // 
            // numeroAbonne
            // 
            this.numeroAbonne.Location = new System.Drawing.Point(926, 450);
            this.numeroAbonne.Name = "numeroAbonne";
            this.numeroAbonne.Size = new System.Drawing.Size(100, 20);
            this.numeroAbonne.TabIndex = 29;
            // 
            // Liste_Abonne
            // 
            this.Liste_Abonne.AutoSize = true;
            this.Liste_Abonne.Location = new System.Drawing.Point(805, 434);
            this.Liste_Abonne.Name = "Liste_Abonne";
            this.Liste_Abonne.Size = new System.Drawing.Size(69, 13);
            this.Liste_Abonne.TabIndex = 30;
            this.Liste_Abonne.Text = "Liste Abonne";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 627);
            this.Controls.Add(this.Liste_Abonne);
            this.Controls.Add(this.numeroAbonne);
            this.Controls.Add(this.ListeAbonne);
            this.Controls.Add(this.US6);
            this.Controls.Add(this.US1);
            this.Controls.Add(this.US7);
            this.Controls.Add(this.US10);
            this.Controls.Add(this.US4);
            this.Controls.Add(this.US2);
            this.Controls.Add(this.Partie_admin);
            this.Controls.Add(this.Partie_abonne);
            this.Controls.Add(this.Affichage);
            this.Controls.Add(this.ajouterAbonné);
            this.Controls.Add(this.Recomandation);
            this.Controls.Add(this.nationalite);
            this.Controls.Add(this.Mot_de_passe);
            this.Controls.Add(this.Identifiant);
            this.Controls.Add(this.Prénom);
            this.Controls.Add(this.Nom);
            this.Controls.Add(this.Nationalité);
            this.Controls.Add(this.Suppression);
            this.Controls.Add(this.buttonTOP10);
            this.Controls.Add(this.ListButton);
            this.Controls.Add(this.Consulter);
            this.Controls.Add(this.Numero_Abonne);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label Numero_Abonne;
        private System.Windows.Forms.Button Consulter;
        private System.Windows.Forms.Button ListButton;
        private System.Windows.Forms.Button buttonTOP10;
        private System.Windows.Forms.Button Suppression;
        private System.Windows.Forms.Button Recomandation;
        private System.Windows.Forms.Label Nationalité;
        private System.Windows.Forms.Label Nom;
        private System.Windows.Forms.Label Prénom;
        private System.Windows.Forms.Label Identifiant;
        private System.Windows.Forms.Label Mot_de_passe;
        private System.Windows.Forms.ListBox nationalite;
        private System.Windows.Forms.Label ajouterAbonné;
        private System.Windows.Forms.Label Affichage;
        private System.Windows.Forms.Label Partie_abonne;
        private System.Windows.Forms.Label Partie_admin;
        private System.Windows.Forms.Label US2;
        private System.Windows.Forms.Label US4;
        private System.Windows.Forms.Label US10;
        private System.Windows.Forms.Label US7;
        private System.Windows.Forms.Label US1;
        private System.Windows.Forms.Label US6;
        private System.Windows.Forms.ListBox ListeAbonne;
        private System.Windows.Forms.TextBox numeroAbonne;
        private System.Windows.Forms.Label Liste_Abonne;
    }
}

