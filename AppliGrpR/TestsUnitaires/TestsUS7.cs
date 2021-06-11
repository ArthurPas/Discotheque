using AppliGrpR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestsUnitaires
{
    [TestClass]
    public class TestsUS7
    {
        OleDbConnection dbCon;
        string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";
        Accueil accueil = new Accueil();
        AdministrateurAccueil adminAcc = new AdministrateurAccueil();
        List<Albums> topTest = new List<Albums>();
        public void InitConnexion()
        {
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
        }
        [TestMethod]
        public void TestTop10()
        {
            InitConnexion();

            string sql = " SELECT TOP 10 COUNT(DATE_EMPRUNT)'Nombre d`emprunts', Titre_Album " +
                "FROM EMPRUNTER INNER JOIN ALBUMS" +
                " ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                "GROUP BY TITRE_ALBUM " +
                "ORDER BY COUNT(DATE_EMPRUNT) DESC";
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            cmd.ExecuteNonQuery(); ;
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string titreAlbum = reader.GetString(1);

                string sqlalbum = "SELECT TITRE_ALBUM, albums.CODE_ALBUM, DATE_RETOUR_ATTENDUE " +
                    "FROM EMPRUNTER INNER JOIN ALBUMS " +
                    "ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                    "where TITRE_ALBUM ='" + Utils.manageSingleQuote(titreAlbum) + "'";
                OleDbCommand cmdalbum = new OleDbCommand(sqlalbum, dbCon);
                cmdalbum.ExecuteNonQuery();
                OleDbDataReader readeralbum = cmdalbum.ExecuteReader();
                if (readeralbum.Read())
                {
                    string titre = readeralbum.GetString(0);
                    int code = readeralbum.GetInt32(1);
                    Albums a = new Albums(code, titre);
                    topTest.Add(a);
                }
            }
            reader.Close();
            bool same = true;
            for (int i = 0; i < topTest.Count; i++)
            {
                if (!topTest[i].getID().Equals(AdministrateurAccueil.top10[i].getID()))
                {
                    same = false;
                }
                i++;
            }
            Assert.IsTrue(same);
        }
    }
}
