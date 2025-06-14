namespace loja_jd_modas
{
    partial class formConsultaCargo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formConsultaCargo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvcargo = new System.Windows.Forms.DataGridView();
            this.gbtipopesquisa = new System.Windows.Forms.GroupBox();
            this.rbinicio = new System.Windows.Forms.RadioButton();
            this.rbcontem = new System.Windows.Forms.RadioButton();
            this.btsair = new System.Windows.Forms.Button();
            this.btpesquisar = new System.Windows.Forms.Button();
            this.cbopcoes = new System.Windows.Forms.ComboBox();
            this.gbstatus = new System.Windows.Forms.GroupBox();
            this.rbativo = new System.Windows.Forms.RadioButton();
            this.rbinativo = new System.Windows.Forms.RadioButton();
            this.txtpesquisar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcargo)).BeginInit();
            this.gbtipopesquisa.SuspendLayout();
            this.gbstatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvcargo);
            this.groupBox1.Controls.Add(this.gbtipopesquisa);
            this.groupBox1.Controls.Add(this.btsair);
            this.groupBox1.Controls.Add(this.btpesquisar);
            this.groupBox1.Controls.Add(this.cbopcoes);
            this.groupBox1.Controls.Add(this.gbstatus);
            this.groupBox1.Controls.Add(this.txtpesquisar);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 394);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecione o Tipo de Consulta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(14, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Para alterar ou excluir um cargo, a selecione na grid.";
            // 
            // dgvcargo
            // 
            this.dgvcargo.AllowUserToAddRows = false;
            this.dgvcargo.AllowUserToDeleteRows = false;
            this.dgvcargo.AllowUserToResizeColumns = false;
            this.dgvcargo.AllowUserToResizeRows = false;
            this.dgvcargo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvcargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcargo.Location = new System.Drawing.Point(18, 167);
            this.dgvcargo.MultiSelect = false;
            this.dgvcargo.Name = "dgvcargo";
            this.dgvcargo.ReadOnly = true;
            this.dgvcargo.RowHeadersVisible = false;
            this.dgvcargo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvcargo.Size = new System.Drawing.Size(546, 214);
            this.dgvcargo.TabIndex = 8;
            this.dgvcargo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvcargo_CellContentClick);
            // 
            // gbtipopesquisa
            // 
            this.gbtipopesquisa.Controls.Add(this.rbinicio);
            this.gbtipopesquisa.Controls.Add(this.rbcontem);
            this.gbtipopesquisa.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbtipopesquisa.Location = new System.Drawing.Point(179, 81);
            this.gbtipopesquisa.Name = "gbtipopesquisa";
            this.gbtipopesquisa.Size = new System.Drawing.Size(158, 61);
            this.gbtipopesquisa.TabIndex = 7;
            this.gbtipopesquisa.TabStop = false;
            this.gbtipopesquisa.Text = "Tipo de Pesquisa:";
            // 
            // rbinicio
            // 
            this.rbinicio.AutoSize = true;
            this.rbinicio.Checked = true;
            this.rbinicio.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbinicio.Location = new System.Drawing.Point(6, 22);
            this.rbinicio.Name = "rbinicio";
            this.rbinicio.Size = new System.Drawing.Size(62, 23);
            this.rbinicio.TabIndex = 2;
            this.rbinicio.TabStop = true;
            this.rbinicio.Text = "Inicio";
            this.rbinicio.UseVisualStyleBackColor = true;
            // 
            // rbcontem
            // 
            this.rbcontem.AutoSize = true;
            this.rbcontem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbcontem.Location = new System.Drawing.Point(74, 22);
            this.rbcontem.Name = "rbcontem";
            this.rbcontem.Size = new System.Drawing.Size(77, 23);
            this.rbcontem.TabIndex = 3;
            this.rbcontem.TabStop = true;
            this.rbcontem.Text = "Contém";
            this.rbcontem.UseVisualStyleBackColor = true;
            // 
            // btsair
            // 
            this.btsair.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsair.Image = ((System.Drawing.Image)(resources.GetObject("btsair.Image")));
            this.btsair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btsair.Location = new System.Drawing.Point(443, 90);
            this.btsair.Name = "btsair";
            this.btsair.Size = new System.Drawing.Size(121, 48);
            this.btsair.TabIndex = 6;
            this.btsair.Text = "   Sair";
            this.btsair.UseVisualStyleBackColor = true;
            this.btsair.Click += new System.EventHandler(this.btsair_Click);
            // 
            // btpesquisar
            // 
            this.btpesquisar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btpesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btpesquisar.Image")));
            this.btpesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btpesquisar.Location = new System.Drawing.Point(443, 36);
            this.btpesquisar.Name = "btpesquisar";
            this.btpesquisar.Size = new System.Drawing.Size(121, 45);
            this.btpesquisar.TabIndex = 5;
            this.btpesquisar.Text = "        Pesquisar";
            this.btpesquisar.UseVisualStyleBackColor = true;
            this.btpesquisar.Click += new System.EventHandler(this.btpesquisar_Click);
            // 
            // cbopcoes
            // 
            this.cbopcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbopcoes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbopcoes.FormattingEnabled = true;
            this.cbopcoes.Location = new System.Drawing.Point(18, 36);
            this.cbopcoes.Name = "cbopcoes";
            this.cbopcoes.Size = new System.Drawing.Size(121, 27);
            this.cbopcoes.TabIndex = 4;
            this.cbopcoes.SelectedIndexChanged += new System.EventHandler(this.cbopcoes_SelectedIndexChanged);
            // 
            // gbstatus
            // 
            this.gbstatus.Controls.Add(this.rbativo);
            this.gbstatus.Controls.Add(this.rbinativo);
            this.gbstatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbstatus.Location = new System.Drawing.Point(18, 81);
            this.gbstatus.Name = "gbstatus";
            this.gbstatus.Size = new System.Drawing.Size(144, 61);
            this.gbstatus.TabIndex = 1;
            this.gbstatus.TabStop = false;
            this.gbstatus.Text = "Status:";
            // 
            // rbativo
            // 
            this.rbativo.AutoSize = true;
            this.rbativo.Checked = true;
            this.rbativo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbativo.Location = new System.Drawing.Point(6, 22);
            this.rbativo.Name = "rbativo";
            this.rbativo.Size = new System.Drawing.Size(60, 23);
            this.rbativo.TabIndex = 2;
            this.rbativo.TabStop = true;
            this.rbativo.Text = "Ativo";
            this.rbativo.UseVisualStyleBackColor = true;
            // 
            // rbinativo
            // 
            this.rbinativo.AutoSize = true;
            this.rbinativo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbinativo.Location = new System.Drawing.Point(72, 22);
            this.rbinativo.Name = "rbinativo";
            this.rbinativo.Size = new System.Drawing.Size(71, 23);
            this.rbinativo.TabIndex = 3;
            this.rbinativo.Text = "Inativo";
            this.rbinativo.UseVisualStyleBackColor = true;
            // 
            // txtpesquisar
            // 
            this.txtpesquisar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpesquisar.Location = new System.Drawing.Point(165, 36);
            this.txtpesquisar.MaxLength = 25;
            this.txtpesquisar.Name = "txtpesquisar";
            this.txtpesquisar.Size = new System.Drawing.Size(263, 27);
            this.txtpesquisar.TabIndex = 0;
            this.txtpesquisar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpesquisar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consulta de Cargo";
            // 
            // formConsultaCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 435);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "formConsultaCargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loja J.D Modas - Consulta de Cargo";
            this.Load += new System.EventHandler(this.formConsultaCargo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcargo)).EndInit();
            this.gbtipopesquisa.ResumeLayout(false);
            this.gbtipopesquisa.PerformLayout();
            this.gbstatus.ResumeLayout(false);
            this.gbstatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvcargo;
        private System.Windows.Forms.GroupBox gbtipopesquisa;
        private System.Windows.Forms.RadioButton rbinicio;
        private System.Windows.Forms.RadioButton rbcontem;
        private System.Windows.Forms.Button btsair;
        private System.Windows.Forms.Button btpesquisar;
        private System.Windows.Forms.ComboBox cbopcoes;
        private System.Windows.Forms.GroupBox gbstatus;
        private System.Windows.Forms.RadioButton rbativo;
        private System.Windows.Forms.RadioButton rbinativo;
        private System.Windows.Forms.TextBox txtpesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}