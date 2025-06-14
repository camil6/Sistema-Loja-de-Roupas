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
    public partial class formRelatorioVenda : Form
    {
        public formRelatorioVenda()
        {
            InitializeComponent();
        }

        private void formRelatorioVenda_Load(object sender, EventArgs e)
        {
            //CARREGAR AS OPÇÕES DE PESQUISA
            cbTipo_relatorio.Items.Add("Periodo de Venda");
            cbTipo_relatorio.Items.Add("Cliente");
            cbTipo_relatorio.Items.Add("Funcionário");
            cbTipo_relatorio.Items.Add("Periodo de Venda por Funcionario");

            //DEIXAR SELECIONADA UMA OPÇÃO
            cbTipo_relatorio.SelectedItem = "Periodo de Venda";

            //copiar as combos de fk da de cadastro!!~~~~~~~~~~~~
            //CARREGAR COMBO DE CLIENTE
            classCliente cCliente = new classCliente();
            cbCliente.DataSource = cCliente.BuscarCliente();
            cbCliente.DisplayMember = "nome";
            cbCliente.ValueMember = "id_cliente";
            cbCliente.SelectedIndex = -1;

            //CARREGAR COMBO DE FUNCIONARIO
            classFuncionario cFuncionario = new classFuncionario();
            cbFuncionario.DataSource = cFuncionario.BuscarFuncionario();
            cbFuncionario.DisplayMember = "nome";
            cbFuncionario.ValueMember = "id_funcionario";
            cbFuncionario.SelectedIndex = -1;

        }

        private void cbTipo_relatorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dar 2 clicks na combo de tipo consulta, tambem nomear todas as caixinhas do form
            //ATIVAR/DESATIVAR OS ELEMENTOS DO FORM CONFORME A ESCOLHA DO USUARIO

            //periodo venda
            if (cbTipo_relatorio.SelectedIndex == 0)
            {
                gbPeriodo_venda.Enabled = true;
                cbCliente.Enabled = false;
                lbCliente.Enabled = false;
                cbFuncionario.Enabled = false;
                lbFuncionario.Enabled = false;

            }

            //cliente
            if (cbTipo_relatorio.SelectedIndex == 1)
            {
                gbPeriodo_venda.Enabled = false;
                cbCliente.Enabled = true;
                lbCliente.Enabled = true;
                cbFuncionario.Enabled = false;
                lbFuncionario.Enabled = false;

            }

            //funcionario
            if (cbTipo_relatorio.SelectedIndex == 2)
            {
                gbPeriodo_venda.Enabled = false;
                cbCliente.Enabled = false;
                lbCliente.Enabled = false;
                cbFuncionario.Enabled = true;
                lbFuncionario.Enabled = true;

            }

            //funcionario por periodo
            if (cbTipo_relatorio.SelectedIndex == 3)
            {
                gbPeriodo_venda.Enabled = true;
                cbCliente.Enabled = false;
                lbCliente.Enabled = false;
                cbFuncionario.Enabled = true;
                lbFuncionario.Enabled = true;
            }
        }

        private void btRelatorio_Click(object sender, EventArgs e)
        {
            //INSTANCIAR A CLASSE PARA USAR OS METODOS DE CONSULTA
            classRelatorioVenda cRelatorioVenda = new classRelatorioVenda();

            //CRIAR UMA VARIAVEL PARA RECEBER A OPÇAO ESCOLHIDA PELO USUARIO NA COMBO
            string relatorio = cbTipo_relatorio.SelectedItem.ToString();

            switch(relatorio)
            {
                //Periodode venda
                case "Periodo de Venda":
                    if(dtpInicio.Text != "" && dtpFinal.Text != "")
                    {
                        //se não aparecer o binding source- ir no formulario - clicar na setinha do reportviwer - e ligar com o binding source 
                        //datasource le select
                        classRelatorioVendaBindingSource.DataSource = cRelatorioVenda.RelVendaDetalhadoPeriodo(Convert.ToDateTime(dtpInicio.Text), Convert.ToDateTime(dtpFinal.Text));

                        //APÓS CHAMAR O METODO, VAI CHAMAR O RELATORIO e dar reflesh na sua exibição
                        this.reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Favor preencher as 2 datas.", "Sistema Loja Cosmeticos - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case "Cliente":
                    {
                        if(cbCliente.SelectedIndex != -1)
                        {
                            classRelatorioVendaBindingSource.DataSource = cRelatorioVenda.RelVendaCliente(Convert.ToInt32(cbCliente.SelectedValue));

                            //APÓS CHAMAR O METODO, VAI CHAMAR O RELATORIO e dar reflesh na sua exibição
                            this.reportViewer1.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("Favor selecionar um cliente.", "Sistema Loja Cosmeticos - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    break;

                case "Funcionário":
                    {
                        if(cbFuncionario.SelectedIndex != -1)
                        {
                            classRelatorioVendaBindingSource.DataSource = cRelatorioVenda.RelVendaFuncionario(Convert.ToInt32(cbFuncionario.SelectedValue));

                            //APÓS CHAMAR O METODO, VAI CHAMAR O RELATORIO e dar reflesh na sua exibição
                            this.reportViewer1.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("Favor selecionar um funcionário.", "Sistema Loja Cosmeticos - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    }

                case "Periodo de Venda por Funcionario":
                    {
                        if(cbFuncionario.SelectedIndex != -1 && dtpInicio.Text != "" && dtpFinal.Text != "")
                        {
                            classRelatorioVendaBindingSource.DataSource = cRelatorioVenda.RelVendaFuncionarioPeriodo(Convert.ToInt32(cbFuncionario.SelectedValue), Convert.ToDateTime(dtpInicio.Text), Convert.ToDateTime(dtpFinal.Text));

                            //APÓS CHAMAR O METODO, VAI CHAMAR O RELATORIO e dar reflesh na sua exibição
                            this.reportViewer1.RefreshReport();
                        }
                        else
                        {
                            MessageBox.Show("Favor selecionar um funcionário e preencher as 2 datas.", "Sistema Loja Cosmeticos - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    break;


            }





        }
    }
}
