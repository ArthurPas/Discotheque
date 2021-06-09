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
        Abonne_Accueil abo = new Abonne_Accueil();
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
            
            string login = "testUS1";
            string mdp = "testmdp";
            string prenom = "prenomTest";
            string nom = "testNom";
            string nationalite = "France";
            string codePays = "1";
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);
            string consult = "Select * from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "' AND PASSWORD_ABONNÉ ='"+mdp+"' AND" +
                " NOM_ABONNÉ ='"+nom+"' AND PRÉNOM_ABONNÉ ='"+prenom+"' AND CODE_PAYS = "+ codePays;
            OleDbCommand cmdConsult = new OleDbCommand(consult, dbCon);
            OleDbDataReader reader = cmdConsult.ExecuteReader();
            Assert.IsTrue(reader.HasRows, "pas inscrit");
            reader.Close();
            string delete = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "'";
            OleDbCommand cmdDel = new OleDbCommand(delete, dbCon);
            cmdDel.ExecuteNonQuery();
        }
        [TestMethod]
        public void testEmprunt()
        {
            InitConnexion();
            bool testVerif;
            string login = "testUS1";
            string mdp = "testmdp";
            string prenom = "prenomTest";
            string nom = "testNom";
            string nationalite = "France";
            int codeAbo = 0;
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);
            string consult = "Select CODE_ABONNÉ from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdConsult = new OleDbCommand(consult, dbCon);
            OleDbDataReader reader = cmdConsult.ExecuteReader();
            while (reader.Read())
            {
                codeAbo =reader.GetInt32(0);
            }
            reader.Close();
            int codeAlb = 624;
            abo.EmprunterFonction(codeAlb, codeAbo);
            string check = "SELECT * FROM EMPRUNTER INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ WHERE CODE_ALBUM = " + codeAlb + " AND ABONNÉS.CODE_ABONNÉ=" + codeAbo;
            OleDbCommand cmdCheck = new OleDbCommand(check, dbCon);
            cmdCheck.ExecuteNonQuery();
            OleDbDataReader readerCheck = cmdCheck.ExecuteReader();
            testVerif = readerCheck.HasRows;
            readerCheck.Close();
            Assert.IsTrue(testVerif);
            string delete = " DELETE FROM EMPRUNTER WHERE CODE_ALBUM = " + codeAlb;
            OleDbCommand cmdDelete = new OleDbCommand(delete, dbCon);
            cmdDelete.ExecuteNonQuery();
            string deleteAbo = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "'";
            OleDbCommand cmdDel = new OleDbCommand(deleteAbo, dbCon);
            cmdDel.ExecuteNonQuery();



            /*
            int codeAlbumAEmprunter =554;
            int codeAbo = 0;
            bool testVerif;
            int delayNumber = 0;
            string test = "insert into ABONNÉS(CODE_PAYS, NOM_ABONNÉ, PRÉNOM_ABONNÉ, LOGIN_ABONNÉ, PASSWORD_ABONNÉ) values(?,?,?,?,?)";
            OleDbCommand cmdInsert = new OleDbCommand(test, dbCon);
            cmdInsert.Parameters.Add("CODE_PAYS", OleDbType.Integer).Value = 1;
            cmdInsert.Parameters.Add("NOM_ABONNÉ", OleDbType.VarChar).Value = "Test";
            cmdInsert.Parameters.Add("PRÉNOM_ABONNÉ", OleDbType.VarChar).Value = "Pas dans la base";
            cmdInsert.Parameters.Add("LOGIN_ABONNÉ", OleDbType.VarChar).Value = "log";
            cmdInsert.Parameters.Add("PASSWORD_ABONNÉ", OleDbType.VarChar).Value = "pwd";
            cmdInsert.ExecuteNonQuery();
            string sql = "select * from ABONNÉS WHERE LOGIN_ABONNÉ ='log'";
            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();
            while (reader.Read())
            {
                codeAbo = reader.GetInt32(0);
            }
            reader.Close();
            string delay = "SELECT DÉLAI FROM GENRES INNER JOIN ALBUMS on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
                "WHERE ALBUMS.CODE_ALBUM = "+ codeAlbumAEmprunter;
            OleDbCommand cmdDelay = new OleDbCommand(delay, dbCon);
            cmdDelay.ExecuteNonQuery();
            OleDbDataReader readerDelay = cmdDelay.ExecuteReader();
            while (readerDelay.Read())
            { 
                delayNumber = readerDelay.GetInt32(0);
            }
            readerDelay.Close();
            string dispo = "SELECT * FROM ALBUMS FULL JOIN EMPRUNTER ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM WHERE DATE_RETOUR_ATTENDUE IS NULL";
            OleDbCommand cmdDispo = new OleDbCommand(dispo, dbCon);
            cmdDispo.ExecuteNonQuery();
            OleDbDataReader readerDispo = cmdDispo.ExecuteReader();
            while (readerDispo.Read())
            {
                 albumDispo.Add(readerDispo.GetInt32(0));
            }
            readerDispo.Close();
            string request = "insert into EMPRUNTER(CODE_ABONNÉ,CODE_ALBUM,DATE_EMPRUNT,DATE_RETOUR_ATTENDUE) " +
                "values(" + codeAbo + ", ?, GETDATE(),DATEADD(Day,?,GETDATE()))";
            OleDbCommand cmdTwo = new OleDbCommand(request, dbCon);
            Trace.WriteLine(albumDispo.Contains(codeAlbumAEmprunter));
            if (albumDispo.Contains(codeAlbumAEmprunter))
            {
                cmdTwo.Parameters.Add("CODE_ALBUM", OleDbType.Integer).Value = codeAlbumAEmprunter;
                cmdTwo.Parameters.Add("DÉLAIS", OleDbType.Integer).Value = delayNumber;
                cmdTwo.ExecuteNonQuery();
            }
            string check = "SELECT * FROM EMPRUNTER INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ WHERE CODE_ALBUM = "+codeAlbumAEmprunter+" AND ABONNÉS.CODE_ABONNÉ="+codeAbo;
            OleDbCommand cmdCheck = new OleDbCommand(check, dbCon);
            cmdCheck.ExecuteNonQuery();
            OleDbDataReader readerCheck = cmdCheck.ExecuteReader();
            testVerif = readerCheck.HasRows;
            readerCheck.Close();
            Assert.IsTrue(testVerif);
            string delete = " DELETE FROM EMPRUNTER WHERE CODE_ALBUM = " + codeAlbumAEmprunter;
            OleDbCommand cmdDelete = new OleDbCommand(delete, dbCon);
            cmdDelete.ExecuteNonQuery();
            */
        }
        
    }
}
