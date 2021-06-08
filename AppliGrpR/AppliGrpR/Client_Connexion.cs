using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliGrpR
{
    public partial class Client_Connexion : Form
    {
        public Client_Connexion()
        {
            InitializeComponent();
        }

   

        private void connexion_button_Click(object sender, EventArgs e)
        {

        }

        private void retour_button_Click(object sender, EventArgs e)
        {
            Accueil a = new Accueil();
            a.Show();
            this.Close();
        }
    }
}
