﻿namespace BattleShip_Client
{
    partial class TableauAttaque
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.LB_GrilleAttaque = new System.Windows.Forms.Label();
            this.LB_GrillePerso = new System.Windows.Forms.Label();
            this.DGV_Attaque = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_Attaquer = new System.Windows.Forms.Button();
            this.DGV_Perso = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Demarrer = new System.Windows.Forms.Button();
            this.LB_Demarrer = new System.Windows.Forms.Label();
            this.lb_MSGJoueurConnection = new System.Windows.Forms.Label();
            this.LB_MsgAttaque = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_Quitter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Attaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Perso)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_GrilleAttaque
            // 
            this.LB_GrilleAttaque.AutoSize = true;
            this.LB_GrilleAttaque.Location = new System.Drawing.Point(208, 32);
            this.LB_GrilleAttaque.Name = "LB_GrilleAttaque";
            this.LB_GrilleAttaque.Size = new System.Drawing.Size(55, 17);
            this.LB_GrilleAttaque.TabIndex = 2;
            this.LB_GrilleAttaque.Text = "Ennemi";
            // 
            // LB_GrillePerso
            // 
            this.LB_GrillePerso.AutoSize = true;
            this.LB_GrillePerso.Location = new System.Drawing.Point(869, 32);
            this.LB_GrillePerso.Name = "LB_GrillePerso";
            this.LB_GrillePerso.Size = new System.Drawing.Size(30, 17);
            this.LB_GrillePerso.TabIndex = 2;
            this.LB_GrillePerso.Text = "Moi";
            // 
            // DGV_Attaque
            // 
            this.DGV_Attaque.AllowUserToResizeColumns = false;
            this.DGV_Attaque.AllowUserToResizeRows = false;
            this.DGV_Attaque.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV_Attaque.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DGV_Attaque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_Attaque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.DGV_Attaque.Location = new System.Drawing.Point(12, 64);
            this.DGV_Attaque.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGV_Attaque.MultiSelect = false;
            this.DGV_Attaque.Name = "DGV_Attaque";
            this.DGV_Attaque.RowTemplate.Height = 24;
            this.DGV_Attaque.Size = new System.Drawing.Size(589, 278);
            this.DGV_Attaque.TabIndex = 0;
            this.DGV_Attaque.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGV_Attaque_CellMouseClick);
            this.DGV_Attaque.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Attaque_CellMouseEnter);
            this.DGV_Attaque.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Attaque_CellMouseLeave);
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "1";
            this.Column1.MinimumWidth = 2;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 45;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 45;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 45;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 45;
            // 
            // Column5
            // 
            this.Column5.Frozen = true;
            this.Column5.HeaderText = "5";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 45;
            // 
            // Column6
            // 
            this.Column6.Frozen = true;
            this.Column6.HeaderText = "6";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 45;
            // 
            // Column7
            // 
            this.Column7.Frozen = true;
            this.Column7.HeaderText = "7";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 45;
            // 
            // Column8
            // 
            this.Column8.Frozen = true;
            this.Column8.HeaderText = "8";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 45;
            // 
            // Column9
            // 
            this.Column9.Frozen = true;
            this.Column9.HeaderText = "9";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 45;
            // 
            // Column10
            // 
            this.Column10.Frozen = true;
            this.Column10.HeaderText = "10";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 53;
            // 
            // BTN_Attaquer
            // 
            this.BTN_Attaquer.Location = new System.Drawing.Point(431, 347);
            this.BTN_Attaquer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTN_Attaquer.Name = "BTN_Attaquer";
            this.BTN_Attaquer.Size = new System.Drawing.Size(171, 28);
            this.BTN_Attaquer.TabIndex = 4;
            this.BTN_Attaquer.Text = "Lancer attaque";
            this.BTN_Attaquer.UseVisualStyleBackColor = true;
            this.BTN_Attaquer.EnabledChanged += new System.EventHandler(this.BTN_Attaquer_EnabledChanged);
            this.BTN_Attaquer.Click += new System.EventHandler(this.BTN_Attaquer_Click);
            // 
            // DGV_Perso
            // 
            this.DGV_Perso.AllowUserToResizeColumns = false;
            this.DGV_Perso.AllowUserToResizeRows = false;
            this.DGV_Perso.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV_Perso.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DGV_Perso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_Perso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.DGV_Perso.Enabled = false;
            this.DGV_Perso.Location = new System.Drawing.Point(605, 64);
            this.DGV_Perso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGV_Perso.Name = "DGV_Perso";
            this.DGV_Perso.ReadOnly = true;
            this.DGV_Perso.RowTemplate.Height = 24;
            this.DGV_Perso.Size = new System.Drawing.Size(604, 278);
            this.DGV_Perso.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "1";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 2;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 45;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "3";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 45;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "4";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 45;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "5";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 45;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "6";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 45;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "7";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 45;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.Frozen = true;
            this.dataGridViewTextBoxColumn8.HeaderText = "8";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 45;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.Frozen = true;
            this.dataGridViewTextBoxColumn9.HeaderText = "9";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 45;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.Frozen = true;
            this.dataGridViewTextBoxColumn10.HeaderText = "10";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 352);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "*Cliquez sur une case pour pouvoir lancer une attaque";
            // 
            // BTN_Demarrer
            // 
            this.BTN_Demarrer.Enabled = false;
            this.BTN_Demarrer.Location = new System.Drawing.Point(552, 192);
            this.BTN_Demarrer.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_Demarrer.Name = "BTN_Demarrer";
            this.BTN_Demarrer.Size = new System.Drawing.Size(100, 48);
            this.BTN_Demarrer.TabIndex = 6;
            this.BTN_Demarrer.Text = "Démarrer la partie";
            this.BTN_Demarrer.UseVisualStyleBackColor = true;
            this.BTN_Demarrer.Click += new System.EventHandler(this.BTN_Demarrer_Click);
            // 
            // LB_Demarrer
            // 
            this.LB_Demarrer.AutoSize = true;
            this.LB_Demarrer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Demarrer.Location = new System.Drawing.Point(461, 151);
            this.LB_Demarrer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Demarrer.Name = "LB_Demarrer";
            this.LB_Demarrer.Size = new System.Drawing.Size(264, 24);
            this.LB_Demarrer.TabIndex = 7;
            this.LB_Demarrer.Text = "En attente de votre adversaire";
            // 
            // lb_MSGJoueurConnection
            // 
            this.lb_MSGJoueurConnection.AutoSize = true;
            this.lb_MSGJoueurConnection.Location = new System.Drawing.Point(548, 122);
            this.lb_MSGJoueurConnection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_MSGJoueurConnection.Name = "lb_MSGJoueurConnection";
            this.lb_MSGJoueurConnection.Size = new System.Drawing.Size(0, 17);
            this.lb_MSGJoueurConnection.TabIndex = 8;
            // 
            // LB_MsgAttaque
            // 
            this.LB_MsgAttaque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_MsgAttaque.AutoEllipsis = true;
            this.LB_MsgAttaque.AutoSize = true;
            this.LB_MsgAttaque.Location = new System.Drawing.Point(37, 9);
            this.LB_MsgAttaque.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_MsgAttaque.Name = "LB_MsgAttaque";
            this.LB_MsgAttaque.Size = new System.Drawing.Size(0, 17);
            this.LB_MsgAttaque.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.LB_MsgAttaque);
            this.panel1.Location = new System.Drawing.Point(431, 26);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 31);
            this.panel1.TabIndex = 10;
            // 
            // BTN_Quitter
            // 
            this.BTN_Quitter.Location = new System.Drawing.Point(1114, 352);
            this.BTN_Quitter.Name = "BTN_Quitter";
            this.BTN_Quitter.Size = new System.Drawing.Size(95, 24);
            this.BTN_Quitter.TabIndex = 11;
            this.BTN_Quitter.Text = "Quitter";
            this.BTN_Quitter.UseVisualStyleBackColor = true;
            this.BTN_Quitter.Click += new System.EventHandler(this.BTN_Quitter_Click);
            // 
            // TableauAttaque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 405);
            this.Controls.Add(this.BTN_Quitter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_MSGJoueurConnection);
            this.Controls.Add(this.LB_Demarrer);
            this.Controls.Add(this.BTN_Demarrer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_Attaquer);
            this.Controls.Add(this.LB_GrillePerso);
            this.Controls.Add(this.LB_GrilleAttaque);
            this.Controls.Add(this.DGV_Perso);
            this.Controls.Add(this.DGV_Attaque);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TableauAttaque";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TableauAttaque_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Attaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Perso)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LB_GrilleAttaque;
        private System.Windows.Forms.Label LB_GrillePerso;
        private System.Windows.Forms.DataGridView DGV_Attaque;
        private System.Windows.Forms.Button BTN_Attaquer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridView DGV_Perso;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_Demarrer;
        private System.Windows.Forms.Label LB_Demarrer;
        private System.Windows.Forms.Label lb_MSGJoueurConnection;
        private System.Windows.Forms.Label LB_MsgAttaque;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTN_Quitter;
    }
}

