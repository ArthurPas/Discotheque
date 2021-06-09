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
    public partial class Abonne_Accueil : Form
    {
        OleDbConnection dbCon = Accueil.dbCon;
        List<Albums> empruntés = new List<Albums>();
        List<string> genres = new List<string>();
        List<string> album = new List<string>();
        int CodeAlbumEmprunter= 0;
        //
        // initialisé pour le test
        //
        public static string Nom;
        public static string Prenom;
        public static string Id;
        public static string MotDePasse;
        public static int numeroAbonne;
        public Abonne_Accueil()
        {
            InitializeComponent();
            refreshList();
        }

        public void refreshList ()
        {
            ConsultAlbum(SetNumAbonne());
            Suggestions(numeroAbonne);
            Album();
            Abonne_Prolonger.accueil = this;
        }

        private int SetNumAbonne()
        {
            string sql = "select * from ABONNÉS WHERE LOGIN_ABONNÉ ='" + Id + "'";
            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();

            int code = 0;
            while (reader.Read())
            {
                code = reader.GetInt32(0);
            }
            reader.Close();
            return code;
        }

        public void ConsultAlbum(int numeroAbo)
        {
            AlbumsEmpruntes.Items.Clear();
            string sql = "select  EMPRUNTER.CODE_ALBUM, TITRE_ALBUM, DATE_RETOUR_ATTENDUE from EMPRUNTER " +
                "Inner join ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "Inner join ABONNÉS on EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ " +
                "WHERE ABONNÉS.CODE_ABONNÉ = '" + numeroAbo + "'";


            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                int code = Convert.ToInt32(reader.GetInt32(0));
                string titre = reader.GetString(1);
                DateTime dateRetour = new DateTime();
                if (!reader.IsDBNull(2))
                    dateRetour = reader.GetDateTime(2);

                Albums a = new Albums(code, titre, dateRetour);
                AlbumsEmpruntes.Items.Add(a);
                empruntés.Add(a);
            }
            reader.Close();
            numeroAbonne = numeroAbo;
        }

        private void Suggestions(int numeroAbo)
        {
            //test si l'abonné a déjà emprunté
            string sqlTest = "SELECT * From emprunter where CODE_ABONNÉ ="+ numeroAbo;
            OleDbCommand cmdTest = new OleDbCommand(sqlTest, dbCon);
            cmdTest.ExecuteNonQuery(); ;
            OleDbDataReader readerTest = cmdTest.ExecuteReader();
            if (readerTest.Read())
            {
                var random = new Random();
                string sql = "SELECT TOP 1 LIBELLÉ_GENRE, COUNT(DATE_EMPRUNT) as 'Emprunts totaux' " +
                    "FROM GENRES INNER JOIN ALBUMS ON ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
                    "INNER JOIN EMPRUNTER ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                    "INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ " +
                    "WHERE ABONNÉS.CODE_ABONNÉ = " + SetNumAbonne() +
                    "GROUP BY LIBELLÉ_GENRE " +
                    "ORDER BY COUNT(DATE_EMPRUNT) DESC";
                OleDbCommand cmd = new OleDbCommand(sql, dbCon);
                cmd.ExecuteNonQuery(); ;
                OleDbDataReader reader = cmd.ExecuteReader();
                genres.Clear();
                while (reader.Read())
                {
                    genres.Add(reader.GetString(0));
                }
                string sqlTwo = "SELECT TITRE_ALBUM FROM ALBUMS INNER JOIN GENRES ON GENRES.CODE_GENRE = ALBUMS.CODE_GENRE " +
                    "WHERE LIBELLÉ_GENRE = '" + genres[0] + "'";
                OleDbCommand cmdTwo = new OleDbCommand(sqlTwo, dbCon);
                cmdTwo.ExecuteNonQuery();
                OleDbDataReader readerTwo = cmdTwo.ExecuteReader();
                AlbumsConseillés.Items.Add("Nous vous recommandons dans le genre " + genres[0]);
                while (readerTwo.Read())
                {
                    string nomAlbum = readerTwo.GetString(0);
                    album.Add(nomAlbum);
                }
                for (int i = 0; i < 10; i++)
                {
                    int index = random.Next(album.Count);
                    AlbumsConseillés.Items.Add(album[index]);
                    Console.WriteLine(index);
                }
            }
            else
            {
                AlbumsConseillés.Items.Add("Aucun emprunt effectué donc pas de recommandation");
            }
        }

        public void Album()
        {
            string sql = "select * from ALBUMS";

            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                string titre = reader.GetString(3);
                album.Add(titre);
                TousLesAlbums.Items.Add(titre);
            }
            reader.Close();
        }

        private void RechercherTextBox_TextChanged(object sender, EventArgs e)
        {
            if (RechercherTextBox.Text.Equals(""))
            {
                Album();
            }
            else
            {
                TousLesAlbums.Items.Clear();
                string apostrophe = "'";
                string titreRech = RechercherTextBox.Text;
                if (titreRech.Contains("'"))
                {
                    titreRech = titreRech.Insert(titreRech.IndexOf("'"), apostrophe);
                }
                string sql = "SELECT TITRE_ALBUM, ALBUMS.CODE_ALBUM, EMPRUNTER.DATE_RETOUR_ATTENDUE " +
                    "FROM ALBUMS " +
                    "FULL JOIN EMPRUNTER on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                    "WHERE TITRE_ALBUM LIKE '%" + titreRech + "%'";
                OleDbCommand cmd = new OleDbCommand(sql, dbCon);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string titre = reader.GetString(0);
                    int id = reader.GetInt32(1);
                    DateTime dateRetour = new DateTime();
                    if (!reader.IsDBNull(2))
                        dateRetour = reader.GetDateTime(2);
                    Albums a = new Albums(id, titre, dateRetour);
                    TousLesAlbums.Items.Add(titre);

                }
            }
        }

        private void Prolonger_un_emprunt_MouseDown(object sender, MouseEventArgs e)
        {
            Abonne_Prolonger Abonneprolonger = new Abonne_Prolonger();
            Abonneprolonger.StartPosition = FormStartPosition.CenterScreen;
            Abonneprolonger.ShowDialog();
        }

        private void Emprunter_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                EmprunterFonction(CodeAlbumEmprunter, SetNumAbonne());
            }catch(System.Data.OleDb.OleDbException)
            {
                MessageBox.Show("Vous avez déjà emprunté cet album");
            }
            ConsultAlbum(SetNumAbonne());
            Suggestions(numeroAbonne);
        }

        private void EmprunterFonction(int codeAlbum, int numAbo)
        {
            int codeAbo = numAbo;
            int delayNumber = 0;
            string delay = "SELECT DÉLAI FROM GENRES INNER JOIN ALBUMS on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
                "WHERE ALBUMS.CODE_ALBUM = " + codeAlbum;
            OleDbCommand cmdDelay = new OleDbCommand(delay, dbCon);
            cmdDelay.ExecuteNonQuery();
            OleDbDataReader readerDelay = cmdDelay.ExecuteReader();
            while (readerDelay.Read())
            {
                delayNumber = readerDelay.GetInt32(0);
            }
            string request = "insert into EMPRUNTER(CODE_ABONNÉ,CODE_ALBUM,DATE_EMPRUNT,DATE_RETOUR_ATTENDUE) " +
                "values(" + codeAbo + ", ?, GETDATE(),DATEADD(Day,?,GETDATE()))";
            OleDbCommand cmdTwo = new OleDbCommand(request, dbCon);
            cmdTwo.Parameters.Add("CODE_ALBUM", OleDbType.Integer).Value = codeAlbum;
            cmdTwo.Parameters.Add("CODE_ALBUM", OleDbType.Integer).Value = delayNumber;
            cmdTwo.ExecuteNonQuery();
        }

        private void TousLesAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            string titre = TousLesAlbums.SelectedItem.ToString();
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
                CodeAlbumEmprunter = reader.GetInt32(0);
            }
        }

        private void Retour_MouseDown(object sender, MouseEventArgs e)
        {
            Accueil a = new Accueil();
            a.Show();
            this.Close();
        }
    }
}
