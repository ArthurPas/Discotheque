
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
            this.label1 = new System.Windows.Forms.Label();
            this.SearchName = new System.Windows.Forms.TextBox();
            this.Consulter = new System.Windows.Forms.Button();
            this.ListButton = new System.Windows.Forms.Button();
            this.buttonTOP10 = new System.Windows.Forms.Button();
            this.Suppression = new System.Windows.Forms.Button();
            this.Recomandation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(172, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(172, 123);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(172, 166);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(172, 208);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 4;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(172, 247);
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
            this.listBox1.Location = new System.Drawing.Point(519, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(254, 238);
            this.listBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(616, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nom Abonne";
            // 
            // SearchName
            // 
            this.SearchName.Location = new System.Drawing.Point(605, 297);
            this.SearchName.Name = "SearchName";
            this.SearchName.Size = new System.Drawing.Size(100, 20);
            this.SearchName.TabIndex = 8;
            // 
            // Consulter
            // 
            this.Consulter.Location = new System.Drawing.Point(610, 358);
            this.Consulter.Name = "Consulter";
            this.Consulter.Size = new System.Drawing.Size(75, 23);
            this.Consulter.TabIndex = 9;
            this.Consulter.Text = "Consulter";
            this.Consulter.UseVisualStyleBackColor = true;
            this.Consulter.Click += new System.EventHandler(this.Consulter_Click);
            // 
            // ListButton
            // 
            this.ListButton.Location = new System.Drawing.Point(225, 374);
            this.ListButton.Name = "ListButton";
            this.ListButton.Size = new System.Drawing.Size(86, 38);
            this.ListButton.TabIndex = 0;
            this.ListButton.Text = "Liste prolongé";
            // 
            // buttonTOP10
            // 
            this.buttonTOP10.Location = new System.Drawing.Point(22, 374);
            this.buttonTOP10.Name = "buttonTOP10";
            this.buttonTOP10.Size = new System.Drawing.Size(120, 38);
            this.buttonTOP10.TabIndex = 10;
            this.buttonTOP10.Text = "Afficher TOP10";
            this.buttonTOP10.UseVisualStyleBackColor = true;
            this.buttonTOP10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonTOP10_MouseDown_1);
            // 
            // Suppression
            // 
            this.Suppression.Location = new System.Drawing.Point(407, 374);
            this.Suppression.Name = "Suppression";
            this.Suppression.Size = new System.Drawing.Size(86, 38);
            this.Suppression.TabIndex = 11;
            this.Suppression.Text = "Suppression plus 1 an";
            this.Suppression.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Suppression_MouseDown);
            // 
            // Recomandation
            // 
            this.Recomandation.Location = new System.Drawing.Point(519, 382);
            this.Recomandation.Name = "Recomandation";
            this.Recomandation.Size = new System.Drawing.Size(75, 23);
            this.Recomandation.TabIndex = 12;
            this.Recomandation.Text = "recommandations";
            this.Recomandation.UseVisualStyleBackColor = true;
            this.Recomandation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Recomandation_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Recomandation);
            this.Controls.Add(this.Suppression);
            this.Controls.Add(this.buttonTOP10);
            this.Controls.Add(this.ListButton);
            this.Controls.Add(this.Consulter);
            this.Controls.Add(this.SearchName);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchName;
        private System.Windows.Forms.Button Consulter;
        private System.Windows.Forms.Button ListButton;
        private System.Windows.Forms.Button buttonTOP10;
        private System.Windows.Forms.Button Suppression;
        private System.Windows.Forms.Button Recomandation;
    }
}

