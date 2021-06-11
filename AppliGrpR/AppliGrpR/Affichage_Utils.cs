using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliGrpR
{
    static class Affichage_Utils
    {
        /// <summary>
        /// Affiche les élements de liste par page
        /// </summary>
        /// <param name="index">index de la page</param>
        /// <param name="listBox">nom de la ListBox</param>
        /// <param name="list">la list</param>
        /// <param name="taille">taille de la list</param>
        /// <param name="direction">attribut qui permet de changer de page</param>
        /// <param name="label">affiche le numéro de la page actuelle</param>
        static public void Paginer(ref int index, ListBox listBox, List<string> list, Label label, int taille, int direction)
        {

            if (direction == 1)
            {
                if (index < getIindexedMax(index, list, taille))
                    index++;
            }
            if(direction == -1)
            {
                if (index > 1)
                    index--;
            }
            if(direction == 0)
            {
                index = 1;
            }

            AfficherPagination(index, listBox, list, label, taille);
        }

        /// <summary>
        /// Permet d'afficher page par page
        /// </summary>
        /// <param name="index">index de la page</param>
        /// <param name="listBox">nom de la ListBox</param>
        /// <param name="list">la list</param>
        /// <param name="label">affiche le numéro de la page actuelle</param>
        /// <param name="taille">taille de la list</param>
        static public void AfficherPagination(int index, ListBox listBox, List<string> list, Label label, int taille)
        {
            listBox.Items.Clear();
            for (int i = taille * index - taille; i < taille * index; i++)
            {
                if (i < list.Count)
                {
                    listBox.Items.Add(list[i]);
                }
            }
            label.Text = index.ToString() + "/" + getIindexedMax(index, list, taille);

        }

        /// <summary>
        /// Nombres de pages max
        /// </summary>
        /// <param name="index">index que l'on cherche</param>
        /// <param name="list">la List</param>
        /// <param name="taille">taille de la List</param>
        /// <returns></returns>
        static public double getIindexedMax(int index, List<string> list, int taille)
        {

            float l = list.Count;
            float t = taille;
            if (l > 0)
            {
                return Math.Ceiling(l / t);
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// Permet de changer de page
        /// </summary>
        /// <param name="index">index que l'on cherche</param>
        /// <param name="listBox">nom de la ListBox</param>
        /// <param name="list">la List</param>
        /// <param name="taille">taille de la List</param>
        /// <param name="direction">attribut qui permet de changer de page</param>
        /// <param name="label">affiche le numéro de la page actuelle</param>
        static public void PaginerAvecAlbum(ref int index, ListBox listBox, List<Albums> list, Label label, int taille, int direction)
        {

            if (direction == 1)
            {
                if (index < getIindexedMaxAlbum(index, list, taille))
                    index++;
            }
            if (direction == -1)
            {
                if (index > 1)
                    index--;
            }
            if (direction == 0)
            {
                index = 1;
            }
            AfficherPaginationAvecAlbum(index, listBox, list, label, taille);
        }

        /// <summary>
        /// Permet d'afficher page par page
        /// </summary>
        /// <param name="index">index que l'on cherche</param>
        /// <param name="listBox">nom de la ListBox</param>
        /// <param name="list">la List</param>
        /// <param name="taille">taille de la List</param>
        /// <param name="label">affiche le numéro de la page actuelle</param>
        static public void AfficherPaginationAvecAlbum(int index, ListBox listBox, List<Albums> list, Label label, int taille)
        {
            listBox.Items.Clear();
            for (int i = taille * index - taille; i < taille * index; i++)
            {
                if (i < list.Count)
                {
                    listBox.Items.Add(list[i]);
                }
            }

            label.Text = index.ToString() + "/" + getIindexedMaxAlbum(index, list, taille);

        }

        /// <summary>
        /// Nombres de pages max
        /// </summary>
        /// <param name="index">index que l'on cherche</param>
        /// <param name="list">la List</param>
        /// <param name="taille">taille de la List</param>
        /// <returns></returns>
        static public double getIindexedMaxAlbum(int index, List<Albums> list, int taille)
        {
            float l = list.Count;
            float t = taille;
            if (l > 0)
            {
                return Math.Ceiling(l / t);
            }
            else
            {
                return 1;
            }
        }
    }
}
