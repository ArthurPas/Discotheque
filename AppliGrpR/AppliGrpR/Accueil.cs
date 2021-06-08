using System;
using System.Windows.Forms;

namespace AppliGrpR
{
    public partial class Accueil : Form
    {
        public Accueil()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void inscription_Click(object sender, EventArgs e)
        {           
            Client_Inscription i = new Client_Inscription();      
            i.Show();
            this.Hide(); //Close() ne marche pas bien
            
        }

        private void connexion_user_Click(object sender, EventArgs e)
        {

        }

        private void connexion_admin_Click(object sender, EventArgs e)
        {

        }
    }
}
