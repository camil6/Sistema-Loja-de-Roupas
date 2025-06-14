
namespace loja_jd_modas
{
    partial class formRelatorioCategoria
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
            this.classCategoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptvCategoria = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.classCategoriaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // classCategoriaBindingSource
            // 
            this.classCategoriaBindingSource.DataSource = typeof(loja_jd_modas.classCategoria);
            // 
            // rptvCategoria
            // 
            this.rptvCategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "datasetCategoria";
            reportDataSource1.Value = this.classCategoriaBindingSource;
            this.rptvCategoria.LocalReport.DataSources.Add(reportDataSource1);
            this.rptvCategoria.LocalReport.ReportEmbeddedResource = "loja_jd_modas.rptCategoria.rdlc";
            this.rptvCategoria.Location = new System.Drawing.Point(0, 0);
            this.rptvCategoria.Name = "rptvCategoria";
            this.rptvCategoria.ServerReport.BearerToken = null;
            this.rptvCategoria.Size = new System.Drawing.Size(800, 450);
            this.rptvCategoria.TabIndex = 0;
            // 
            // formRelatorioCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptvCategoria);
            this.Name = "formRelatorioCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loja J.D Modas - Relatório de Categorias";
            this.Load += new System.EventHandler(this.formRelatorioCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.classCategoriaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptvCategoria;
        private System.Windows.Forms.BindingSource classCategoriaBindingSource;
    }
}