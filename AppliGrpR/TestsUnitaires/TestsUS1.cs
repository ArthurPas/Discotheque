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
    public class TestsUS1
    {
        OleDbConnection dbCon;
        string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";
        Client_Inscription client = new Client_Inscription();
        Accueil accueil = new Accueil();
        List<int> albumDispo = new List<int>();
        public void InitConnexion()
        {
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
        }
        [TestMethod]
        public void TestInscription()
        {
            InitConnexion();
            
            string login = "testUS1Inscription1";
            string mdp = "testmdp";
            string prenom = "prenomTest";
            string nom = "testNom";
            string nationalite = "France";
            string codePays = "1";
            Abonne_Accueil abo = new Abonne_Accueil(nom, prenom, login);
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);
            string consult = "Select * from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login +
                "' AND NOM_ABONNÉ ='"+nom+"' AND PRÉNOM_ABONNÉ ='"+prenom+"' AND CODE_PAYS = "+ codePays;
            OleDbCommand cmdConsult = new OleDbCommand(consult, dbCon);
            OleDbDataReader reader = cmdConsult.ExecuteReader();
            Assert.IsTrue(reader.HasRows, "pas inscrit");
            reader.Close();
            string delete = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "'";
            OleDbCommand cmdDel = new OleDbCommand(delete, dbCon);
            cmdDel.ExecuteNonQuery();
        }
        [TestMethod]
        public void TestInscriptionMemeLogin()
        {
            InitConnexion();

            string login = "testUS1.1";
            string mdp = "testmdp";
            string prenom = "prenomTest";
            string nom = "testNom";
            string nationalite = "France";
            string codePays = "1";
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);
            string consult = "Select * from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login +
                "' AND NOM_ABONNÉ ='" + nom + "' AND PRÉNOM_ABONNÉ ='" + prenom + "' AND CODE_PAYS = " + codePays;
            OleDbCommand cmdConsult = new OleDbCommand(consult, dbCon);
            OleDbDataReader reader = cmdConsult.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i++;
            }
            Assert.AreEqual(i, 1,"ajouté alors que même login");
            reader.Close();
            string delete = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "'";
            OleDbCommand cmdDel = new OleDbCommand(delete, dbCon);
            cmdDel.ExecuteNonQuery();
        }
        [TestMethod]
        public void testEmprunt()
        {
            InitConnexion();
            string login = "testUS1.1.1";
            string mdp = "testmdp";
            string prenom = "prenomTest";
            string nom = "testNom";
            string nationalite = "France";
            int codeAbo = 0;
            Abonne_Accueil abo = new Abonne_Accueil(nom, prenom, login);
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);
            string consult = "Select CODE_ABONNÉ from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdConsult = new OleDbCommand(consult, dbCon);
            OleDbDataReader reader = cmdConsult.ExecuteReader();
            while (reader.Read())
            {
                codeAbo =reader.GetInt32(0);
            }
            reader.Close();
            int codeAlb = 658;
            abo.RendreFonction(codeAlb,codeAbo);
            abo.EmprunterFonction(codeAlb, codeAbo);
            string check = "SELECT * FROM EMPRUNTER INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ WHERE CODE_ALBUM = " + codeAlb + " AND ABONNÉS.CODE_ABONNÉ=" + codeAbo;
            OleDbCommand cmdCheck = new OleDbCommand(check, dbCon);
            cmdCheck.ExecuteNonQuery();
            OleDbDataReader readerCheck = cmdCheck.ExecuteReader();
            Assert.IsTrue(readerCheck.HasRows);
            readerCheck.Close();
            string delete = " DELETE FROM EMPRUNTER WHERE CODE_ALBUM = " + codeAlb;
            OleDbCommand cmdDelete = new OleDbCommand(delete, dbCon);
            cmdDelete.ExecuteNonQuery();
            string deleteAbo = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "'";
            OleDbCommand cmdDel = new OleDbCommand(deleteAbo, dbCon);
            cmdDel.ExecuteNonQuery();
        }
        [TestMethod]
        public void testDeuxFoisMemeEmprunt()
        {
            InitConnexion();
            string login = "testUS1.1.1.1";
            string mdp = "testmdp";
            string prenom = "prenomTest";
            string nom = "testNom";
            string nationalite = "France";
            int codeAbo = 0;
            string login2 = "testUS1.2";
            string mdp2 = "testmdp";
            string prenom2 = "prenomTest";
            string nom2 = "testNom";
            string nationalite2 = "France";
            int codeAbo2 = 0;
            Abonne_Accueil abo = new Abonne_Accueil(nom, prenom, login);
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);
            client.AddAbonnes(login2, nationalite2, nom2, mdp2, prenom2);
            string consult = "Select CODE_ABONNÉ from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdConsult = new OleDbCommand(consult, dbCon);
            OleDbDataReader reader = cmdConsult.ExecuteReader();
            while (reader.Read())
            {
                codeAbo = reader.GetInt32(0);
            }
            reader.Close();
            string consult2 = "Select CODE_ABONNÉ from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login2 + "'";
            OleDbCommand cmdConsult2 = new OleDbCommand(consult2, dbCon);
            OleDbDataReader reader2 = cmdConsult.ExecuteReader();
            while (reader2.Read())
            {
                codeAbo2 = reader2.GetInt32(0);
            }
            reader2.Close();
            int codeAlb = 658;
            abo.RendreFonction(codeAlb, codeAbo);
            abo.EmprunterFonction(codeAlb, codeAbo);
            Assert.IsFalse(abo.EmprunterFonction(codeAlb, codeAbo2));
            string check = "SELECT * FROM EMPRUNTER INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ WHERE CODE_ALBUM = " + codeAlb + 
                " AND ABONNÉS.CODE_ABONNÉ=" + codeAbo + "OR ABONNÉS.CODE_ABONNÉ=" + codeAbo2;
            OleDbCommand cmdCheck = new OleDbCommand(check, dbCon);
            cmdCheck.ExecuteNonQuery();
            string delete = " DELETE FROM EMPRUNTER WHERE CODE_ALBUM = " + codeAlb;
            OleDbCommand cmdDelete = new OleDbCommand(delete, dbCon);
            cmdDelete.ExecuteNonQuery();
            string deleteAbo = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "'";
            OleDbCommand cmdDel = new OleDbCommand(deleteAbo, dbCon);
            cmdDel.ExecuteNonQuery();
        }

    }
}
