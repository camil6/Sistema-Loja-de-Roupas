using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loja_jd_modas
{
    public partial class formRelatorioMarca : Form
    {
        public formRelatorioMarca()
        {
            InitializeComponent();
        }

        private void formRelatorioMarca_Load(object sender, EventArgs e)
        {
            classMarca cMarca = new classMarca();
            //se não aparecer o binding source- ir no formulario - clicar na setinha do reportviwer - e ligar com o binding source 
            //datasource le select
            classMarcaBindingSource.DataSource = cMarca.RelatorioMarca();
            this.rptMarca.RefreshReport();
        }
    }
}
