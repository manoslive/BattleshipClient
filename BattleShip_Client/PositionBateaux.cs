using BattleShip_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip_Client
{
    public partial class PositionBateaux : Form
    {
        // Variables
        private int casesRestantes = 0;
        private bool basEstDisponible = true, hautEstDisponible = true, droiteEstDisponible = true, gaucheEstDisponible = true;
        private int direction = 3;
        private static Socket socket;
        DataGridViewCell derniereCellule;
        private IPEndPoint localEndPoint;
        private const string ip = "127.0.0.1";
        private const int port = 666;
        private List<Bateau> _bateaux = new List<Bateau>();
        private List<int> _positions = new List<int>();
        private Flotte flotte = null;

        // Nom des bateaux
        const string bateau1 = "Porte-Avions";
        const string bateau2 = "Croiseur";
        const string bateau3 = "Contre-Torpilleur";
        const string bateau4 = "Sous-Marin";
        const string bateau5 = "Torpilleur";

        public PositionBateaux()
        {
            InitializeComponent();
        }

        private void PositionBateaux_Load(object sender, EventArgs e)
        {
            remplirDgv(DGV_Choix);
            BTN_Jouer.Enabled = false;
        }
        private void remplirDgv(DataGridView dgv)
        {
            char lettre = 'A';
            dgv.RowHeadersWidth = 55;

            for (int i = 0; i < 10; i++)
            {
                if (dgv.Rows.Count != 0)
                {
                    dgv.Rows.Add("", "", "", "", "", "", "", "", "", "");

                    dgv.Rows[i].HeaderCell.Value = lettre.ToString();
                    lettre = (Char)(Convert.ToUInt16(lettre) + 1);
                }
            }
            dgv.AllowUserToAddRows = false;
        }
        private void SetJouerTrue()
        {
            if (RB_PorteAvion.Enabled == false
                && RB_Croiseur.Enabled == false
                && RB_CTorpilleur.Enabled == false
                && RB_SousMarin.Enabled == false
                && RB_Torpilleur.Enabled == false)
                BTN_Jouer.Enabled = true;
        }
        private void DGV_Choix_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RB_PorteAvion.Checked)
            {
                changerCell(e, "A");
                if (casesRestantes == 0)
                {
                    RB_PorteAvion.Enabled = false;
                    DGV_Choix.Enabled = false;
                    SetJouerTrue();
                }
            }

            if (RB_Croiseur.Checked)
            {
                changerCell(e, "B");
                if (casesRestantes == 0 && RB_Croiseur.Checked)
                {
                    RB_Croiseur.Enabled = false;
                    DGV_Choix.Enabled = false;
                    SetJouerTrue();
                }
            }
            if (RB_CTorpilleur.Checked)
            {
                changerCell(e, "C");
                if (casesRestantes == 0)
                {
                    RB_CTorpilleur.Enabled = false;
                    DGV_Choix.Enabled = false;
                    SetJouerTrue();
                }
            }
            if (RB_SousMarin.Checked)
            {
                changerCell(e, "D");
                if (casesRestantes == 0)
                {
                    RB_SousMarin.Enabled = false;
                    DGV_Choix.Enabled = false;
                    SetJouerTrue();
                }
            }
            if (RB_Torpilleur.Checked)
            {
                changerCell(e, "E");
                if (casesRestantes == 0)
                {
                    RB_Torpilleur.Enabled = false;
                    DGV_Choix.Enabled = false;
                    SetJouerTrue();
                }
            }
        }

        private void RB_PorteAvion_CheckedChanged(object sender, EventArgs e)
        {
            DGV_Choix.Enabled = true;
            casesRestantes = 5;
            TB_CasesRestantes.Text = casesRestantes.ToString();
        }

        private void RB_Croiseur_CheckedChanged(object sender, EventArgs e)
        {
            DGV_Choix.Enabled = true;
            casesRestantes = 4;
            TB_CasesRestantes.Text = casesRestantes.ToString();
        }

        private void RB_CTorpilleur_CheckedChanged(object sender, EventArgs e)
        {
            DGV_Choix.Enabled = true;
            casesRestantes = 3;
            TB_CasesRestantes.Text = casesRestantes.ToString();
        }

        private void RB_SousMarin_CheckedChanged(object sender, EventArgs e)
        {
            DGV_Choix.Enabled = true;
            casesRestantes = 3;
            TB_CasesRestantes.Text = casesRestantes.ToString();
        }
        private void DGV_Choix_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            SetAllDirectionsTrue();
            int rangee = e.RowIndex;
            int colonne = e.ColumnIndex;
            verifierPosibiliteOver(rangee, colonne);
            switch (direction)
            {
                case 0: //vers la droite
                    if (droiteEstDisponible)
                    {
                        if ((colonne + casesRestantes - 1) < 10 && colonne >= 0 && rangee >= 0)
                        {
                            for (int i = 0; i < (casesRestantes); i++)
                            {
                                DGV_Choix.Rows[rangee].Cells[colonne + i].Selected = true;
                            }
                        }
                    }
                    break;
                case 1:
                    if (basEstDisponible)
                    {
                        if ((rangee + casesRestantes - 1) < 10 && rangee >= 0 && colonne >= 0)
                        {
                            for (int i = 0; i < (casesRestantes); i++)
                            {
                                DGV_Choix.Rows[rangee + i].Cells[colonne].Selected = true;
                            }
                        }
                    }
                    break;
                case 2:
                    if (gaucheEstDisponible)
                    {
                        if ((colonne - (casesRestantes - 1)) >= 0 && rangee >= 0 && rangee < 10)
                        {
                            for (int i = 0; i < (casesRestantes); i++)
                            {
                                DGV_Choix.Rows[rangee].Cells[colonne - i].Selected = true;
                            }
                        }
                    }
                    break;
                case 3:
                    if (hautEstDisponible)
                    {
                        if ((rangee - (casesRestantes - 1)) >= 0 && colonne >= 0 && colonne < 10)
                        {
                            for (int i = 0; i < (casesRestantes); i++)
                            {
                                DGV_Choix.Rows[rangee - i].Cells[colonne].Selected = true;
                            }
                        }
                    }
                    break;
                default:
                    if (droiteEstDisponible)
                    {
                        if ((colonne + casesRestantes - 1) < 10 && rangee > 0)
                        {
                            for (int i = 0; i < (casesRestantes); i++)
                            {
                                DGV_Choix.Rows[rangee].Cells[colonne + i].Selected = true;
                            }
                        }
                    }
                    break;
            }
        }

        private void DGV_Choix_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            DGV_Choix.ClearSelection();
        }

        private void RB_Torpilleur_CheckedChanged(object sender, EventArgs e)
        {
            DGV_Choix.Enabled = true;
            casesRestantes = 2;
            TB_CasesRestantes.Text = casesRestantes.ToString();
        }

        private void PositionBateaux_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
            {
                if (direction < 3)
                    direction++;
                else
                    direction = 0;
            }
        }

        private void changerCell(DataGridViewCellEventArgs e, string marqueurBateau)
        {
            if (!DGV_Choix.CurrentCell.Value.Equals(marqueurBateau))
            {
                int rangee = e.RowIndex;
                int colonne = e.ColumnIndex;
                switch (direction)
                {
                    case 0: //vers la droite
                        if (droiteEstDisponible)
                        {
                            if ((colonne + casesRestantes - 1) < 10 && rangee >= 0)
                            {
                                for (int i = 0; i < (casesRestantes); i++)
                                {
                                    DGV_Choix.Rows[rangee].Cells[colonne + i].Value = marqueurBateau;
                                }
                                casesRestantes = 0;
                            }
                        }
                        break;
                    case 1:
                        if (basEstDisponible)
                        {
                            if ((rangee + casesRestantes - 1) < 10 && colonne >= 0)
                            {
                                for (int i = 0; i < (casesRestantes); i++)
                                {
                                    DGV_Choix.Rows[rangee + i].Cells[colonne].Value = marqueurBateau;
                                }
                                casesRestantes = 0;
                            }
                        }
                        break;
                    case 2:
                        if (gaucheEstDisponible)
                        {
                            if ((colonne - (casesRestantes - 1)) >= 0 && rangee < 10)
                            {
                                for (int i = 0; i < (casesRestantes); i++)
                                {
                                    DGV_Choix.Rows[rangee].Cells[colonne - i].Value = marqueurBateau;
                                }
                                casesRestantes = 0;
                            }
                        }
                        break;
                    case 3:
                        if (hautEstDisponible)
                        {
                            if ((rangee - (casesRestantes - 1)) >= 0 && colonne < 10)
                            {
                                for (int i = 0; i < (casesRestantes); i++)
                                {
                                    DGV_Choix.Rows[rangee - i].Cells[colonne].Value = marqueurBateau;
                                }
                                casesRestantes = 0;
                            }
                        }
                        break;
                    default:
                        if (droiteEstDisponible)
                        {
                            if ((colonne + casesRestantes - 1) < 10 && rangee > 0)
                            {
                                for (int i = 0; i < (casesRestantes); i++)
                                {
                                    DGV_Choix.Rows[rangee].Cells[colonne + i].Value = marqueurBateau;
                                }
                                casesRestantes = 0;
                            }
                        }
                        break;
                }
                //DGV_Choix.CurrentCell.Value = "X";
                /*for(int i=0; i< DGV_Choix.SelectedCells.Count; i++)
                {
                    DGV_Choix.SelectedCells[i].Value = "X";
                    casesRestantes--;
                }
                TB_CasesRestantes.Text = casesRestantes.ToString();*/
                //derniereCellule = DGV_Choix.CurrentCell;
            }
        }

        private void BTN_Jouer_Click(object sender, EventArgs e)
        {
            Connecter();
        }

        private void SetAllDirectionsTrue()
        {
            basEstDisponible = true;
            hautEstDisponible = true;
            droiteEstDisponible = true;
            gaucheEstDisponible = true;
        }
        private void verifierPosibiliteOver(int rangee, int colonne)
        {
            for (int i = 0; i < casesRestantes; i++)
            {
                if (rangee + i < 10 && rangee >= 0 && colonne >= 0)
                {
                    if (!DGV_Choix.Rows[rangee + i].Cells[colonne].Value.Equals("")) // Vers le bas
                        basEstDisponible = false;
                }
                if (rangee - i > 0 && colonne >= 0)
                {
                    if (!DGV_Choix.Rows[rangee - i].Cells[colonne].Value.Equals("")) // Vers le haut
                        hautEstDisponible = false;
                }
                if (colonne + i < 10 && colonne >= 0 && rangee >= 0)
                {
                    if (!DGV_Choix.Rows[rangee].Cells[colonne + i].Value.Equals("")) // Vers la droite
                        droiteEstDisponible = false;
                }
                if (colonne - i > 0 && rangee >= 0)
                {
                    if (!DGV_Choix.Rows[rangee].Cells[colonne - i].Value.Equals("")) // Vers la gauche
                        gaucheEstDisponible = false;
                }
            }
        }
        private void verifierPosibilite(DataGridViewCell cell)
        {
            int rangee = cell.RowIndex;
            int colonne = cell.ColumnIndex;

            for (int i = 1; i < casesRestantes; i++)
            {
                if (!DGV_Choix.Rows[rangee + i].Cells[colonne].Value.Equals("")) // Vers le bas
                {
                    basEstDisponible = false;
                }
                if (!DGV_Choix.Rows[rangee - i].Cells[colonne].Value.Equals("")) // Vers le haut
                {
                    hautEstDisponible = false;
                }
                if (!DGV_Choix.Rows[rangee].Cells[colonne + i].Value.Equals("")) // Vers la droite
                {
                    droiteEstDisponible = false;
                }
                if (!DGV_Choix.Rows[rangee].Cells[colonne - i].Value.Equals("")) // Vers la gauche
                {
                    gaucheEstDisponible = false;
                }
            }
        }
        private void Connecter()
        {
            try
            {
                // On rempli la flotte avec les informations du DataGridView
                RemplirFlotte();
                // On défini le socket
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // On affecte l'ip et le port au IPEndPoint
                localEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
                // Connection du joueur au socket
                socket.Connect(localEndPoint);
                // On envoie la flotte au serveur
                EnvoyerFlotte();
                // On démarre la partie
                DemarrerPartie();

            }
            catch (SocketException e)
            {
                MessageBox.Show("Erreur de connexion: " + e.Message.ToString(), "Erreur", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                this.Close(); //to turn off current app
            }
        }
        private void EnvoyerFlotte()
        {
            // Création du tableau de bytes
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            // On encrypte la flotte
            using (var stream = new MemoryStream())
            {
                // On sérialise la flotte
                binaryFormatter.Serialize(stream, flotte);
                // On envoie la flotte
                socket.Send(stream.ToArray());
            }
        }
        private void DemarrerPartie()
        {
            TableauAttaque partie = new TableauAttaque(DGV_Choix);
            partie.ShowDialog();
            
        }
        private void RemplirFlotte()
        {
            List<Point> positionsA = new List<Point>();
            List<Point> positionsB = new List<Point>();
            List<Point> positionsC = new List<Point>();
            List<Point> positionsD = new List<Point>();
            List<Point> positionsE = new List<Point>();

            var nombreTotalCases = DGV_Choix.ColumnCount * DGV_Choix.RowCount;

            for (int i = 0; i < DGV_Choix.RowCount; i++)
            {
                for (int j = 0; j < DGV_Choix.ColumnCount; j++)
                {
                    switch (DGV_Choix.Rows[i].Cells[j].Value.ToString())
                    {
                        case "A":
                            positionsA.Add(new Point(DGV_Choix.Rows[i].Cells[j].RowIndex, DGV_Choix.Rows[i].Cells[j].ColumnIndex));
                            break;
                        case "B":
                            positionsB.Add(new Point(DGV_Choix.Rows[i].Cells[j].RowIndex, DGV_Choix.Rows[i].Cells[j].ColumnIndex));
                            break;
                        case "C":
                            positionsC.Add(new Point(DGV_Choix.Rows[i].Cells[j].RowIndex, DGV_Choix.Rows[i].Cells[j].ColumnIndex));
                            break;
                        case "D":
                            positionsD.Add(new Point(DGV_Choix.Rows[i].Cells[j].RowIndex, DGV_Choix.Rows[i].Cells[j].ColumnIndex));
                            break;
                        case "E":
                            positionsE.Add(new Point(DGV_Choix.Rows[i].Cells[j].RowIndex, DGV_Choix.Rows[i].Cells[j].ColumnIndex));
                            break;
                    }
                }
            }
            _bateaux.Add(new Bateau(bateau1, positionsA));
            _bateaux.Add(new Bateau(bateau2, positionsB));
            _bateaux.Add(new Bateau(bateau3, positionsC));
            _bateaux.Add(new Bateau(bateau4, positionsD));
            _bateaux.Add(new Bateau(bateau5, positionsE));
            flotte = new Flotte(_bateaux);
        }
    }
}
