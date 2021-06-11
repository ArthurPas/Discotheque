using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliGrpR
{
    static class Utils
    {
        public static string manageSingleQuote(string titre)
        {
            string apostrophe = "'";
            int i = 0;
            while (i < titre.Length)
            {
                if (titre[i] == apostrophe[0])
                {
                    titre = titre.Insert(i, apostrophe);
                    i++;

                }
                i++;
            }
            return titre;
        }
    }
}
