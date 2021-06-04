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
        }

        public void AddAbonnes()
        {

            string consult = "Select * from ABONNÉS WHERE NOM_ABONNÉ = '"+textBox2.Text+ "' and PRÉNOM_ABONNÉ ='"+textBox3.Text+"'";
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
            Console.WriteLine(name + firstName +" a prolongé son emprunt");
        }

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

    private void ListButton_MouseDown(object sender, MouseEventArgs e)
    {
        ListExtended();

    }
}
}
