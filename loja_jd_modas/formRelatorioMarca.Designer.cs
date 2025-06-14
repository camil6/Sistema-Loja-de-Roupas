
namespace loja_jd_modas
{
    partial class formRelatorioMarca
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
            this.classMarcaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptMarca = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.classMarcaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // classMarcaBindingSource
            // 
            this.classMarcaBindingSource.DataSource = typeof(loja_jd_modas.classMarca);
            // 
            // rptMarca
            // 
            this.rptMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetMarca";
            reportDataSource1.Value = this.classMarcaBindingSource;
            this.rptMarca.LocalReport.DataSources.Add(reportDataSource1);
            this.rptMarca.LocalReport.ReportEmbeddedResource = "loja_jd_modas.rptMarca.rdlc";
            this.rptMarca.Location = new System.Drawing.Point(0, 0);
            this.rptMarca.Name = "rptMarca";
            this.rptMarca.ServerReport.BearerToken = null;
            this.rptMarca.Size = new System.Drawing.Size(800, 379);
            this.rptMarca.TabIndex = 0;
            // 
            // formRelatorioMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 379);
            this.Controls.Add(this.rptMarca);
            this.Name = "formRelatorioMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loja J.D Modas - Relatório de Marcas";
            this.Load += new System.EventHandler(this.formRelatorioMarca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.classMarcaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptMarca;
        private System.Windows.Forms.BindingSource classMarcaBindingSource;
    }
}