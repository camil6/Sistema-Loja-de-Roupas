
namespace loja_jd_modas
{
    partial class formRelatorioProduto
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formRelatorioProduto));
            this.rptvProduto = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cbTipo_relatorio = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbEstoque = new System.Windows.Forms.GroupBox();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.gbValor = new System.Windows.Forms.GroupBox();
            this.txtValor2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValor1 = new System.Windows.Forms.TextBox();
            this.gbTamanho = new System.Windows.Forms.GroupBox();
            this.cbTamanho = new System.Windows.Forms.ComboBox();
            this.gbMarca = new System.Windows.Forms.GroupBox();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.rbInativo = new System.Windows.Forms.RadioButton();
            this.rbAtivo = new System.Windows.Forms.RadioButton();
            this.gbCategoria = new System.Windows.Forms.GroupBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.btRelatorio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.classProdutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.gbEstoque.SuspendLayout();
            this.gbValor.SuspendLayout();
            this.gbTamanho.SuspendLayout();
            this.gbMarca.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.gbCategoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classProdutoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rptvProduto
            // 
            reportDataSource1.Name = "DataSetProduto";
            reportDataSource1.Value = this.classProdutoBindingSource;
            this.rptvProduto.LocalReport.DataSources.Add(reportDataSource1);
            this.rptvProduto.LocalReport.ReportEmbeddedResource = "loja_jd_modas.rptProduto.rdlc";
            this.rptvProduto.Location = new System.Drawing.Point(12, 231);
            this.rptvProduto.Name = "rptvProduto";
            this.rptvProduto.ServerReport.BearerToken = null;
            this.rptvProduto.Size = new System.Drawing.Size(610, 434);
            this.rptvProduto.TabIndex = 0;
            // 
            // cbTipo_relatorio
            // 
            this.cbTipo_relatorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo_relatorio.FormattingEnabled = true;
            this.cbTipo_relatorio.Location = new System.Drawing.Point(240, 34);
            this.cbTipo_relatorio.Name = "cbTipo_relatorio";
            this.cbTipo_relatorio.Size = new System.Drawing.Size(146, 26);
            this.cbTipo_relatorio.TabIndex = 1;
            this.cbTipo_relatorio.SelectedIndexChanged += new System.EventHandler(this.cbTipo_relatorio_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.gbEstoque);
            this.groupBox1.Controls.Add(this.gbValor);
            this.groupBox1.Controls.Add(this.gbTamanho);
            this.groupBox1.Controls.Add(this.gbMarca);
            this.groupBox1.Controls.Add(this.gbStatus);
            this.groupBox1.Controls.Add(this.gbCategoria);
            this.groupBox1.Controls.Add(this.btRelatorio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbTipo_relatorio);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 213);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(187, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Relatório de Produtos";
            // 
            // gbEstoque
            // 
            this.gbEstoque.Controls.Add(this.txtEstoque);
            this.gbEstoque.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEstoque.Location = new System.Drawing.Point(467, 141);
            this.gbEstoque.Name = "gbEstoque";
            this.gbEstoque.Size = new System.Drawing.Size(124, 61);
            this.gbEstoque.TabIndex = 9;
            this.gbEstoque.TabStop = false;
            this.gbEstoque.Text = "Estoque abaixo de:";
            // 
            // txtEstoque
            // 
            this.txtEstoque.Location = new System.Drawing.Point(47, 24);
            this.txtEstoque.MaxLength = 3;
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(52, 27);
            this.txtEstoque.TabIndex = 8;
            this.txtEstoque.TextChanged += new System.EventHandler(this.txtEstoque_TextChanged);
            this.txtEstoque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstoque_KeyPress);
            // 
            // gbValor
            // 
            this.gbValor.Controls.Add(this.txtValor2);
            this.gbValor.Controls.Add(this.label3);
            this.gbValor.Controls.Add(this.txtValor1);
            this.gbValor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbValor.Location = new System.Drawing.Point(223, 141);
            this.gbValor.Name = "gbValor";
            this.gbValor.Size = new System.Drawing.Size(184, 61);
            this.gbValor.TabIndex = 5;
            this.gbValor.TabStop = false;
            this.gbValor.Text = "Valor Entre:";
            // 
            // txtValor2
            // 
            this.txtValor2.Location = new System.Drawing.Point(105, 24);
            this.txtValor2.MaxLength = 6;
            this.txtValor2.Name = "txtValor2";
            this.txtValor2.Size = new System.Drawing.Size(70, 27);
            this.txtValor2.TabIndex = 7;
            this.txtValor2.TextChanged += new System.EventHandler(this.txtValor2_TextChanged);
            this.txtValor2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "E";
            // 
            // txtValor1
            // 
            this.txtValor1.Location = new System.Drawing.Point(6, 24);
            this.txtValor1.MaxLength = 6;
            this.txtValor1.Name = "txtValor1";
            this.txtValor1.Size = new System.Drawing.Size(70, 27);
            this.txtValor1.TabIndex = 0;
            this.txtValor1.TextChanged += new System.EventHandler(this.txtValor1_TextChanged);
            this.txtValor1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor1_KeyPress);
            // 
            // gbTamanho
            // 
            this.gbTamanho.Controls.Add(this.cbTamanho);
            this.gbTamanho.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTamanho.Location = new System.Drawing.Point(467, 71);
            this.gbTamanho.Name = "gbTamanho";
            this.gbTamanho.Size = new System.Drawing.Size(124, 64);
            this.gbTamanho.TabIndex = 8;
            this.gbTamanho.TabStop = false;
            this.gbTamanho.Text = "Tamanho:";
            // 
            // cbTamanho
            // 
            this.cbTamanho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTamanho.FormattingEnabled = true;
            this.cbTamanho.Location = new System.Drawing.Point(21, 26);
            this.cbTamanho.Name = "cbTamanho";
            this.cbTamanho.Size = new System.Drawing.Size(78, 27);
            this.cbTamanho.TabIndex = 2;
            // 
            // gbMarca
            // 
            this.gbMarca.Controls.Add(this.cbMarca);
            this.gbMarca.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMarca.Location = new System.Drawing.Point(231, 71);
            this.gbMarca.Name = "gbMarca";
            this.gbMarca.Size = new System.Drawing.Size(167, 64);
            this.gbMarca.TabIndex = 7;
            this.gbMarca.TabStop = false;
            this.gbMarca.Text = "Marca:";
            // 
            // cbMarca
            // 
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(21, 26);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(130, 27);
            this.cbMarca.TabIndex = 2;
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.rbInativo);
            this.gbStatus.Controls.Add(this.rbAtivo);
            this.gbStatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStatus.Location = new System.Drawing.Point(18, 141);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(148, 61);
            this.gbStatus.TabIndex = 4;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status:";
            // 
            // rbInativo
            // 
            this.rbInativo.AutoSize = true;
            this.rbInativo.Location = new System.Drawing.Point(73, 24);
            this.rbInativo.Name = "rbInativo";
            this.rbInativo.Size = new System.Drawing.Size(71, 23);
            this.rbInativo.TabIndex = 1;
            this.rbInativo.Text = "Inativo";
            this.rbInativo.UseVisualStyleBackColor = true;
            // 
            // rbAtivo
            // 
            this.rbAtivo.AutoSize = true;
            this.rbAtivo.Checked = true;
            this.rbAtivo.Location = new System.Drawing.Point(6, 24);
            this.rbAtivo.Name = "rbAtivo";
            this.rbAtivo.Size = new System.Drawing.Size(60, 23);
            this.rbAtivo.TabIndex = 0;
            this.rbAtivo.TabStop = true;
            this.rbAtivo.Text = "Ativo";
            this.rbAtivo.UseVisualStyleBackColor = true;
            // 
            // gbCategoria
            // 
            this.gbCategoria.Controls.Add(this.cbCategoria);
            this.gbCategoria.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCategoria.Location = new System.Drawing.Point(15, 71);
            this.gbCategoria.Name = "gbCategoria";
            this.gbCategoria.Size = new System.Drawing.Size(167, 64);
            this.gbCategoria.TabIndex = 6;
            this.gbCategoria.TabStop = false;
            this.gbCategoria.Text = "Categoria:";
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(21, 26);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(130, 27);
            this.cbCategoria.TabIndex = 2;
            // 
            // btRelatorio
            // 
            this.btRelatorio.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRelatorio.Image = ((System.Drawing.Image)(resources.GetObject("btRelatorio.Image")));
            this.btRelatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRelatorio.Location = new System.Drawing.Point(436, 19);
            this.btRelatorio.Name = "btRelatorio";
            this.btRelatorio.Size = new System.Drawing.Size(155, 46);
            this.btRelatorio.TabIndex = 3;
            this.btRelatorio.Text = "        Gerar Relatório";
            this.btRelatorio.UseVisualStyleBackColor = true;
            this.btRelatorio.Click += new System.EventHandler(this.btRelatorio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selecione o Tipo de Relatório:";
            // 
            // classProdutoBindingSource
            // 
            this.classProdutoBindingSource.DataSource = typeof(loja_jd_modas.classProduto);
            // 
            // formRelatorioProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 677);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rptvProduto);
            this.Name = "formRelatorioProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loja J.D Modas - Relatório de Produtos";
            this.Load += new System.EventHandler(this.formRelatorioProduto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbEstoque.ResumeLayout(false);
            this.gbEstoque.PerformLayout();
            this.gbValor.ResumeLayout(false);
            this.gbValor.PerformLayout();
            this.gbTamanho.ResumeLayout(false);
            this.gbMarca.ResumeLayout(false);
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.gbCategoria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.classProdutoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptvProduto;
        private System.Windows.Forms.BindingSource classProdutoBindingSource;
        private System.Windows.Forms.ComboBox cbTipo_relatorio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbEstoque;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.GroupBox gbValor;
        private System.Windows.Forms.TextBox txtValor2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValor1;
        private System.Windows.Forms.GroupBox gbTamanho;
        private System.Windows.Forms.ComboBox cbTamanho;
        private System.Windows.Forms.GroupBox gbMarca;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.RadioButton rbInativo;
        private System.Windows.Forms.RadioButton rbAtivo;
        private System.Windows.Forms.GroupBox gbCategoria;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Button btRelatorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}