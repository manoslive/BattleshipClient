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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip_Client
{
    public partial class TableauAttaque : Form
    {
        private static Socket socket;
        private bool _monTour = false;
        private bool _cibleSelectionnee = false;
        public TableauAttaque(Socket org_socket, DataGridView mesBateaux)
        {
            InitializeComponent();
            //Copie ton DGV PositionBateaux au nouveau DGV
            CopyDataGridView(mesBateaux, DGV_Perso);
            //Retien mon socket de^PositionBateaux
            socket = org_socket;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            remplirDgv(DGV_Attaque);
            RecevoirOrdre();
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
                MessageBox.Show("Vous êtes premier et votre adversaire est:" + tabreponse[1].ToString());
                BTN_Attaquer.Enabled = true;
                _monTour = true;
            }
            else
            {
                MessageBox.Show("Vous êtes deuxième et votre adversaire est:" + tabreponse[1].ToString());
                BTN_Attaquer.Enabled = false;
                _monTour = false;
                RecevoirReponse();
            }
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
        }
        //Reçoit le résultat de son coup
        private void RecevoirReponse()
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
            //Si le coup touche un bateau
            if(tabreponse[0] == "True")
            {
                if (_monTour)
                {
                    MessageBox.Show("Touché!");
                    DGV_Attaque.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Value = "X";
                }
                else
                {
                    MessageBox.Show("Touché");
                    DGV_Perso.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Value = "X";
                }
                if (tabreponse.Length > 3)//si tabreponse[3] existe, il contient le bateau coulé
                {
                    MessageBox.Show(tabreponse[3] + " coulé!");
                    if (tabreponse.Length > 4)//si tabreponse[4] existe, quelqu'un à gagné, le match est fini
                    {
                        if (tabreponse[4] == "1")
                            MessageBox.Show("Vous avez gagné!");
                        DialogResult dialogResult = MessageBox.Show("Vous avez gagné \n Play Again ?", "Fini", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            Close();
                        }
                        else
                            MessageBox.Show("Vous avez perdu :-(");
                    }
                }
            }
            else
            {
                if (_monTour)
                {
                    MessageBox.Show("Manqué");
                    DGV_Attaque.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Value = "O";
                }
                else
                {
                    MessageBox.Show("Manqué!");
                    DGV_Perso.Rows[Int32.Parse(tabreponse[2])].Cells[Int32.Parse(tabreponse[1])].Value = "O";
                }
            }
            BTN_Attaquer.Enabled = !BTN_Attaquer.Enabled;
            _monTour = !_monTour;
            DGV_Attaque.Refresh();
            if (BTN_Attaquer.Enabled == false)
                RecevoirReponse();
        }

        private void EnvoyerAttaque()
        {
            int X = 0, Y = 0;
            //X = CB_Chiffres.GetItemText(CB_Chiffres.SelectedItem);
            //Y = CB_Lettres.GetItemText(CB_Lettres.SelectedItem);
            X = DGV_Attaque.CurrentCell.ColumnIndex;
            Y = DGV_Attaque.CurrentCell.RowIndex;
            string coordonnees = X + " " + Y;
            byte[] data = Encoding.ASCII.GetBytes(coordonnees);
            socket.Send(data);
            RecevoirReponse();
        }

        private void BTN_Attaquer_Click(object sender, EventArgs e)
        {
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
                if(e.ColumnIndex >= 0 && e.RowIndex >= 0)
                    DGV_Attaque.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
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
                    _cibleSelectionnee = true;
                    DGV_Attaque.ClearSelection();
                    DGV_Attaque.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                }
            }
        }
    }
}
