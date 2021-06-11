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
        public static OleDbConnection dbCon;
        List<Albums> empruntés = new List<Albums>();
        List<string> genres = new List<string>();
        List<string> nationalités = new List<string>();
        List<string> album = new List<string>();
        List<int> albumDispo = new List<int>();
        int CodeAlbumEmprunter= 0;
        int CodeAlbumProlonger = 0;
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InitConnexion();
            
        }

        public void InitConnexion()
        {

            string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";

            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
            Nationalite();
            Abonnes();
            Album();
        }

        /// <summary>
        /// Ajoute un Abonné à la Base depuis les valeurs récupéré dans les textBox
        /// </summary>

        public void AddAbonnes()
        {

            string consult = "Select * from ABONNÉS WHERE LOGIN_ABONNÉ = '"+textBox4.Text+"'";
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

        /// <summary>
        /// US2
        /// Consulte les albums empruntés par un utilisateur
        /// </summary>
        public void ConsultAlbum()
        {
            string sql = "select  EMPRUNTER.CODE_ALBUM, TITRE_ALBUM, DATE_RETOUR_ATTENDUE from EMPRUNTER " +
                "Inner join ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "Inner join ABONNÉS on EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ " +
                "WHERE ABONNÉS.CODE_ABONNÉ = '" + numeroAbonne.Text + "'";


            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                int code = Convert.ToInt32(reader.GetInt32(0));
                string titre = reader.GetString(1);
                DateTime dateRetour = new DateTime();
                if (!reader.IsDBNull(2))
                    dateRetour = reader.GetDateTime(2);

                Albums a = new Albums(code, titre, dateRetour);
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
            }
            reader.Close();
        }
        public void Album()
        {
            string sql = "select * from ALBUMS";

            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                string titre = reader.GetString(3);
                album.Add(titre);
                ListAlbum.Items.Add(titre);
            }
            reader.Close();
        }
        public void Abonnes()
        {
            ListeAbonne.Items.Clear();
            string sql = "select * from ABONNÉS";


            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                string titre = reader.GetString(2);
                ListeAbonne.Items.Add(titre);
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
            Abonnes();
        }

        /// <summary>
        /// US3
        /// Prolonge un emprent donné
        /// @param l'identifiant de l'utilisateur qui réalise sont prolongement
        /// @param le titre de l'album que l'on veut prolonger
        /// </summary>

        public void ExtendBorrowing()
        {

            string extendDate = "UPDATE EMPRUNTER Set EMPRUNTER.DATE_RETOUR_ATTENDUE = DATEADD(month, 1, EMPRUNTER.DATE_RETOUR_ATTENDUE) " +
                "FROM EMPRUNTER INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE WHERE ABONNÉS.CODE_ABONNÉ = "+numeroAbonne.Text+
                " AND ALBUMS.CODE_ALBUM = "+CodeAlbumProlonger+" AND DATE_RETOUR_ATTENDUE - DATE_EMPRUNT <= DÉLAI";

            OleDbCommand cmd = new OleDbCommand(extendDate, dbCon);
            cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// US9
        /// Prolonge l'emprunt de tous les emprunts
        /// @param l'identifiant de l'utilisateur qui réalise sont prolongement
        /// </summary>
        public void ExtendAllBorrowing()
        {

            string extendDate = "UPDATE EMPRUNTER " +
            "Set EMPRUNTER.DATE_RETOUR_ATTENDUE = DATEADD(MONTH,1,EMPRUNTER.DATE_RETOUR_ATTENDUE) " +
            "FROM EMPRUNTER " +
            "INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ " +
            "INNER JOIN ALBUMS ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
            "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
            "WHERE ABONNÉS.CODE_ABONNÉ = " + numeroAbonne.Text  +
            "AND DATE_RETOUR_ATTENDUE - DATE_EMPRUNT <= DÉLAI";

            OleDbCommand cmd = new OleDbCommand(extendDate, dbCon);
            cmd.ExecuteNonQuery();
            listBox1.Items.Add("Date d'emprunt étendue pour tous vos emprunts");

        }

        /// <summary>
        ///US8 
        ///Affiche les almbums qui n'ont pas était emprunté depuis 1 ans
        /// </summary>
        
        public void GetAlbumNotBorrowedSinceOneYear() {

            string request = "SELECT * " +
                "FROM ALBUMS " +
                "FULL JOIN EMPRUNTER ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                "WHERE DATEDIFF(day, DATE_EMPRUNT,GETDATE()) > 365 OR DATE_EMPRUNT IS NULL ";

            OleDbCommand cmd = new OleDbCommand(request, dbCon);
            cmd.ExecuteNonQuery();

            OleDbDataReader reader = cmd.ExecuteReader();

            listBox1.Items.Add("Album qui n'ont pas été emprunté depuis un an: ");
            while (reader.Read())
            {
                string titreAlbum = reader.GetString(3); 
                listBox1.Items.Add(titreAlbum);

            }
        }


        private void Consulter_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            ConsultAlbum();
        }

        /// <summary>
        /// US5
        /// Affiche les abonnés ayant des emprunts non rapportés en retard de 10 jours
        /// </summary>
        public void ListRetard10J()
        {
            string sql = "SELECT DISTINCT NOM_ABONNÉ,PRÉNOM_ABONNÉ, TITRE_ALBUM from ABONNÉS" +
                " INNER JOIN EMPRUNTER on ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ " +
                "INNER JOIN ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM "+
                "WHERE DATEDIFF(day,Emprunter.DATE_RETOUR_ATTENDUE, GETDATE()) > 10;";
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Add("Les retards de 10 jours ou plus sont sur : ");
            while (reader.Read())
            {
                string nom = reader.GetString(0);
                string titre = reader.GetString(2);
                listBox1.Items.Add(nom + titre);
            }
        }

        /// <summary>
        /// US4
        /// Affiche les emprunts qui on été prolongés
        /// </summary>
        public void ListExtended()
        {
            string list = "Select NOM_ABONNÉ, PRÉNOM_ABONNÉ, TITRE_ALBUM FROM ABONNÉS INNER JOIN EMPRUNTER on ABONNÉS.CODE_ABONNÉ = " +
                "EMPRUNTER.CODE_ABONNÉ INNER JOIN ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
                "WHERE DATE_RETOUR_ATTENDUE - DATE_EMPRUNT > DÉLAI";
            OleDbCommand cmd = new OleDbCommand(list, dbCon);
            OleDbDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Add("Les emprunts qui ont étés prolongés sont : ");
            while (reader.Read())
            {
                string name = reader.GetString(0);
                string titre = reader.GetString(2);
                listBox1.Items.Add(name  +" a prolongé l'emprunt de "+titre);
            }

        }

        /// <summary>
        /// US6
        /// Supprimer les abonnés et leur emprunts si leur dernière emprunt date de plus d'un an
        /// </summary>
        public void PurgeAbonne()
        {
            //regarde si l'abonné a un emprunt qui date de plus d'un an
            string sql = "select ABONNÉS.PRÉNOM_ABONNÉ, NOM_ABONNÉ,ABONNÉS.CODE_ABONNÉ, CODE_ALBUM,DATE_EMPRUNT " +
                "from emprunter " +
                "inner join ABONNÉS on ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ " +
                "WHERE DATEDIFF(day, DATE_EMPRUNT, GETDATE()) > 365 AND DATE_RETOUR iS NOT NULL";

            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                //récupère le code de l'abo
                int code = reader.GetInt32(2);
                //regarde si il a un emprunt qui date de moins d'un an
                string test = "select ABONNÉS.PRÉNOM_ABONNÉ, NOM_ABONNÉ,ABONNÉS.CODE_ABONNÉ, CODE_ALBUM,DATE_EMPRUNT " +
                    "from emprunter " +
                    "inner join ABONNÉS on ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ " +
                    "WHERE DATEDIFF(day, DATE_EMPRUNT, GETDATE()) < 365 AND ABONNÉS.CODE_ABONNÉ ="+code;
                OleDbCommand cmdReadtest = new OleDbCommand(test, dbCon);
                OleDbDataReader readertest = cmdReadtest.ExecuteReader();
                //si pas d'emprunt qui date de moins d'un an
                if (!readertest.Read())
                {
                    //suppression
                    string sup = "DELETE FROM EMPRUNTER where CODE_ABONNÉ =" + code +
                        "DELETE FROM ABONNÉS where CODE_ABONNÉ =" + code;
                    OleDbCommand cmd = new OleDbCommand(sup, dbCon);
                    cmd.ExecuteNonQuery();
                }
            }
            reader.Close();
        }

        /// <summary>
        /// US7
        /// Affiche les 10 albums les plus empruntés dans l'année
        /// </summary>
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
            listBox1.Items.Add("Classement : ");
            while (reader.Read())
            {
                int nbEmprunts = reader.GetInt32(0);
                string titreAlbum = reader.GetString(1);
                

               listBox1.Items.Add(classement + " | Nombre d'emprunts : " + nbEmprunts + " | Titre de l'album :" + titreAlbum);
                classement++;
            }
        }
        private void Suggestions()
        {
            var random = new Random();
            string sql = "SELECT TOP 1 LIBELLÉ_GENRE, COUNT(DATE_EMPRUNT) as 'Emprunts totaux' " +
                "FROM GENRES INNER JOIN ALBUMS ON ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
                "INNER JOIN EMPRUNTER ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                "INNER JOIN ABONNÉS ON EMPRUNTER.CODE_ABONNÉ = ABONNÉS.CODE_ABONNÉ " +
                "WHERE ABONNÉS.CODE_ABONNÉ = "+numeroAbonne.Text +
                "GROUP BY LIBELLÉ_GENRE " +
                "ORDER BY COUNT(DATE_EMPRUNT) DESC";
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            cmd.ExecuteNonQuery(); ;
            OleDbDataReader reader = cmd.ExecuteReader();
            genres.Clear();
            while (reader.Read())
            {
                genres.Add(reader.GetString(0));
            }
            string sqlTwo = "SELECT ALBUMS.TITRE_ALBUM, ALBUMS.CODE_ALBUM,EMPRUNTER.DATE_RETOUR_ATTENDUE FROM ALBUMS INNER JOIN GENRES ON GENRES.CODE_GENRE = ALBUMS.CODE_GENRE " +
                "INNER JOIN EMPRUNTER ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "WHERE LIBELLÉ_GENRE = '"+genres[0]+"'";
            OleDbCommand cmdTwo = new OleDbCommand(sqlTwo, dbCon);
            cmdTwo.ExecuteNonQuery(); 
            OleDbDataReader readerTwo = cmdTwo.ExecuteReader();
            listBox1.Items.Add("Nous vous recommandons dans le genre " + genres[0]);
            int code = 0;
            string nomAlbum = "";
            DateTime date = new DateTime();
            while (readerTwo.Read())
            {
                nomAlbum= readerTwo.GetString(0);
                code = readerTwo.GetInt32(1);
                date = readerTwo.GetDateTime(2);
                album.Add(nomAlbum);
            }
            for (int i = 0; i < 10; i++)
            {                                            
                int index = random.Next(album.Count);
                Albums a = new Albums(code, album[index], date);
                listBox1.Items.Add(a);
            }    
        }

        private void buttonTOP10_MouseDown_1(object sender, MouseEventArgs e)
        {
            listBox1.Items.Clear();
            TOP10ALBUMS();
        }

        private void Suppression_MouseDown(object sender, MouseEventArgs e)
        {
            PurgeAbonne();
            Abonnes();
        }

        private void nationalite_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from PAYS WHERE NOM_PAYS ='"+ nationalite.SelectedItem.ToString()+"'";
            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();

            int code = 0; ;
            while (reader.Read())
            {
                code = reader.GetInt32(0);
            }
            reader.Close();
            textBox1.Text= code.ToString();
        }

        private void Recomandation_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.Items.Clear();
            Suggestions();
        }

        private void ListeAbonne_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from ABONNÉS WHERE NOM_ABONNÉ ='" + ListeAbonne.SelectedItem.ToString() + "'";
            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();

            int code = 0; ;
            while (reader.Read())
            {
                code = reader.GetInt32(0);
            }
            reader.Close();
            numeroAbonne.Text = code.ToString();
        }

        public void Emprunter()
        {
            string codeAbo = numeroAbonne.Text;
            int delayNumber = 0;
            string delay = "SELECT DÉLAI FROM GENRES INNER JOIN ALBUMS on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
                "WHERE ALBUMS.CODE_ALBUM = " + CodeAlbumEmprunter;
            OleDbCommand cmdDelay = new OleDbCommand(delay, dbCon);
            cmdDelay.ExecuteNonQuery();
            OleDbDataReader readerDelay = cmdDelay.ExecuteReader();
            while (readerDelay.Read())
            {
                delayNumber = readerDelay.GetInt32(0);
            }
            string dispo = "SELECT * FROM ALBUMS FULL JOIN EMPRUNTER ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM WHERE DATE_RETOUR_ATTENDUE IS NULL";
            OleDbCommand cmdDispo = new OleDbCommand(dispo, dbCon);
            cmdDispo.ExecuteNonQuery();
            OleDbDataReader redaerDispo = cmdDispo.ExecuteReader();
            while (redaerDispo.Read())
            {
                albumDispo.Add(redaerDispo.GetInt32(0));
            }
            string request = "insert into EMPRUNTER(CODE_ABONNÉ,CODE_ALBUM,DATE_EMPRUNT,DATE_RETOUR_ATTENDUE) " +
                "values(" + codeAbo + ", ?, GETDATE(),DATEADD(Day,?,GETDATE()))";
            OleDbCommand cmdTwo = new OleDbCommand(request, dbCon);
            if (albumDispo.Contains(CodeAlbumEmprunter)) { 
            cmdTwo.Parameters.Add("CODE_ALBUM", OleDbType.Integer).Value = CodeAlbumEmprunter;
            cmdTwo.Parameters.Add("DÉLAIS", OleDbType.Integer).Value = delayNumber;
            cmdTwo.ExecuteNonQuery();
            }
            albumDispo.Clear();
        }

        private void emprunterButton_MouseDown(object sender, MouseEventArgs e)
        {
            Emprunter();
        }

        private void ListButton_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.Items.Clear();
            ListExtended();
        }

        private void ListAlbum_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string titre = ListAlbum.SelectedItem.ToString();

            string sql = "SELECT CODE_ALBUM FROM ALBUMS WHERE TITRE_ALBUM ='" + Utils.manageSingleQuote(titre) + "'";
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CodeAlbumEmprunter = reader.GetInt32(0);
            }
        }
        private void ProlongerButton_MouseDown(object sender, MouseEventArgs e)
        {
            ExtendBorrowing();
        }

        private void Retard10_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.Items.Clear();
            ListRetard10J();
        }

        private void PlusUnAn_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.Items.Clear();
            GetAlbumNotBorrowedSinceOneYear();
        }

        private void ProlongerTout_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.Items.Clear();
            ExtendAllBorrowing();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
                Albums album = (Albums)listBox1.SelectedItem;
                string titre = album.titre.ToString();

                string sql = "SELECT CODE_ALBUM FROM ALBUMS WHERE TITRE_ALBUM ='" + Utils.manageSingleQuote(titre) + "'";
                OleDbCommand cmd = new OleDbCommand(sql, dbCon);
                cmd.ExecuteNonQuery();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CodeAlbumProlonger = reader.GetInt32(0);
                }
            }
            catch (System.InvalidCastException)
            {

            }
        }

        private void RechercherTextBox_TextChanged(object sender, EventArgs e)
        {
            if (RechercherTextBox.Text.Equals(""))
            {
                Album();
            }
            else
            {
                ListAlbum.Items.Clear();
                string titreRech = RechercherTextBox.Text;

                string sql = "SELECT TITRE_ALBUM, ALBUMS.CODE_ALBUM, EMPRUNTER.DATE_RETOUR_ATTENDUE " +
                    "FROM ALBUMS " +
                    "FULL JOIN EMPRUNTER on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                    "WHERE TITRE_ALBUM LIKE '%"+ Utils.manageSingleQuote(titreRech) + "%'";
                OleDbCommand cmd = new OleDbCommand(sql, dbCon);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string titre = reader.GetString(0);
                    int id = reader.GetInt32(1);
                    DateTime dateRetour= new DateTime();
                    if (!reader.IsDBNull(2))
                        dateRetour = reader.GetDateTime(2);
                    Albums a = new Albums(id, titre, dateRetour);
                    ListAlbum.Items.Add(a);
                    
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PasserAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            Administrateur_Connexion adminConnexion = new Administrateur_Connexion();
            adminConnexion.StartPosition = FormStartPosition.CenterScreen;
            adminConnexion.ShowDialog();
        }

        private void PasserAbonne_MouseDown(object sender, MouseEventArgs e)
        {
            Abonne_Connexion AbonneConnexion = new Abonne_Connexion();
            AbonneConnexion.StartPosition = FormStartPosition.CenterScreen;
            AbonneConnexion.ShowDialog();
        }
    } 
}
