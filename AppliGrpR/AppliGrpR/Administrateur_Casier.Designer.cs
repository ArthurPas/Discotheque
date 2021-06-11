
namespace AppliGrpR
{
    partial class Administrateur_Casier
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
            this.numCasier = new System.Windows.Forms.ComboBox();
            this.listCasierEmprunts = new System.Windows.Forms.ListBox();
            this.numCasierTxt = new System.Windows.Forms.Label();
            this.RetourButton = new System.Windows.Forms.Button();
            this.imageAlbum = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageAlbum)).BeginInit();
            this.SuspendLayout();
            // 
            // numCasier
            // 
            this.numCasier.FormattingEnabled = true;
            this.numCasier.Location = new System.Drawing.Point(156, 99);
            this.numCasier.Name = "numCasier";
            this.numCasier.Size = new System.Drawing.Size(121, 21);
            this.numCasier.TabIndex = 0;
            this.numCasier.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listCasierEmprunts
            // 
            this.listCasierEmprunts.FormattingEnabled = true;
            this.listCasierEmprunts.Location = new System.Drawing.Point(421, 55);
            this.listCasierEmprunts.Name = "listCasierEmprunts";
            this.listCasierEmprunts.Size = new System.Drawing.Size(247, 342);
            this.listCasierEmprunts.TabIndex = 1;
            this.listCasierEmprunts.SelectedIndexChanged += new System.EventHandler(this.listCasierEmprunts_SelectedIndexChanged);
            // 
            // numCasierTxt
            // 
            this.numCasierTxt.AutoSize = true;
            this.numCasierTxt.Location = new System.Drawing.Point(170, 66);
            this.numCasierTxt.Name = "numCasierTxt";
            this.numCasierTxt.Size = new System.Drawing.Size(96, 13);
            this.numCasierTxt.TabIndex = 2;
            this.numCasierTxt.Text = "Numéro du casier :";
            // 
            // RetourButton
            // 
            this.RetourButton.BackColor = System.Drawing.Color.Navy;
            this.RetourButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RetourButton.Location = new System.Drawing.Point(697, 12);
            this.RetourButton.Name = "RetourButton";
            this.RetourButton.Size = new System.Drawing.Size(75, 23);
            this.RetourButton.TabIndex = 3;
            this.RetourButton.Text = "Retour";
            this.RetourButton.UseVisualStyleBackColor = false;
            this.RetourButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RetourButton_MouseDown);
            // 
            // imageAlbum
            // 
            this.imageAlbum.Location = new System.Drawing.Point(127, 178);
            this.imageAlbum.Name = "imageAlbum";
            this.imageAlbum.Size = new System.Drawing.Size(200, 200);
            this.imageAlbum.TabIndex = 4;
            this.imageAlbum.TabStop = false;
            // 
            // Administrateur_Casier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.imageAlbum);
            this.Controls.Add(this.RetourButton);
            this.Controls.Add(this.numCasierTxt);
            this.Controls.Add(this.listCasierEmprunts);
            this.Controls.Add(this.numCasier);
            this.Name = "Administrateur_Casier";
            this.Text = "Administrateur_Casier";
            ((System.ComponentModel.ISupportInitialize)(this.imageAlbum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox numCasier;
        private System.Windows.Forms.ListBox listCasierEmprunts;
        private System.Windows.Forms.Label numCasierTxt;
        private System.Windows.Forms.Button RetourButton;
        private System.Windows.Forms.PictureBox imageAlbum;
    }
}