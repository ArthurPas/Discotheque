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
    public partial class Administrateur_Connexion : Form
    {

        public Administrateur_Connexion()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void SeConnecter_MouseDown(object sender, MouseEventArgs e)
        {
            if (pseudoTextBox.Text.Equals("admin") && motdepassetextbox.Text.Equals("admin")) {
                this.Close();
                AdministrateurAccueil admin = new AdministrateurAccueil();
                admin.StartPosition = FormStartPosition.CenterScreen;
                admin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Utilisateur ou mot de passe incorrect");
            }
        }

        private void Retour_MouseDown(object sender, MouseEventArgs e)
        {
            Accueil a = new Accueil();
            a.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            motdepassetextbox.UseSystemPasswordChar = !motdepassetextbox.UseSystemPasswordChar;
        }
    }
}
