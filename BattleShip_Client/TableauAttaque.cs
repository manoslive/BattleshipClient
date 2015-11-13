using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip_Client
{
    public partial class TableauAttaque : Form
    {
        private static Socket socket;
        private bool _monTour = false;
        private bool _cibleSelectionnee = false;
        Color orgStyle = Color.Empty;
        public TableauAttaque(Socket org_socket, DataGridView mesBateaux)
        {
            InitializeComponent();
            //Copie ton DGV PositionBateaux au nouveau DGV
            CopyDataGridView(mesBateaux, DGV_Perso);
            //Retien mon socket de PositionBateaux
            socket = org_socket;
            Thread threadConnectionJoueur = new Thread(RecevoirOrdre);
            threadConnectionJoueur.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RendreToutVisible(false);
            remplirDgv(DGV_Attaque);
        }
        private void RendreToutVisible(bool b)
        {
            LB_Demarrer.Visible = !b;
            BTN_Demarrer.Visible = !b;

            DGV_Attaque.Visible = b;
            DGV_Perso.Visible = b;
            label1.Visible = b;
            LB_GrilleAttaque.Visible = b;
            LB_GrillePerso.Visible = b;
            BTN_Attaquer.Visible = b;
            LB_MsgAttaque.Visible = b;
            panel1.Visible = b;

            DGV_Attaque.ClearSelection();
            DGV_Perso.ClearSelection();
        }
        // Reçoit le message d'ordre de passage
        private void RecevoirOrdre()
        {
            string reponse;
            byte[] buffer = new byte[socket.SendBufferSize];
            int byteLecture = socket.Receive(buffer);
            byte[] byteFormatter = new byte[byteLecture];

            for (int i = 0; i < byteLecture; ++i)
            {
                byteFormatter[i] = buffer[i];
            }

            reponse = Encoding.ASCII.GetString(byteFormatter);
            string[] tabreponse = reponse.Split(' ');
            if (tabreponse[0] == "1")
            {
                if (LB_Demarrer.InvokeRequired)//pour exécuter un délégué qui met à jour le thread d'interface utilisateur
                {
                    Action act = () => LB_Demarrer.Text = ("Vous êtes premier et votre adversaire est: " + tabreponse[1].ToString());
                    LB_Demarrer.Invoke(act);
                    Action act2 = () => BTN_Attaquer.Enabled = true;
                    BTN_Attaquer.Invoke(act2);
                }
                else
                {
                    LB_Demarrer.Text = ("Vous êtes premier et votre adversaire est: " + tabreponse[1].ToString());
                    BTN_Attaquer.Enabled = true;
                }
                _monTour = true;
            }
            else
            {
                if (LB_Demarrer.InvokeRequired)//pour exécuter un délégué qui met à jour le thread d'interface utilisateur
                {
                    Action act = () => LB_Demarrer.Text = ("Vous êtes deuxième et votre adversaire est: " + tabreponse[1].ToString());
                    LB_Demarrer.Invoke(act);
                    Action act2 = () => BTN_Attaquer.Enabled = false;
                    BTN_Attaquer.Invoke(act2);
                    _monTour = false;
                }
                else
                {
                    LB_Demarrer.Text = ("Vous êtes deuxième et votre adversaire est: " + tabreponse[1].ToString());
                    BTN_Attaquer.Enabled = false;
                    _monTour = false;
                }
            }
            if (BTN_Demarrer.InvokeRequired)//pour exécuter un délégué qui met à jour le thread d'interface utilisateur
            {
                Action act3 = () => BTN_Demarrer.Enabled = true;
                BTN_Demarrer.Invoke(act3);
            }
            else
                BTN_Demarrer.Enabled = true;
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

        private void CopyDataGridView(DataGridView dgv_org, DataGridView dgv_new)
        {
            //Pour chaque rangéé du dgv original
            for (int i = 0; i < dgv_org.RowCount; i++)
            {
                //Clone la rangée 
                DataGridViewRow row = dgv_org.Rows[i];
                DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
                for (Int32 index = 0; index < row.Cells.Count; index++)
                {
                    clonedRow.Cells[index].Value = row.Cells[index].Value;//Copie la value de chaque cell
                }
                dgv_new.Rows.Add(clonedRow);//Ajoute la rangée cloné dans le nouveau dgv
            }
            DGV_Perso.ClearSelection();
        }
        //Reçoit le résultat de son coup
        private void RecevoirReponse()
        {
            DataGridViewCellStyle toucheStyle = new DataGridViewCellStyle();
            toucheStyle.BackColor = Color.Red;
            toucheStyle.ForeColor = Color.Red;
            DataGridViewCellStyle manqueStyle = new DataGridViewCellStyle();
            manqueStyle.BackColor = Color.Blue;
            manqueStyle.ForeColor = Color.Blue;
            DialogResult dialogResult;
            string reponse;
            byte[] buffer = new byte[socket.SendBufferSize];
            int byteLecture = socket.Receive(buffer);
            byte[] byteFormatter = new byte[byteLecture];

            for (int i = 0; i < byteLecture; ++i)
            {
                byteFormatter[i] = buffer[i];
            }

            reponse = Encoding.ASCII.GetString(byteFormatter);

            string[] tabreponse = reponse.Split(' ');

            //Si le coup touche un bateau
            if (tabreponse[0] == "True")
            {
                if (_monTour)
                {
                    if (LB_MsgAttaque.InvokeRequired)//pour exécuter un délégué qui met à jour le thread d'interface utilisateur
                    {
                        Action act1 = () => LB_MsgAttaque.Text = "Touché!";
                        LB_MsgAttaque.Invoke(act1);
                        Action act2 = () => LB_MsgAttaque.ForeColor = Color.Green;
                        LB_MsgAttaque.Invoke(act2);
                        Action act3 = () => DGV_Attaque.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Style = toucheStyle;
                        DGV_Attaque.Invoke(act3);
                    }
                    else
                    {
                        LB_MsgAttaque.Text = "Touché!";
                        LB_MsgAttaque.ForeColor = Color.Green;
                        DGV_Attaque.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Style = toucheStyle;
                    }
                }
                else
                {
                    if (LB_MsgAttaque.InvokeRequired)//pour exécuter un délégué qui met à jour le thread d'interface utilisateur
                    {
                        Action act1 = () => LB_MsgAttaque.Text = "Touché!";
                        LB_MsgAttaque.Invoke(act1);
                        Action act2 = () => LB_MsgAttaque.ForeColor = Color.Red;
                        LB_MsgAttaque.Invoke(act2);
                        Action act3 = () => DGV_Perso.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Style = toucheStyle;
                        DGV_Perso.Invoke(act3);
                    }
                    else
                    {
                        LB_MsgAttaque.Text = "Touché!";
                        LB_MsgAttaque.ForeColor = Color.Red;
                        DGV_Perso.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Style = toucheStyle;
                    }
                }
                if (tabreponse.Length > 3)//si tabreponse[3] existe, il contient le bateau coulé
                {
                    if (LB_MsgAttaque.InvokeRequired)//pour exécuter un délégué qui met à jour le thread d'interface utilisateur
                    {
                        Action act1 = () => LB_MsgAttaque.Text = tabreponse[3] + " coulé!";
                        LB_MsgAttaque.Invoke(act1);
                    }
                    else
                        LB_MsgAttaque.Text = tabreponse[3] + " coulé!";
                    if (tabreponse.Length > 4)//si tabreponse[4] existe, quelqu'un à gagné, le match est fini
                    {
                        if (tabreponse[4] == "1")
                            dialogResult = MessageBox.Show("Vous avez gagné \n Play Again ?", "Fini", MessageBoxButtons.YesNo);
                        else
                            dialogResult = MessageBox.Show("Vous avez perdu \n Play Again ?", "Fini", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            envoyerMessageNouvellePartie("NouvellePartie");
                            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                            Dispose(); //to turn off current app
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            envoyerMessageNouvellePartie("Non");
                            Dispose();
                        }
                    }
                }
            }
            else
            {
                if (_monTour)
                {
                    if (LB_MsgAttaque.InvokeRequired)//pour exécuter un délégué qui met à jour le thread d'interface utilisateur
                    {
                        Action act1 = () => LB_MsgAttaque.Text = "Manqué!";
                        LB_MsgAttaque.Invoke(act1);
                        Action act2 = () => LB_MsgAttaque.ForeColor = Color.Red;
                        LB_MsgAttaque.Invoke(act2);
                        Action act3 = () => DGV_Attaque.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Style = manqueStyle;
                        DGV_Attaque.Invoke(act3);
                    }
                    else
                    {
                        LB_MsgAttaque.Text = "Manqué!";
                        LB_MsgAttaque.ForeColor = Color.Red;
                        DGV_Attaque.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Style = manqueStyle;
                    }
                }
                else
                {
                    if (LB_MsgAttaque.InvokeRequired)//pour exécuter un délégué qui met à jour le thread d'interface utilisateur
                    {
                        Action act1 = () => LB_MsgAttaque.Text = "Manqué!";
                        LB_MsgAttaque.Invoke(act1);
                        Action act2 = () => LB_MsgAttaque.ForeColor = Color.Green;
                        LB_MsgAttaque.Invoke(act2);
                        Action act3 = () => DGV_Perso.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Style = manqueStyle;
                        DGV_Perso.Invoke(act3);
                    }
                    else
                    {
                        LB_MsgAttaque.Text = "Manqué!";
                        LB_MsgAttaque.ForeColor = Color.Green;
                        DGV_Perso.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Style = manqueStyle;
                    }
                }
            }
            if (BTN_Attaquer.InvokeRequired)//pour exécuter un délégué qui met à jour le thread d'interface utilisateur
            {
                Action act1 = () => BTN_Attaquer.Enabled = !BTN_Attaquer.Enabled;
                BTN_Attaquer.Invoke(act1);
                Action act2 = () => DGV_Attaque.Refresh();
                DGV_Attaque.Invoke(act2);
                Action act3 = () => this.Refresh();
                this.Invoke(act3);
            }
            else
            {
                BTN_Attaquer.Enabled = !BTN_Attaquer.Enabled;
                DGV_Attaque.Refresh();
                this.Refresh();
            }
            _monTour = !_monTour;
            if (!_monTour)
            {
                RecevoirReponse();
            }
        }
        private void envoyerMessageNouvellePartie(string reponse)
        {
            byte[] data = Encoding.ASCII.GetBytes(reponse);
            socket.Send(data);
        }

        private void EnvoyerAttaque()
        {
            int X = 0, Y = 0;
            X = DGV_Attaque.CurrentCell.ColumnIndex;
            Y = DGV_Attaque.CurrentCell.RowIndex;
            string coordonnees = X + " " + Y;
            byte[] data = Encoding.ASCII.GetBytes(coordonnees);
            socket.Send(data);
            Thread monThreadTour1 = new Thread(RecevoirReponse);
            monThreadTour1.Start();
            Dispose();
        }

        private void BTN_Attaquer_Click(object sender, EventArgs e)
        {
            DGV_Attaque.ClearSelection();
            DGV_Perso.ClearSelection();
            if (_cibleSelectionnee)
            {
                EnvoyerAttaque();
                _cibleSelectionnee = false;
            }
        }

        private void DGV_Attaque_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!_cibleSelectionnee)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    if (DGV_Attaque.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor.Equals(orgStyle))
                        DGV_Attaque.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                }
            }
        }

        private void DGV_Attaque_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (!_cibleSelectionnee)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                    DGV_Attaque.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
            }
        }

        private void DGV_Attaque_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_monTour)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    if (DGV_Attaque.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == orgStyle)
                    {
                        _cibleSelectionnee = true;
                        DGV_Attaque.ClearSelection();
                        DGV_Attaque.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    }
                    else
                    {
                        _cibleSelectionnee = false;
                        DGV_Attaque.ClearSelection();
                    }
                }
            }
        }

        private void BTN_Demarrer_Click(object sender, EventArgs e)
        {
            RendreToutVisible(true);
            if (!_monTour)
            {
                BTN_Attaquer.Text = "En attente";
                Thread monThreadTour2 = new Thread(RecevoirReponse);
                monThreadTour2.Start();
            }
        }

        private void TableauAttaque_FormClosing(object sender, FormClosingEventArgs e)
        {
            socket.Dispose();
            Dispose();
        }

        private void BTN_Attaquer_EnabledChanged(object sender, EventArgs e)
        {
            if (!_monTour)
            {
                BTN_Attaquer.Text = "Lancer attaque";
            }
            else
            {
                BTN_Attaquer.Text = "En attente";
            }
        }
    }
}
