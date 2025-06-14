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
    public partial class formConsultaFuncionario : Form
    {
        public formConsultaFuncionario()
        {
            InitializeComponent();
        }

        private void formConsultaFuncionario_Load(object sender, EventArgs e)
        {

            cbopcoes.Items.Add("CPF");
            cbopcoes.Items.Add("Nome");
            cbopcoes.Items.Add("Sexo");
            cbopcoes.Items.Add("Status");
            cbopcoes.Items.Add("Cargo");


            //DEIXAR A OPÇÃO SELECIONADA

            cbopcoes.SelectedItem = "Nome";

            //SEXO
            cbsexo.Items.Add("Masculino");
            cbsexo.Items.Add("Feminino");
            cbsexo.Items.Add("Outro");

            //CARGO

            classCargo cCargo = new classCargo();
            cbCargo.DataSource = cCargo.BuscarCargo();
            cbCargo.DisplayMember = "nome";
            cbCargo.ValueMember = "id_cargo";
            cbCargo.SelectedIndex = -1;

        }

        private void cbopcoes_SelectedIndexChanged(object sender, EventArgs e)
        {

            //ATIVAR/DESATIVAR OS ELEMENTOS DO FORM CONFORME A ESCOLHA DO USUÁRIO

            //CPF
            if (cbopcoes.SelectedIndex == 0)
            {
                txtPesquisar.Enabled = false;
                gbtipopesquisa.Enabled = false;
                cbsexo.Enabled = false;
                gbstatus.Enabled = false;
                gbcpf.Enabled = true;
                cbCargo.Enabled = false;

            }

            //NOME
            if (cbopcoes.SelectedIndex == 1)
            {
                txtPesquisar.Enabled = true;
                gbtipopesquisa.Enabled = true;
                cbsexo.Enabled = false;
                gbstatus.Enabled = false;
                gbcpf.Enabled = false;
                cbCargo.Enabled = false;

            }

            //SEXO
            if (cbopcoes.SelectedIndex == 2)
            {
                txtPesquisar.Enabled = false;
                gbtipopesquisa.Enabled = false;
                cbsexo.Enabled = true;
                gbstatus.Enabled = false;
                gbcpf.Enabled = false;
                cbCargo.Enabled = false;

            }

            //STATUS
            if (cbopcoes.SelectedIndex == 3)
            {
                txtPesquisar.Enabled = false;
                gbtipopesquisa.Enabled = false;
                cbsexo.Enabled = false;
                gbstatus.Enabled = true;
                gbcpf.Enabled = false;
                cbCargo.Enabled = false;

            }

            //CARGO
            if (cbopcoes.SelectedIndex == 4)
            {
                txtPesquisar.Enabled = false;
                gbtipopesquisa.Enabled = false;
                cbsexo.Enabled = false;
                gbstatus.Enabled = false;
                gbcpf.Enabled = false;
                cbCargo.Enabled = true;

            }

        }

        private void btpesquisar_Click(object sender, EventArgs e)
        {

            //INSTANCIAR A CLASSE CLIENTE PARA OS MÉTODOS DE CONSULTA
            classFuncionario cFuncionario = new classFuncionario();

            //CRIAR UMA VARIAVEL PARA RECEBER A OPÇÃO ESCOLHIDA DO USUÁRIO NA COMBO
            string consulta = cbopcoes.SelectedItem.ToString();

            switch (consulta)
            {
                //CPF
                case "CPF":
                    if (mskcpf.Text == "   .   .   -")
                    {
                        dgvfuncionario.DataSource = cFuncionario.ConsultaFuncionarioCPF(mskcpf.Text);
                    }
                    else
                    {
                        dgvfuncionario.DataSource = cFuncionario.ConsultaFuncionarioCPF(mskcpf.Text);

                    }
                    break;

                //NOME
                case "Nome":
                    if (txtPesquisar.Text != "")
                    {
                        if (rbinicio.Checked == true)
                        {
                            dgvfuncionario.DataSource = cFuncionario.ConsultaFuncionarioInicio(txtPesquisar.Text);
                        }
                        else //CAMPOS PESQUISAR VALIDAÇÃO
                        {
                            dgvfuncionario.DataSource = cFuncionario.ConsultaFuncionarioContem(txtPesquisar.Text);
                        }
                    }

                    else //CAMPOS DE PESQUISAR VALIDAÇÃO
                    {
                        MessageBox.Show("Favor informar um nome", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                case "Sexo":
                    if (cbsexo.SelectedItem == "Feminino")
                    {
                        dgvfuncionario.DataSource = cFuncionario.ConsultaFuncionarioSexo("Feminino");
                    }
                    else if (cbsexo.SelectedItem == "Masculino")
                    {
                        dgvfuncionario.DataSource = cFuncionario.ConsultaFuncionarioSexo("Masculino");
                    }
                    else
                    {
                        dgvfuncionario.DataSource = cFuncionario.ConsultaFuncionarioSexo("Outro");
                    }
                    break;


                //STATUS
                case "Status":
                    if (rbativo.Checked == true)
                    {
                        dgvfuncionario.DataSource = cFuncionario.ConsultaFuncionarioStatus(1);
                    }
                    else
                    {
                        dgvfuncionario.DataSource = cFuncionario.ConsultaFuncionarioStatus(0);
                    }
                    break;


                //CARGO
                case "Cargo":
                    if (cbCargo.Text != "")
                    {
                        dgvfuncionario.DataSource = cFuncionario.ConsultaFuncionarioCargo(Convert.ToInt32(cbCargo.SelectedValue));
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar um cargo.", "Sistema Loja Cosmeticos - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    break;






            }





        }

      

        private void btsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvfuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //NÃO DEIXAR SELECIONAR A GRID QUANDO VAZIA
            if (dgvfuncionario.Rows.Count > 0)
            {
                if (MessageBox.Show("Deseja alterar o funcionario selecionado?", "Sistema Loja J.D Modas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //INSTANCIAR A CLASSE CLIENTE PARA USAR MÉTODOS E PROPRIEDADES
                    classFuncionario cFuncionario = new classFuncionario();

                    //INSTANCIAR O FORMULARIO DE CADASTRO/ATUALIZAÇÃO DE CLIENTE PARA USAR OS CONTROLES DO FORM
                    formFuncionario fFuncionario = new formFuncionario();

                    //PEGAR O CODIGO DO CLIENTE SELECIONADO PELO USUARIO NA GRID
                    cFuncionario.ConsultarFuncionario(Convert.ToInt32(dgvfuncionario.SelectedRows[0].Cells[0].Value));

                    //PASSAR OS DADOS DO BD PARA OS CONTROLES DO FORM DE CLIENTES
                    fFuncionario.txtcodigo_funcionario.Text = cFuncionario.id_funcionario.ToString();
                    fFuncionario.txtNome.Text = cFuncionario.nome.ToString();
                    fFuncionario.mskCPF.Text = cFuncionario.cpf.ToString();
                    fFuncionario.mskData_nascimento.Text = cFuncionario.data_nascimento.ToString();
                    fFuncionario.sexo = cFuncionario.sexo.ToString();
                    fFuncionario.txtEmail.Text = cFuncionario.email.ToString();
                    fFuncionario.msktelefone.Text = cFuncionario.telefone.ToString();
                    fFuncionario.mskcelular.Text = cFuncionario.celular.ToString();
                    fFuncionario.datacad = cFuncionario.data_cadastro;
                    fFuncionario.txtLogin.Text = cFuncionario.login.ToString();
                    fFuncionario.txtSenha.Text = cFuncionario.senha.ToString();
                    fFuncionario.txtTipo_acesso.Text = cFuncionario.tipo_acesso.ToString();
                    fFuncionario.txtSalario.Text = cFuncionario.salario.ToString();
                    //FK
                    fFuncionario.cargo = cFuncionario.id_cargo.ToString();

                    if (cFuncionario.status == 1)
                    {
                        fFuncionario.ckbstatus.Checked = true;
                    }
                    else
                    {
                        fFuncionario.ckbstatus.Checked = false;
                    }

                    //MANDAR A INFORMAÇÃO DE UPDATE
                    fFuncionario.tipo = "Atualização";
                    //ABRIR O FORMULARIO DE CADASTRO EM MODO EXCLUSIVO
                    fFuncionario.ShowDialog();
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
