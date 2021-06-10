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
    public class TestUS2
    {
        Accueil accueil = new Accueil();
        Abonne_Accueil accueilAbo = new Abonne_Accueil();
        OleDbConnection dbCon;
        string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";
        List<Albums> albumAbo = new List<Albums>();
        public void InitConnexion()
        {
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
        }
        [TestMethod]
        public void TestList1EmpruntAbo()
        {
            InitConnexion();
            bool same = true;
            int codeAbo = 0;
            int codeAlbumEmprunter = 515;
            int codeAlbumsGet = 0;
            string titreAlbums = "";
            DateTime dateRetour = new DateTime();
            Client_Inscription client = new Client_Inscription();
            string login = "testUS2";
            string mdp = "US2TestMDP";
            string prenom = "US2TestPrenom";
            string nom = "US2TestNom";
            string nationalite = "France";
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);

            string getCode = "SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "' AND PASSWORD_ABONNÉ = '" + mdp + "'";
            OleDbCommand cmdCode = new OleDbCommand(getCode, dbCon);
            cmdCode.ExecuteNonQuery();
            OleDbDataReader readCode = cmdCode.ExecuteReader();
            while (readCode.Read())
            {
                codeAbo = readCode.GetInt32(0);
            }
            readCode.Close();

            accueilAbo.EmprunterFonction(codeAlbumEmprunter, codeAbo);

            string sqlEmpruntList = "SELECT EMPRUNTER.CODE_ALBUM, TITRE_ALBUM, DATE_RETOUR_ATTENDUE FROM EMPRUNTER " +
                "INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM WHERE EMPRUNTER.CODE_ABONNÉ = ( SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "')";
            OleDbCommand cmdList = new OleDbCommand(sqlEmpruntList, dbCon);
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
                    codeAlbumsGet = rdList.GetInt32(0);
                    titreAlbums = rdList.GetString(1).Trim();
                    dateRetour = rdList.GetDateTime(2);
                    Albums a = new Albums(codeAlbumsGet, titreAlbums, dateRetour);
                    albumAbo.Add(a);
                }
            }
            rdList.Close();
            accueilAbo.ConsultAlbum(codeAbo);
            int i = 0;
            foreach (Albums a in Abonne_Accueil.empruntés)
            {
                if (!albumAbo[i].getID().Equals(a.getID()))
                {
                    same = false;
                }
                i++;
            }
            Assert.IsTrue(same);
            string deleteFromEmprunts = "DELETE FROM EMPRUNTER WHERE CODE_ABONNÉ = (SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "' AND PASSWORD_ABONNÉ = '" + mdp + "')";
            string deleteFromAbonnés = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='testUS2' AND PASSWORD_ABONNÉ = 'US2TestMDP'";
            OleDbCommand cmdDeleteFromEmprunts = new OleDbCommand(deleteFromEmprunts, dbCon);
            cmdDeleteFromEmprunts.ExecuteNonQuery();
            OleDbCommand cmdDeleteFromAbonnés = new OleDbCommand(deleteFromAbonnés, dbCon);
            cmdDeleteFromEmprunts.ExecuteNonQuery();
            cmdDeleteFromAbonnés.ExecuteNonQuery();
        }

        [TestMethod]
        public void TestListMultiplesEmpruntsAbo()
        {
            InitConnexion();
            bool same = true;
            int codeAbo = 0;
            int codeAlbumEmprunter = 674;
            int codeAlbumsGet = 0;
            string titreAlbums = "";
            DateTime dateRetour = new DateTime();
            Client_Inscription client = new Client_Inscription();
            string login = "testUS2Multiple";
            string mdp = "US2TestMDPMultiple";
            string prenom = "US2TestPrenomMultiple";
            string nom = "US2TestNomMultiple";
            string nationalite = "France";
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);

            string getCode = "SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "' AND PASSWORD_ABONNÉ = '" + mdp + "'";
            OleDbCommand cmdCode = new OleDbCommand(getCode, dbCon);
            cmdCode.ExecuteNonQuery();
            OleDbDataReader readCode = cmdCode.ExecuteReader();
            while (readCode.Read())
            {
                codeAbo = readCode.GetInt32(0);
            }
            readCode.Close();
            for (int j = 0; j < 10; j++)
            {
                accueilAbo.EmprunterFonction(codeAlbumEmprunter + j, codeAbo);
            }
            string sqlEmpruntList = "SELECT EMPRUNTER.CODE_ALBUM, TITRE_ALBUM, DATE_RETOUR_ATTENDUE FROM EMPRUNTER " +
                "INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM WHERE EMPRUNTER.CODE_ABONNÉ = ( SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "')";
            OleDbCommand cmdList = new OleDbCommand(sqlEmpruntList, dbCon);
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
                    codeAlbumsGet = rdList.GetInt32(0);
                    titreAlbums = rdList.GetString(1).Trim();
                    dateRetour = rdList.GetDateTime(2);
                    Albums a = new Albums(codeAlbumsGet, titreAlbums, dateRetour);
                    albumAbo.Add(a);
                }
            }
            rdList.Close();
            accueilAbo.ConsultAlbum(codeAbo);
            int i = 0;
            foreach (Albums a in Abonne_Accueil.empruntés)
            {
                if (!albumAbo[i].getID().Equals(a.getID()))
                {
                    same = false;
                }
                i++;
            }
            Assert.IsTrue(same);
            string deleteFromEmprunts = "DELETE FROM EMPRUNTER WHERE CODE_ABONNÉ = (SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "' AND PASSWORD_ABONNÉ = '" + mdp + "')";
            string deleteFromAbonnés = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='testUS2' AND PASSWORD_ABONNÉ = 'US2TestMDP'";
            OleDbCommand cmdDeleteFromEmprunts = new OleDbCommand(deleteFromEmprunts, dbCon);
            cmdDeleteFromEmprunts.ExecuteNonQuery();
            OleDbCommand cmdDeleteFromAbonnés = new OleDbCommand(deleteFromAbonnés, dbCon);
            cmdDeleteFromEmprunts.ExecuteNonQuery();
            cmdDeleteFromAbonnés.ExecuteNonQuery();
        }

        [TestMethod]
        public void TestListNoEmpruntsAbo()
        {
            InitConnexion();
            bool same = true;
            int codeAbo = 0;
            Client_Inscription client = new Client_Inscription();
            string login = "testUS2None";
            string mdp = "US2TestMDPNone";
            string prenom = "US2TestPrenomNone";
            string nom = "US2TestNomNone";
            string nationalite = "France";
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);

            string getCode = "SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "' AND PASSWORD_ABONNÉ = '" + mdp + "'";
            OleDbCommand cmdCode = new OleDbCommand(getCode, dbCon);
            cmdCode.ExecuteNonQuery();
            OleDbDataReader readCode = cmdCode.ExecuteReader();
            while (readCode.Read())
            {
                codeAbo = readCode.GetInt32(0);
            }

            string sqlEmpruntList = "SELECT EMPRUNTER.CODE_ALBUM, TITRE_ALBUM, DATE_RETOUR_ATTENDUE FROM EMPRUNTER " +
                "INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM WHERE EMPRUNTER.CODE_ABONNÉ = ( SELECT CODE_ABONNÉ FROM ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "')";
            OleDbCommand cmdList = new OleDbCommand(sqlEmpruntList, dbCon);
            cmdList.ExecuteNonQuery();
            OleDbDataReader rdList = cmdList.ExecuteReader();
            if (rdList.HasRows)
            {
                same = false;
            }
            rdList.Close();
            accueilAbo.ConsultAlbum(codeAbo);
            int i = 0;
            foreach (Albums a in Abonne_Accueil.empruntés)
            {
                if (!albumAbo[i].getID().Equals(a.getID()))
                {
                    same = false;
                }
                i++;
            }
            Assert.IsTrue(same);
            string deleteFromAbonnés = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='testUS2' AND PASSWORD_ABONNÉ = 'US2TestMDP'";
            OleDbCommand cmdDeleteFromAbonnés = new OleDbCommand(deleteFromAbonnés, dbCon);
            cmdDeleteFromAbonnés.ExecuteNonQuery();
        }
    }
}
