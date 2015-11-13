using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShip_Classes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing;

namespace BattleShip_Serveur
{
    class PartieBattleShip
    {
        public Thread thread;
        Socket joueur1;
        Socket joueur2;
        Flotte flotteJ1 = null;
        Flotte flotteJ2 = null;
        bool _nouvellePartie = true;
        bool _joueur1NouvellePartie = false;

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
        /// dans le cas d'une victoire d'un des 2 joueurs
        /// </summary>
        /// <param name="reponse"></param>
        private void envoyerReponse(string reponse)
        {
            byte[] dataJ1;
            byte[] dataJ2;

            // Si le joueur1 a gagné on envoie les réponses correspondante
            if(flotteJ1.FlotteEstVivante() && !flotteJ2.FlotteEstVivante())
            {
                dataJ1 = Encoding.ASCII.GetBytes(reponse + " 1");
                dataJ2 = Encoding.ASCII.GetBytes(reponse + " 0");
                Console.WriteLine("Le joueur1 (" + (joueur1.RemoteEndPoint as IPEndPoint).Address.ToString() + ") a gagné la partie");
            }

            // Si le joueur2 a gagné on envoie les réponses correspondante
            else if(flotteJ2.FlotteEstVivante() && !flotteJ1.FlotteEstVivante())
            {
                dataJ1 = Encoding.ASCII.GetBytes(reponse + " 0");
                dataJ2 = Encoding.ASCII.GetBytes(reponse + " 1");
                Console.WriteLine("Le joueur2 (" + (joueur2.RemoteEndPoint as IPEndPoint).Address.ToString() + ") a gagné la partie");
            }

            else
            {
                dataJ1 = Encoding.ASCII.GetBytes(reponse);
                dataJ2 = Encoding.ASCII.GetBytes(reponse);
            }

            // Envoie des l'information
            joueur1.Send(dataJ1);
            joueur2.Send(dataJ2);
        }

