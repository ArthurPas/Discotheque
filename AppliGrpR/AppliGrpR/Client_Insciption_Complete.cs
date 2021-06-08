using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliGrpR
{
    public partial class Client_Insciption_Complete : Form
    {
        string nom, prénom, id;

        public Client_Insciption_Complete(string nom, string prénom, string id)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.nom = nom;
            this.prénom = prénom;
            this.id = id;
        }

       
        /// <summary>
        /// Affiche message de confirmation d'inscription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Client_Insciption_Complete_Paint(object sender, PaintEventArgs e)
        {
            string message = "Bonjour, " + prénom + " " + nom + ", votre compte ayant pour identifiant '" + id + "' a bien était créer." + '\n' + "\n"
                + "Appuyer sur continuer pour vous rendre à la page d'accueil et vous pourrez désormais vous connecter";

            Font font = new Font("Arial", 16);
            SolidBrush brush = new SolidBrush(Color.Black);

            float x = 550.0F;
            float y = 200.0F;

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(message, font, brush, x, y,format);
        }

        private void continuer_Click(object sender, EventArgs e)
        {
            Accueil a = new Accueil();
            a.Show();
            this.Close();
        }

        private void quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
