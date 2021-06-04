using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliGrpR
{
    public partial class Form1 : Form
    {
        OleDbConnection dbCon;
        List<Albums> empruntés = new List<Albums>();
        List<string> nationalités = new List<string>();
        string nationaliteActuelle = "";
        public Form1()
        {
            InitializeComponent();
            InitConnexion();
            
        }
        public void InitConnexion()
        {

            string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";

            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
            Nationalite();
            ExtendBorrowing("arthurp", "Le Boeuf sur le Toit"); //TEST
            ExtendAllBorrowing("arthurp"); //TEST
            GetAlbumNotBorrowSinceOneYears();//TEST

        }

        public void AddAbonnes()
        {

            string consult = "Select * from ABONNÉS WHERE NOM_ABONNÉ = '" + textBox2.Text + "' and PRÉNOM_ABONNÉ ='" + textBox3.Text + "'";
            OleDbCommand cmdConsult = new OleDbCommand(consult, dbCon);
            OleDbDataReader reader = cmdConsult.ExecuteReader();
            if (!reader.HasRows)
            {

                string insert = "insert into ABONNÉS(CODE_PAYS,NOM_ABONNÉ,PRÉNOM_ABONNÉ,LOGIN_ABONNÉ,PASSWORD_ABONNÉ) values(?,?,?,?,?)";
                OleDbCommand cmd = new OleDbCommand(insert, dbCon);
                cmd.Parameters.Add("CODE_PAYS", OleDbType.Integer).Value = textBox1.Text;
                cmd.Parameters.Add("NOM_ABONNÉ", OleDbType.VarChar).Value = textBox2.Text;
                cmd.Parameters.Add("PRÉNOM_ABONNÉ", OleDbType.VarChar).Value = textBox3.Text;
                cmd.Parameters.Add("LOGIN_ABONNÉ", OleDbType.VarChar).Value = textBox4.Text;
                cmd.Parameters.Add("PASSWORD_ABONNÉ", OleDbType.VarChar).Value = textBox5.Text;
                cmd.ExecuteNonQuery();
            }
            else
            {
                Console.WriteLine("Déjà inscrit");
            }
        }

        public void ConsultAlbum()
        {
            string sql = "select  EMPRUNTER.CODE_ALBUM, TITRE_ALBUM, ANNÉE_ALBUM from EMPRUNTER " +
                "Inner join ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "Inner join ABONNÉS on EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ " +
                "WHERE ABONNÉS.NOM_ABONNÉ = '" + SearchName.Text + "'";


            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                int code = Convert.ToInt32(reader.GetInt32(0));
                string titre = reader.GetString(1);
                int annee = 0;
                if (!reader.IsDBNull(2))
                    annee = reader.GetInt32(2);

                Albums a = new Albums(code, titre, annee);
                listBox1.Items.Add(a);
                empruntés.Add(a);
            }
            reader.Close();
        }

        public void Nationalite()
        {
            string sql = "select * from PAYS";


            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                string titre = reader.GetString(1);
                nationalités.Add(titre);
                nationalite.Items.Add(titre);
                Console.WriteLine(nationalite.SelectedItems.ToString());
            }
            reader.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddAbonnes();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        /*
         * US3-
         * 
         */

        public void ExtendBorrowing(string username, string titreAlbum)
        {

            string extendDate = "UPDATE EMPRUNTER " +
            "Set EMPRUNTER.DATE_RETOUR_ATTENDUE = DATEADD(MONTH,1,EMPRUNTER.DATE_RETOUR_ATTENDUE) " +
            "FROM EMPRUNTER " +
            "INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ " +
            "INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
            "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
            "WHERE ABONNÉS.LOGIN_ABONNÉ = '" + username + "' " +
            "AND ALBUMS.TITRE_ALBUM = '" + titreAlbum + "' " +
            "AND DATE_RETOUR_ATTENDUE - DATE_EMPRUNT < DÉLAI";

            OleDbCommand cmd = new OleDbCommand(extendDate, dbCon);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Date d'emprunt étendue");

        }

        /*
         * US9-
         * 
         */
        public void ExtendAllBorrowing(string username)
        {

            string extendDate = "UPDATE EMPRUNTER " +
            "Set EMPRUNTER.DATE_RETOUR_ATTENDUE = DATEADD(MONTH,1,EMPRUNTER.DATE_RETOUR_ATTENDUE) " +
            "FROM EMPRUNTER " +
            "INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ " +
            "INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
            "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
            "WHERE ABONNÉS.LOGIN_ABONNÉ = '" + username + "' " +
            "AND DATE_RETOUR_ATTENDUE - DATE_EMPRUNT < DÉLAI";

            OleDbCommand cmd = new OleDbCommand(extendDate, dbCon);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Date d'emprunt étendue pour tout les emprunts de " + username);

        }

        /*
         * US8 
         * 
        */
        public void GetAlbumNotBorrowSinceOneYears() {

            string request = "SELECT * " +
                "FROM ALBUMS " +
                "FULL JOIN EMPRUNTER ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                "WHERE DATEDIFF(day, DATE_EMPRUNT,GETDATE()) > 365 OR DATE_EMPRUNT IS NULL ";

            OleDbCommand cmd = new OleDbCommand(request, dbCon);
            cmd.ExecuteNonQuery();

            OleDbDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("Album qui n'ont pas été emprunté depuis un mois: ");
            while (reader.Read())
            {
                string titreAlbum = reader.GetString(3); 
                Console.WriteLine("titre de l'Album: " + titreAlbum);

            }
        }


        private void Consulter_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            ConsultAlbum();
            SearchName.Text = "";
        }
        public void ListRetard10J()
        {
            string sql = "SELECT DISTINCT NOM_ABONNÉ,PRÉNOM_ABONNÉ from ABONNÉS" +
                " INNER JOIN EMPRUNTER on ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ " +
                "WHERE DATEDIFF(day, GETDATE(), Emprunter.DATE_RETOUR_ATTENDUE) > 10;";
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string nom = reader.GetString(0);
                string prenom = reader.GetString(1);
                Console.WriteLine(nom + prenom);
            }
        }
        public void ListExtended()
        {
            string list = "Select NOM_ABONNÉ, PRÉNOM_ABONNÉ FROM ABONNÉS INNER JOIN EMPRUNTER on ABONNÉS.CODE_ABONNÉ = " +
                "EMPRUNTER.CODE_ABONNÉ INNER JOIN ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE WHERE DATE_RETOUR_ATTENDUE - DATE_EMPRUNT > DÉLAI";
            OleDbCommand cmd = new OleDbCommand(list, dbCon);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                string firstName = reader.GetString(1);
                Console.WriteLine(name + firstName + " a prolongé son emprunt");
            }

        }

        private void ListButton_MouseDown_1(object sender, MouseEventArgs e)
        {
            ListExtended();
        }

        public void PurgeAbonne()
        {
            string sql = "select ABONNÉS.PRÉNOM_ABONNÉ, NOM_ABONNÉ,ABONNÉS.CODE_ABONNÉ, CODE_ALBUM,DATE_EMPRUNT " +
                "from emprunter " +
                "inner join ABONNÉS on ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ " +
                "WHERE DATEDIFF(day, DATE_EMPRUNT, GETDATE()) > 365";

            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                int code = reader.GetInt32(2);
                //suppression
                string sup = "DELETE FROM EMPRUNTER where CODE_ABONNÉ ="+code +
                    "DELETE FROM ABONNÉS where CODE_ABONNÉ ="+code;
                OleDbCommand cmd = new OleDbCommand(sup, dbCon);
                cmd.ExecuteNonQuery();
            }
            reader.Close();
        }

        private void TOP10ALBUMS()
        {
            int classement = 1;
            string sql = " SELECT TOP 10 COUNT(DATE_EMPRUNT)'Nombre d`emprunts', Titre_Album " +
                "FROM EMPRUNTER INNER JOIN ALBUMS" +
                " ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                "GROUP BY TITRE_ALBUM " +
                "ORDER BY COUNT(DATE_EMPRUNT) DESC";
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            cmd.ExecuteNonQuery(); ;
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int nbEmprunts = reader.GetInt32(0);
                string titreAlbum = reader.GetString(1);
                Console.WriteLine("Classement : " + classement + " | Nombre d'emprunts : " + nbEmprunts + " | Titre de l'album :" + titreAlbum);
                classement++;
            }
        }

        private void buttonTOP10_MouseDown_1(object sender, MouseEventArgs e)
        {
            TOP10ALBUMS();
        }

        private void Suppression_MouseDown(object sender, MouseEventArgs e)
        {
            PurgeAbonne();
        }

        private void nationalite_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(nationalite.SelectedItem.ToString());
            nationaliteActuelle = nationalite.SelectedItem.ToString();

            string sql = "select * from PAYS WHERE NOM_PAYS ='"+ nationalite.SelectedItem.ToString()+"'";
            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();

            int code = 0; ;
            while (reader.Read())
            {
                code = reader.GetInt32(0);
                Console.WriteLine(nationalite.SelectedItems.ToString());
            }
            reader.Close();
            textBox1.Text= code.ToString();
        }
    } 
}
