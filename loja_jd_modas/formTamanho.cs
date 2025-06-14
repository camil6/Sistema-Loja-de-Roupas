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
    public partial class formTamanho : Form
    {
        public formTamanho()
        {
            InitializeComponent();
        }

        //10.

        //VARIAVEL tipo: GUARDAR COMO O FORMULÁRIO DEVE SER ABERTO SE PARA CADASTRO OU ATUALIZAÇÃO/EXCLUSÃO
        public string tipo;
        //VARIAVEL datacad: MOSTRAR INFORMAÇÃO GUARDADA NO BD E NÃO A DATA ATUAL, COMO PROGRAMADO NO LOAD DO FORM
        public DateTime datacad;


        private void Limpar()
        {
            //limpar as caixinhas
            txtNome.Clear();
            //...








        }


        private void btCadastrar_Click(object sender, EventArgs e)
        {
            //verificar campos obrigatorios
            if (txtNome.Text != "")
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE AS INFORMAÇÕES DIGITADAS PELO USUARIO NO FORMULARIO 
                //tem que enxergar a classe cliente - chamá-la:

                classTamanho cTamanho = new classTamanho();
                cTamanho.nome = txtNome.Text;

                //CHAMAR O MÉTODO CADASTRAR DA CLASSE
                int resp = cTamanho.CadastroTamanho();

                //EXIBIR MENSAGEM DE CADASTRO REALIZADO 
                if (resp == 1)
                {
                    MessageBox.Show("Tamanho " + cTamanho.nome + " Cadastrado com Sucesso.", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
                else
                {
                    MessageBox.Show("Este tamanho já existe.", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } //ERRO



            }
            else
            {
                MessageBox.Show("FAVOR PREENCHER O CAMPO OBRIGATÓRIO.", "Sistema Loja J.D Modas - ATENÇÃO:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.BackColor = Color.MistyRose;
                txtNome.Focus();
            }



        }

        private void formTamanho_Load(object sender, EventArgs e)
        {
            //CARREGAR DATA NA LABEL
            lbData.Text = DateTime.Now.ToShortDateString();

            //----------------------------
            //11.QUANDO O FORMULARIO ABRIR
            //ATUALIZAÇÃO
            if (tipo == "Atualização")
            {
                lbTitulo.Text = "Atualização de Marca";
                btCadastrar.Enabled = false;
                panel1.Enabled = true;
                txtID_tamanho.Enabled = false;
                ckbStatus.Enabled = true;
                lbData.Text = datacad.ToString();
            }
            else
            {
                btAtualizar.Enabled = false;
                btExcluir.Enabled = false;
            }

        }

        //13. BOTÃO ATUALIZAR
        private void btAtualizar_Click(object sender, EventArgs e)
        {

            //verificar campos obrigatorios
            if (txtNome.Text != "")
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE AS INFORMAÇÕES DIGITADAS PELO USUARIO NO FORMULARIO 
                //tem que enxergar a classe cliente - chamá-la:
                classTamanho cTamanho = new classTamanho();
                cTamanho.nome = txtNome.Text;

                //-------------------------------------------------
                //STATUS
                if (ckbStatus.Checked == true)
                {
                    cTamanho.status = 1;
                }
                else
                {
                    cTamanho.status = 0;
                }
                cTamanho.id_tamanho = Convert.ToInt32(txtID_tamanho.Text);

                //CHAMAR O MÉTODO ATUALIZAR DA CLASSE categoria  - O METODO PODE SER INT IGUAL AO BOTAO CADASTRAR, OU BOOLEANO.
                bool resp = cTamanho.AtualizarTamanho();
                if (resp == true)
                {
                    MessageBox.Show("Marca " + cTamanho.nome + " Atualizada com Sucesso.", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERRO AO REALIZAR A ATUALIZAÇÃO", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("FAVOR PREENCHER O CAMPO OBRIGATÓRIO.", "Sistema Loja J.D Modas - ATENÇÃO:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.BackColor = Color.MistyRose;
                txtNome.Focus();
            }





        }

        //14. BOTÃO EXCLUIR
        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o tamanho?", "Sistema Loja J.D Modas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                classTamanho cTamanho = new classTamanho();
                cTamanho.id_tamanho = Convert.ToInt32(txtID_tamanho.Text);

                bool resp = cTamanho.ExcluirTamanho();
                if(resp == true)
                {
                    MessageBox.Show("Tamanho " + cTamanho.nome + " excluído com sucesso.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este Tamanho não pode ser excluído, há registros em outras tabelas!", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }
    }


}

