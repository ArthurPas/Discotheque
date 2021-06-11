using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliGrpR
{
    public partial class Abonne_Accueil : Form
    {
        OleDbConnection dbCon = Accueil.dbCon;
        public static List<Albums> empruntés = new List<Albums>();
        List<string> genres = new List<string>();
        List<string> album = new List<string>();
        List<string> albumRecherche = new List<string>();
        public static List<Albums> suggestionsAlbums = new List<Albums>();
        public static List<Albums> suggestionsAlbumsChoisit = new List<Albums>();
        int CodeAlbumEmprunter= 0;
        int CodeAlbumRendre = 0;
        
        public string Nom;
        public string Prenom;
        public string Id;
        public string MotDePasse;
        public int numeroAbonne;
        
        public int indexEmprunt = 1;
        public int indexTout = 1;

        public Abonne_Accueil(string nom, string prenom, string login)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Id = login;
            this.numeroAbonne = SetNumAbonne();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            refreshList();
        }

        /// <summary>
        /// Permet d'actualiser les différentes Listes
        /// </summary>
        public void refreshList()
        {
            ConsultAlbum(SetNumAbonne());
            Suggestions(numeroAbonne);
            Album();
        }

        /// <summary>
        /// Permet d'obtenir le numéro de l'abonné qui est connecté
        /// </summary>
        /// <returns>la variable int code (le code de l'abonné)</returns>
        private int SetNumAbonne()
        {
            Accueil accueil = new Accueil();
            dbCon = Accueil.dbCon;
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

        /// <summary>
        /// Permet d'afficher la liste des albums que l'abonné a emprunté.
        /// </summary>
        /// <param name="numeroAbo">numéro de l'abonné</param>
        public void ConsultAlbum(int numeroAbo)
        {
            empruntés.Clear();
            AlbumsEmpruntes.Items.Clear();
            string sql = "select  EMPRUNTER.CODE_ALBUM, TITRE_ALBUM, DATE_RETOUR_ATTENDUE from EMPRUNTER " +
                "Inner join ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "Inner join ABONNÉS on EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ " +
                "WHERE ABONNÉS.CODE_ABONNÉ = '" + numeroAbo + "' AND DATE_RETOUR IS NULL";


            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                int code = Convert.ToInt32(reader.GetInt32(0));
                string titre = reader.GetString(1).Trim();
                DateTime dateRetour = new DateTime();
                if (!reader.IsDBNull(2))
                    dateRetour = reader.GetDateTime(2);
                
                Albums a = new Albums(code, titre, dateRetour);
                empruntés.Add(a); 
            }
            Affichage_Utils.AfficherPaginationAvecAlbum(indexEmprunt, AlbumsEmpruntes, empruntés, pageEmprunté,10);
            reader.Close();
            numeroAbonne = numeroAbo;
        }

        /// <summary>
        /// Suggère 10 albums a l'abonné connecté selon le genre le plus emprunté de l'abonné
        /// </summary>
        /// <param name="numeroAbo">numéro de l'abonné</param>
        public void Suggestions(int numeroAbo)
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
                string sqlTwo = "SELECT ALBUMS.CODE_ALBUM, TITRE_ALBUM FROM ALBUMS INNER JOIN GENRES ON GENRES.CODE_GENRE = ALBUMS.CODE_GENRE " +
                    "WHERE LIBELLÉ_GENRE like '"+genres[0]+"'";
                OleDbCommand cmdTwo = new OleDbCommand(sqlTwo, dbCon);
                cmdTwo.ExecuteNonQuery();
                OleDbDataReader readerTwo = cmdTwo.ExecuteReader();
                AlbumsConseillés.Items.Add("Nous vous recommandons dans le genre " + genres[0]);
                while (readerTwo.Read())
                {
                    string nomAlbum = readerTwo.GetString(1);
                    album.Add(nomAlbum);
                    int code = readerTwo.GetInt32(0);
                    Albums a = new Albums(code, nomAlbum);
                    suggestionsAlbums.Add(a);
                }
                for (int i = 0; i < 10; i++)
                {
                    int index1 = random.Next(album.Count);
                    int index2 = random.Next(suggestionsAlbums.Count);
                    AlbumsConseillés.Items.Add(album[index1]);
                    suggestionsAlbumsChoisit.Add(suggestionsAlbums[index2]);
                }
            }
            else
            {
                AlbumsConseillés.Items.Add("Aucun emprunt effectué donc pas de recommandation");
            }
        }

        /// <summary>
        /// Permet d'ajouter la liste de tous les albums.
        /// </summary>
        public void Album()
        {
            album.Clear();
            string sql = "select * from ALBUMS";

            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();

                    
            while (reader.Read())
            {
                string titre = reader.GetString(3);
                album.Add(titre);
                
            }
            Affichage_Utils.AfficherPagination(indexTout, TousLesAlbums, album, pageAlbum, 10);

            reader.Close();
        }

        /// <summary>
        /// Permet de rechercher un album selon son titre/auteur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RechercherTextBox_TextChanged(object sender, EventArgs e)
        {
            if (RechercherTextBox.Text.Equals(""))
            {
                Album();               
            }
            else
            {
                try
                {
                    TousLesAlbums.Items.Clear();

                    string titreRech = RechercherTextBox.Text;
                    string sql = "SELECT TITRE_ALBUM, ALBUMS.CODE_ALBUM " +
                        "FROM ALBUMS " +
                        "WHERE TITRE_ALBUM LIKE '%" + Utils.manageSingleQuote(titreRech) + "%'";
                    OleDbCommand cmd = new OleDbCommand(sql, dbCon);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    albumRecherche.Clear();

                    while (reader.Read())
                    {
                        string titre = reader.GetString(0);
                        int id = reader.GetInt32(1);
                        Albums a = new Albums(id, titre);
                        albumRecherche.Add(titre);

                    }
                } catch(System.Data.OleDb.OleDbException)
                {
                
                }
                Affichage_Utils.Paginer(ref indexTout, TousLesAlbums, albumRecherche, pageAlbum, 10,0);

            }
        }

        /// <summary>
        /// Gestion du clic sur le bouton Prolonger un emprunt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Prolonger_un_emprunt_MouseDown(object sender, MouseEventArgs e)
        {
            Abonne_Prolonger Abonneprolonger = new Abonne_Prolonger(this);
            Abonneprolonger.StartPosition = FormStartPosition.CenterScreen;
            Abonneprolonger.ShowDialog();
        }

        /// <summary>
        /// Permet à l'abonné d'emprunter un album 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Emprunter_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                EmprunterFonction(CodeAlbumEmprunter, SetNumAbonne());
            }catch(System.Data.OleDb.OleDbException)
            {
                MessageBox.Show("Vous avez déjà emprunté cet album");
            }
            AlbumsConseillés.Items.Clear();
            ConsultAlbum(SetNumAbonne());
            Suggestions(numeroAbonne);
        }

        /// <summary>
        /// Permet de valider l'emprunt et d'ajouter dans la liste des albums emprunté par 
        /// l'abonné
        /// </summary>
        /// <param name="codeAlbum">code de l'album qui est emprunté</param>
        /// <param name="numAbo">numéro de l'abonné qui emprunte l'album</param>
        /// <returns></returns>
        public bool EmprunterFonction(int codeAlbum, int numAbo)
        {
            bool effectuer = true;
            bool dispo=true;
            string sqlEmpruntdispo = "SELECT * FROM EMPRUNTER WHERE CODE_ALBUM = " + codeAlbum + " AND DATE_RETOUR IS NULL";
            OleDbCommand cmdEmpruntdispo = new OleDbCommand(sqlEmpruntdispo, dbCon);
            cmdEmpruntdispo.ExecuteNonQuery();
            OleDbDataReader rdTestDispo = cmdEmpruntdispo.ExecuteReader();
            if (rdTestDispo.Read())
            {
                dispo = false;
            }
            if (dispo)
            {
                string sqlEmpruntExistant = "SELECT DATE_RETOUR FROM EMPRUNTER WHERE CODE_ALBUM = " + codeAlbum + " and CODE_ABONNÉ = " + numAbo + "AND DATE_RETOUR IS NOT NULL";
                OleDbCommand cmdEmpruntExistant = new OleDbCommand(sqlEmpruntExistant, dbCon);
                cmdEmpruntExistant.ExecuteNonQuery();
                OleDbDataReader rdTestEmprunt = cmdEmpruntExistant.ExecuteReader();
                if (rdTestEmprunt.Read())
                {
                    try
                    {
                        string delete = "DELETE FROM EMPRUNTER WHERE CODE_ALBUM = " + codeAlbum + " and CODE_ABONNÉ = " + numAbo;
                        OleDbCommand deleteFromEmprunt = new OleDbCommand(delete, dbCon);
                        deleteFromEmprunt.ExecuteNonQuery();
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
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        effectuer = false;
                    }
                }
                string sqlEmpruntInexistant = "SELECT DATE_RETOUR FROM EMPRUNTER WHERE CODE_ALBUM = " + codeAlbum + " and CODE_ABONNÉ = " + numAbo;
                OleDbCommand cmdEmpruntInexistant = new OleDbCommand(sqlEmpruntInexistant, dbCon);
                cmdEmpruntInexistant.ExecuteNonQuery();
                OleDbDataReader rdTestEmpruntInexistant = cmdEmpruntInexistant.ExecuteReader();
                if (!rdTestEmprunt.Read())
                {
                    try
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
                    catch (System.Data.OleDb.OleDbException e)
                    {
                        effectuer = false;
                    }
                }
                else
                {
                    effectuer = false;
                    MessageBox.Show("Impossible de l'emprunter.");
                }
            }
            else
            {
                effectuer = false;
                MessageBox.Show("Album déjà emprunté par quelqu'un");
            }
            return effectuer;
        }

        /// <summary>
        /// Permet à l'utilisateur de rendre un album qu'il 
        /// emprunte
        /// </summary>
        /// <param name="CodeAlbumRendre">le code de l'album qui va être rendu</param>
        /// <param name="codeAbo">le code l'abonné qui rend un album</param>
        public void RendreFonction(int CodeAlbumRendre, int codeAbo)
        {
            int numAbo = codeAbo;
            string sqlRendreCD = "UPDATE EMPRUNTER SET DATE_RETOUR = GETDATE() " +
                "WHERE CODE_ABONNÉ = " + numAbo + " AND CODE_ALBUM = " + CodeAlbumRendre;
            OleDbCommand cmdRendreCD = new OleDbCommand(sqlRendreCD,dbCon);
            cmdRendreCD.ExecuteNonQuery();
        }

        /// <summary>
        /// Permet de sélectionner l'album sur lequel on a cliqué dans la liste
        /// de tous les albums
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TousLesAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TousLesAlbums.SelectedItem != null)
            {
                string titre = TousLesAlbums.SelectedItem.ToString();
  
                string sql = "SELECT CODE_ALBUM FROM ALBUMS WHERE TITRE_ALBUM ='" + Utils.manageSingleQuote(titre) + "'";
                OleDbCommand cmd = new OleDbCommand(sql, dbCon);
                cmd.ExecuteNonQuery();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CodeAlbumEmprunter = reader.GetInt32(0);
                }

                string sqlimage = "SELECT POCHETTE FROM ALBUMS WHERE CODE_ALBUM ='" + CodeAlbumEmprunter + "' and POCHETTE is not null";
                OleDbCommand cmdimage = new OleDbCommand(sqlimage, dbCon);
                cmdimage.ExecuteNonQuery();
                OleDbDataReader readerimage = cmdimage.ExecuteReader();
                if (readerimage.Read())
                {
                    pictureBox1.Visible = true;
                    byte[] image = (byte[])readerimage[0];
                    MemoryStream ms = new MemoryStream(image);
                    pictureBox1.Image = new Bitmap(ms);
                    pictureBox1.Image = resizeImage(pictureBox1.Image, new Size(200, 200));
                }
                else
                {
                    pictureBox1.Visible = false;
                }
                readerimage.Close();
            }
        }

        /// <summary>
        /// Permet de changer la taille d'une image
        /// </summary>
        /// <param name="imgToResize">l'image dont la taille va être changé</param>
        /// <param name="size">nouvelle taille de l'image</param>
        /// <returns></returns>
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        /// <summary>
        /// Permet de retourner à la page "Acceuil" si on appuie sur le bouton "retour"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Retour_MouseDown(object sender, MouseEventArgs e)
        {
            Accueil a = new Accueil();
            Nom="";
            Prenom = "";
            Id = "";
            MotDePasse = "";
            numeroAbonne = 0;
            a.Show();
            this.Close();
        }


        //
        //Gestion de la pagination
        //
        private void ButtonRightEmprunt_Click(object sender, EventArgs e)
        {

            Affichage_Utils.PaginerAvecAlbum(ref indexEmprunt, AlbumsEmpruntes, empruntés, pageEmprunté,10, 1);
        }

        private void ButtonLeftEmprunt_Click(object sender, EventArgs e)
        {

            Affichage_Utils.PaginerAvecAlbum(ref indexEmprunt, AlbumsEmpruntes, empruntés, pageEmprunté, 10, -1);

        }
        private void ToutRightButton_Click(object sender, EventArgs e)
        {
            if (RechercherTextBox.Text.Equals(""))
            {
                Affichage_Utils.Paginer(ref indexTout, TousLesAlbums, album, pageAlbum, 10, 1);

            }
            else
            {
                Affichage_Utils.Paginer(ref indexTout, TousLesAlbums, albumRecherche, pageAlbum, 10, 1);
            }

        }

        private void ToutLeftButton_Click(object sender, EventArgs e)
        {
            if (RechercherTextBox.Text.Equals(""))
            {
                Affichage_Utils.Paginer(ref indexTout, TousLesAlbums, album, pageAlbum, 10, -1);

            }
            else
            {
                Affichage_Utils.Paginer(ref indexTout, TousLesAlbums, albumRecherche, pageAlbum, 10, -1);
            }

        }

        private void buttonRendre_MouseDown(object sender, MouseEventArgs e)
        {
            RendreFonction(CodeAlbumRendre,SetNumAbonne());
            empruntés.Clear();
            ConsultAlbum(SetNumAbonne());

        }

        /// <summary>
        /// Sélectionne un album qui a été emprunté
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlbumsEmpruntes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AlbumsEmpruntes.SelectedItem != null)
            {
                Albums a = (Albums)AlbumsEmpruntes.SelectedItem;
                string titre = a.getTitre();

                string sql = "SELECT CODE_ALBUM FROM ALBUMS WHERE TITRE_ALBUM ='" + Utils.manageSingleQuote(titre) + "'";
                OleDbCommand cmd = new OleDbCommand(sql, dbCon);
                cmd.ExecuteNonQuery();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CodeAlbumRendre = reader.GetInt32(0);
                }     
            }
        }

        private void modifierMdp_Click(object sender, EventArgs e)
        {
            Abonne_ModifierMdp a = new Abonne_ModifierMdp(this);
            a.Show();
            this.Close();
        }
    }
}
