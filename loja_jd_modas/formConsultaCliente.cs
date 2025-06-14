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
    public partial class formConsultaCliente : Form
    {
        public formConsultaCliente()
        {
            InitializeComponent();
        }

        //PASSO 7 PROGRAMAR O LOAD DO FORMULÁRIO DE CONSULTA (CARREGAR AS COMBOS);
        private void formConsultaCliente_Load(object sender, EventArgs e)
        {

            cbTipo_consulta.Items.Add("CPF");
            cbTipo_consulta.Items.Add("Nome");
            cbTipo_consulta.Items.Add("Sexo");
            cbTipo_consulta.Items.Add("Status");

            //DEIXAR A OPÇÃO SELECIONADA

            cbTipo_consulta.SelectedItem = "Nome";


            cbSexo.Items.Add("Escolha um Sexo");
            cbSexo.Items.Add("Masculino");
            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Outro");

            cbSexo.SelectedItem = "Escolha um Sexo";


            //Status
            rbativo.Checked = true;

        }

        private void cbopcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ATIVAR/DESATIVAR OS ELEMENTOS DO FORM CONFORME A ESCOLHA DO USUÁRIO

            //CPF
            if (cbTipo_consulta.SelectedIndex == 0)
            {
                txtPesquisar.Enabled = false;
                gbtipopesquisa.Enabled = false;
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                gbcpf.Enabled = true;

            }

            //NOME
            if (cbTipo_consulta.SelectedIndex == 1)
            {
                txtPesquisar.Enabled = true;
                gbtipopesquisa.Enabled = true;
                cbSexo.Enabled = false;
                gbStatus.Enabled = false;
                gbcpf.Enabled = false;

            }

            //SEXO
            if (cbTipo_consulta.SelectedIndex == 2)
            {
                txtPesquisar.Enabled = false;
                gbtipopesquisa.Enabled = false;
                cbSexo.Enabled = true;
                gbStatus.Enabled = false;
                gbcpf.Enabled = false;

            }

            //STATUS
            if (cbTipo_consulta.SelectedIndex == 3)
            {
                txtPesquisar.Enabled = false;
                gbtipopesquisa.Enabled = false;
                cbSexo.Enabled = false;
                gbStatus.Enabled = true;
                gbcpf.Enabled = false;

            }

        }

        private void btpesquisar_Click(object sender, EventArgs e)
        {
            //INSTANCIAR A CLASSE CLIENTE PARA OS MÉTODOS DE CONSULTA
            classCliente cCliente = new classCliente();

            //CRIAR UMA VARIAVEL PARA RECEBER A OPÇÃO ESCOLHIDA DO USUÁRIO NA COMBO
            string consulta = cbTipo_consulta.SelectedItem.ToString();

            switch (consulta)
            {
                //CPF
                case "CPF":
                    if (mskcpf.Text == "   .   .   -")
                    {
                        dgvcliente.DataSource = cCliente.ConsultaClienteCPF(mskcpf.Text);
                    }
                    else
                    {
                        dgvcliente.DataSource = cCliente.ConsultaClienteCPF(mskcpf.Text);

                    }
                    break;

                //NOME
                case "Nome":
                    if (txtPesquisar.Text != "")
                    {
                        if (rbinicio.Checked == true)
                        {
                            dgvcliente.DataSource = cCliente.ConsultaClienteInicio(txtPesquisar.Text);
                        }
                        else //CAMPOS PESQUISAR VALIDAÇÃO
                        {
                            dgvcliente.DataSource = cCliente.ConsultaClienteContem(txtPesquisar.Text);
                        }
                    }

                    else //CAMPOS DE PESQUISAR VALIDAÇÃO
                    {
                        MessageBox.Show("Favor informar um nome", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case "Sexo":
                   
                        if (Convert.ToString(cbSexo.SelectedItem) == "Feminino")
                        {
                            dgvcliente.DataSource = cCliente.ConsultaClienteSexo("Feminino");
                        }
                        else if (Convert.ToString(cbSexo.SelectedItem) == "Masculino")
                        {
                            dgvcliente.DataSource = cCliente.ConsultaClienteSexo("Masculino");
                        }
                        else
                        {
                            dgvcliente.DataSource = cCliente.ConsultaClienteSexo("Outro");
                        }

                    break;
                   

                
                //STATUS
                case "Status":
                    if (rbativo.Checked == true)
                    {
                        dgvcliente.DataSource = cCliente.ConsultaClienteStatus(1);
                    }
                    else
                    {
                        dgvcliente.DataSource = cCliente.ConsultaClienteStatus(0);
                    }
                    break;



            }


        }




        //12- CLICAR NA GRID DE CLIENTES E EDITAR OU EXCLUIR UM CLIENTE
        //USAR O EVENTO CellClick (PODE CLICAR EM QUALQUER LUGAR NA CÉLULAR, NÃO SOMENTE NO TEXTO)
        //USANDO O EVENTO CellContentClick (TEM QUE CLICAR NO CONTÉUDO(TEXTO))
 
        private void btsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvcliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //NÃO DEIXAR SELECIONAR A GRID QUANDO VAZIA
            if (dgvcliente.Rows.Count > 0)
            {
                if (MessageBox.Show("Deseja alterar o cliente selecionado?", "Sistema Loja J.D Modas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //INSTANCIAR A CLASSE CLIENTE PARA USAR MÉTODOS E PROPRIEDADES
                    classCliente cCliente = new classCliente();

                    //INSTANCIAR O FORMULARIO DE CADASTRO/ATUALIZAÇÃO DE CLIENTE PARA USAR OS CONTROLES DO FORM
                    formClientecs fCliente = new formClientecs();

                    //PEGAR O CODIGO DO CLIENTE SELECIONADO PELO USUARIO NA GRID
                    cCliente.ConsultarCliente(Convert.ToInt32(dgvcliente.SelectedRows[0].Cells[0].Value));

                    //PASSAR OS DADOS DO BD PARA OS CONTROLES DO FORM DE CLIENTES
                    fCliente.txtCodigo_do_cliente.Text = cCliente.id_cliente.ToString();
                    fCliente.txtNome.Text = cCliente.nome.ToString();
                    fCliente.mskCPF.Text = cCliente.cpf.ToString();
                    fCliente.mskData_nascimento.Text = cCliente.data_nascimento.ToString();
                    fCliente.sexo = cCliente.sexo.ToString();
                    fCliente.txtEmail.Text = cCliente.email.ToString();
                    fCliente.mskRG.Text = cCliente.rg.ToString();
                    fCliente.mskTelefone.Text = cCliente.telefone.ToString();
                    fCliente.mskCelular.Text = cCliente.celular.ToString();
                    fCliente.mskCEP.Text = cCliente.cep.ToString();
                    fCliente.txtRua.Text = cCliente.rua.ToString();
                    fCliente.txtBairro.Text = cCliente.bairro.ToString();
                    fCliente.txtNumero.Text = cCliente.numero.ToString();
                    fCliente.txtCidade.Text = cCliente.cidade.ToString();
                    fCliente.estado = cCliente.estado.ToString();
                    fCliente.txtComplemento.Text = cCliente.complemento.ToString();
                    fCliente.datacad = cCliente.data_cadastro;


                    if (cCliente.status == 1)
                    {
                        fCliente.ckbStatus.Checked = true;
                    }
                    else
                    {
                        fCliente.ckbStatus.Checked = false;
                    }

                    //MANDAR A INFORMAÇÃO DE UPDATE
                    fCliente.tipo = "Atualização";
                    //ABRIR O FORMULARIO DE CADASTRO EM MODO EXCLUSIVO
                    fCliente.ShowDialog();
                    //CHAMAR METODO DE PESQUISAR
                    btpesquisar_Click(this, new EventArgs());


                }
            }
        }

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }

}
