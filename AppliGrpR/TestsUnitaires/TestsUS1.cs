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
            string login = "aikahloul"; // Déja dans la base 
            string consult = "Select * from ABONNÉS WHERE LOGIN_ABONNÉ = '"+login+"'";
            OleDbCommand cmdConsult = new OleDbCommand(consult, dbCon);
            OleDbDataReader reader = cmdConsult.ExecuteReader();
            if (!reader.HasRows)
            {
                // Ajout théorique d'un abonné
            }
            Assert.IsTrue(reader.HasRows, "erreur ajout alors que login déja pris");
            reader.Close();
            string loginTwo = "PasDansLabase"; // Pas dans la base
            string consultTwo = "Select * from ABONNÉS WHERE LOGIN_ABONNÉ = '" + loginTwo + "'";
            OleDbCommand cmdConsultTwo = new OleDbCommand(consultTwo, dbCon);
            OleDbDataReader readerTwo = cmdConsultTwo.ExecuteReader();
            if (!readerTwo.HasRows)
            {
                string insert = "insert into ABONNÉS(CODE_PAYS,NOM_ABONNÉ,PRÉNOM_ABONNÉ,LOGIN_ABONNÉ,PASSWORD_ABONNÉ) values(?,?,?,?,?)";
                OleDbCommand cmdInsert = new OleDbCommand(insert, dbCon);
                cmdInsert.Parameters.Add("CODE_PAYS", OleDbType.Integer).Value = 1;
                cmdInsert.Parameters.Add("NOM_ABONNÉ", OleDbType.VarChar).Value = "Test";
                cmdInsert.Parameters.Add("PRÉNOM_ABONNÉ", OleDbType.VarChar).Value = "Pas dans la base";
                cmdInsert.Parameters.Add("LOGIN_ABONNÉ", OleDbType.VarChar).Value = loginTwo;
                cmdInsert.Parameters.Add("PASSWORD_ABONNÉ", OleDbType.VarChar).Value = "pwd";
                cmdInsert.ExecuteNonQuery();

            }
            readerTwo.Close();
            string consultTree = "Select * from ABONNÉS WHERE LOGIN_ABONNÉ = '" + loginTwo + "' AND CODE_PAYS= 1 AND NOM_ABONNÉ='Test' AND PRÉNOM_ABONNÉ = 'Pas dans la base' AND PASSWORD_ABONNÉ = 'pwd'";
            OleDbCommand cmdConsultTree = new OleDbCommand(consultTree, dbCon);
            OleDbDataReader readerTree = cmdConsultTree.ExecuteReader();
            Assert.IsTrue(readerTree.HasRows, "pas ajouté");
            string delete = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + loginTwo + "'";
            OleDbCommand cmdDel = new OleDbCommand(delete, dbCon);
            cmdDel.ExecuteNonQuery();
        }
        public bool testEmprunt(string codeAbo, int codeAlbumAEmprunter)
        {
            InitConnexion();
            bool testVerif;
            int delayNumber = 0;
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
            Assert.IsTrue(testEmprunt("39", 701)); // album non emprunté par aikahloul (numero 39 de la base)
            Assert.IsFalse(testEmprunt("39", 700));// album emprunté par aikahloul
            string delete = " DELETE FROM EMPRUNTER WHERE CODE_ALBUM = " + codeAlbumAEmprunter;
            OleDbCommand cmdDelete = new OleDbCommand(delete, dbCon);
            cmdDelete.ExecuteNonQuery();

            return testVerif;
        }
    }
}
