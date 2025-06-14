
namespace loja_jd_modas
{
    partial class formRelatorioCargo
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
            this.classCargoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptvCargo = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.classCargoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // classCargoBindingSource
            // 
            this.classCargoBindingSource.DataSource = typeof(loja_jd_modas.classCargo);
            // 
            // rptvCargo
            // 
            this.rptvCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "datasetCargo";
            reportDataSource1.Value = this.classCargoBindingSource;
            this.rptvCargo.LocalReport.DataSources.Add(reportDataSource1);
            this.rptvCargo.LocalReport.ReportEmbeddedResource = "loja_jd_modas.rptCargo.rdlc";
            this.rptvCargo.Location = new System.Drawing.Point(0, 0);
            this.rptvCargo.Name = "rptvCargo";
            this.rptvCargo.ServerReport.BearerToken = null;
            this.rptvCargo.Size = new System.Drawing.Size(800, 450);
            this.rptvCargo.TabIndex = 0;
            // 
            // formRelatorioCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rptvCargo);
            this.Name = "formRelatorioCargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loja J.D Modas - Relatório de Cargos";
            this.Load += new System.EventHandler(this.formRelatorioCargo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.classCargoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptvCargo;
        private System.Windows.Forms.BindingSource classCargoBindingSource;
    }
}