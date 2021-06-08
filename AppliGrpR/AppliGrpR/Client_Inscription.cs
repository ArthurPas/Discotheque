﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AppliGrpR
{
    public partial class Client_Inscription : Form
    {
        OleDbConnection dbCon;
        List<string> nationalités = new List<string>();

        public Client_Inscription()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
            string ChaineBd = "Provider=SQLOLEDB;Data Source=INFO-DORMEUR;Initial Catalog=MusiquePT2_R;Integrated Security=SSPI;";
            dbCon = new OleDbConnection(ChaineBd);
            dbCon.Open();
            Nationalite();
            disableAllErrorMessage();
        }


        /// <summary>
        /// Ajoute un Abonné à la Base depuis les valeurs récupéré dans les textBox
        /// </summary>

        public void AddAbonnes()
        {
            bool valide = true;

            string consult = "Select * from ABONNÉS WHERE LOGIN_ABONNÉ = '" + id_box.Text + "'";
            OleDbCommand cmdConsult = new OleDbCommand(consult, dbCon);
            OleDbDataReader reader = cmdConsult.ExecuteReader();

            disableAllErrorMessage();
            valide = manageErrorMessage();

            if (valide)
            {
                if (!reader.HasRows)
                {
                    string insert = "insert into ABONNÉS(CODE_PAYS,NOM_ABONNÉ,PRÉNOM_ABONNÉ,LOGIN_ABONNÉ,PASSWORD_ABONNÉ) values(?,?,?,?,?)";
                    OleDbCommand cmd = new OleDbCommand(insert, dbCon);

                    cmd.Parameters.Add("CODE_PAYS", OleDbType.Integer).Value = getCodePaysFromNationalite(nationalité_comboBox.Text);
                    cmd.Parameters.Add("NOM_ABONNÉ", OleDbType.VarChar).Value = nom_box.Text;
                    cmd.Parameters.Add("PRÉNOM_ABONNÉ", OleDbType.VarChar).Value = prénom_box.Text;
                    cmd.Parameters.Add("LOGIN_ABONNÉ", OleDbType.VarChar).Value = id_box.Text;
                    cmd.Parameters.Add("PASSWORD_ABONNÉ", OleDbType.VarChar).Value = mdp_box.Text;
                    cmd.ExecuteNonQuery();


                    Client_Insciption_Complete c = new Client_Insciption_Complete(nom_box.Text, prénom_box.Text, id_box.Text);
                    c.Show();
                  
                    this.Close();

                    nationalité_comboBox.Text = "";
                    nom_box.Text = "";
                    prénom_box.Text = "";
                    id_box.Text = "";
                    mdp_box.Text = "";

                }
                else
                {
                    MessageBox.Show("Erreur un compte existe déja avec le même identifiant");
                }
            }
            
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
            }
            reader.Close();

            foreach(string s in nationalités)
            {
                nationalité_comboBox.Items.Add(s);
            }
        }

        /// <summary>
        /// Renvoie le code Pays a partir du nom d'un pays
        /// </summary>
        /// <param name="pays"></param>
        /// <returns></returns>
        private string getCodePaysFromNationalite(string pays)
        {
            string sql = "select * from PAYS WHERE NOM_PAYS ='" + pays + "'";
            OleDbCommand cmdRead = new OleDbCommand(sql, dbCon);
            OleDbDataReader reader = cmdRead.ExecuteReader();

            int code = 0; ;
            while (reader.Read())
            {
                code = reader.GetInt32(0);
            }
            reader.Close();
            return code.ToString();
        }

        /// <summary>
        ///  Désactive to les messages d'erreurs que l'on affichera indépendament si nécessaire
        /// </summary>
        void disableAllErrorMessage()
        {
            foreach (Label l in Controls.OfType<Label>())
            {
                if (l.Tag != null)
                {
                    if (l.Tag.ToString() == "erreur")
                    {
                        l.Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Affiche si nécessaire les messages d'erreur des champs
        /// </summary>
        /// <returns> Renvoie si l'inscription est possible ou non</returns>
        private bool manageErrorMessage()
        {
            bool valide = true;
            if (nom_box.Text == "")
            {
                valide = false;
                erreur_nom.Visible = true;

            }
            if (prénom_box.Text == "")
            {
                valide = false;
                erreur_prénom.Visible = true;
            }
            if (id_box.Text == "")
            {
                valide = false;
                erreur_id.Visible = true;
            }
            if (mdp_box.Text == "")
            {
                valide = false;
                erreur_mdp.Visible = true;
            }
            if (nationalité_comboBox.Text == "")
            {
                valide = false;
                erreur_nationalité.Visible = true;                     
            }
            return valide;
        }

        private void inscription_Click(object sender, EventArgs e)
        {
            AddAbonnes();
            
        }

        private void retour_button_Click(object sender, EventArgs e)
        {
            Accueil a = new Accueil();
            a.Show();
            this.Close();
        }

    }
}
