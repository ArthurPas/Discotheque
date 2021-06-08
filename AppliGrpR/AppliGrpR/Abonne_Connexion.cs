using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliGrpR
{
    public partial class Abonne_Connexion : Form
    {
        OleDbConnection dbCon = Accueil.dbCon;
        public Abonne_Connexion()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Retour_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void SeConnecter_MouseDown(object sender, MouseEventArgs e)
        {
            string sql = "Select PASSWORD_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = '"+ pseudoTextBox.Text + "'";
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            string motDePasseBDD = "";
            string motDePasse = motdepassetextbox.Text;
            int taille = motDePasse.Length;
            char c = ' ';
            while(taille!=32)
            {
                motDePasse+=c;
                taille = motDePasse.Length;
            }
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                motDePasseBDD = reader.GetString(0);
            }
            if (motDePasse.Equals(motDePasseBDD))
            {
                string sqlSet = "Select NOM_ABONNÉ, PRÉNOM_ABONNÉ, LOGIN_ABONNÉ, PASSWORD_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = '" + pseudoTextBox.Text + "'";
                OleDbCommand cmdSet = new OleDbCommand(sqlSet, dbCon);
                OleDbDataReader readerSet = cmdSet.ExecuteReader();
                while (readerSet.Read())
                {
                    string nom = readerSet.GetString(0);
                    Abonne_Accueil.Nom = nom;

                    string prenom = readerSet.GetString(1);
                    Abonne_Accueil.Prenom = prenom;

                    string login = readerSet.GetString(2);
                    Abonne_Accueil.Id = login;

                    Abonne_Accueil.MotDePasse = motDePasse;
                }

                this.Close();
                Abonne_Accueil AbonneAccueil = new Abonne_Accueil();
                AbonneAccueil.StartPosition = FormStartPosition.CenterScreen;
                AbonneAccueil.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Le mot de passe ou l'utilisateur est incorrect");
            }
        }
    }
}
