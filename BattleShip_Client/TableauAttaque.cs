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
    public partial class TableauAttaque : Form
    {
        public TableauAttaque(DataGridView mesBateaux)
        {
            //DGV_Perso = mesBateaux;
            InitializeComponent();

            CopyDataGridView(mesBateaux, DGV_Perso);
        }

        private void DGV_Attaque_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void DGV_Perso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CopyDataGridView(DataGridView dgv_org, DataGridView dgv_new)
        {
            for (int i = 0; i < dgv_org.RowCount; i++)
            {
                DataGridViewRow row = dgv_org.Rows[i];
                DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
                for (Int32 index = 0; index < row.Cells.Count; index++)
                {
                    clonedRow.Cells[index].Value = row.Cells[index].Value;
                }
                dgv_new.Rows.Add(clonedRow);
            }
        }
    }
}
