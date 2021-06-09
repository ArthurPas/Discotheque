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
        public Albums(int c, string n)
        {
            id = c;
            titre = n;
        }
        public override string ToString()
        {
            return titre + "date de retour : " + dateRetour;
        }
        public int getID()
        {
            return id;
        }

        public string getTitre()
        {
            return titre;
        }
    }
}
