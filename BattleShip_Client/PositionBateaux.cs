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
        private int direction = 0;

        DataGridViewCell derniereCellule;

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
                    dgv.Rows.Add("","","","","","","","","","");

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
            changerCell(e);
            if (casesRestantes == 0 && RB_PorteAvion.Checked)
            {
                RB_PorteAvion.Enabled = false;
                DGV_Choix.Enabled = false;
                SetJouerTrue();
            }

            if (casesRestantes == 0 && RB_Croiseur.Checked)
            {
                RB_Croiseur.Enabled = false;
                DGV_Choix.Enabled = false;
                SetJouerTrue();
            }
            if (casesRestantes == 0 && RB_CTorpilleur.Checked)
            {
                RB_CTorpilleur.Enabled = false;
                DGV_Choix.Enabled = false;
                SetJouerTrue();
            }
            if (casesRestantes == 0 && RB_SousMarin.Checked)
            {
                RB_SousMarin.Enabled = false;
                DGV_Choix.Enabled = false;
                SetJouerTrue();
            }
            if (casesRestantes == 0 && RB_Torpilleur.Checked)
            {
                RB_Torpilleur.Enabled = false;
                DGV_Choix.Enabled = false;
                SetJouerTrue();
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
            switch(direction)
            {
                case 0: //vers la droite
                    if (droiteEstDisponible)
                    {
                        if ((colonne + casesRestantes - 1) < 10 && colonne >=0 && rangee >= 0)
                        {
                            for(int i = 0; i < (casesRestantes); i++)
                            {
                                DGV_Choix.Rows[rangee].Cells[colonne + i].Selected = true;
                            }
                        }
                    }
                    break;
                case 1:
                    if (basEstDisponible)
                    {
                        if ((rangee + casesRestantes - 1) < 10 && colonne > 0)
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
                        if ((colonne - (casesRestantes - 1)) >= 0 && rangee < 10)
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
                        if ((rangee - (casesRestantes - 1)) >= 0 && colonne < 10)
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

        private void changerCell(DataGridViewCellEventArgs e)
        {
            if (!DGV_Choix.CurrentCell.Value.Equals("X"))
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
                                    DGV_Choix.Rows[rangee].Cells[colonne + i].Value = 'X';
                                }
                            }
                        }
                        break;
                    case 1:
                        if (basEstDisponible)
                        {
                            if ((rangee + casesRestantes - 1) < 10 && colonne > 0)
                            {
                                for (int i = 0; i < (casesRestantes); i++)
                                {
                                    DGV_Choix.Rows[rangee + i].Cells[colonne].Value = 'X';
                                }
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
                                    DGV_Choix.Rows[rangee].Cells[colonne - i].Value = 'X';
                                }
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
                                    DGV_Choix.Rows[rangee - i].Cells[colonne].Value = 'X';
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
                                    DGV_Choix.Rows[rangee].Cells[colonne + i].Value = 'X';
                                }
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
                casesRestantes = 0;
            }
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
                if (rangee + i < 10 && rangee >=0 && colonne >= 0)
                {
                    if (!DGV_Choix.Rows[rangee + i].Cells[colonne].Value.Equals("")) // Vers le bas
                        basEstDisponible = false;
                }
                if (rangee - i > 0 && colonne >= 0)
                {
                    if (!DGV_Choix.Rows[rangee - i].Cells[colonne].Value.Equals("")) // Vers le haut
                        hautEstDisponible = false;
                }
                if (colonne + i < 10 && colonne >=0 && rangee >= 0)
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
    }
}
