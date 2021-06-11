using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AppliGrpR
{
    public partial class Abonne_ModifierMdp : Form
    {
        OleDbConnection dbCon = Accueil.dbCon;
        Abonne_Accueil abo;
        string mdpActuel;
        string mdpActuelEntré;
        string nouveauMdp;
        string nouveauMdpConfirm;

        public Abonne_ModifierMdp(Abonne_Accueil abo)
        {
            this.abo = abo;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            hideError();
        }

        /// <summary>
        /// Permet à l'abonné de changer son mot de passe
        /// </summary>
        public void modifierMotdePasse()
        {
            bool valide = true;
            string login = abo.Id;   //ATTENTION le Log en Static n'est pas du tout une bonne idée, le logiciel ne serait pas utilisable par plusieur utilisateur en même temps

            //Get value from TextBox && Show error if necessary
            if (mdp_box.Text == "")
            {
                errorMdp.Visible = true;
                valide = false;
            }
            else {
                mdpActuelEntré = mdp_box.Text.Trim(' ');
            }

            if (newMdp_box.Text == "")
            {
                errorNewMdp.Visible = true;
                valide = false;
            }
            else{
                nouveauMdp = newMdp_box.Text.Trim(' ');
            }
            if (newMdpConfirm_box.Text == "")
            {
                errorConfirmNewMdp.Visible = true;
                valide = false;
            }
            else{
                nouveauMdpConfirm = newMdpConfirm_box.Text.Trim(' ');
            }
            

            //Get Mdp from userLog
            string sqlSet = "SELECT PASSWORD_ABONNÉ FROM ABONNÉS where LOGIN_ABONNÉ = '" + login + "'"; 
            OleDbCommand cmd = new OleDbCommand(sqlSet, dbCon);
            OleDbDataReader reader = cmd.ExecuteReader();
   
            while (reader.Read())
            {
               mdpActuel = reader.GetString(0).Trim(' ');
            }
            mdpActuel = DecryptageDeMotDePasse(mdpActuel);

            if (nouveauMdp == mdpActuel)
            {
                errorSameMdp.Visible = true;
                valide = false;
            }
       

            //Check if Mdp from user equals mdpActuel
            if (mdpActuel != mdpActuelEntré && newMdp_box.Text != "")
            {
                errorMdpNotEqual.Visible = true;
                valide = false;
            }
            //check if newMdp = newMdpConfirm && Update the new Password if true
            if (nouveauMdp == nouveauMdpConfirm)
            {
                if (valide)
                {
                    MettreAJourMotDePasse(login, nouveauMdp);
                   
                    string message ="Votre Mot de Passe a bien été modifié";
                    string caption = "Modification de mot de passe";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    //Redirige à l'accueil après avoir appuyer sur Ok
                    if (result == DialogResult.OK)
                    {
                        abo.Show();
                        this.Close();
                    }

                }
            }
            else
            {
                errrorNewMdpConfirm.Visible = true;
            }

        }

        /// <summary>
        /// Permet de décrypter un mot de passe de la base de donnée
        /// </summary>
        /// <param name="mdp">mot de passe à décrypté</param>
        /// <returns>mot de passe décrypté</returns>
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



        /// <summary>
        /// Met a jour le Mot de Passe d'un abonné dans la base de donnée
        /// </summary>
        private void MettreAJourMotDePasse(string login,string nouveauMdp)
        {

            string sqlUpdate = "Update ABONNÉS SET PASSWORD_ABONNÉ = '" + EncryptageDeMotDePasse(nouveauMdp) + "' FROM ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdUpdate = new OleDbCommand(sqlUpdate, dbCon);
            cmdUpdate.ExecuteNonQuery();

        }

        /// <summary>
        /// Permet de crypter un mot de passe
        /// </summary>
        /// <param name="mdp">mot de passe à crypter</param>
        /// <returns>mot de passe crypé</returns>
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

        /// <summary>
        /// Permet de cacher les messages d'erreurs
        /// </summary>
        private void hideError()
        {
            errorMdp.Visible = false;
            errorMdpNotEqual.Visible = false;
            errorNewMdp.Visible = false;
            errrorNewMdpConfirm.Visible = false;
            errorConfirmNewMdp.Visible = false;
            errorSameMdp.Visible = false;
        }

        private void modifierMdp_Click(object sender, EventArgs e)
        {
            hideError();
            modifierMotdePasse();
        }

        private void retour_Click(object sender, EventArgs e)
        {
            abo.Show();
            this.Close();
        }

        private void viewMdp_Click(object sender, EventArgs e)
        {
            mdp_box.UseSystemPasswordChar = !mdp_box.UseSystemPasswordChar;
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
