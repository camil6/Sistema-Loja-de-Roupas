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
    public partial class formCargo : Form
    {
        public formCargo()
        {
            InitializeComponent();
        }

        //VARIÁVEL tipo: GUARDAR COMO O FORMULARIO DEVE SER ABERTO SE PARA CADASTRO OU ATUALIZAÇÃO/EXCLUSÃO
        public string tipo;


        //VARIÁVEL datacad: MOSTRAR INFORMAÇÃO GUARDADA NO BD E NÃO DATA ATUAL COMO PROGRAMADO NO LOAD DO FORM
        public DateTime datacad;


        private void Limpar()
        {
            txtNome.Clear();
           
        }


        private void btCadastrar_Click(object sender, EventArgs e)
        {

            if (txtNome.Text != "")
            {
                classCargo cCargo = new classCargo();
                cCargo.nome = txtNome.Text;

                int resp = cCargo.CadastroCargo();


                if (resp == 1)
                {
                    MessageBox.Show("Cargo: " + cCargo.nome + " Cadastrado com Sucesso", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();


                }
                else
                {
                    MessageBox.Show("Erro ao realizar o cadastro ", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }



            }

            else
            {
                MessageBox.Show("FAVOR PREENCHER TODOS OS CAMPOS OBRIGATÓRIOS", "Sistema Loja J.D Modas - ATENÇÃO:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtNome.BackColor = Color.LemonChiffon;
                


            }


        }

       


        private void btAtualizar_Click(object sender, EventArgs e)
        {

            if (txtNome.Text != "")
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE AS INFORMAÇÕES DIGITADAS PELO USUARIO NO FORMULARIO 
                //tem que enxergar a classe cliente - chamá-la:

                classCargo cCargo = new classCargo();
                cCargo.nome = txtNome.Text;
                cCargo.id_cargo = Convert.ToInt32(txtID_cargo.Text);

                //STATUS
                if (ckbStatus.Checked == true)
                {
                    cCargo.status = 1;
                }
                else
                {
                    cCargo.status = 0;
                }
                

                //CHAMAR O MÉTODOS ATUALIZAR DA CLASSE CARGO - O METODO PODE SER INT IGUAL AO BOTAO CADASTRA, OU BOOLEANO
                bool resp = cCargo.AtualizarCargo();

                //EXIBIR MENSAGEM DE CADASTRO REALIZADO 
                if (resp)
                {
                    MessageBox.Show("Cargo: " + cCargo.nome + "Atualizado com Sucesso", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();


                }
                else
                {
                    MessageBox.Show("Erro ao Atualizar o Cargo", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //ERRO NO CÓDIGO 
                }



            }

            else//VALIDAÇÃO DE CAMPOS OBRIGATÓRIOS - se o usuario nao preencher todos os campos obrigatorios 
            {
                //MOSTRAR MENSAGEM PARA PREENCHER CAMPOS OBRIGATORIOS
                MessageBox.Show("FAVOR PREENCHER TODOS OS CAMPOS OBRIGATÓRIOS", "Sistema Loja J.D Modas - ATENÇÃO:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtNome.BackColor = Color.LemonChiffon;
                lbData.BackColor = Color.LemonChiffon;

                txtNome.Focus();


            }



        }

       

        private void formCargo_Load(object sender, EventArgs e)
        {
            if (tipo == "Atualização")
            {
                lbtitulo.Text = "Atualização de Cargo";
                btCadastrar.Enabled = false;
                ckbStatus.Enabled = true;
                lbData.Text = datacad.ToString();

            }
            else
            {
                btAtualizar.Enabled = false;
                btExcluir.Enabled = false;

            }

            //CARREGAR DATA NA LABEL

            lbData.Text = DateTime.Now.ToShortDateString();

        }

        private void btExcluir_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o Cargo?", "Sistema Loja J.D Modas!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                classCargo cCargo = new classCargo();
                cCargo.id_cargo = Convert.ToInt32(txtID_cargo.Text);

                bool resp = cCargo.ExcluirCargo();

                if (resp == true)
                {
                    MessageBox.Show("Cargo" + cCargo.nome + " excluido com sucesso.", "Sistema Loja de Cosméticos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este Cliente não pode ser excluido, há registros em outras tabelas.", "Sistema Loja de Cosméticos!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;

        }
    }
}
