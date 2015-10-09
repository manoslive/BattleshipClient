using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip_Client
{
    public partial class PositionBateaux : Form
    {
        private int casesRestantes = 0;
        private bool basEstDisponible = true, hautEstDisponible = true, droiteEstDisponible = true, gaucheEstDisponible = true;

        DataGridViewCell derniereCellule;

        public PositionBateaux()
        {
            InitializeComponent();
        }

        private void PositionBateaux_Load(object sender, EventArgs e)
        {
            remplirDgv(DGV_Choix);
        }
        private void remplirDgv(DataGridView dgv)
        {
            char lettre = 'A';
            dgv.RowHeadersWidth = 55;

            for (int i = 0; i < 10; i++)
            {
                if (dgv.Rows.Count != 0)
                {
                    dgv.Rows.Add("","","","","","","","","","");

                    dgv.Rows[i].HeaderCell.Value = lettre.ToString();
                    lettre = (Char)(Convert.ToUInt16(lettre) + 1);
                }
            }
            dgv.AllowUserToAddRows = false;
        }

        private void DGV_Choix_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RB_PorteAvion.Checked)
            {
                if (casesRestantes != 0)
                {
                    changerCell();
                }
                else
                {
                    RB_PorteAvion.Enabled = false;
                }
            }
            if (RB_Croiseur.Checked)
            {
                if (casesRestantes != 0)
                {
                    changerCell();
                }
                else
                {
                    RB_Croiseur.Enabled = false;
                }
            }
            if (RB_CTorpilleur.Checked)
            {
                if (casesRestantes != 0)
                {
                    changerCell();
                }
                else
                {
                    RB_CTorpilleur.Enabled = false;
                }
            }
            if (RB_SousMarin.Checked)
            {
                if (casesRestantes != 0)
                {
                    changerCell();
                }
                else
                {
                    RB_SousMarin.Enabled = false;
                }
            }
            if (RB_Torpilleur.Checked)
            {
                if (casesRestantes != 0)
                {
                    changerCell();
                }
                else
                {
                    RB_Torpilleur.Enabled = false;
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

        private void RB_Torpilleur_CheckedChanged(object sender, EventArgs e)
        {
            DGV_Choix.Enabled = true;
            casesRestantes = 2;
            TB_CasesRestantes.Text = casesRestantes.ToString();
        }
        private void changerCell()
        {
            if (!DGV_Choix.CurrentCell.Value.Equals("X"))
            {
                DGV_Choix.CurrentCell.Value = "X";
                casesRestantes--;
                TB_CasesRestantes.Text = casesRestantes.ToString();
                derniereCellule = DGV_Choix.CurrentCell;
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
    }
}
