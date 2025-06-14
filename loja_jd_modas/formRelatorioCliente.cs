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
    public partial class formRelatorioCliente : Form
    {
        public formRelatorioCliente()
        {
            InitializeComponent();
        }

        private void formRelatorioCliente_Load(object sender, EventArgs e)
        {
            

            //CARREGAR COMBO TIPO DE RELATÓRIO

            cbTipoRel.Items.Add("Aniversariantes do Mês");
            cbTipoRel.Items.Add("Aniversariantes Maiores de");
            cbTipoRel.Items.Add("Cidade");
            cbTipoRel.Items.Add("Sexo");
            cbTipoRel.Items.Add("Status");
            cbTipoRel.SelectedIndex = 4;

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
            
            cbSexo.SelectedIndex = 0;

            //CARREGAR COMBO DE CIDADE DO BANCO DE DADOS - TABELA CLIENTE
            classCliente cCliente = new classCliente();
            cbCidade.DataSource = cCliente.BuscarCidade(); // EXECUTAR MÉTODO DE CONSULTA CRIADO NA CLASSE CLIENTE
            cbCidade.DisplayMember = "Cidade"; // EXIBIR NA COMBO (CIDADE)
            cbCidade.ValueMember = "Cidade"; // GUARDAR NO BD (CIDADE)
            cbCidade.SelectedIndex = -1;
            this.rptvCliente.RefreshReport();





        }


        private void cbTipoRel_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cbTipoRel.SelectedIndex == 0) //Aniversariantes do mês
            {
                gbAniversariantes.Enabled = true;
                gbIdadeMaior.Enabled = false;
                gbStatus.Enabled = false;
                cbCidade.Enabled = false;
                cbSexo.Enabled = false;
            }
           

            if (cbTipoRel.SelectedIndex == 1) //Aniversariantes Maiores de 
            {
                gbAniversariantes.Enabled = false;
                gbIdadeMaior.Enabled = true;
                gbStatus.Enabled = false;
                cbCidade.Enabled = false;
                cbSexo.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 2) //Cidade
            {
                gbAniversariantes.Enabled = false;
                gbIdadeMaior.Enabled = false;
                gbStatus.Enabled = false;
                cbCidade.Enabled = true;
                cbSexo.Enabled = false;
            }

            if (cbTipoRel.SelectedIndex == 3) //Sexo
            {
                gbAniversariantes.Enabled = false;
                gbIdadeMaior.Enabled = false;
                gbStatus.Enabled = false;
                cbCidade.Enabled = false;
                cbSexo.Enabled = true;
            }

            if (cbTipoRel.SelectedIndex == 4) //Status
            {
                gbAniversariantes.Enabled = false;
                gbIdadeMaior.Enabled = false;
                gbStatus.Enabled = true;
                cbCidade.Enabled = false;
                cbSexo.Enabled = false;
            }
        }

        private void btGerarRelatorio_Click(object sender, EventArgs e)
        {
            classCliente cCliente = new classCliente();

            string relatorio = cbTipoRel.SelectedItem.ToString();


            switch (relatorio)
            {

                


                case "Aniversariantes do Mês":
                    if (cbMes.SelectedItem != "Escolha um Mês")
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteMes(Convert.ToInt32(cbMes.SelectedIndex));
                        this.rptvCliente.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar um Mês", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;


                case "Aniversariantes Maiores de":
                    if (txtIdadeMaior.Text != "")
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteMaiorDe(Convert.ToInt32(txtIdadeMaior.Text));
                        this.rptvCliente.RefreshReport();

                    }
                    else
                    {
                        MessageBox.Show("Favor preencher a idade", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    break;

                case "Cidade":
                    if (cbCidade.SelectedIndex != -1)
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteCidade(cbCidade.SelectedValue.ToString());
                        this.rptvCliente.RefreshReport();

                    }
                    else
                    {
                        MessageBox.Show("Favor escolher uma cidade", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    break;

                case "Sexo":

                    if (cbSexo.SelectedItem == "Feminino")
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteSexo("Feminino");
                        this.rptvCliente.RefreshReport();
                    }
                    else if (cbSexo.SelectedItem == "Masculino")
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteSexo("Masculino");
                        this.rptvCliente.RefreshReport();
                    }
                    else 
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteSexo("Outro");
                        this.rptvCliente.RefreshReport();
                    }
                    break;


                case "Status":
                    if (rbAtivo.Checked == true)
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteStatus(1);
                        this.rptvCliente.RefreshReport();
                    }
                    else
                    {
                        classClienteBindingSource.DataSource = cCliente.RelatorioClienteStatus(0);
                        this.rptvCliente.RefreshReport();
                    }
                    break;







            }
        }

        //ESCREVER APENAS NUMEROS NO TXT - eventos - TextChanged
        private void txtIdadeMaior_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtIdadeMaior.Text, "[^0-9]"))
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
