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

        string mdpActuel;
        string mdpActuelEntré;
        string nouveauMdp;
        string nouveauMdpConfirm;

        public Abonne_ModifierMdp()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            hideError();
        }


        public void modifierMotdePasse()
        {
            bool valide = true;
            string login = Abonne_Accueil.Id;   //ATTENTION le Log en Static n'est pas du tout une bonne idée, le logiciel ne serait pas utilisable par plusieur utilisateur en même temps

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
            Console.WriteLine(valide);
            Console.WriteLine(mdpActuelEntré + "      " + mdpActuel + valide);

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
                    MettreAJourMotDePasse(login, mdpActuelEntré);
                    MessageBox.Show("Votre Mot de Passe à bien était modifié");
                               
                    
                }
            }
            else
            {
                errrorNewMdpConfirm.Visible = true;
            }

        }

        /// <summary>
        /// Met a jour le Mot de Passe d'un user a parti d'un nouveau mot de passe entré
        /// </summary>
        private void MettreAJourMotDePasse(string login,string mdpActuelEntré)
        {
            //Get le Code Abbonné From Login
            int codeAbo;
            string consultCode = "Select CODE_ABONNÉ from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdConsultCode = new OleDbCommand(consultCode, dbCon);
            OleDbDataReader readerTwo = cmdConsultCode.ExecuteReader();
            while (readerTwo.Read())
            {
                codeAbo = readerTwo.GetInt32(0);
            }

            string sqlUpdate = "Update ABONNÉS SET PASSWORD_ABONNÉ = '" + mdpActuelEntré +"' FROM ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdUpdate = new OleDbCommand(sqlUpdate, dbCon);
            cmdUpdate.ExecuteNonQuery();

        }

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
            Abonne_Accueil a = new Abonne_Accueil();
            a.Show();
            this.Close();
        }
    }
}
