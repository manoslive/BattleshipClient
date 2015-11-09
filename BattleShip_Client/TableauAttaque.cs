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
        public TableauAttaque(Socket org_socket,DataGridView mesBateaux)
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

        private void BTN_Attaquer_Click(object sender, EventArgs e)
        {

        }
    }
}
