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
    public class TestsUS5
    {
        OleDbConnection dbCon;
        string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";
        Dictionary<string, DateTime> emprunt = new Dictionary<string, DateTime>();
        Client_Inscription client = new Client_Inscription();
        Accueil accueil = new Accueil();
        AdministrateurAccueil admin = new AdministrateurAccueil();
        public void InitConnexion()
        {
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
        }
        [TestMethod]
        public void TestUS5()
        {
            InitConnexion();
            string login = "US5retard10Jours";
            string mdp = "testmdp";
            string prenom = "prenomTest";
            string nom = "testNom";
            string nationalite = "France";
            int codeAbo = 0;
            int codeAlbumPro = 258;
            bool retardBool = true;
            Abonne_Accueil abo= new Abonne_Accueil(nom, prenom, login);
            Abonne_Prolonger prolo = new Abonne_Prolonger(abo);
            client.AddAbonnes(login, nationalite, nom, mdp, prenom);
            string consultCode = "Select CODE_ABONNÉ from ABONNÉS WHERE LOGIN_ABONNÉ = '" + login + "'";
            OleDbCommand cmdConsultCode = new OleDbCommand(consultCode, dbCon);
            OleDbDataReader reader = cmdConsultCode.ExecuteReader();
            while (reader.Read())
            {
                codeAbo = reader.GetInt32(0);
            }
            reader.Close();
            abo.EmprunterFonction(codeAlbumPro, codeAbo);
            string retard = "UPDATE EMPRUNTER SET DATE_RETOUR_ATTENDUE = '2020-06-08 15:26:39.133' WHERE CODE_ABONNÉ = " + codeAbo + "AND CODE_ALBUM =" + codeAlbumPro;
            OleDbCommand cmdRetard = new OleDbCommand(retard, dbCon);
            cmdRetard.ExecuteNonQuery();
            OleDbDataReader readerTwo = cmdConsultCode.ExecuteReader();
            admin.ListRetard10J();
            while (readerTwo.Read())
            {
                foreach (string testnom in admin.listeRetard)
                {
                    if (!admin.listeRetard.Contains(testnom))
                    {
                        retardBool = false;
                    }
                }
            }
            Assert.IsTrue(retardBool);
            string deleteEmprunt = " DELETE FROM EMPRUNTER WHERE CODE_ABONNÉ = " + codeAbo;
            OleDbCommand cmdDelete = new OleDbCommand(deleteEmprunt, dbCon);
            cmdDelete.ExecuteNonQuery();
            string delete = "DELETE FROM ABONNÉS WHERE LOGIN_ABONNÉ ='" + login + "'";
            OleDbCommand cmdDel = new OleDbCommand(delete, dbCon);
            cmdDel.ExecuteNonQuery();
        }
    }
}
