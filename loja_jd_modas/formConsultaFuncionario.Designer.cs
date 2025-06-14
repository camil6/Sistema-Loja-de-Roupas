namespace loja_jd_modas
{
    partial class formConsultaFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formConsultaFuncionario));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gpcargo = new System.Windows.Forms.GroupBox();
            this.cbCargo = new System.Windows.Forms.ComboBox();
            this.gbsexo = new System.Windows.Forms.GroupBox();
            this.cbsexo = new System.Windows.Forms.ComboBox();
            this.dgvfuncionario = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btsair = new System.Windows.Forms.Button();
            this.btpesquisar = new System.Windows.Forms.Button();
            this.gbstatus = new System.Windows.Forms.GroupBox();
            this.rbativo = new System.Windows.Forms.RadioButton();
            this.rbinativo = new System.Windows.Forms.RadioButton();
            this.gbcpf = new System.Windows.Forms.GroupBox();
            this.mskcpf = new System.Windows.Forms.MaskedTextBox();
            this.gbtipopesquisa = new System.Windows.Forms.GroupBox();
            this.rbcontem = new System.Windows.Forms.RadioButton();
            this.rbinicio = new System.Windows.Forms.RadioButton();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.cbopcoes = new System.Windows.Forms.ComboBox();
            this.lbtitulo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gpcargo.SuspendLayout();
            this.gbsexo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfuncionario)).BeginInit();
            this.gbstatus.SuspendLayout();
            this.gbcpf.SuspendLayout();
            this.gbtipopesquisa.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gpcargo);
            this.groupBox1.Controls.Add(this.gbsexo);
            this.groupBox1.Controls.Add(this.dgvfuncionario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btsair);
            this.groupBox1.Controls.Add(this.btpesquisar);
            this.groupBox1.Controls.Add(this.gbstatus);
            this.groupBox1.Controls.Add(this.gbcpf);
            this.groupBox1.Controls.Add(this.gbtipopesquisa);
            this.groupBox1.Controls.Add(this.txtPesquisar);
            this.groupBox1.Controls.Add(this.cbopcoes);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 523);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecione um tipo de consulta:";
            // 
            // gpcargo
            // 
            this.gpcargo.Controls.Add(this.cbCargo);
            this.gpcargo.Location = new System.Drawing.Point(205, 60);
            this.gpcargo.Name = "gpcargo";
            this.gpcargo.Size = new System.Drawing.Size(246, 69);
            this.gpcargo.TabIndex = 8;
            this.gpcargo.TabStop = false;
            this.gpcargo.Text = "Cargo:";
            // 
            // cbCargo
            // 
            this.cbCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCargo.FormattingEnabled = true;
            this.cbCargo.Location = new System.Drawing.Point(15, 27);
            this.cbCargo.Name = "cbCargo";
            this.cbCargo.Size = new System.Drawing.Size(212, 26);
            this.cbCargo.TabIndex = 7;
            // 
            // gbsexo
            // 
            this.gbsexo.Controls.Add(this.cbsexo);
            this.gbsexo.Location = new System.Drawing.Point(205, 135);
            this.gbsexo.Name = "gbsexo";
            this.gbsexo.Size = new System.Drawing.Size(138, 68);
            this.gbsexo.TabIndex = 0;
            this.gbsexo.TabStop = false;
            this.gbsexo.Text = "Sexo:";
            // 
            // cbsexo
            // 
            this.cbsexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsexo.FormattingEnabled = true;
            this.cbsexo.Location = new System.Drawing.Point(6, 27);
            this.cbsexo.Name = "cbsexo";
            this.cbsexo.Size = new System.Drawing.Size(121, 26);
            this.cbsexo.TabIndex = 3;
            // 
            // dgvfuncionario
            // 
            this.dgvfuncionario.AllowUserToAddRows = false;
            this.dgvfuncionario.AllowUserToDeleteRows = false;
            this.dgvfuncionario.AllowUserToResizeColumns = false;
            this.dgvfuncionario.AllowUserToResizeRows = false;
            this.dgvfuncionario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvfuncionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfuncionario.Location = new System.Drawing.Point(14, 227);
            this.dgvfuncionario.MultiSelect = false;
            this.dgvfuncionario.Name = "dgvfuncionario";
            this.dgvfuncionario.ReadOnly = true;
            this.dgvfuncionario.RowHeadersVisible = false;
            this.dgvfuncionario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvfuncionario.Size = new System.Drawing.Size(686, 282);
            this.dgvfuncionario.TabIndex = 6;
            this.dgvfuncionario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvfuncionario_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(19, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Para alterar ou excluir um cliente, selecione na grid.";
            // 
            // btsair
            // 
            this.btsair.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsair.Image = ((System.Drawing.Image)(resources.GetObject("btsair.Image")));
            this.btsair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btsair.Location = new System.Drawing.Point(578, 160);
            this.btsair.Name = "btsair";
            this.btsair.Size = new System.Drawing.Size(116, 42);
            this.btsair.TabIndex = 4;
            this.btsair.Text = " Sair";
            this.btsair.UseVisualStyleBackColor = true;
            this.btsair.Click += new System.EventHandler(this.btsair_Click);
            // 
            // btpesquisar
            // 
            this.btpesquisar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btpesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btpesquisar.Image")));
            this.btpesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btpesquisar.Location = new System.Drawing.Point(578, 103);
            this.btpesquisar.Name = "btpesquisar";
            this.btpesquisar.Size = new System.Drawing.Size(116, 43);
            this.btpesquisar.TabIndex = 3;
            this.btpesquisar.Text = "     Pesquisar";
            this.btpesquisar.UseVisualStyleBackColor = true;
            this.btpesquisar.Click += new System.EventHandler(this.btpesquisar_Click);
            // 
            // gbstatus
            // 
            this.gbstatus.Controls.Add(this.rbativo);
            this.gbstatus.Controls.Add(this.rbinativo);
            this.gbstatus.Location = new System.Drawing.Point(14, 134);
            this.gbstatus.Name = "gbstatus";
            this.gbstatus.Size = new System.Drawing.Size(152, 68);
            this.gbstatus.TabIndex = 0;
            this.gbstatus.TabStop = false;
            this.gbstatus.Text = "Status:";
            // 
            // rbativo
            // 
            this.rbativo.AutoSize = true;
            this.rbativo.Checked = true;
            this.rbativo.Location = new System.Drawing.Point(6, 26);
            this.rbativo.Name = "rbativo";
            this.rbativo.Size = new System.Drawing.Size(58, 22);
            this.rbativo.TabIndex = 3;
            this.rbativo.TabStop = true;
            this.rbativo.Text = "Ativo";
            this.rbativo.UseVisualStyleBackColor = true;
            // 
            // rbinativo
            // 
            this.rbinativo.AutoSize = true;
            this.rbinativo.Location = new System.Drawing.Point(72, 27);
            this.rbinativo.Name = "rbinativo";
            this.rbinativo.Size = new System.Drawing.Size(68, 22);
            this.rbinativo.TabIndex = 4;
            this.rbinativo.Text = "Inativo";
            this.rbinativo.UseVisualStyleBackColor = true;
            // 
            // gbcpf
            // 
            this.gbcpf.Controls.Add(this.mskcpf);
            this.gbcpf.Location = new System.Drawing.Point(14, 60);
            this.gbcpf.Name = "gbcpf";
            this.gbcpf.Size = new System.Drawing.Size(152, 68);
            this.gbcpf.TabIndex = 0;
            this.gbcpf.TabStop = false;
            this.gbcpf.Text = "CPF:";
            // 
            // mskcpf
            // 
            this.mskcpf.Location = new System.Drawing.Point(21, 26);
            this.mskcpf.Mask = "000,000,000-00";
            this.mskcpf.Name = "mskcpf";
            this.mskcpf.Size = new System.Drawing.Size(108, 26);
            this.mskcpf.TabIndex = 0;
            // 
            // gbtipopesquisa
            // 
            this.gbtipopesquisa.Controls.Add(this.rbcontem);
            this.gbtipopesquisa.Controls.Add(this.rbinicio);
            this.gbtipopesquisa.Location = new System.Drawing.Point(552, 17);
            this.gbtipopesquisa.Name = "gbtipopesquisa";
            this.gbtipopesquisa.Size = new System.Drawing.Size(148, 68);
            this.gbtipopesquisa.TabIndex = 2;
            this.gbtipopesquisa.TabStop = false;
            this.gbtipopesquisa.Text = "Tipo de Pesquisa:";
            // 
            // rbcontem
            // 
            this.rbcontem.AutoSize = true;
            this.rbcontem.Location = new System.Drawing.Point(65, 23);
            this.rbcontem.Name = "rbcontem";
            this.rbcontem.Size = new System.Drawing.Size(75, 22);
            this.rbcontem.TabIndex = 1;
            this.rbcontem.TabStop = true;
            this.rbcontem.Text = "Contém";
            this.rbcontem.UseVisualStyleBackColor = true;
            // 
            // rbinicio
            // 
            this.rbinicio.AutoSize = true;
            this.rbinicio.Checked = true;
            this.rbinicio.Location = new System.Drawing.Point(3, 23);
            this.rbinicio.Name = "rbinicio";
            this.rbinicio.Size = new System.Drawing.Size(59, 22);
            this.rbinicio.TabIndex = 0;
            this.rbinicio.TabStop = true;
            this.rbinicio.Text = "Início";
            this.rbinicio.UseVisualStyleBackColor = true;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Location = new System.Drawing.Point(182, 26);
            this.txtPesquisar.MaxLength = 50;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(351, 26);
            this.txtPesquisar.TabIndex = 1;
            this.txtPesquisar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPesquisar_KeyPress);
            // 
            // cbopcoes
            // 
            this.cbopcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbopcoes.FormattingEnabled = true;
            this.cbopcoes.Location = new System.Drawing.Point(14, 26);
            this.cbopcoes.Name = "cbopcoes";
            this.cbopcoes.Size = new System.Drawing.Size(138, 26);
            this.cbopcoes.TabIndex = 0;
            this.cbopcoes.SelectedIndexChanged += new System.EventHandler(this.cbopcoes_SelectedIndexChanged);
            // 
            // lbtitulo
            // 
            this.lbtitulo.AutoSize = true;
            this.lbtitulo.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitulo.Location = new System.Drawing.Point(249, 9);
            this.lbtitulo.Name = "lbtitulo";
            this.lbtitulo.Size = new System.Drawing.Size(229, 25);
            this.lbtitulo.TabIndex = 2;
            this.lbtitulo.Text = "Consulta de Funcionário";
            // 
            // formConsultaFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 568);
            this.Controls.Add(this.lbtitulo);
            this.Controls.Add(this.groupBox1);
            this.Name = "formConsultaFuncionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loja J.D Modas - Consulta de Funcionário";
            this.Load += new System.EventHandler(this.formConsultaFuncionario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpcargo.ResumeLayout(false);
            this.gbsexo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvfuncionario)).EndInit();
            this.gbstatus.ResumeLayout(false);
            this.gbstatus.PerformLayout();
            this.gbcpf.ResumeLayout(false);
            this.gbcpf.PerformLayout();
            this.gbtipopesquisa.ResumeLayout(false);
            this.gbtipopesquisa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.ComboBox cbopcoes;
        private System.Windows.Forms.GroupBox gbsexo;
        private System.Windows.Forms.GroupBox gbtipopesquisa;
        private System.Windows.Forms.RadioButton rbcontem;
        private System.Windows.Forms.RadioButton rbinicio;
        private System.Windows.Forms.GroupBox gbstatus;
        private System.Windows.Forms.GroupBox gbcpf;
        private System.Windows.Forms.ComboBox cbsexo;
        private System.Windows.Forms.RadioButton rbativo;
        private System.Windows.Forms.RadioButton rbinativo;
        private System.Windows.Forms.MaskedTextBox mskcpf;
        private System.Windows.Forms.Button btsair;
        private System.Windows.Forms.Button btpesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvfuncionario;
        private System.Windows.Forms.ComboBox cbCargo;
        private System.Windows.Forms.GroupBox gpcargo;
        private System.Windows.Forms.Label lbtitulo;
    }
}