using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;

namespace TestsUnitaires
{
    [TestClass]
    public class TestUS2
    {
        OleDbConnection dbCon;
        string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";
        List<string> albumAbo = new List<string>();
        public void InitConnexion()
        {
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
        }
        [TestMethod]
        public void TestListEmpruntAbo()
        {
            Boolean sameList = true;
            int i = 0;
            InitConnexion();
            int nbrAlbums = 0;
            int codeAlbums = 549;
            string login = "loginaAjouter";
            string insert = "insert into ABONNÉS(CODE_PAYS,NOM_ABONNÉ,PRÉNOM_ABONNÉ,LOGIN_ABONNÉ,PASSWORD_ABONNÉ) values(?,?,?,?,?)";
            OleDbCommand cmdInsert = new OleDbCommand(insert, dbCon);
            cmdInsert.Parameters.Add("CODE_PAYS", OleDbType.Integer).Value = 1;
            cmdInsert.Parameters.Add("NOM_ABONNÉ", OleDbType.VarChar).Value = "Test";
            cmdInsert.Parameters.Add("PRÉNOM_ABONNÉ", OleDbType.VarChar).Value = "Pas dans la base";
            cmdInsert.Parameters.Add("LOGIN_ABONNÉ", OleDbType.VarChar).Value = login;
            cmdInsert.Parameters.Add("PASSWORD_ABONNÉ", OleDbType.VarChar).Value = "pwd";
            cmdInsert.ExecuteNonQuery();
            string sqlAjoutEmpruntFictif = "insert into EMPRUNTER(CODE_ABONNÉ,CODE_ALBUM,DATE_EMPRUNT,DATE_RETOUR_ATTENDUE) values((SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ='"+login+"'),"+codeAlbums+", '04/06/2014', '04/07/2015')";
            OleDbCommand cmdAjoutFictif = new OleDbCommand(sqlAjoutEmpruntFictif, dbCon);
            cmdAjoutFictif.ExecuteNonQuery();
            string sqlEmprunt = "SELECT ALBUMS.TITRE_ALBUM FROM EMPRUNTER INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM WHERE EMPRUNTER.CODE_ABONNÉ = ( SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "')";
            OleDbCommand cmdList = new OleDbCommand(sqlEmprunt, dbCon);
            cmdList.ExecuteNonQuery();
            OleDbDataReader rdList = cmdList.ExecuteReader();
            if (rdList is null)
            {
                Trace.Write("Aucun livre emprunté");
            }
            else
            {
                while (rdList.Read())
                {
                    albumAbo.Add(rdList.GetString(0));
                }
            }
            rdList.Close();
            string sqlCount = "SELECT COUNT(ALBUMS.TITRE_ALBUM) FROM EMPRUNTER INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM WHERE EMPRUNTER.CODE_ABONNÉ = ( SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "')";
            OleDbCommand cmdCount = new OleDbCommand(sqlCount, dbCon);
            cmdCount.ExecuteNonQuery();
            OleDbDataReader rdCount = cmdCount.ExecuteReader();
            while (rdCount.Read())
            {
                nbrAlbums = rdCount.GetInt32(0);
            }
            rdCount.Close();
            Assert.AreEqual(albumAbo.Count, nbrAlbums);
            string sqlVerif = "SELECT ALBUMS.TITRE_ALBUM FROM EMPRUNTER " +
                "INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "WHERE EMPRUNTER.CODE_ABONNÉ = ( SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "')";
            OleDbCommand cmdVerif = new OleDbCommand(sqlVerif, dbCon);
            cmdVerif.ExecuteNonQuery();
            OleDbDataReader rdVerif = cmdVerif.ExecuteReader();
            while (rdVerif.Read())
            {
                if (!albumAbo[i].Equals(rdVerif.GetString(0)))
                {
                    sameList = false;
                }
                i++;
            }
            Assert.IsTrue(sameList);
            string sqlDeleteFromEmprunts = "DELETE FROM EMPRUNTER WHERE EMPRUNTER.CODE_ABONNÉ = (SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "')";
            OleDbCommand cmdDeleteFromEmprunts = new OleDbCommand(sqlDeleteFromEmprunts, dbCon);
            cmdDeleteFromEmprunts.ExecuteNonQuery();
            string sqlDeleteFromAbonnés = "DELETE FROM ABONNÉS WHERE ABONNÉS.CODE_ABONNÉ = (SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ = '"+login+"')";
            OleDbCommand cmdDeleteFromAbonnés = new OleDbCommand(sqlDeleteFromAbonnés, dbCon);
            cmdDeleteFromAbonnés.ExecuteNonQuery();
        }
    }
}
