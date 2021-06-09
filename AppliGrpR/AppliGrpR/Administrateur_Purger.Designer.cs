
namespace AppliGrpR
{
    partial class Administrateur_Purger
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
            this.AbonnesPurger = new System.Windows.Forms.ListBox();
            this.Retour = new System.Windows.Forms.Button();
            this.PurgeAll = new System.Windows.Forms.Button();
            this.inactifPlusUnAn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AbonnesPurger
            // 
            this.AbonnesPurger.FormattingEnabled = true;
            this.AbonnesPurger.Location = new System.Drawing.Point(216, 93);
            this.AbonnesPurger.Name = "AbonnesPurger";
            this.AbonnesPurger.Size = new System.Drawing.Size(367, 186);
            this.AbonnesPurger.TabIndex = 0;
            // 
            // Retour
            // 
            this.Retour.Location = new System.Drawing.Point(713, 12);
            this.Retour.Name = "Retour";
            this.Retour.Size = new System.Drawing.Size(75, 23);
            this.Retour.TabIndex = 11;
            this.Retour.Text = "Retour";
            this.Retour.UseVisualStyleBackColor = true;
            this.Retour.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Retour_MouseDown);
            // 
            // PurgeAll
            // 
            this.PurgeAll.Location = new System.Drawing.Point(353, 363);
            this.PurgeAll.Name = "PurgeAll";
            this.PurgeAll.Size = new System.Drawing.Size(75, 23);
            this.PurgeAll.TabIndex = 13;
            this.PurgeAll.Text = "Purger tous les abonnes";
            this.PurgeAll.UseVisualStyleBackColor = true;
            this.PurgeAll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PurgeAll_MouseDown);
            // 
            // inactifPlusUnAn
            // 
            this.inactifPlusUnAn.AutoSize = true;
            this.inactifPlusUnAn.Location = new System.Drawing.Point(213, 77);
            this.inactifPlusUnAn.Name = "inactifPlusUnAn";
            this.inactifPlusUnAn.Size = new System.Drawing.Size(174, 13);
            this.inactifPlusUnAn.TabIndex = 14;
            this.inactifPlusUnAn.Text = "Abonnes inactif depuis plus d\'un an";
            // 
            // Administrateur_Purger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.inactifPlusUnAn);
            this.Controls.Add(this.PurgeAll);
            this.Controls.Add(this.Retour);
            this.Controls.Add(this.AbonnesPurger);
            this.Name = "Administrateur_Purger";
            this.Text = "Administrateur_Purger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AbonnesPurger;
        private System.Windows.Forms.Button Retour;
        private System.Windows.Forms.Button PurgeAll;
        private System.Windows.Forms.Label inactifPlusUnAn;
    }
}