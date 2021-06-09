using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using AppliGrpR;
using System.Linq;

namespace TestsUnitaires
    {
        [TestClass]
        public class TestsUS4

        {
            Accueil accueil = new Accueil();
            AdministrateurAccueil accueilAdmin = new AdministrateurAccueil();
            OleDbConnection dbCon;
            string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";
            List<Albums> listProlongée = new List<Albums>();
            public void InitConnexion()
            {
                dbCon = new OleDbConnection(ChaineBd);
                dbCon.Open();
            }

            [TestMethod]
            public void TestListProlongement()
            {
                bool same = true;
                int i = 0;
                InitConnexion();
                AdministrateurAccueil.listeProlongement.Clear();
                accueilAdmin.ListExtended();
                string sqlEmpruntsProlongés = "Select TITRE_ALBUM, EMPRUNTER.CODE_ALBUM, EMPRUNTER.DATE_RETOUR_ATTENDUE FROM  EMPRUNTER  " +
                    "INNER JOIN ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                    "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
                    "WHERE DATE_RETOUR_ATTENDUE -DATE_EMPRUNT > DÉLAI";
                OleDbCommand cmdListProlongement = new OleDbCommand(sqlEmpruntsProlongés, dbCon);
                cmdListProlongement.ExecuteNonQuery();
                OleDbDataReader readListProlongement = cmdListProlongement.ExecuteReader();
                while (readListProlongement.Read())
                {
                    DateTime dateRetourAttendue = new DateTime();
                    string titreAlbum = readListProlongement.GetString(0);
                    int codeAlbum = readListProlongement.GetInt32(1);
                    dateRetourAttendue = readListProlongement.GetDateTime(2);
                    Albums a = new Albums(codeAlbum, titreAlbum, dateRetourAttendue);
                    listProlongée.Add(a);
                }
                readListProlongement.Close();
                foreach (Albums a in AdministrateurAccueil.listeProlongement)
                {
                    Trace.WriteLine(AdministrateurAccueil.listeProlongement.Count);
                    if (!listProlongée[i].getID().Equals(a.getID()))
                    {
                        same = false;
                    }
                    i++;
                }
                Assert.IsTrue(same);
            }
        }
}


