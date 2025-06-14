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
    public partial class formFuncionario : Form
    {
        public formFuncionario()
        {
            InitializeComponent();
        }

        //VARIÁVEL tipo: GUARDAR COMO O FORMULARIO DEVE SER ABERTO SE PARA CADASTRO OU ATUALIZAÇÃO/EXCLUSÃO
        public string tipo, sexo, cargo;

        //VARIÁVEL datacad: MOSTRAR INFORMAÇÃO GUARDADA NO BD E NÃO DATA ATUAL COMO PROGRAMADO NO LOAD DO FORM
        public DateTime datacad;




        private void Limpar()
        {
            txtNome.Clear();
            mskCPF.Clear();
            mskData_nascimento.Clear();
            txtEmail.Clear();
            txtSalario.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtTipo_acesso.Clear();

        }

        
        private void bt_Cadastrar_Click(object sender, EventArgs e)
        {

            if (txtNome.Text != "" && mskData_nascimento.Text != "  /  /" && mskCPF.Text != "000,000,000-00" && txtEmail.Text != "" && cbSexo.Text != "" && txtSalario.Text != "" && (msktelefone.Text != "(  )     -" || mskcelular.Text != "(  )      -") && txtTipo_acesso.Text != "" && txtLogin.Text != "" && txtSenha.Text != "")
            {
                classFuncionario cFuncionario = new classFuncionario();
                cFuncionario.nome = txtNome.Text;
                cFuncionario.data_nascimento = Convert.ToDateTime(mskData_nascimento.Text);
                cFuncionario.cpf = mskCPF.Text;
                cFuncionario.email = txtEmail.Text;
                cFuncionario.sexo = cbSexo.SelectedItem.ToString();
                cFuncionario.salario = Convert.ToDecimal(txtSalario.Text);
                cFuncionario.tipo_acesso = txtTipo_acesso.Text;
                cFuncionario.login = txtLogin.Text;
                cFuncionario.senha = txtSenha.Text;
                //FK
                cFuncionario.id_cargo = Convert.ToInt32(cbCargo.SelectedValue);


                if (msktelefone.Text != "(  )     -")
                {
                    cFuncionario.telefone = msktelefone.Text;
                }
                else
                {
                    cFuncionario.telefone = "";
                }

                if (mskcelular.Text != "(  )      -")
                {
                    cFuncionario.celular = mskcelular.Text;
                }
                else
                {
                    cFuncionario.celular = "";
                }


                int resp = cFuncionario.CadastroFuncionario();

                if (resp == 1)
                {

                    MessageBox.Show("Funcionário: " + cFuncionario.nome + " Cadastrado com Sucesso", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();


                }
                else
                {
                    MessageBox.Show("Erro ao realizar o cadastro", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            else
            {
                MessageBox.Show("FAVOR PREENCHER TODOS OS CAMPOS OBRIGATÓRIOS", "Sistema Loja J.D Modas - ATENÇÃO:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtNome.BackColor = Color.LemonChiffon;
                mskCPF.BackColor = Color.LemonChiffon;
                mskData_nascimento.BackColor = Color.LemonChiffon;
                cbSexo.BackColor = Color.LemonChiffon;
                txtEmail.BackColor = Color.LemonChiffon;
                lbData.BackColor = Color.LemonChiffon;
                txtEmail.BackColor = Color.LemonChiffon;
                txtSalario.BackColor = Color.LemonChiffon;
                txtTipo_acesso.BackColor = Color.LemonChiffon;
                txtLogin.BackColor = Color.LemonChiffon;
                txtSenha.BackColor = Color.LemonChiffon;
                



                txtNome.Focus();





            }
        }

        private void formFuncionario_Load(object sender, EventArgs e)
        {

            cbSexo.Sorted = true;
            cbSexo.Items.Add("Masculino");
            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Outro");


            classCargo cCargo = new classCargo();
            cbCargo.DataSource = cCargo.BuscarCargo();
            cbCargo.DisplayMember = "nome";
            cbCargo.ValueMember = "id_cargo";
            cbCargo.SelectedIndex = -1;


            //11-
            if (tipo == "Atualização")
            {
                bt_Cadastrar.Enabled = false;
                cbCargo.SelectedValue = cargo;
                lbtitulo.Text = "Atualização de Funcionario";
                bt_Cadastrar.Enabled = false;
                ckbstatus.Enabled = true;
                panel.Enabled = true;
                cbSexo.SelectedItem = sexo;
                lbData.Text = datacad.ToString();
            }

            else
            {
                btAtualizar.Enabled = false;
                btExcluir.Enabled = false;

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

            
        private void btExcluir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja excluir o Funcionario?", "Sistema Loja J.D Modas!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                classFuncionario cFuncionario = new classFuncionario();
                cFuncionario.id_funcionario = Convert.ToInt32(txtcodigo_funcionario.Text);

                bool resp = cFuncionario.ExcluirFuncionario();

                if (resp == true)
                {
                    MessageBox.Show("Funcionario" + cFuncionario.nome + " Excluido com sucesso.", "Sistema Loja de Cosméticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este Funcionario não pode ser excluido, há registros em outras tabelas.", "Sistema Loja de Cosméticos!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }






            }
        }   
        private void btAtualizar_Click(object sender, EventArgs e)
        {

            if (txtNome.Text != "" && mskData_nascimento.Text != "  /  /" && mskCPF.Text != "000,000,000-00" && txtEmail.Text != "" && cbSexo.Text != "" && txtSalario.Text != "" && (msktelefone.Text != "(  )     -" || mskcelular.Text != "(  )      -") && txtTipo_acesso.Text != "" && txtLogin.Text != "" && txtSenha.Text != "")
            {
                classFuncionario cFuncionario = new classFuncionario();
                cFuncionario.nome = txtNome.Text;
                cFuncionario.data_nascimento = Convert.ToDateTime(mskData_nascimento.Text);
                cFuncionario.cpf = mskCPF.Text;
                cFuncionario.email = txtEmail.Text;
                cFuncionario.sexo = cbSexo.SelectedItem.ToString();
                cFuncionario.salario = Convert.ToDecimal(txtSalario.Text);
                cFuncionario.tipo_acesso = txtTipo_acesso.Text;
                cFuncionario.login = txtLogin.Text;
                cFuncionario.senha = txtSenha.Text;
                cFuncionario.id_funcionario = Convert.ToInt32(txtcodigo_funcionario.Text);
                //FK
                cFuncionario.id_cargo = Convert.ToInt32(cbCargo.SelectedValue);


                if (msktelefone.Text != "(  )     -")
                {
                    cFuncionario.telefone = msktelefone.Text;
                }
                else
                {
                    cFuncionario.telefone = "";
                }

                if (mskcelular.Text != "(  )      -")
                {
                    cFuncionario.celular = mskcelular.Text;
                }
                else
                {
                    cFuncionario.celular = "";
                }


                //STATUS
                if (ckbstatus.Checked == true)
                {
                    cFuncionario.status = 1;
                }
                else
                {
                    cFuncionario.status = 0;
                }


                bool resp = cFuncionario.AtualizarFuncionario();

                if (resp)
                {

                    MessageBox.Show("Funcionário: " + cFuncionario.nome + " Atualizado com Sucesso", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();


                }
                else
                {
                    MessageBox.Show("Erro ao Atualizar o Funcionario", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

            else
            {
                MessageBox.Show("FAVOR PREENCHER TODOS OS CAMPOS OBRIGATÓRIOS", "Sistema Loja J.D Modas - ATENÇÃO:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtNome.BackColor = Color.LemonChiffon;
                mskCPF.BackColor = Color.LemonChiffon;
                mskData_nascimento.BackColor = Color.LemonChiffon;
                cbSexo.BackColor = Color.LemonChiffon;
                txtEmail.BackColor = Color.LemonChiffon;
                lbData.BackColor = Color.LemonChiffon;
                txtEmail.BackColor = Color.LemonChiffon;
                txtSalario.BackColor = Color.LemonChiffon;
                txtTipo_acesso.BackColor = Color.LemonChiffon;
                txtLogin.BackColor = Color.LemonChiffon;
                txtSenha.BackColor = Color.LemonChiffon;

                txtNome.Focus();
            }



        }

        //VALIDAR DATA DA MASCARA - eventos - typeValidationCompleted
        private void mskData_nascimento_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MessageBox.Show("Data Inválida.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskData_nascimento.Clear();
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Tudo menos espaço
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtTipo_acesso_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Tudo menos espaço
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Tudo menos espaço
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Numeros com virgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44)
                e.Handled = true;

        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Tudo menos espaço
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) &&  !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }

    }
}
