using AppliGrpR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires
{
    [TestClass]
    public class TestsUS10
    {
        OleDbConnection dbCon;
        string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";
        Accueil accueil = new Accueil();
        Abonne_Accueil aboAccu = new Abonne_Accueil();
        Client_Inscription client = new Client_Inscription();
        List<string> genres = new List<string>();
        public static List<Albums> suggestionsAlbums = new List<Albums>();
        public static List<Albums> suggestionsAlbumsChoisit = new List<Albums>();
        public void InitConnexion()
        {
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
        }
        //test s'il n'y a pas d'emprunt
        [TestMethod]
        public void SuggestionsTest()
        {
            InitConnexion();
            string login = "testUS10";
            string mdp = "testmdp";
            string prenom = "prenomTest";
            string nom = "testNom";
            string nationalite = "France";
            int numeroAbo = 0;
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);

            string getCode = "SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "' AND PASSWORD_ABONNÉ = '" + mdp + "'";
            OleDbCommand cmdCode = new OleDbCommand(getCode, dbCon);
            cmdCode.ExecuteNonQuery();
            OleDbDataReader readCode = cmdCode.ExecuteReader();
            while (readCode.Read())
            {
                numeroAbo = readCode.GetInt32(0);
            }
            readCode.Close();

            string sqlTest = "SELECT * From emprunter where CODE_ABONNÉ =" + numeroAbo;
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
                    "WHERE ABONNÉS.CODE_ABONNÉ = " + numeroAbo +
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
                string sqlTwo = "SELECT CODE_ALBUM, TITRE_ALBUM, EMPRUNTER.DATE_RETOUR_ATTENDUE FROM ALBUMS INNER JOIN GENRES ON GENRES.CODE_GENRE = ALBUMS.CODE_GENRE " +
                    "INNER JOIN EMPRUNTER ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM" +
                    "WHERE LIBELLÉ_GENRE = '" + genres[0] + "'";
                OleDbCommand cmdTwo = new OleDbCommand(sqlTwo, dbCon);
                cmdTwo.ExecuteNonQuery();
                OleDbDataReader readerTwo = cmdTwo.ExecuteReader();
                while (readerTwo.Read())
                {
                    string nomAlbum = readerTwo.GetString(1);
                    int code = readerTwo.GetInt32(0);
                    Albums a = new Albums(code, nomAlbum);
                    suggestionsAlbums.Add(a);
                }
                for (int i = 0; i < 10; i++)
                {
                    int index = random.Next(suggestionsAlbums.Count);
                    suggestionsAlbumsChoisit.Add(suggestionsAlbums[index]);
                }
            }
            Assert.AreEqual(Abonne_Accueil.suggestionsAlbumsChoisit.Count, suggestionsAlbumsChoisit.Count, "Pas pareil");
            string deleteFromAbonnés = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='"+ login + "' AND PASSWORD_ABONNÉ = '"+mdp+"'";
            OleDbCommand cmdDeleteFromAbonnés = new OleDbCommand(deleteFromAbonnés, dbCon);
            cmdDeleteFromAbonnés.ExecuteNonQuery();
        }
    }
}
