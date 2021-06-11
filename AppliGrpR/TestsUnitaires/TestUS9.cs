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
    public class TestUS9
    {
        OleDbConnection dbCon;
        string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";
        Client_Inscription client = new Client_Inscription();
        public void InitConnexion()
        {
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
        }

        [TestMethod]
        public void TestProlongementAll()
        {

            InitConnexion();

            string login = "US9ProlongementAll2";
            string mdp = "testmdp";
            string prenom = "prenomTest";
            string nom = "testNom";
            string nationalite = "France";
            int codeAbo = 0;
            Abonne_Accueil abo = new Abonne_Accueil(nom,prenom,login) ;
            Abonne_Prolonger prolo = new Abonne_Prolonger(abo);
            List<int> codeAlbum = new List<int>();
            List<DateTime> dateRetour = new List<DateTime>();
            List<DateTime> dateRetourInit = new List <DateTime>();
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);
            //On get les codes pour emprunter
            string consultCode = "Select CODE_ABONNÉ from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdConsultCode = new OleDbCommand(consultCode, dbCon);
            OleDbDataReader reader = cmdConsultCode.ExecuteReader();
            while (reader.Read())
            {
                codeAbo = reader.GetInt32(0);
            }

            //on remplie notre Liste de Code Almbum par des codes disponibles aléatoirement
            Random rd = new Random();
            int random;
            for (int i = 0; i < 3; i++)
            {
                random = rd.Next(100, 500);
                codeAlbum.Add(random);
                abo.EmprunterFonction(codeAlbum[i], codeAbo); //Emprunt des Livres

                if (i == 2)
                {
                    prolo.ExtendBorrowing(codeAbo, codeAlbum[i]); //On prolonge d'abord le dernier album pour tester par la suite qu'il ne se reprolonge pas
                }
            }

            //On Get la date de retour avant prolongement pour chaque livre
            foreach (int codeA in codeAlbum)
            {
                
                string consultDate = "SELECT DATE_RETOUR_ATTENDUE FROM EMPRUNTER INNER JOIN ABONNÉS ON " +
                    "EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ INNER JOIN ALBUMS ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM WHERE ABONNÉS.LOGIN_ABONNÉ = '" + login +
                    "' AND ALBUMS.CODE_ALBUM = " + codeA;
                OleDbCommand cmd = new OleDbCommand(consultDate, dbCon);
                OleDbDataReader readerTwo = cmd.ExecuteReader();
                while (readerTwo.Read())
                {
                    dateRetourInit.Add(readerTwo.GetDateTime(0));
                }
                //Prolongement
                prolo.ExtendBorrowing(codeAbo, codeA);
            }


            //On Get la date de retour après le prolongement pour chaque livre
            int j = 0;
            foreach (int codeA in codeAlbum)
            {

                string consultExtend = " SELECT * FROM EMPRUNTER WHERE CODE_ABONNÉ = " + codeAbo;
                OleDbCommand cmdCE = new OleDbCommand(consultExtend, dbCon);
                OleDbDataReader readerTree = cmdCE.ExecuteReader();
                while (readerTree.Read())
                {
                    dateRetour.Add(readerTree.GetDateTime(3));
                }

                if (j == 2) //On regarde si la date n'a pas bouger pour l'album que l'on avait déja prolongé par la suite
                {
                    Assert.AreEqual(dateRetourInit[j].Month, dateRetour[j].Month, "test pas passé");

                }
                else //Si la date de retour initiale est agale à la date de retour après prolongement

                {
                    Assert.AreEqual(dateRetourInit[j].AddMonths(1).Month, dateRetour[j].Month, "test pas passé");
                }
                
                j++;
            }

            //Supression des abonnés créer pour le Test
            string deleteEmprunt = " DELETE FROM EMPRUNTER WHERE CODE_ABONNÉ = " + codeAbo;
            OleDbCommand cmdDelete = new OleDbCommand(deleteEmprunt, dbCon);
            cmdDelete.ExecuteNonQuery();
            string delete = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "'";
            OleDbCommand cmdDel = new OleDbCommand(delete, dbCon);
            cmdDel.ExecuteNonQuery();
        }
    }
}
