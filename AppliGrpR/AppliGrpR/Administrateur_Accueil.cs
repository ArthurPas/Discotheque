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
    public partial class AdministrateurAccueil : Form
    {
        OleDbConnection dbCon = Accueil.dbCon;
        public static List<Albums> top10 = new List<Albums>();
        public List<string> listeAbo = new List<string>();
        public List<string> listeRetard = new List<string>();
        public List<string> listeAlbNonEmprUnAn = new List<string>();
        public static List<Albums> listeProlongement = new List<Albums>();
        public int indexAbo = 1;
        public int indexNonEmprunteUnAn = 1;
        public int indexProlo = 1;
        public int indexRetard = 1;
        public AdministrateurAccueil()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            ListExtended();
            ListRetard10J();
            Abonnes();
            TOP10ALBUMS();
            GetAlbumNotBorrowedSinceOneYear();
        }

        /// <summary>
        /// US4
        /// Affiche les emprunts qui on été prolongés
        /// </summary>
        public void ListExtended()
        {
            string list = "Select NOM_ABONNÉ, PRÉNOM_ABONNÉ, TITRE_ALBUM,EMPRUNTER.CODE_ALBUM,EMPRUNTER.DATE_RETOUR_ATTENDUE FROM ABONNÉS INNER JOIN EMPRUNTER on ABONNÉS.CODE_ABONNÉ = " +
                "EMPRUNTER.CODE_ABONNÉ INNER JOIN ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "INNER JOIN GENRES on ALBUMS.CODE_GENRE = GENRES.CODE_GENRE " +
                "WHERE DATE_RETOUR_ATTENDUE - DATE_EMPRUNT > DÉLAI";
            OleDbCommand cmd = new OleDbCommand(list, dbCon);
            OleDbDataReader reader = cmd.ExecuteReader();
            listeProlongementBox.Items.Add("Les emprunts qui ont étés prolongés sont : ");
            while (reader.Read())
            {
                DateTime dateRetourAttendue = new DateTime();
                string name = reader.GetString(0);
                string titre = reader.GetString(2);
                int codeAlbum = reader.GetInt32(3);
                dateRetourAttendue = reader.GetDateTime(4);
                
                Albums a = new Albums(codeAlbum, titre, dateRetourAttendue);
                listeProlongement.Add(a);
            }
            AfficherPaginationAvecAlbum(indexProlo, listeProlongementBox, listeProlongement,pageProlongement, 10);

        }

        /// <summary>
        /// US5
        /// Affiche les abonnés ayant des emprunts non rapportés en retard de 10 jours
        /// </summary>
        public void ListRetard10J()
        {
            string sql = "SELECT DISTINCT NOM_ABONNÉ,PRÉNOM_ABONNÉ, TITRE_ALBUM from ABONNÉS" +
                " INNER JOIN EMPRUNTER on ABONNÉS.CODE_ABONNÉ = EMPRUNTER.CODE_ABONNÉ " +
                "INNER JOIN ALBUMS on EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "WHERE DATEDIFF(day,Emprunter.DATE_RETOUR_ATTENDUE, GETDATE()) > 10;";
            OleDbCommand cmd = new OleDbCommand(sql, dbCon);
            cmd.ExecuteNonQuery();
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string nom = reader.GetString(0);
                string titre = reader.GetString(2);
                listeRetard.Add(nom+titre);
            }
            AfficherPagination(indexRetard, Retard10joursBox, listeRetard,pageRetard, 10);
        }

        public void Abonnes()
        {
            listeAbonnebox.Items.Clear();
            string sql = "select * from ABONNÉS";


            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();


            while (reader.Read())
            {
                string titre = reader.GetString(2);
                
                listeAbo.Add(titre);
            }
            AfficherPagination(indexAbo, listeAbonnebox, listeAbo,pageListAbo, 20);
            reader.Close();
        }

        public void TOP10ALBUMS()
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
            top10liste.Items.Add("Classement : ");
            while (reader.Read())
            {
                int nbEmprunts = reader.GetInt32(0);
                string titreAlbum = reader.GetString(1);
                string apostrophe = "'";
                if (titreAlbum.Contains("'"))
                {
                    titreAlbum = titreAlbum.Insert(titreAlbum.IndexOf("'"), apostrophe);
                }
                //
                string sqlalbum = "SELECT TITRE_ALBUM, albums.CODE_ALBUM, DATE_RETOUR_ATTENDUE " +
                    "FROM EMPRUNTER INNER JOIN ALBUMS " +
                    "ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                    "where TITRE_ALBUM ='"+titreAlbum+"'";
                OleDbCommand cmdalbum = new OleDbCommand(sqlalbum, dbCon);
                cmdalbum.ExecuteNonQuery();
                OleDbDataReader readeralbum = cmdalbum.ExecuteReader();
                if (readeralbum.Read())
                {
                    string titre = readeralbum.GetString(0);
                    int code = readeralbum.GetInt32(1);
                    Albums a = new Albums(code, titre);
                    top10.Add(a);
                }
                top10liste.Items.Add(classement + " | Nombre d'emprunts : " + nbEmprunts + " | Titre de l'album :" + titreAlbum);
                classement++;
            }
            reader.Close();
        }

        public void GetAlbumNotBorrowedSinceOneYear()
        {

            string request = "SELECT * " +
                "FROM ALBUMS " +
                "FULL JOIN EMPRUNTER ON ALBUMS.CODE_ALBUM = EMPRUNTER.CODE_ALBUM " +
                "WHERE DATEDIFF(day, DATE_EMPRUNT,GETDATE()) > 365 OR DATE_EMPRUNT IS NULL ";

            OleDbCommand cmd = new OleDbCommand(request, dbCon);
            cmd.ExecuteNonQuery();

            OleDbDataReader reader = cmd.ExecuteReader();

            nonEmprunté.Items.Add("Album qui n'ont pas été emprunté depuis un an: ");
            while (reader.Read())
            {
                int codeAlb = reader.GetInt32(0);
                string titreAlbum = reader.GetString(3);
                
                listeAlbNonEmprUnAn.Add(titreAlbum);
            }
            AfficherPagination(indexNonEmprunteUnAn, nonEmprunté, listeAlbNonEmprUnAn,pageNonEmprunté, 20);
        }

        private void PurgerAbonnes_MouseDown(object sender, MouseEventArgs e)
        {
            Administrateur_Purger adminPurger = new Administrateur_Purger();
            adminPurger.ShowDialog();
            this.Hide();
            this.Close();
        }

        private void Retour_MouseDown(object sender, MouseEventArgs e)
        {
            Accueil a = new Accueil();
            a.Show();
            this.Close();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="listBox"></param>
        /// <param name="list"></param>
        /// <param name="taille"></param>
        public void Paginer(ref int index, ListBox listBox, List<string> list, Label label ,int taille,int direction)
        {
            
            if (direction == 1)
            {
                if (index < getIindexedMax(index, list, taille))
                    index++;
            }
            else
            {
                if(index >1)
                    index--;
            }

            AfficherPagination(index, listBox, list,label, taille);
        }

        public void AfficherPagination(int index, ListBox listBox, List<string> list,Label label, int taille)
        {
            listBox.Items.Clear();
            for (int i = taille * index - taille; i < taille * index; i++)
            {
                if (i < list.Count)
                {
                    listBox.Items.Add(list[i]);
                }
            }
            label.Text = index.ToString() + "/" + getIindexedMax(index, list, taille);

        }
        public double getIindexedMax(int index, List<string> list, int taille)
        {
            float l = list.Count;
            float t = taille;
            return Math.Ceiling(l / t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="listBox"></param>
        /// <param name="list"></param>
        /// <param name="taille"></param>
        public void PaginerAvecAlbum(ref int index, ListBox listBox, List<Albums> list,Label label,int taille, int direction)
        {

            if (direction == 1)
            {
                if(index < getIindexedMaxAlbum(index, list, taille))
                index++;
            }
            else
            {
                if (index > 1)
                    index--;
            }
            AfficherPaginationAvecAlbum(index, listBox, list,label , taille);
        }

        public void AfficherPaginationAvecAlbum(int index, ListBox listBox, List<Albums> list,Label label, int taille)
        {
            listBox.Items.Clear();
            for (int i = taille * index - taille; i < taille * index; i++)
            {
                if (i < list.Count)
                {
                    listBox.Items.Add(list[i]);
                }
            }

            label.Text = index.ToString() + "/" +  getIindexedMaxAlbum(index,list,taille);

        }

    public double getIindexedMaxAlbum(int index, List<Albums> list, int taille)
    {
        float l = list.Count;
        float t = taille;
        return Math.Ceiling(l / t);
    }



    private void RightListButton_Click(object sender, EventArgs e)
        {
            Paginer(ref indexAbo, listeAbonnebox,listeAbo,pageListAbo, 20,1);    
            
        }

        private void LeftListButton_Click(object sender, EventArgs e)
        {

            Paginer(ref indexAbo, listeAbonnebox, listeAbo, pageListAbo, 20,-1);
        }

        private void RightNonEmprButton_Click(object sender, EventArgs e)//
        {
            Paginer(ref indexNonEmprunteUnAn, nonEmprunté, listeAlbNonEmprUnAn,pageNonEmprunté,20, 1); 
            
        }

        private void LeftNonEmprButton_Click(object sender, EventArgs e)
        {
            Paginer(ref indexNonEmprunteUnAn, nonEmprunté, listeAlbNonEmprUnAn, pageNonEmprunté,20,-1);
        }

        private void ProloRightButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(indexProlo);
            PaginerAvecAlbum(ref indexProlo, listeProlongementBox, listeProlongement,pageProlongement,10, 1);
        }

        private void ProloLeftButton_Click(object sender, EventArgs e)
        {
            PaginerAvecAlbum(ref indexProlo, listeProlongementBox, listeProlongement, pageProlongement,10, -1);

        }

        private void RetardRightButton_Click(object sender, EventArgs e)
        {
            Paginer(ref indexRetard, Retard10joursBox,listeRetard,pageRetard,10, 1);
        }

        private void RetardLeftButton_Click(object sender, EventArgs e)
        {
            Paginer(ref indexRetard, Retard10joursBox, listeRetard, pageRetard,10, -1);
        }
    }
}
