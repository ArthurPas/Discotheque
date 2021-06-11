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
    public class TestsUS8
    {
        OleDbConnection dbCon;
        string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";
        Accueil accueil = new Accueil();
        AdministrateurAccueil adminAcc = new AdministrateurAccueil();
        public void InitConnexion()
        {
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
        }
        [TestMethod]
        public void TestsPlusDunAn()
        {
            InitConnexion();
            bool same = true;
            List<string> test = new List<string>();
            string request = "SELECT * " +
                "FROM ALBUMS " +
                "FULL JOIN EMPRUNTER ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                "WHERE DATEDIFF(day, DATE_EMPRUNT,GETDATE()) > 365 OR DATE_EMPRUNT IS NULL ";

            OleDbCommand cmd = new OleDbCommand(request, dbCon);
            cmd.ExecuteNonQuery();

            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                test.Add(reader.GetString(3));
            }
            if (adminAcc.listeAlbNonEmprUnAn.Count>0)
            {
                test.Count();
                for (int i = 0; i < adminAcc.listeAlbNonEmprUnAn.Count; i++)
                {
                    if (!test[i].Equals(adminAcc.listeAlbNonEmprUnAn[i]))
                    {
                        same = false;
                    }
                }
            }
            Assert.IsTrue(same);
        }
    }
}
