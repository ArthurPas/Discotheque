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
    public partial class AdministrateurAccueil : Form
    {
        OleDbConnection dbCon = Accueil.dbCon;
        public static List<Albums> top10 = new List<Albums>();
        public List<string> listeRetard = new List<string>();
        public List<int> listeAlbNonEmprUnAn = new List<int>();
        public AdministrateurAccueil()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            ListExtended();
            ListRetard10J();
            Abonnes();
            TOP10ALBUMS();
            GetAlbumNotBorrowedSinceOneYear();
        }

        /// <summary>
        /// US4
        /// Affiche les emprunts qui on été prolongés
        /// </summary>
        public void ListExtended()
        {
            string list = "Select NOM_ABONNÉ, PRÉNOM_ABONNÉ, TITRE_ALBUM FROM ABONNÉS INNER JOIN EMPRUNTER on ABONNÉS.CODE_ABONNÉ = " +
                "EMPRUNTER.CODE_ABONNÉ INNER JOIN ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
                "WHERE DATE_RETOUR_ATTENDUE - DATE_EMPRUNT > DÉLAI";
            OleDbCommand cmd = new OleDbCommand(list, dbCon);
            OleDbDataReader reader = cmd.ExecuteReader();
            ListeProlongementBox.Items.Add("Les emprunts qui ont étés prolongés sont : ");
            while (reader.Read())
            {
                string name = reader.GetString(0);
                string titre = reader.GetString(2);
                ListeProlongementBox.Items.Add(name + " a prolongé l'emprunt de " + titre);
            }

        }

        /// <summary>
        /// US5
        /// Affiche les abonnés ayant des emprunts non rapportés en retard de 10 jours
        /// </summary>
        public void ListRetard10J()
        {
            string sql = "SELECT DISTINCT NOM_ABONNÉ,PRÉNOM_ABONNÉ, TITRE_ALBUM from ABONNÉS" +
                " INNER JOIN EMPRUNTER on ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ " +
                "INNER JOIN ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "WHERE DATEDIFF(day,Emprunter.DATE_RETOUR_ATTENDUE, GETDATE()) > 10;";
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string nom = reader.GetString(0);
                string titre = reader.GetString(2);
                Retard10joursBox.Items.Add(nom + titre);
                listeRetard.Add(nom);
            }
        }

        public void Abonnes()
        {
            ListeAbonnebox.Items.Clear();
            string sql = "select * from ABONNÉS";


            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                string titre = reader.GetString(2);
                ListeAbonnebox.Items.Add(titre);
            }
            reader.Close();
        }

        public void TOP10ALBUMS()
        {
            int classement = 1;
            string sql = " SELECT TOP 10 COUNT(DATE_EMPRUNT)'Nombre d`emprunts', Titre_Album " +
                "FROM EMPRUNTER INNER JOIN ALBUMS" +
                " ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                "GROUP BY TITRE_ALBUM " +
                "ORDER BY COUNT(DATE_EMPRUNT) DESC";
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            cmd.ExecuteNonQuery(); ;
            OleDbDataReader reader = cmd.ExecuteReader();
            top10liste.Items.Add("Classement : ");
            while (reader.Read())
            {
                int nbEmprunts = reader.GetInt32(0);
                string titreAlbum = reader.GetString(1);
                string apostrophe = "'";
                if (titreAlbum.Contains("'"))
                {
                    titreAlbum = titreAlbum.Insert(titreAlbum.IndexOf("'"), apostrophe);
                }
                //
                string sqlalbum = "SELECT TITRE_ALBUM, albums.CODE_ALBUM, DATE_RETOUR_ATTENDUE " +
                    "FROM EMPRUNTER INNER JOIN ALBUMS " +
                    "ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                    "where TITRE_ALBUM ='"+titreAlbum+"'";
                OleDbCommand cmdalbum = new OleDbCommand(sqlalbum, dbCon);
                cmdalbum.ExecuteNonQuery();
                OleDbDataReader readeralbum = cmdalbum.ExecuteReader();
                if (readeralbum.Read())
                {
                    string titre = readeralbum.GetString(0);
                    int code = readeralbum.GetInt32(1);
                    Albums a = new Albums(code, titre);
                    top10.Add(a);
                }
                top10liste.Items.Add(classement + " | Nombre d'emprunts : " + nbEmprunts + " | Titre de l'album :" + titreAlbum);
                classement++;
            }
            reader.Close();
        }

        public void GetAlbumNotBorrowedSinceOneYear()
        {

            string request = "SELECT * " +
                "FROM ALBUMS " +
                "FULL JOIN EMPRUNTER ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                "WHERE DATEDIFF(day, DATE_EMPRUNT,GETDATE()) > 365 OR DATE_EMPRUNT IS NULL ";

            OleDbCommand cmd = new OleDbCommand(request, dbCon);
            cmd.ExecuteNonQuery();

            OleDbDataReader reader = cmd.ExecuteReader();

            nonEmprunté.Items.Add("Album qui n'ont pas été emprunté depuis un an: ");
            while (reader.Read())
            {
                int codeAlb = reader.GetInt32(0);
                string titreAlbum = reader.GetString(3);
                nonEmprunté.Items.Add(titreAlbum);
                listeAlbNonEmprUnAn.Add(codeAlb);
            }
        }

        private void PurgerAbonnes_MouseDown(object sender, MouseEventArgs e)
        {
            Administrateur_Purger adminPurger = new Administrateur_Purger();
            adminPurger.ShowDialog();
            this.Hide();
            this.Close();
        }

        private void Retour_MouseDown(object sender, MouseEventArgs e)
        {
            Accueil a = new Accueil();
            a.Show();
            this.Close();
        }
    }
}
