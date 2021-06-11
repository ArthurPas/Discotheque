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
using AppliGrpR;

namespace TestsUnitaires
{
    [TestClass]
    public class TestUS6
    {
        OleDbConnection dbCon;
        string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";

        public void InitConnexion()
        {
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
        }

        [TestMethod]
        public void TestPurgerAbonnée()
        {

            InitConnexion();

            Client_Inscription client = new Client_Inscription();
            Administrateur_Purger admin = new Administrateur_Purger();

                      
            //Ajout d'un Abonné qui n'a pas empruntée depuis un an
            string login = "old8";
            string mdp = "0000";
            string prenom = "John";
            string nom = "Vieux";
            string nationalite = "France";
            int codeAbo = 0;
            Abonne_Accueil abonnée = new Abonne_Accueil(nom,prenom,login);
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);

            //On get les codes pour emprunter
            string consult = "Select CODE_ABONNÉ from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdConsult = new OleDbCommand(consult, dbCon);
            OleDbDataReader reader = cmdConsult.ExecuteReader();
            while (reader.Read())
            {
                codeAbo = reader.GetInt32(0);
            }
            reader.Close();
            int codeAlb = 620;

            Console.WriteLine("code Abo" + codeAbo);

            abonnée.EmprunterFonction(codeAlb, codeAbo);

            admin.PurgeAbonne();

            //On Test avant de modifier la date si la purge ne se fait pas car la date est d'emprunt est au jour d'aujourd'hui
            string consult4 = "Select * from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdConsult4 = new OleDbCommand(consult4, dbCon);
            OleDbDataReader reader3 = cmdConsult4.ExecuteReader();        

            Assert.IsTrue(reader3.HasRows, "purger"); 
            reader3.Close();
            

            //On modifie la date d'emprunt pour quels soit plus vielle qu'un an
            string consult2 = "UPDATE EMPRUNTER SET DATE_EMPRUNT = '04/06/2014', DATE_RETOUR = '04/07/2015', DATE_RETOUR_ATTENDUE = '04/07/2015'" +
                "WHERE CODE_ABONNÉ = '" + codeAbo +"'";
            OleDbCommand cmdConsult2 = new OleDbCommand(consult2, dbCon);
            cmdConsult2.ExecuteReader();

            admin.PurgeAbonne();

            //Test si l'abonné est bien supprimé
            string consult3 = "Select * from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdConsult3 = new OleDbCommand(consult3, dbCon);
            OleDbDataReader readerResult = cmdConsult3.ExecuteReader();


            Assert.IsTrue(!readerResult.HasRows, "pas purger");
            reader.Close();
        }
    }
}
