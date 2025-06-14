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
    public partial class formClientecs : Form
    {
        public formClientecs()
        {
            InitializeComponent();

        }

        //VARIÁVEL tipo: GUARDAR COMO O FORMULARIO DEVE SER ABERTO SE PARA CADASTRO OU ATUALIZAÇÃO/EXCLUSÃO
        //VARIAVEL estado: INFORMAÇÃO E MOSTRADA EM UMA COMBO
        public string tipo, estado,sexo;
        
        //VARIÁVEL datacad: MOSTRAR INFORMAÇÃO GUARDADA NO BD E NÃO DATA ATUAL COMO PROGRAMADO NO LOAD DO FORM
        public DateTime datacad;

        private void Limpar()
        {
            txtNome.Clear();
            mskCPF.Clear();
            mskData_nascimento.Clear();
            txtEmail.Clear();
            mskRG.Clear();
            mskTelefone.Clear();
            mskCelular.Clear();
            mskCEP.Clear();
            txtRua.Clear();
            txtBairro.Clear();
            txtNumero.Clear();
            txtCidade.Clear();
            txtComplemento.Clear();
            

        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {

            if (txtNome.Text != "" && mskCPF.Text != "   .   .   -" && mskData_nascimento.Text != "  /  /" && cbSexo.Text != "" && txtEmail.Text != "" && (mskTelefone.Text != "(  )     -" || mskCelular.Text != "(  )      -") && txtRua.Text != "" && txtNumero.Text != "")
            {
                classCliente cCliente = new classCliente();
                cCliente.nome = txtNome.Text;
                cCliente.cpf = mskCPF.Text;
                cCliente.data_nascimento = Convert.ToDateTime(mskData_nascimento.Text);
                cCliente.sexo = cbSexo.SelectedItem.ToString();
                cCliente.email = txtEmail.Text;
                cCliente.rua = txtRua.Text;
                cCliente.bairro = txtBairro.Text;
                cCliente.numero = Convert.ToInt32(txtNumero.Text);
                cCliente.cidade = txtCidade.Text;
                cCliente.estado = cbEstado.SelectedItem.ToString() ;
                cCliente.complemento = txtComplemento.Text;

                              

                if (mskRG.Text != "  .   .   -")
                {
                    cCliente.rg = mskRG.Text;
                }
                else
                {
                    cCliente.rg = "";
                }

                if (mskTelefone.Text != "(  )     -")
                {
                    cCliente.telefone = mskTelefone.Text;
                }
                else
                {
                    cCliente.telefone = "";
                }

                if (mskCelular.Text != "(  )      -")
                {
                    cCliente.celular = mskCelular.Text;
                }
                else
                {
                    cCliente.celular = "";
                }

                if (mskCEP.Text != "     -")
                {
                    cCliente.cep = mskCEP.Text;
                }
                else
                {
                    cCliente.cep = "";
                }


                int resp = cCliente.CadastroCliente();

                if (resp == 1)
                {
                    MessageBox.Show("Cliente: " + cCliente.nome + " Cadastrado com Sucesso", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                txtRua.BackColor = Color.LemonChiffon;
                txtNumero.BackColor = Color.LemonChiffon;
                lbData.BackColor = Color.LemonChiffon;

                txtNome.Focus();

            }

        }

       

       

        private void formClientecs_Load(object sender, EventArgs e)
        {
            //CARREGAR DATA NA LABEL
            lbData.Text =  DateTime.Now.ToShortDateString(); 

            //CARREGAR COMBO DE ESTADOS
            cbEstado.Sorted = true;
            cbEstado.Items.Add("AC");
            cbEstado.Items.Add("AL");
            cbEstado.Items.Add("AP");
            cbEstado.Items.Add("AM");
            cbEstado.Items.Add("BA");
            cbEstado.Items.Add("CE");
            cbEstado.Items.Add("ES");
            cbEstado.Items.Add("GO");
            cbEstado.Items.Add("MA");
            cbEstado.Items.Add("MT");
            cbEstado.Items.Add("MS");
            cbEstado.Items.Add("MG");
            cbEstado.Items.Add("PA");
            cbEstado.Items.Add("PB");
            cbEstado.Items.Add("PR");
            cbEstado.Items.Add("PE");
            cbEstado.Items.Add("PI");
            cbEstado.Items.Add("RJ");
            cbEstado.Items.Add("RN");
            cbEstado.Items.Add("RS");
            cbEstado.Items.Add("RO");
            cbEstado.Items.Add("RR");
            cbEstado.Items.Add("SC");
            cbEstado.Items.Add("SP");
            cbEstado.Items.Add("SE");
            cbEstado.Items.Add("TO");
            cbEstado.Items.Add("DF");

            cbEstado.SelectedItem = "SP";

            //COMBO DE SEXO
            cbSexo.Sorted = true;
            cbSexo.Items.Add("Masculino");
            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Outro");

            //11-
            if (tipo == "Atualização")
            {
                lbtitulo.Text = "Atualização de Cliente";
                btCadastrar.Enabled = false;
                ckbStatus.Enabled = true;
                cbEstado.SelectedItem = estado;
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

        //BOTAO EXCLUIR
        private void btExcluir_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Deseja excluir o Cliente?", "Sistema Loja J.D Modas!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                classCliente cCliente = new classCliente();
                cCliente.id_cliente = Convert.ToInt32(txtCodigo_do_cliente.Text);

                bool resp = cCliente.ExcluirCliente();

                if (resp == true)
                {
                    MessageBox.Show("Cliente" + cCliente.nome + " excluido com sucesso.", "Sistema Loja de Cosméticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este Cliente não pode ser excluido, há registros em outras tabelas.", "Sistema Loja de Cosméticos!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }






        }

        //BOTAO SAIR
        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        //ESCREVER APENAS NUMEROS NO TXT - eventos - TextChanged
        //private void txtNumero_TextChanged(object sender, EventArgs e)
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch(txtNumero.Text, "[^0-9]"))
        //    {
        //        MessageBox.Show("Favor escrever apenas números.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        txtNumero.Text = txtNumero.Text.Remove(txtNumero.Text.Length - 1);
        //    }


        //}

       

        private void btAtualizar_Click(object sender, EventArgs e)//COPIAR TUDO DO FORM CADASTRO PRA FACILITAR O PROCESSO
        {

            if (txtNome.Text != "" && mskCPF.Text != "   .   .   -" && mskData_nascimento.Text != "  /  /" && cbSexo.Text != "" && txtEmail.Text != "" && (mskTelefone.Text != "(  )     -" || mskCelular.Text != "(  )      -") && txtRua.Text != "" && txtNumero.Text != "")
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE AS INFORMAÇÕES DIGITADAS PELO USUARIO NO FORMULARIO 
                //tem que enxergar a classe cliente - chamá-la:

                classCliente cCliente = new classCliente();
                cCliente.nome = txtNome.Text;
                cCliente.cpf = mskCPF.Text;
                cCliente.data_nascimento = Convert.ToDateTime(mskData_nascimento.Text);
                cCliente.sexo = cbSexo.SelectedItem.ToString();
                cCliente.email = txtEmail.Text;
                cCliente.rua = txtRua.Text;
                cCliente.bairro = txtBairro.Text;
                cCliente.numero = Convert.ToInt32(txtNumero.Text);
                cCliente.cidade = txtCidade.Text;
                cCliente.estado = cbEstado.SelectedItem.ToString();
                cCliente.complemento = txtComplemento.Text;
                cCliente.id_cliente = Convert.ToInt32(txtCodigo_do_cliente.Text);


                if (mskRG.Text != "  .   .   -")
                {
                    cCliente.rg = mskRG.Text;
                }
                else
                {
                    cCliente.rg = "";
                }

                if (mskTelefone.Text != "(  )     -")
                {
                    cCliente.telefone = mskTelefone.Text;
                }
                else
                {
                    cCliente.telefone = "";
                }

                if (mskCelular.Text != "(  )      -")
                {
                    cCliente.celular = mskCelular.Text;
                }
                else
                {
                    cCliente.celular = "";
                }

                if (mskCEP.Text != "     -")
                {
                    cCliente.cep = mskCEP.Text;
                }
                else
                {
                    cCliente.cep = "";
                }

                //STATUS
                if (ckbStatus.Checked == true)
                {
                    cCliente.status = 1;
                }
                else
                {
                    cCliente.status = 0;
                }

                //CHAMAR O MÉTODOS ATUALIZAR DA CLASSE CLIENTE - O METODO PODE SER INT IGUAL AO BOTAO CADASTRA, OU BOOLEANO
                bool resp = cCliente.AtualizarCliente();


                //EXIBIR MENSAGEM DE CADASTRO REALIZADO 
                if (resp)
                {
                    MessageBox.Show("Cliente: " + cCliente.nome + " Atualizado com Sucesso", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();


                }
                else
                {
                    MessageBox.Show("Erro ao Atualizar o Cliente", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //ERRO NO CÓDIGO 
                }




            }



            else//VALIDAÇÃO DE CAMPOS OBRIGATÓRIOS - se o usuario nao preencher todos os campos obrigatorios 
            {
                //MOSTRAR MENSAGEM PARA PREENCHER CAMPOS OBRIGATORIOS
                MessageBox.Show("FAVOR PREENCHER TODOS OS CAMPOS OBRIGATÓRIOS", "Sistema Loja J.D Modas - ATENÇÃO:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtNome.BackColor = Color.LemonChiffon;
                mskCPF.BackColor = Color.LemonChiffon;
                mskData_nascimento.BackColor = Color.LemonChiffon;
                cbSexo.BackColor = Color.LemonChiffon;
                txtEmail.BackColor = Color.LemonChiffon;
                txtRua.BackColor = Color.LemonChiffon;
                txtNumero.BackColor = Color.LemonChiffon;
                lbData.BackColor = Color.LemonChiffon;

                txtNome.Focus();


            }


        }

        //VALIDAR DATA DA MASCARA - eventos - TypeValidationCompleted
        private void mskData_nascimento_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MessageBox.Show("Data Inválida.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskData_nascimento.Clear();
                //mskData_nascimento.Focus();
            }
        }


        private void lbData_Click(object sender, EventArgs e)
        {

            lbData.Text = DateTime.Now.ToShortDateString();

        }

        private void txtRua_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras

            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtComplemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;

        }

        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;

        }

        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Tudo menos espaço
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
               
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }


    }
}
