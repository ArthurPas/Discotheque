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
    public partial class Abonne_Prolonger : Form
    {
        OleDbConnection dbCon = Accueil.dbCon;
        public static Abonne_Accueil accueil;
        int CodeAlbumProlonger=0;
        public Abonne_Prolonger()
        {
            InitializeComponent();
            ListeDesProlongeable();
        }

        private void Retour_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        public void ListeDesProlongeable()
        {
            string list = "Select ALBUMS.TITRE_ALBUM, ALBUMS.CODE_ALBUM, EMPRUNTER.DATE_RETOUR_ATTENDUE FROM ABONNÉS INNER JOIN EMPRUNTER on ABONNÉS.CODE_ABONNÉ = " +
                "EMPRUNTER.CODE_ABONNÉ INNER JOIN ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
                "WHERE DATE_RETOUR_ATTENDUE - DATE_EMPRUNT <= DÉLAI AND ABONNÉS.CODE_ABONNÉ =" +Abonne_Accueil.numeroAbonne;
            OleDbCommand cmd = new OleDbCommand(list, dbCon);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string titre = reader.GetString(0);
                int id = reader.GetInt32(1);
                DateTime dateRetour = new DateTime();
                if (!reader.IsDBNull(2))
                    dateRetour = reader.GetDateTime(2);
                Albums a = new Albums(id, titre, dateRetour);
                AlbumsProlongeables.Items.Add(a);
            }

        }

        public void ExtendBorrowing(int numeroABo, int codeAlbumPro)
        {

            string extendDate = "UPDATE EMPRUNTER Set EMPRUNTER.DATE_RETOUR_ATTENDUE = DATEADD(month, 1, EMPRUNTER.DATE_RETOUR_ATTENDUE) " +
                "FROM EMPRUNTER INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE WHERE ABONNÉS.CODE_ABONNÉ = " + numeroABo +
                " AND ALBUMS.CODE_ALBUM = " + codeAlbumPro + " AND DATE_RETOUR_ATTENDUE - DATE_EMPRUNT <= DÉLAI";

            OleDbCommand cmd = new OleDbCommand(extendDate, dbCon);
            cmd.ExecuteNonQuery();

        }

        private void AlbumsProlongeables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlbumsProlongeables.SelectedItem != null)
            {
                try
                {
                    Albums album = (Albums)AlbumsProlongeables.SelectedItem;
                    string titre = album.titre.ToString();
                    string apostrophe = "'";
                    if (titre.Contains("'"))
                    {
                        titre = titre.Insert(titre.IndexOf("'"), apostrophe);
                    }

                    string sql = "SELECT CODE_ALBUM FROM ALBUMS WHERE TITRE_ALBUM ='" + titre + "'";
                    OleDbCommand cmd = new OleDbCommand(sql, dbCon);
                    cmd.ExecuteNonQuery();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CodeAlbumProlonger = reader.GetInt32(0);
                    }
                }
                catch (System.InvalidCastException)
                {

                }
            }

        }

        private void ProlongerButton_MouseDown(object sender, MouseEventArgs e)
        {
            ExtendBorrowing(Abonne_Accueil.numeroAbonne, CodeAlbumProlonger);
            AlbumsProlongeables.Items.Clear();
            ListeDesProlongeable();
            accueil.refreshList();
        }

        private void Pronlonger_tout_bouton_MouseDown(object sender, MouseEventArgs e)
        {
            if (ConfirmDialog())
            {
                ExtendAllBorrowing(Abonne_Accueil.numeroAbonne);
                AlbumsProlongeables.Items.Clear();
                ListeDesProlongeable();
                accueil.refreshList();
            }
        }

        public bool ConfirmDialog()
        {
            string message = "Confirmer ?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            return MessageBox.Show(message, "", buttons) == DialogResult.Yes;
        }

        /// <summary>
        /// US9
        /// Prolonge l'emprunt de tous les emprunts
        /// @param l'identifiant de l'utilisateur qui réalise sont prolongement
        /// </summary>
        public void ExtendAllBorrowing(int numeroAbo)
        {

            string extendDate = "UPDATE EMPRUNTER " +
            "Set EMPRUNTER.DATE_RETOUR_ATTENDUE = DATEADD(MONTH,1,EMPRUNTER.DATE_RETOUR_ATTENDUE) " +
            "FROM EMPRUNTER " +
            "INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ " +
            "INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
            "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
            "WHERE ABONNÉS.CODE_ABONNÉ = " + numeroAbo +
            "AND DATE_RETOUR_ATTENDUE - DATE_EMPRUNT <= DÉLAI";

            OleDbCommand cmd = new OleDbCommand(extendDate, dbCon);
            cmd.ExecuteNonQuery();
            AlbumsProlongeables.Items.Add("Date d'emprunt étendue pour tous vos emprunts");

        }
    }
}
