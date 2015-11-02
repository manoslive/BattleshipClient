using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShip_Serveur
{
    class PartieBattleShip
    {
        public Thread thread;
        Socket joueur1;
        Socket joueur2;
        string[] tabJ1;
        string[] tabJ2;

        /// <summary>
        ///  Constructeur paramétrique
        /// </summary>
        /// <param name="socketJ1"></param>
        /// <param name="socketJ2"></param>
        public PartieBattleShip(Socket socketJ1, Socket socketJ2)
        {
            thread = new Thread(new ThreadStart(Run));
            joueur1 = socketJ1;
            joueur2 = socketJ2;
        }

        /// <summary>
        /// Fonction principale pour jouer
        /// </summary>
        public void Run()
        {
            try
            {
                // Recoit la position des bateaux de chaque joueur et l'affecte à une variable globale
                tabJ1 = recevoirPositionBateaux(joueur1);
                tabJ2 = recevoirPositionBateaux(joueur2);

                // Envoie de l'ordre de jeu des joueurs ainsi que l'ip de son opposant
                envoyerReponse("1 " + (joueur2.RemoteEndPoint as IPEndPoint).Address, joueur1);
                envoyerReponse("2 " + (joueur1.RemoteEndPoint as IPEndPoint).Address, joueur2);

                // Boucle du jeu
                while (BattleShip_Serveur.Program.SocketEstConnecte(joueur1) && BattleShip_Serveur.Program.SocketEstConnecte(joueur2))
                {
                    envoyerReponse(analyserAttaque(recevoirAttaque(joueur1)), joueur1);
                    if (verifierSiBateauxRestants(joueur2))
                    {
                        envoyerReponse(analyserAttaque(recevoirAttaque(joueur2)), joueur2);
                    }
                }
                // lorsque la partie est terminée, on termine la connection
                joueur1.Close();
                joueur2.Close();
            }
            catch (Exception e)
            {

            }
        }

        /// <summary>
        /// Envoie de la réponse à un joueur en particulier
        /// </summary>
        /// <param name="reponse"></param>
        /// <param name="socket"></param>
        private void envoyerReponse(string reponse, Socket socket)
        {
            byte[] data = Encoding.ASCII.GetBytes(reponse);
            socket.Send(data);
        }

        /// <summary>
        /// Envoie de la réponse aux 2 joueurs
        /// </summary>
        /// <param name="reponse"></param>
        private void envoyerReponse(string reponse)
        {
            byte[] dataJ1;
            byte[] dataJ2;

            dataJ1 = Encoding.ASCII.GetBytes(reponse);
            dataJ2 = Encoding.ASCII.GetBytes(reponse);

            joueur1.Send(dataJ1);
            joueur2.Send(dataJ2);
        }

        /// <summary>
        /// Analyse de la string d'attaque
        /// </summary>
        /// <param name="attaque"></param>
        /// <param name="joueur"></param>
        /// <returns></returns>
        private string analyserAttaque(string attaque, Socket joueur)
        {
            string[] tabAttaque = attaque.Split(' ');
            // devra comparer le tableau d'attaque et le tab initial
            for (int i = 0; i < tabAttaque.Count(); i++)
            {
                if (tabAttaque[i].Equals('X'))
                {
                    if (joueur == joueur1)
                    {
                        if (tabJ1[i].Equals('A') || tabJ1[i].Equals('B') || tabJ1[i].Equals('C') || tabJ1[i].Equals('D') || tabJ1[i].Equals('E'))
                        {

                        }
                    }
                    else if (joueur == joueur2)
                    {

                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Recoit le byte[] du joueur reçu en paramètre, 
        /// le formatte et le transforme en string.
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>
        private string recevoirAttaque(Socket joueur)
        {
            string attaque;
            byte[] buffer = new byte[joueur.SendBufferSize];
            int byteLecture = joueur.Receive(buffer);
            byte[] byteFormatter = new byte[byteLecture];

            for (int i = 0; i < byteLecture; ++i)
            {
                byteFormatter[i] = buffer[i];
            }

            attaque = Encoding.ASCII.GetString(byteFormatter);
            return attaque;
        }

        /// <summary>
        /// Recoit la position des bateaux, la convertie en string, la sépare
        /// et l'affecte au tableau du joueur correspondant
        /// correspondant
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>
        private string[] recevoirPositionBateaux(Socket joueur)
        {
            string stringJoueur;
            byte[] buffer = new byte[joueur.SendBufferSize];
            int byteLecture = joueur.Receive(buffer);
            byte[] byteFormatter = new byte[byteLecture];

            for (int i = 0; i < byteLecture; ++i)
            {
                byteFormatter[i] = buffer[i];
            }
            stringJoueur = Encoding.ASCII.GetString(byteFormatter);
            string[] tabStringJoueur = stringJoueur.Split(' ');
            return tabStringJoueur;
        }

        /// <summary>
        /// Parcourt le tableau pour vérifier s'il contient des bateaux non coulés
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>
        private bool verifierSiBateauxRestants(Socket joueur)
        {
            bool aBateauxRestants = true;
            if (joueur == joueur1)
            {
                foreach (string element in tabJ1)
                {
                    if (element.Contains('X') || element.Contains('0'))
                    {
                        aBateauxRestants = true;
                    }
                    else
                    {
                        aBateauxRestants = false;
                    }
                }
            }
            else if (joueur == joueur2)
            {
                foreach (string element in tabJ2)
                {
                    if (element.Contains('X') || element.Contains('0'))
                    {
                        aBateauxRestants = true;
                    }
                    else
                    {
                        aBateauxRestants = false;
                    }
                }
            }
            return aBateauxRestants;
        }
    }
}
