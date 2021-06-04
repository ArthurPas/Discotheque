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
        string titre;
        int annee;

        public Albums(int c, string n, int p)
        {
            id = c;
            titre = n;
            annee = p;
        }
        public override string ToString()
        {
            return titre + " " + annee;
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
