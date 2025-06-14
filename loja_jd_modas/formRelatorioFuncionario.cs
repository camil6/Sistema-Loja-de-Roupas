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
    public partial class formRelatorioFuncionario : Form
    {
        public formRelatorioFuncionario()
        {
            InitializeComponent();
        }

        private void formRelatorioFuncionario_Load(object sender, EventArgs e)
        {

            //CARREGAR COMBO TIPO DE RELATÓRIO


            cbTipoRel.Items.Add("Aniversariantes do Mês");
            cbTipoRel.Items.Add("Cargo");
            cbTipoRel.Items.Add("Sexo");
            cbTipoRel.Items.Add("Status");
            cbTipoRel.Items.Add("Aniversariantes Maiores de");

            cbTipoRel.SelectedItem = "Status";
            
                        

            //CARREGAR COMBO MÊS
            cbMes.Items.Add("Escolha um Mês");
            cbMes.Items.Add("Janeiro");
            cbMes.Items.Add("Fevereiro");
            cbMes.Items.Add("Março");
            cbMes.Items.Add("Abril");
            cbMes.Items.Add("Maio");
            cbMes.Items.Add("Junho");
            cbMes.Items.Add("Julho");
            cbMes.Items.Add("Agosto");
            cbMes.Items.Add("Setembro");
            cbMes.Items.Add("Outubro");
            cbMes.Items.Add("Novembro");
            cbMes.Items.Add("Dezembro");
            cbMes.SelectedIndex = 0;

            

            //CARREGAR COMBO SEXO

            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Masculino");
            cbSexo.Items.Add("Outro");

            cbSexo.SelectedIndex = 2;

            //FK
            classCargo cCargo = new classCargo();
            cbCargo.DataSource = cCargo.BuscarCargo();
            cbCargo.DisplayMember = "nome";
            cbCargo.ValueMember = "id_cargo";
            cbCargo.SelectedIndex = -1;

            this.rptvFuncionario.RefreshReport();
            
        }

        private void cbTipoRel_SelectedIndexChanged(object sender, EventArgs e)
        {

          
            if (cbTipoRel.SelectedIndex == 0) //Aniversariantes do mês
            {
                
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                cbCargo.Enabled = false;
                cbMes.Enabled = true;
                txtIdadeMaior.Enabled = false;

            }

            if (cbTipoRel.SelectedIndex == 1) //Cargo
            {
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                cbCargo.Enabled = true;
                cbMes.Enabled = false;
                txtIdadeMaior.Enabled = false;
            }                            

            if (cbTipoRel.SelectedIndex == 2) //Sexo
            {
                cbSexo.Enabled = true;
                gbStatus.Enabled = false;
                cbCargo.Enabled = false;
                cbMes.Enabled = false;
                txtIdadeMaior.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 3) //Status
            {
                cbSexo.Enabled = false;
                gbStatus.Enabled = true;
                cbCargo.Enabled = false;
                cbMes.Enabled = false;
                txtIdadeMaior.Enabled = false;
            }


            if (cbTipoRel.SelectedIndex == 4) //Aniversariantes Maiores de 
            {
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                cbCargo.Enabled = false;
                cbMes.Enabled = false;
                txtIdadeMaior.Enabled = true;
            }






        }

        private void btGerarRelatorio_Click(object sender, EventArgs e)
        {



            classFuncionario cFuncionario = new classFuncionario();

            string relatorio = cbTipoRel.SelectedItem.ToString();


            switch (relatorio)
            {


                case "Sexo":

                    if (cbSexo.SelectedItem == "Feminino")
                    {
                        classFuncionarioBindingSource.DataSource = cFuncionario.RelatorioFuncionarioSexo("Feminino");
                        this.rptvFuncionario.RefreshReport();
                    }
                    else if (cbSexo.SelectedItem == "Masculino")
                    {
                        classFuncionarioBindingSource.DataSource = cFuncionario.RelatorioFuncionarioSexo("Masculino");
                        this.rptvFuncionario.RefreshReport();
                    }
                    else
                    {
                        classFuncionarioBindingSource.DataSource = cFuncionario.RelatorioFuncionarioSexo("Outro");
                        this.rptvFuncionario.RefreshReport();
                    }
                    break;


                case "Status":
                    if (rbAtivo.Checked == true)
                    {
                        classFuncionarioBindingSource.DataSource = cFuncionario.RelatorioFuncionarioStatus(1);
                        this.rptvFuncionario.RefreshReport();
                    }
                    else
                    {
                        classFuncionarioBindingSource.DataSource = cFuncionario.RelatorioFuncionarioStatus(0);
                        this.rptvFuncionario.RefreshReport();
                    }
                    break;


                case "Cargo":
                    if (cbCargo.Text != "")
                    {
                        classFuncionarioBindingSource.DataSource = cFuncionario.RelatorioFuncionarioCargo(Convert.ToInt32(cbCargo.SelectedValue));
                        this.rptvFuncionario.RefreshReport();

                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar um Cargo", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;


                case "Aniversariantes do Mês":
                    if (cbMes.SelectedItem != "Escolha um Mês")
                    {
                        classFuncionarioBindingSource.DataSource = cFuncionario.RelatorioFuncionarioMes(Convert.ToInt32(cbMes.SelectedIndex));
                        this.rptvFuncionario.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar um Mês", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;



                case "Aniversariantes Maiores de":
                    if (txtIdadeMaior.Text != "")
                    {
                        classFuncionarioBindingSource.DataSource = cFuncionario.RelatorioFuncionarioMaiorDe(Convert.ToInt32(txtIdadeMaior.Text));
                        this.rptvFuncionario.RefreshReport();

                    }
                    else
                    {
                        MessageBox.Show("Favor preencher a idade", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    break;








            }






        
        }

        //ESCREVER APENAS NUMEROS NO TXT - eventos - TextChanged
        private void txtIdadeMaior_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtIdadeMaior.Text, "[^0-9,]"))
            {
                MessageBox.Show("Favor escrever apenas números.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdadeMaior.Text = txtIdadeMaior.Text.Remove(txtIdadeMaior.Text.Length - 1);
            }
        }

        private void txtIdadeMaior_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Numeros

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