        /// <summary>
        /// Analyse de la string d'attaque
        /// </summary>
        /// <param name="attaque"></param>
        /// <param name="listeBateau"></param>
        /// <returns></returns>
        private string analyserAttaque(string attaque, List<Bateau> listeBateau)
        {
            string[] tabAttaque = attaque.Split(' '); //chiffre lettre (X,Y)
            Point coordonnee = new Point(Int32.Parse(tabAttaque[1]), Int32.Parse(tabAttaque[0])); //switch du x,y car il a un switch up du x,y dans _position.Contains(coordonné)
            bool bateauToucher = false;
            for(int i = 0; i < listeBateau.Count && !bateauToucher; ++i)
            {
                // Si un bateau de la liste contient la coordonnée
                if(listeBateau[i]._position.Contains(coordonnee))
                {
                    bool rechercheTerminer = false;
                    for(int j = 0; j < listeBateau[i]._estVivant.Length && !rechercheTerminer; ++j)
                    {
                        // Si la case du bateau n'est pas touchée
                        if(listeBateau[i]._estVivant[j])
                        {
                            listeBateau[i]._estVivant[j] = false;
                            rechercheTerminer = true;
                            // Si le bateau est coulé
                            if(!listeBateau[i].BateauEstVivant())
                            {
                                bateauToucher = !bateauToucher;
                                // Le format de retour : (true/false) si le bateau est touché + " " + les_coordonnées_d'attaque + " " + le nom du bateau coulé
                                return bateauToucher.ToString() + " " + tabAttaque[0] + " " + tabAttaque[1] + " " + listeBateau[i]._nom;
                            }
                        }
                    }
                    bateauToucher = !bateauToucher;
                }
            }
            // Format de retour : (true/false) si le bateau est touché + " " + les_coordonnées_d'attaque
            return bateauToucher.ToString() + " " + tabAttaque[0] + " " + tabAttaque[1];
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
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>
        private Flotte recevoirPositionBateaux(Socket joueur)
        {
            Flotte flotte = null;
            byte[] buffer = new byte[joueur.SendBufferSize];
            int byteLecture = joueur.Receive(buffer);
            byte[] byteFormatter = new byte[byteLecture];

            for (int i = 0; i < byteLecture; ++i)
            {
                byteFormatter[i] = buffer[i];
            }
            // Désérialisation du byte[] en Flotte
            BinaryFormatter recevoir = new BinaryFormatter();
            using (var stream = new MemoryStream(byteFormatter))
            {
                flotte = recevoir.Deserialize(stream) as Flotte;
            }
            return flotte;
        }

        /// <summary>
        /// Fonction principale pour jouer
        /// </summary>
        public void Run()
        {
            try
            {
                if (_nouvellePartie)
                {
                    // Envoie au 2 joueurs que les 2 sont connectés pour pouvoir poursuivre avec le jeux
                    envoyerReponse("Joueur 1 et Joueur 2 connectés", joueur1);
                    envoyerReponse("Joueur 1 et Joueur 2 connectés", joueur2);
                }
                // Recoit la position des bateaux de chaque joueur et l'affecte à une variable globale
                flotteJ1 = recevoirPositionBateaux(joueur1);
                flotteJ2 = recevoirPositionBateaux(joueur2);

                // Envoie de l'ordre de jeu des joueurs ainsi que l'ip de son opposant
                envoyerReponse("1 " + (joueur2.RemoteEndPoint as IPEndPoint).Address, joueur1);
                envoyerReponse("2 " + (joueur1.RemoteEndPoint as IPEndPoint).Address, joueur2);

                // Boucle du jeu
                while (joueur1.Poll(1000, SelectMode.SelectError) && joueur2.Poll(1000, SelectMode.SelectError))
                {
                    while (flotteJ1.FlotteEstVivante() && flotteJ2.FlotteEstVivante() && BattleShip_Serveur.Program.SocketEstConnecte(joueur1) && BattleShip_Serveur.Program.SocketEstConnecte(joueur2))
                    {
                        envoyerReponse(analyserAttaque(recevoirAttaque(joueur1), flotteJ2.flotte));
                        if (flotteJ2.FlotteEstVivante())
                        {
                            envoyerReponse(analyserAttaque(recevoirAttaque(joueur2), flotteJ1.flotte));
                        }
                    }
                    if (estNouvellePartie(joueur1))
                    {
                        _joueur1NouvellePartie = true;
                    }
                    if (_joueur1NouvellePartie && estNouvellePartie(joueur2))
                    {
                        _nouvellePartie = false;
                        Run();
                    }
                    else
                    {
                        if (!_joueur1NouvellePartie)
                        {
                            envoyerReponse("Joueur 1 s'est déconnecté", joueur2);
                        }
                        else
                        {
                            envoyerReponse("Joueur 2 s'est déconnecté", joueur1);
                        }
                        // lorsque la partie est terminée, on termine la connection
                        Console.WriteLine("Le joueur1 (" + (joueur1.RemoteEndPoint as IPEndPoint).Address.ToString() + ") est déconnecté");
                        joueur1.Close();
                        Console.WriteLine("Le joueur2 (" + (joueur2.RemoteEndPoint as IPEndPoint).Address.ToString() + ") est déconnecté");
                        joueur2.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Reçoit une réponse d'un joueur pour vérifier s'il veut faire une nouvelle game
        /// </summary>
        /// <param name="joueur"></param>
        /// <returns></returns>
        private bool estNouvellePartie(Socket joueur)
        {
            bool nouvellePartie = false;
            string reponse = "";
            byte[] buffer = new byte[joueur.SendBufferSize];
            int byteLecture = joueur.Receive(buffer);
            byte[] byteFormatter = new byte[byteLecture];

            for (int i = 0; i < byteLecture; ++i)
            {
                byteFormatter[i] = buffer[i];
            }
            
            reponse = Encoding.ASCII.GetString(byteFormatter);
            if (reponse.Equals("NouvellePartie"))
                nouvellePartie = true;

            return nouvellePartie;
        }
    }
}
