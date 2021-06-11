using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliGrpR
{
    public class Albums
    {
        int id;
        public string titre;
        DateTime dateRetour;

        public Albums(int c, string n, DateTime d)
        {
            id = c;
            titre = n;
            dateRetour = d;
        }

        /// <summary>
        /// Constructeur de l'objet album
        /// </summary>
        /// <param name="c">l'id de l'album</param>
        /// <param name="n">nom l'album</param>
        public Albums(int c, string n)
        {
            id = c;
            titre = n;
        }

        /// <summary>
        /// Permet d'afficher le nom et la date de retour de l'album
        /// </summary>
        /// <returns>le nom et la date de retour de l'album</returns>
        public override string ToString()
        {
            return titre + "              ==> date de retour : " + dateRetour;
        }

        /// <summary>
        /// Permet d'avoir le code d'un album
        /// </summary>
        /// <returns>le code d'un album</returns>
        public int getID()
        {
            return id;
        }

        /// <summary>
        /// Permet davoir le titre d'un album
        /// </summary>
        /// <returns>le titre d'un album</returns>
        public string getTitre()
        {
            return titre;
        }
    }
}
