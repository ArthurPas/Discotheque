using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppliGrpR;
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
        Client_Inscription client = new Client_Inscription();
        Abonne_Accueil abo = new Abonne_Accueil();
        Abonne_Prolonger prolo = new Abonne_Prolonger();
        Accueil accueil = new Accueil();
        public void InitConnexion()
        {
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
        }
        [TestMethod]
        public void TestProlongement()
        {
            InitConnexion();

            string login = "US3ProlongementUnSeul";
            string mdp = "testmdp";
            string prenom = "prenomTest";
            string nom = "testNom";
            string nationalite = "France";
            string codePays = "1";
            int codeAbo = 0;
            int codeAlbumPro = 568;
            DateTime dateRetour = new DateTime();
            DateTime dateRetourInit = new DateTime();
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);
            string consultCode = "Select CODE_ABONNÉ from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdConsultCode = new OleDbCommand(consultCode, dbCon);
            OleDbDataReader reader = cmdConsultCode.ExecuteReader();
            while (reader.Read())
            {
                codeAbo = reader.GetInt32(0);
            }
            abo.EmprunterFonction(codeAlbumPro, codeAbo);
            string consultDate = "SELECT DATE_RETOUR_ATTENDUE FROM EMPRUNTER INNER JOIN ABONNÉS ON " +
                "EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ INNER JOIN ALBUMS ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM WHERE ABONNÉS.LOGIN_ABONNÉ = '" + login +
                "' AND ALBUMS.CODE_ALBUM = " + codeAlbumPro;
            OleDbCommand cmd = new OleDbCommand(consultDate, dbCon);
            OleDbDataReader readerTwo = cmd.ExecuteReader();
            while (readerTwo.Read())
            {
                dateRetourInit = readerTwo.GetDateTime(0);
            }
            prolo.ExtendBorrowing(codeAbo, codeAlbumPro);
            
            string consultExtend = " SELECT * FROM EMPRUNTER WHERE CODE_ABONNÉ = " + codeAbo;
            OleDbCommand cmdCE = new OleDbCommand(consultExtend, dbCon);
            OleDbDataReader readerTree = cmdCE.ExecuteReader();
            while (readerTree.Read())
            {
                dateRetour = readerTree.GetDateTime(3);
            }
            Assert.AreEqual(dateRetourInit.AddMonths(1).Month,dateRetour.Month, "test pas passé");
            
         
            string deleteEmprunt = " DELETE FROM EMPRUNTER WHERE CODE_ABONNÉ = "+codeAbo;
            OleDbCommand cmdDelete = new OleDbCommand(deleteEmprunt, dbCon);
            cmdDelete.ExecuteNonQuery();
            string delete = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "'";
            OleDbCommand cmdDel = new OleDbCommand(delete, dbCon);
            cmdDel.ExecuteNonQuery();
        }

        [TestMethod]
        public void TestProlongementDejaProl()
        {
            InitConnexion();
            string login = "testUS3ProlongementDejaProl";
            string mdp = "testmdp";
            string prenom = "prenomTest";
            string nom = "testNom";
            string nationalite = "France";
            string codePays = "1";
            int codeAbo = 0;
            int codeAlbumPro = 156;
            DateTime dateRetour = new DateTime();
            DateTime dateRetourInit = new DateTime();
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);
            string consultCode = "Select CODE_ABONNÉ from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdConsultCode = new OleDbCommand(consultCode, dbCon);
            OleDbDataReader reader = cmdConsultCode.ExecuteReader();
            while (reader.Read())
            {
                codeAbo = reader.GetInt32(0);
            }
            abo.EmprunterFonction(codeAlbumPro, codeAbo);
            string consultDate = "SELECT DATE_RETOUR_ATTENDUE FROM EMPRUNTER INNER JOIN ABONNÉS ON " +
                "EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ INNER JOIN ALBUMS ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM WHERE ABONNÉS.LOGIN_ABONNÉ = '" + login +
                "' AND ALBUMS.CODE_ALBUM = " + codeAlbumPro;
            OleDbCommand cmd = new OleDbCommand(consultDate, dbCon);
            OleDbDataReader readerTwo = cmd.ExecuteReader();
            while (readerTwo.Read())
            {
                dateRetourInit = readerTwo.GetDateTime(0);
            }
            prolo.ExtendBorrowing(codeAbo, codeAlbumPro);
            prolo.ExtendBorrowing(codeAbo, codeAlbumPro);
            string consultExtend = " SELECT * FROM EMPRUNTER WHERE CODE_ABONNÉ = " + codeAbo;
            OleDbCommand cmdCE = new OleDbCommand(consultExtend, dbCon);
            OleDbDataReader readerTree = cmdCE.ExecuteReader();
            while (readerTree.Read())
            {
                dateRetour = readerTree.GetDateTime(3);
            }
            Assert.AreEqual(dateRetourInit.AddMonths(1).Month, dateRetour.Month, "test pas passé");

            
            string deleteEmprunt = " DELETE FROM EMPRUNTER WHERE CODE_ABONNÉ = "+codeAbo;
            OleDbCommand cmdDelete = new OleDbCommand(deleteEmprunt, dbCon);
            cmdDelete.ExecuteNonQuery();
            string delete = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "'";
            OleDbCommand cmdDel = new OleDbCommand(delete, dbCon);
            cmdDel.ExecuteNonQuery();
        }
    }
}
