
namespace loja_jd_modas
{
    partial class formRelatorioTamanho
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
            this.classTamanhoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptvTamanho = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.classTamanhoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // classTamanhoBindingSource
            // 
            this.classTamanhoBindingSource.DataSource = typeof(loja_jd_modas.classTamanho);
            // 
            // rptvTamanho
            // 
            this.rptvTamanho.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetTamanho";
            reportDataSource1.Value = this.classTamanhoBindingSource;
            this.rptvTamanho.LocalReport.DataSources.Add(reportDataSource1);
            this.rptvTamanho.LocalReport.ReportEmbeddedResource = "loja_jd_modas.rptvTamanho.rdlc";
            this.rptvTamanho.Location = new System.Drawing.Point(0, 0);
            this.rptvTamanho.Name = "rptvTamanho";
            this.rptvTamanho.ServerReport.BearerToken = null;
            this.rptvTamanho.Size = new System.Drawing.Size(800, 450);
            this.rptvTamanho.TabIndex = 0;
            // 
            // formRelatorioTamanho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptvTamanho);
            this.Name = "formRelatorioTamanho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loja J.D Modas - Relatório de Tamanhos";
            this.Load += new System.EventHandler(this.formRelatorioTamanho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.classTamanhoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptvTamanho;
        private System.Windows.Forms.BindingSource classTamanhoBindingSource;
    }
}