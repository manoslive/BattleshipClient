using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip_Serveur
{
    static class Program
    {
        static Socket socketServeur;
        static Socket socketJ1;
        static Socket socketJ2;

        /// <summary>
        ///  Point d'entré de l'application
        /// </summary>
        static void Main(string[] args)
        {
            socketServeur = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketServeur.Bind(new IPEndPoint(0, 666));
            socketServeur.Listen(2);
            Console.WriteLine("Serveur en attente...");

            while (true)
            {
                // Connexion du J1
                if (socketJ1 == null)
                {
                    socketJ1 = socketServeur.Accept();
                }
                // Connexion du J2
                if (socketJ2 == null)
                {
                    socketJ2 = socketServeur.Accept();
                }
                // Si les 2 joueurs sont connectés
                if (SocketEstConnecte(socketJ1) && SocketEstConnecte(socketJ2))
                {
                    new PartieBattleShip(socketJ1, socketJ2).thread.Start();

                    Console.WriteLine("Partie démarre entre : " + (socketJ1.RemoteEndPoint as IPEndPoint).Address + " et " + (socketJ2.RemoteEndPoint as IPEndPoint).Address);
                    socketJ1 = null;
                    socketJ2 = null;
                }
                // Si le joueur 1 n'est pas connecté
                else if (!SocketEstConnecte(socketJ1))
                {
                    socketJ1 = null;
                }
                // Si le joueur 2 n'est pas connecté
                else
                {
                    socketJ2 = null;
                }
            }

        }

        public static bool SocketEstConnecte(Socket socket)
        {
            return !(socket.Poll(1000, SelectMode.SelectRead) && socket.Available == 0);
        }
    }
}
