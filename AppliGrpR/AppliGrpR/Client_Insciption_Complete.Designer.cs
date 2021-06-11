
namespace AppliGrpR
{
    partial class Client_Insciption_Complete
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
            this.continuer = new System.Windows.Forms.Button();
            this.quitter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // continuer
            // 
            this.continuer.BackColor = System.Drawing.Color.LightSkyBlue;
            this.continuer.Location = new System.Drawing.Point(619, 394);
            this.continuer.Name = "continuer";
            this.continuer.Size = new System.Drawing.Size(116, 37);
            this.continuer.TabIndex = 0;
            this.continuer.Text = "Continuer";
            this.continuer.UseVisualStyleBackColor = false;
            this.continuer.Click += new System.EventHandler(this.continuer_Click);
            // 
            // quitter
            // 
            this.quitter.BackColor = System.Drawing.Color.LightSkyBlue;
            this.quitter.Location = new System.Drawing.Point(401, 396);
            this.quitter.Name = "quitter";
            this.quitter.Size = new System.Drawing.Size(116, 35);
            this.quitter.TabIndex = 1;
            this.quitter.Text = "Quitter";
            this.quitter.UseVisualStyleBackColor = false;
            this.quitter.Click += new System.EventHandler(this.quitter_Click);
            // 
            // Client_Insciption_Complete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.quitter);
            this.Controls.Add(this.continuer);
            this.Name = "Client_Insciption_Complete";
            this.Text = "Client_Insciption_Complete";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Client_Insciption_Complete_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button continuer;
        private System.Windows.Forms.Button quitter;
    }
}