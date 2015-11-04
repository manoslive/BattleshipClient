using System;
using System.Collections.Generic;
using System.Drawing;

namespace BattleShip_Classes
{
    [Serializable]
    public class Bateau
    {
        public string _nom { get; private set; }
        public List<Point> _position = new List<Point>();
        public bool[] _estVivant { get; private set; }
        public int _taille { get; private set; }

        public Bateau(string nom, List<Point> position)
        {
            _nom = nom;
            _position = position;
            // On affecte la taille du bateau en considérant le nombre de coordonnées
            _taille = position.Count;
            // On affecte une booléenne par case du bateau
            _estVivant = new bool[_taille];

            // On met à true toutes les booléennes du bateau en question
            for (int i = 0; i < _taille; ++i)
            {
                _estVivant[i] = true;
            }
        }
        public bool BateauEstVivant()
        {
            int nombreCasesTouchees = 0;
            bool estVivant = true;
            for (int i = 0; i < _taille; ++i)
            {
                // Si la case a été touchée
                if (!_estVivant[i])
                {
                    nombreCasesTouchees++;
                }
            }
            if (nombreCasesTouchees == _taille)
            {
                estVivant = false;
            }
            return estVivant;
        }
    }
}
