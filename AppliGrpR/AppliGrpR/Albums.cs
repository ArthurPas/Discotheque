using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliGrpR
{
    class Albums
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
        public override string ToString()
        {
            return titre + "date de retour : " +dateRetour;
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
