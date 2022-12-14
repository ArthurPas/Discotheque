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
    public partial class Administrateur_Purger : Form
    {
        OleDbConnection dbCon = Accueil.dbCon;
        public Administrateur_Purger()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            AfficherPurgeAbonne();
        }

        private void Retour_MouseDown(object sender, MouseEventArgs e)
        {
            AdministrateurAccueil admin = new AdministrateurAccueil();
            admin.ShowDialog();
            this.Hide();
            this.Close();
        }

        /// <summary>
        /// Ajoute les abonnés qui n'ont rien emprunté depuis plus d'un an et qui ont rendu leur disque dans la liste et les affiches
        /// </summary>
        public void AfficherPurgeAbonne()
        {
            //regarde si l'abonné a un emprunt qui date de plus d'un an
            string sql = "select ABONNÉS.PRÉNOM_ABONNÉ, NOM_ABONNÉ,ABONNÉS.CODE_ABONNÉ, CODE_ALBUM,DATE_EMPRUNT " +
                "from emprunter " +
                "inner join ABONNÉS on ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ " +
                "WHERE DATEDIFF(day, DATE_EMPRUNT, GETDATE()) > 365 AND DATE_RETOUR iS NOT NULL";

            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                //récupère le code de l'abo
                int code = reader.GetInt32(2);
                //regarde si il a un emprunt qui date de moins d'un an
                string test = "select ABONNÉS.PRÉNOM_ABONNÉ, NOM_ABONNÉ,ABONNÉS.CODE_ABONNÉ, CODE_ALBUM,DATE_EMPRUNT " +
                    "from emprunter " +
                    "inner join ABONNÉS on ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ " +
                    "WHERE DATEDIFF(day, DATE_EMPRUNT, GETDATE()) < 365 AND ABONNÉS.CODE_ABONNÉ =" + code + "AND DATE_RETOUR iS NOT NULL";
                OleDbCommand cmdReadtest = new OleDbCommand(test, dbCon);
                OleDbDataReader readertest = cmdReadtest.ExecuteReader();
                //si pas d'emprunt qui date de moins d'un an
                if (!readertest.Read())
                {
                    string prénom = reader.GetString(0);
                    string nom = reader.GetString(1);
                    AbonnesPurger.Items.Add(nom + prénom);
                }
            }
            reader.Close();
        }

        /// <summary>
        /// Affiche un message de confirmation
        /// </summary>
        /// <returns>TRUE si l'abonné appuie sur yes, FALSE si l'abonné appuie sur no</returns>
        public bool ConfirmDialog()
        {
            string message = "Confirmer ?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            return MessageBox.Show(message, "", buttons) == DialogResult.Yes;
        }

        private void PurgeAll_MouseDown(object sender, MouseEventArgs e)
        {
            if (ConfirmDialog())
            {
                PurgeAbonne();
                AbonnesPurger.Items.Clear();
                AfficherPurgeAbonne();
            }
        }

        /// <summary>
        /// Permet de purger tous les abonnés qui n'ont rien emprunté depuis plus d'un an
        /// </summary>
        public void PurgeAbonne()
        {
            //regarde si l'abonné a un emprunt qui date de plus d'un an
            string sql = "select ABONNÉS.PRÉNOM_ABONNÉ, NOM_ABONNÉ,ABONNÉS.CODE_ABONNÉ, CODE_ALBUM,DATE_EMPRUNT " +
                "from emprunter " +
                "inner join ABONNÉS on ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ " +
                "WHERE DATEDIFF(day, DATE_EMPRUNT, GETDATE()) > 365 AND DATE_RETOUR iS NOT NULL";

            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                //récupère le code de l'abo
                int code = reader.GetInt32(2);
                //regarde si il a un emprunt qui date de moins d'un an
                string test = "select ABONNÉS.PRÉNOM_ABONNÉ, NOM_ABONNÉ,ABONNÉS.CODE_ABONNÉ, CODE_ALBUM,DATE_EMPRUNT " +
                    "from emprunter " +
                    "inner join ABONNÉS on ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ " +
                    "WHERE DATEDIFF(day, DATE_EMPRUNT, GETDATE()) < 365 AND ABONNÉS.CODE_ABONNÉ =" + code + " AND DATE_RETOUR iS NOT NULL";
                OleDbCommand cmdReadtest = new OleDbCommand(test, dbCon);
                OleDbDataReader readertest = cmdReadtest.ExecuteReader();
                //si pas d'emprunt qui date de moins d'un an
                if (!readertest.Read())
                {
                    //suppression
                    string sup = "DELETE FROM EMPRUNTER where CODE_ABONNÉ =" + code +
                        "DELETE FROM ABONNÉS where CODE_ABONNÉ =" + code;
                    OleDbCommand cmd = new OleDbCommand(sup, dbCon);
                    cmd.ExecuteNonQuery();
                }
            }
            reader.Close();
        }
    }
}
