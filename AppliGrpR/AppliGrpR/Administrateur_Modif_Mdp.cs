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
    public partial class Administrateur_Modif_Mdp : Form
    {
        OleDbConnection dbCon = Accueil.dbCon;
        string logAbonneSelectionne="";
        List<string> listeAbo = new List<string>();
        int indexAbo = 1;
        string mdpBDD;
        bool valide = true;

        public Administrateur_Modif_Mdp()
        {
            InitializeComponent();
            Abonnes();
            this.StartPosition = FormStartPosition.CenterScreen;
            resetError();
        }

        public void afficherMdpAbonne()
        {
            string sql = "select PASSWORD_ABONNÉ from ABONNÉS where LOGIN_ABONNÉ = '"+logAbonneSelectionne+"'";
            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();

            while (reader.Read())
            {
                string mdp = reader.GetString(0);
                mdp = mdp.Trim();
                mdp = DecryptageDeMotDePasse(mdp);
                motDePasseActuel.Text = mdp;
                mdpBDD = mdp;
            }
        }

        public void modifierMDP()
        {
            resetError();
            if (newMdp_box.Text.Trim().Equals(""))
            {
                errorNewMdp.Visible = true;
                valide = false;
            }
 
            if (newMdpConfirm_box.Text.Trim().Equals(""))
            {
                errorConfirmNewMdp.Visible = true;
                valide = false;
            }

            if (!newMdp_box.Text.Equals(newMdpConfirm_box.Text))
            {
                errorMdpDifferrent.Visible = true;
                valide = false;
            }

            if (!newMdp_box.Text.Trim().Equals("") && !newMdpConfirm_box.Text.Trim().Equals("") && valide)
            {
                if (!logAbonneSelectionne.Equals(""))
                {
                    if (mdpBDD.Equals(newMdp_box.Text))
                    {
                        MessageBox.Show("Le mot de passe est le même que l'ancien");
                    }
                    string sql = "update ABONNÉS set PASSWORD_ABONNÉ = '" + EncryptageDeMotDePasse(newMdp_box.Text) + "' where LOGIN_ABONNÉ = '" + logAbonneSelectionne + "'";
                    OleDbCommand cmdUpdate = new OleDbCommand(sql, dbCon);
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Le mot de passe a bien été mis à jour");

                    newMdp_box.Text = "";
                    newMdpConfirm_box.Text = "";
                    motDePasseActuel.Text = "";
                }
                else
                {
                    MessageBox.Show("Il faut sélectionner un abonné");
                }
            }
        }

        public string EncryptageDeMotDePasse(string mdp)
        {
            string encrypt = "";
            for (int i = 0; i < mdp.Length; i++)
            {
                if ((char)(mdp[i]) > '9')
                {
                    encrypt += (char)(mdp[i] + 'a');
                }
                else
                {
                    encrypt += mdp[i];
                }
            }
            return encrypt;
        }

        void resetError()
        {
            valide = true;
            errorMdpDifferrent.Visible = false;
            errorNewMdp.Visible = false;
            errorConfirmNewMdp.Visible = false;
        }

        public string DecryptageDeMotDePasse(string mdp)
        {
            string decrypt = "";
            for (int i = 0; i < mdp.Length; i++)
            {
                if ((char)mdp[i] != ' ' && (char)mdp[i] > '9')
                {
                    decrypt += (char)(mdp[i] - 'a');
                }
                else if ((char)mdp[i] == ' ')
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


        public void Abonnes()
        {
            listeAbonnebox.Items.Clear();
            string sql = "select * from ABONNÉS";


            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();

            while (reader.Read())
            {
                string login = reader.GetString(4);
                login = login.Trim();
                listeAbo.Add(login);

            }
            Affichage_Utils.AfficherPagination(indexAbo, listeAbonnebox, listeAbo, pageListAbo, 15);
            reader.Close();
        }

        private void listeAbonnebox_SelectedIndexChanged(object sender, EventArgs e)
        {
            logAbonneSelectionne = listeAbonnebox.SelectedItem.ToString();
            afficherMdpAbonne();
        }

        private void modifierMdp_MouseDown(object sender, MouseEventArgs e)
        {
            modifierMDP();
            listeAbo.Clear();
            Abonnes();
            
        }

        private void retour_MouseDown(object sender, MouseEventArgs e)
        {
            AdministrateurAccueil adminacc = new AdministrateurAccueil();
            adminacc.Show();
            this.Close();
        }

        private void RightListButton_Click(object sender, EventArgs e)
        {
            Affichage_Utils.Paginer(ref indexAbo, listeAbonnebox, listeAbo, pageListAbo, 15,1);

        }

        private void LeftListButton_Click(object sender, EventArgs e)
        {
            Affichage_Utils.Paginer(ref indexAbo, listeAbonnebox, listeAbo, pageListAbo, 15,-1);

        }

        private void viewNewMdp_Click(object sender, EventArgs e)
        {
            newMdp_box.UseSystemPasswordChar = !newMdp_box.UseSystemPasswordChar;
        }

        private void viewConfirmNewMdp_Click(object sender, EventArgs e)
        {
            newMdpConfirm_box.UseSystemPasswordChar = !newMdpConfirm_box.UseSystemPasswordChar;
        }
    }
}
