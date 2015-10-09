namespace BattleShip_Client
{
    partial class PositionBateaux
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGV_Choix = new System.Windows.Forms.DataGridView();
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
            this.LB_Position = new System.Windows.Forms.Label();
            this.BTN_Jouer = new System.Windows.Forms.Button();
            this.LB_ListeBateaux = new System.Windows.Forms.Label();
            this.GB_ListeBateaux = new System.Windows.Forms.GroupBox();
            this.RB_PorteAvion = new System.Windows.Forms.RadioButton();
            this.RB_Croiseur = new System.Windows.Forms.RadioButton();
            this.RB_CTorpilleur = new System.Windows.Forms.RadioButton();
            this.RB_SousMarin = new System.Windows.Forms.RadioButton();
            this.RB_Torpilleur = new System.Windows.Forms.RadioButton();
            this.LB_CasesRestantes = new System.Windows.Forms.Label();
            this.TB_CasesRestantes = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Choix)).BeginInit();
            this.GB_ListeBateaux.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_Choix
            // 
            this.DGV_Choix.AllowUserToResizeColumns = false;
            this.DGV_Choix.AllowUserToResizeRows = false;
            this.DGV_Choix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV_Choix.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DGV_Choix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_Choix.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.DGV_Choix.Enabled = false;
            this.DGV_Choix.Location = new System.Drawing.Point(12, 69);
            this.DGV_Choix.Name = "DGV_Choix";
            this.DGV_Choix.RowTemplate.Height = 24;
            this.DGV_Choix.Size = new System.Drawing.Size(590, 278);
            this.DGV_Choix.TabIndex = 1;
            this.DGV_Choix.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Choix_CellClick);
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
            // LB_Position
            // 
            this.LB_Position.AutoSize = true;
            this.LB_Position.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Position.Location = new System.Drawing.Point(154, 20);
            this.LB_Position.Name = "LB_Position";
            this.LB_Position.Size = new System.Drawing.Size(288, 29);
            this.LB_Position.TabIndex = 2;
            this.LB_Position.Text = "Positionnez vos bateaux";
            // 
            // BTN_Jouer
            // 
            this.BTN_Jouer.Location = new System.Drawing.Point(695, 379);
            this.BTN_Jouer.Name = "BTN_Jouer";
            this.BTN_Jouer.Size = new System.Drawing.Size(100, 27);
            this.BTN_Jouer.TabIndex = 3;
            this.BTN_Jouer.Text = "Jouer";
            this.BTN_Jouer.UseVisualStyleBackColor = true;
            // 
            // LB_ListeBateaux
            // 
            this.LB_ListeBateaux.AutoSize = true;
            this.LB_ListeBateaux.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_ListeBateaux.Location = new System.Drawing.Point(648, 20);
            this.LB_ListeBateaux.Name = "LB_ListeBateaux";
            this.LB_ListeBateaux.Size = new System.Drawing.Size(105, 29);
            this.LB_ListeBateaux.TabIndex = 2;
            this.LB_ListeBateaux.Text = "Bateaux";
            // 
            // GB_ListeBateaux
            // 
            this.GB_ListeBateaux.Controls.Add(this.RB_Torpilleur);
            this.GB_ListeBateaux.Controls.Add(this.RB_SousMarin);
            this.GB_ListeBateaux.Controls.Add(this.RB_CTorpilleur);
            this.GB_ListeBateaux.Controls.Add(this.RB_Croiseur);
            this.GB_ListeBateaux.Controls.Add(this.RB_PorteAvion);
            this.GB_ListeBateaux.Location = new System.Drawing.Point(627, 69);
            this.GB_ListeBateaux.Name = "GB_ListeBateaux";
            this.GB_ListeBateaux.Size = new System.Drawing.Size(168, 278);
            this.GB_ListeBateaux.TabIndex = 4;
            this.GB_ListeBateaux.TabStop = false;
            // 
            // RB_PorteAvion
            // 
            this.RB_PorteAvion.AutoSize = true;
            this.RB_PorteAvion.Location = new System.Drawing.Point(15, 30);
            this.RB_PorteAvion.Name = "RB_PorteAvion";
            this.RB_PorteAvion.Size = new System.Drawing.Size(131, 21);
            this.RB_PorteAvion.TabIndex = 0;
            this.RB_PorteAvion.TabStop = true;
            this.RB_PorteAvion.Text = "Porte-avions (5)";
            this.RB_PorteAvion.UseVisualStyleBackColor = true;
            this.RB_PorteAvion.CheckedChanged += new System.EventHandler(this.RB_PorteAvion_CheckedChanged);
            // 
            // RB_Croiseur
            // 
            this.RB_Croiseur.AutoSize = true;
            this.RB_Croiseur.Location = new System.Drawing.Point(15, 80);
            this.RB_Croiseur.Name = "RB_Croiseur";
            this.RB_Croiseur.Size = new System.Drawing.Size(104, 21);
            this.RB_Croiseur.TabIndex = 0;
            this.RB_Croiseur.TabStop = true;
            this.RB_Croiseur.Text = "Croiseur (4)";
            this.RB_Croiseur.UseVisualStyleBackColor = true;
            this.RB_Croiseur.CheckedChanged += new System.EventHandler(this.RB_Croiseur_CheckedChanged);
            // 
            // RB_CTorpilleur
            // 
            this.RB_CTorpilleur.AutoSize = true;
            this.RB_CTorpilleur.Location = new System.Drawing.Point(15, 130);
            this.RB_CTorpilleur.Name = "RB_CTorpilleur";
            this.RB_CTorpilleur.Size = new System.Drawing.Size(153, 21);
            this.RB_CTorpilleur.TabIndex = 0;
            this.RB_CTorpilleur.TabStop = true;
            this.RB_CTorpilleur.Text = "Contre-torpilleur (3)";
            this.RB_CTorpilleur.UseVisualStyleBackColor = true;
            this.RB_CTorpilleur.CheckedChanged += new System.EventHandler(this.RB_CTorpilleur_CheckedChanged);
            // 
            // RB_SousMarin
            // 
            this.RB_SousMarin.AutoSize = true;
            this.RB_SousMarin.Location = new System.Drawing.Point(15, 180);
            this.RB_SousMarin.Name = "RB_SousMarin";
            this.RB_SousMarin.Size = new System.Drawing.Size(123, 21);
            this.RB_SousMarin.TabIndex = 0;
            this.RB_SousMarin.TabStop = true;
            this.RB_SousMarin.Text = "Sous-marin (3)";
            this.RB_SousMarin.UseVisualStyleBackColor = true;
            this.RB_SousMarin.CheckedChanged += new System.EventHandler(this.RB_SousMarin_CheckedChanged);
            // 
            // RB_Torpilleur
            // 
            this.RB_Torpilleur.AutoSize = true;
            this.RB_Torpilleur.Location = new System.Drawing.Point(15, 230);
            this.RB_Torpilleur.Name = "RB_Torpilleur";
            this.RB_Torpilleur.Size = new System.Drawing.Size(111, 21);
            this.RB_Torpilleur.TabIndex = 0;
            this.RB_Torpilleur.TabStop = true;
            this.RB_Torpilleur.Text = "Torpilleur (2)";
            this.RB_Torpilleur.UseVisualStyleBackColor = true;
            this.RB_Torpilleur.CheckedChanged += new System.EventHandler(this.RB_Torpilleur_CheckedChanged);
            // 
            // LB_CasesRestantes
            // 
            this.LB_CasesRestantes.AutoSize = true;
            this.LB_CasesRestantes.Location = new System.Drawing.Point(12, 379);
            this.LB_CasesRestantes.Name = "LB_CasesRestantes";
            this.LB_CasesRestantes.Size = new System.Drawing.Size(118, 17);
            this.LB_CasesRestantes.TabIndex = 5;
            this.LB_CasesRestantes.Text = "Cases restantes :";
            // 
            // TB_CasesRestantes
            // 
            this.TB_CasesRestantes.Enabled = false;
            this.TB_CasesRestantes.Location = new System.Drawing.Point(136, 376);
            this.TB_CasesRestantes.Name = "TB_CasesRestantes";
            this.TB_CasesRestantes.ReadOnly = true;
            this.TB_CasesRestantes.Size = new System.Drawing.Size(30, 22);
            this.TB_CasesRestantes.TabIndex = 6;
            // 
            // PositionBateaux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 418);
            this.Controls.Add(this.TB_CasesRestantes);
            this.Controls.Add(this.LB_CasesRestantes);
            this.Controls.Add(this.GB_ListeBateaux);
            this.Controls.Add(this.BTN_Jouer);
            this.Controls.Add(this.LB_ListeBateaux);
            this.Controls.Add(this.LB_Position);
            this.Controls.Add(this.DGV_Choix);
            this.Name = "PositionBateaux";
            this.Text = "PositionBateaux";
            this.Load += new System.EventHandler(this.PositionBateaux_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Choix)).EndInit();
            this.GB_ListeBateaux.ResumeLayout(false);
            this.GB_ListeBateaux.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Choix;
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
        private System.Windows.Forms.Label LB_Position;
        private System.Windows.Forms.Button BTN_Jouer;
        private System.Windows.Forms.Label LB_ListeBateaux;
        private System.Windows.Forms.GroupBox GB_ListeBateaux;
        private System.Windows.Forms.RadioButton RB_Torpilleur;
        private System.Windows.Forms.RadioButton RB_SousMarin;
        private System.Windows.Forms.RadioButton RB_CTorpilleur;
        private System.Windows.Forms.RadioButton RB_Croiseur;
        private System.Windows.Forms.RadioButton RB_PorteAvion;
        private System.Windows.Forms.Label LB_CasesRestantes;
        private System.Windows.Forms.TextBox TB_CasesRestantes;
    }
}