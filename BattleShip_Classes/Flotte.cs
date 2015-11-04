using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip_Classes
{
    class Flotte
    {
        public List<Bateau> flotte { get; private set; }
        
        public Flotte(List<Bateau> liste)
        {
            flotte = new List<Bateau>();
            flotte = liste;
        }

        public bool FlotteEstVivante()
        {
            bool estVivante = true;
            int bateauxCoules = 0;
            // Calcule le nombre de bateaux coulés
            for(int i = 0; i < flotte.Count; ++i)
            {
                if(!flotte[i].BateauEstVivant())
                {
                    bateauxCoules++;
                }
            }
            if(bateauxCoules == flotte.Count)
            {
                estVivante = false;
            }
            return estVivante;
        }
    }
}
