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
            }
            else
            {
                MessageBox.Show("Vous êtes deuxième et votre adversaire est:" + tabreponse[1].ToString());
                BTN_Attaquer.Enabled = false;
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

            if(tabreponse[0] == "true")
            {
                if (tabreponse.Length > 3)
                {
                    MessageBox.Show(tabreponse[3] + " coulé!");
                    if (tabreponse[5] == "1")
                        MessageBox.Show("Vous avez gagné!");
                    else
                        MessageBox.Show("Vous avez perdu :-(");
                }
                else
                    MessageBox.Show("Touché!");
            }
            else
            {
                MessageBox.Show("Manqué :-(");
            }
            MessageBox.Show(tabreponse[1]+ tabreponse[2]);
        }

        private void BTN_Attaquer_Click(object sender, EventArgs e)
        {
            string X = "", Y = "";
            X = CB_Chiffres.GetItemText(CB_Chiffres.SelectedItem);
            Y = CB_Lettres.GetItemText(CB_Lettres.SelectedItem);
            string coordonnees = X + " " + Y;
            byte[] data = Encoding.ASCII.GetBytes(coordonnees);
            socket.Send(data);
            RecevoirReponse();
        }
    }
}
