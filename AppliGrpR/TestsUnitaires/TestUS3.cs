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
    public class TestUS3
    {
        OleDbConnection dbCon;
        string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";
        Dictionary<string, DateTime> emprunt = new Dictionary<string, DateTime>();
        public void InitConnexion()
        {
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
        }
        [TestMethod]
        public void TestProlongement()
        {
            InitConnexion();
            string logAbo = "testUnitaires3";
            int codeAlb = 522;
            int codeAbo = 0;
            DateTime dateRetour = new DateTime();
            string test = "insert into ABONNÉS(CODE_PAYS, NOM_ABONNÉ, PRÉNOM_ABONNÉ, LOGIN_ABONNÉ, PASSWORD_ABONNÉ) values(?,?,?,?,?)";
            OleDbCommand cmdInsert = new OleDbCommand(test, dbCon);
            cmdInsert.Parameters.Add("CODE_PAYS", OleDbType.Integer).Value = 1;
            cmdInsert.Parameters.Add("NOM_ABONNÉ", OleDbType.VarChar).Value = "Test";
            cmdInsert.Parameters.Add("PRÉNOM_ABONNÉ", OleDbType.VarChar).Value = "Pas dans la base";
            cmdInsert.Parameters.Add("LOGIN_ABONNÉ", OleDbType.VarChar).Value = logAbo;
            cmdInsert.Parameters.Add("PASSWORD_ABONNÉ", OleDbType.VarChar).Value = "pwd";
            cmdInsert.ExecuteNonQuery();
            string sql = "select * from ABONNÉS WHERE LOGIN_ABONNÉ ='" + logAbo + "'";
            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();
            while (reader.Read())
            {
                codeAbo = reader.GetInt32(0);
            }
            reader.Close();
            string testEmprunt = "insert into EMPRUNTER(CODE_ABONNÉ,CODE_ALBUM,DATE_EMPRUNT,DATE_RETOUR_ATTENDUE) values(" + codeAbo + ", " + codeAlb + ", '22/06/2014', '04/07/2014')";
            OleDbCommand cmdEmprunt = new OleDbCommand(testEmprunt, dbCon);
            cmdEmprunt.ExecuteNonQuery();
            string consult = "SELECT DATE_RETOUR_ATTENDUE, ABONNÉS.LOGIN_ABONNÉ FROM EMPRUNTER INNER JOIN ABONNÉS ON " +
                "EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ INNER JOIN ALBUMS ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM WHERE ABONNÉS.LOGIN_ABONNÉ = '" + logAbo +
                "' AND ALBUMS.CODE_ALBUM = " + codeAlb;
            OleDbCommand cmd = new OleDbCommand(consult, dbCon);
            OleDbDataReader readerTwo = cmd.ExecuteReader();
            while (readerTwo.Read())
            {
                emprunt.Add(logAbo, readerTwo.GetDateTime(0));
            }
            readerTwo.Close();
            string extend = "UPDATE EMPRUNTER Set EMPRUNTER.DATE_RETOUR_ATTENDUE = DATEADD(month, 1, EMPRUNTER.DATE_RETOUR_ATTENDUE) " +
                            "FROM EMPRUNTER INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                            "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE WHERE ABONNÉS.CODE_ABONNÉ = " + codeAbo +
                            " AND ALBUMS.CODE_ALBUM = " + codeAlb + " AND DATE_RETOUR_ATTENDUE - DATE_EMPRUNT <= DÉLAI";
            OleDbCommand cmdSql = new OleDbCommand(extend, dbCon);
            cmdSql.ExecuteNonQuery();
            string consultExtend = " SELECT * FROM EMPRUNTER WHERE CODE_ABONNÉ = " + codeAbo;
            OleDbCommand cmdCE = new OleDbCommand(consultExtend, dbCon);
            OleDbDataReader readerTree = cmdCE.ExecuteReader();
            while (readerTree.Read())
            {
                dateRetour = readerTree.GetDateTime(3);
            }
            readerTree.Close();
            Assert.AreEqual(emprunt[logAbo].AddMonths(1),dateRetour, "test pas passé");
            string delete = " DELETE FROM EMPRUNTER WHERE CODE_ABONNÉ = ( SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ = '" + logAbo + "')";
            OleDbCommand cmdDelete = new OleDbCommand(delete, dbCon);
            cmdDelete.ExecuteNonQuery();
            string deleteFromAbo = "DELETE FROM ABONNÉS WHERE CODE_ABONNÉ =" + codeAbo;
            OleDbCommand cmdDeleteFromAbo = new OleDbCommand(deleteFromAbo, dbCon);
            cmdDeleteFromAbo.ExecuteNonQuery();
            emprunt.Clear();
        }
        [TestMethod]
        public void TestProlongementDejaProl()
        {
            InitConnexion();
            string logAbo = "testUnitaires3DejaProl";
            int codeAlb = 523;
            int codeAbo = 0;
            DateTime dateRetour = new DateTime();
            string test = "insert into ABONNÉS(CODE_PAYS, NOM_ABONNÉ, PRÉNOM_ABONNÉ, LOGIN_ABONNÉ, PASSWORD_ABONNÉ) values(?,?,?,?,?)";
            OleDbCommand cmdInsert = new OleDbCommand(test, dbCon);
            cmdInsert.Parameters.Add("CODE_PAYS", OleDbType.Integer).Value = 1;
            cmdInsert.Parameters.Add("NOM_ABONNÉ", OleDbType.VarChar).Value = "Test";
            cmdInsert.Parameters.Add("PRÉNOM_ABONNÉ", OleDbType.VarChar).Value = "Pas dans la base";
            cmdInsert.Parameters.Add("LOGIN_ABONNÉ", OleDbType.VarChar).Value = logAbo;
            cmdInsert.Parameters.Add("PASSWORD_ABONNÉ", OleDbType.VarChar).Value = "pwd";
            cmdInsert.ExecuteNonQuery();
            string sql = "select * from ABONNÉS WHERE LOGIN_ABONNÉ ='" + logAbo + "'";
            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();
            while (reader.Read())
            {
                codeAbo = reader.GetInt32(0);
            }
            reader.Close();
            string testEmprunt = "insert into EMPRUNTER(CODE_ABONNÉ,CODE_ALBUM,DATE_EMPRUNT,DATE_RETOUR_ATTENDUE) values(" + codeAbo + ", " + codeAlb + ", '22/06/2014', '04/07/2021')";
            OleDbCommand cmdEmprunt = new OleDbCommand(testEmprunt, dbCon);
            cmdEmprunt.ExecuteNonQuery();
            string consult = "SELECT DATE_RETOUR_ATTENDUE, ABONNÉS.LOGIN_ABONNÉ FROM EMPRUNTER INNER JOIN ABONNÉS ON " +
                "EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ INNER JOIN ALBUMS ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM WHERE ABONNÉS.LOGIN_ABONNÉ = '" + logAbo +
                "' AND ALBUMS.CODE_ALBUM = " + codeAlb;
            OleDbCommand cmd = new OleDbCommand(consult, dbCon);
            OleDbDataReader readerTwo = cmd.ExecuteReader();
            while (readerTwo.Read())
            {
                emprunt.Add(logAbo, readerTwo.GetDateTime(0));
            }
            readerTwo.Close();
            string extend = "UPDATE EMPRUNTER Set EMPRUNTER.DATE_RETOUR_ATTENDUE = DATEADD(month, 1, EMPRUNTER.DATE_RETOUR_ATTENDUE) " +
                            "FROM EMPRUNTER INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                            "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE WHERE ABONNÉS.CODE_ABONNÉ = " + codeAbo +
                            " AND ALBUMS.CODE_ALBUM = " + codeAlb + " AND DATE_RETOUR_ATTENDUE - DATE_EMPRUNT <= DÉLAI";
            OleDbCommand cmdSql = new OleDbCommand(extend, dbCon);
            cmdSql.ExecuteNonQuery();
            string consultExtend = " SELECT * FROM EMPRUNTER WHERE CODE_ABONNÉ = " + codeAbo;
            OleDbCommand cmdCE = new OleDbCommand(consultExtend, dbCon);
            OleDbDataReader readerTree = cmdCE.ExecuteReader();
            while (readerTree.Read())
            {
                dateRetour = readerTree.GetDateTime(3);
            }
            readerTree.Close();
            Assert.AreEqual(emprunt[logAbo].AddMonths(0), dateRetour, "test pas passé");
            string delete = " DELETE FROM EMPRUNTER WHERE CODE_ABONNÉ = ( SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ = '" + logAbo + "')";
            OleDbCommand cmdDelete = new OleDbCommand(delete, dbCon);
            cmdDelete.ExecuteNonQuery();
            string deleteFromAbo = "DELETE FROM ABONNÉS WHERE CODE_ABONNÉ =" + codeAbo;
            OleDbCommand cmdDeleteFromAbo = new OleDbCommand(deleteFromAbo, dbCon);
            cmdDeleteFromAbo.ExecuteNonQuery();
            emprunt.Clear();
        }
    }
}
