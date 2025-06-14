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
    public partial class formRelatorioCargo : Form
    {
        public formRelatorioCargo()
        {
            InitializeComponent();
        }

        private void formRelatorioCargo_Load(object sender, EventArgs e)
        {
            classCargo cCargo = new classCargo();
            //Caso nao apareça o binding source ir na setinha do relatorio e colocar
            classCargoBindingSource.DataSource = cCargo.RelatorioCargo(); 

            this.rptvCargo.RefreshReport();

            
        }
    }
}
