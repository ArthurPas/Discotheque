using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AppliGrpR
{
    public partial class Accueil : Form
    {
        public static OleDbConnection dbCon;
        public Accueil()
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
        }


        private void inscription_Click(object sender, EventArgs e)
        {           
            Client_Inscription i = new Client_Inscription();      
            i.Show();
            this.Hide(); 
            
        }

        private void connexion_user_Click(object sender, EventArgs e)
        {
            Abonne_Connexion c = new Abonne_Connexion();
            c.Show();
            this.Hide();
        }

        private void connexion_admin_Click(object sender, EventArgs e)
        {
            Administrateur_Connexion a = new Administrateur_Connexion();
            a.Show();
            this.Hide();
        }

        private void quitter_MouseDown(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
