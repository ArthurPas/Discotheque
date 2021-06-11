using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliGrpR
{
    public partial class Administrateur_Casier : Form
    {
        OleDbConnection dbCon = Accueil.dbCon;
        public Administrateur_Casier()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InitComboBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listCasierEmprunts.Items.Clear();
            EmpruntsCasier();           
        }

        public void EmpruntsCasier()
        {
            int codeCasier = (int)numCasier.SelectedIndex+1;
            string sqlEmpruntsCasier = "SELECT TITRE_ALBUM FROM ALBUMS INNER JOIN EMPRUNTER " +
                "ON EMPRUNTER.CODE_ALBUM = ALBUMS.CODE_ALBUM " +
                "WHERE CASIER_ALBUM = "+codeCasier+"  AND DATE_RETOUR IS NULL";
            OleDbCommand cmdEmpruntsCasier = new OleDbCommand(sqlEmpruntsCasier, dbCon);
            cmdEmpruntsCasier.ExecuteNonQuery();
            OleDbDataReader rdEmpruntsCasier = cmdEmpruntsCasier.ExecuteReader();
            while (rdEmpruntsCasier.Read())
            {
                string titreAlbum = rdEmpruntsCasier.GetString(0);
                listCasierEmprunts.Items.Add(titreAlbum);
            }
        }

        public void InitComboBox()
        {
            string sqlCasierNombre = "SELECT DISTINCT CASIER_ALBUM FROM ALBUMS ORDER BY CASIER_ALBUM";
            OleDbCommand cmdInitComboBox = new OleDbCommand(sqlCasierNombre, dbCon);
            cmdInitComboBox.ExecuteNonQuery();
            OleDbDataReader rdInitComboBox = cmdInitComboBox.ExecuteReader();
            while (rdInitComboBox.Read())
            {
                numCasier.Items.Add(rdInitComboBox.GetInt32(0));
            }
        }

        private void RetourButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void listCasierEmprunts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string titre = listCasierEmprunts.SelectedItem.ToString();
            string sqlimage = "SELECT POCHETTE FROM ALBUMS WHERE TITRE_ALBUM ='" + titre + "' and POCHETTE is not null";
            OleDbCommand cmdimage = new OleDbCommand(sqlimage, dbCon);
            cmdimage.ExecuteNonQuery();
            OleDbDataReader readerimage = cmdimage.ExecuteReader();
            if (readerimage.Read())
            {
                byte[] image = (byte[])readerimage[0];
                MemoryStream ms = new MemoryStream(image);
                imageAlbum.Image = new Bitmap(ms);
                imageAlbum.Image = Abonne_Accueil.resizeImage(imageAlbum.Image, new Size(200, 200));
            }
            else
            {

            }
            readerimage.Close();
        }
    }
}
