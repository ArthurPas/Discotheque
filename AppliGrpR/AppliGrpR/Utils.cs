using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliGrpR
{
    public static class Utils
    {
        /// <summary>
        /// permet de doubler tout les apostrophes
        /// </summary>
        /// <param name="titre">titre du string en paramètre</param>
        /// <returns>le titre avec les apostrophes doublés</returns>
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
