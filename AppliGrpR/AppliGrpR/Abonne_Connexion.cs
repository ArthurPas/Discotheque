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
            Accueil a = new Accueil();
            a.Show();
            this.Close();
        }

        private void SeConnecter_MouseDown(object sender, MouseEventArgs e)
        {
            string sql = "Select PASSWORD_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = '"+ Utils.manageSingleQuote(pseudoTextBox.Text) + "'";
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            string motDePasseBDD = "";
            string motDePasse = motdepassetextbox.Text.Trim(' ');
            
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                motDePasseBDD = reader.GetString(0).Trim(' ');
            }
            string a = DecryptageDeMotDePasse(motDePasseBDD);
            if (motDePasse.Equals(DecryptageDeMotDePasse(motDePasseBDD)) && !motDePasse.Equals(""))
            {
                string nom = "";
                string prenom = "";
                string id="";
                string sqlSet = "Select NOM_ABONNÉ, PRÉNOM_ABONNÉ, LOGIN_ABONNÉ, PASSWORD_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = '" + Utils.manageSingleQuote(pseudoTextBox.Text) + "'";
                OleDbCommand cmdSet = new OleDbCommand(sqlSet, dbCon);
                OleDbDataReader readerSet = cmdSet.ExecuteReader();
                while (readerSet.Read())
                {
                    nom = Utils.manageSingleQuote(readerSet.GetString(0));

                    prenom = Utils.manageSingleQuote(readerSet.GetString(1));

                    id = Utils.manageSingleQuote(readerSet.GetString(2));
                }
                readerSet.Close();

                this.Close();
                Abonne_Accueil AbonneAccueil = new Abonne_Accueil(nom,prenom,id);
                AbonneAccueil.StartPosition = FormStartPosition.CenterScreen;
                AbonneAccueil.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Le mot de passe ou l'utilisateur est incorrect");

                Console.WriteLine(motDePasse + "     " + DecryptageDeMotDePasse(motDePasseBDD));

            }
        }

        /// <summary>
        /// Permet de décrypter un mot de passe de la base de donnée
        /// </summary>
        /// <param name="mdp">le mot de passe a décrypté</param>
        /// <returns>le mot de passe décrypté</returns>
        public string DecryptageDeMotDePasse(string mdp)
        {
            string decrypt = "";
            for (int i = 0; i < mdp.Length; i++)
            {
                if ((char)mdp[i]!=' ' && (char)mdp[i] > '9')
                {
                    decrypt += (char)(mdp[i] - 'a');
                } 
                else if((char)mdp[i] == ' ')
                {
                    decrypt += ' ';
                }
                else
                {
                    decrypt += (char)mdp[i];
                }
            }
            return decrypt;
        }

        private void viewMdp_Click(object sender, EventArgs e)
        {
            motdepassetextbox.UseSystemPasswordChar = !motdepassetextbox.UseSystemPasswordChar;
        }
    }
}
