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
    public partial class formRelatorioTamanho : Form
    {
        public formRelatorioTamanho()
        {
            InitializeComponent();
        }

        private void formRelatorioTamanho_Load(object sender, EventArgs e)
        {
            classTamanho cTamanho = new classTamanho();
            //se não aparecer o binding source- ir no formulario - clicar na setinha do reportviwer - e ligar com o binding source 
            //datasource le select
            classTamanhoBindingSource.DataSource = cTamanho.RelatorioTamanho();
            this.rptvTamanho.RefreshReport();
        }
    }
}
