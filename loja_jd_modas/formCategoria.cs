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
    public partial class formCategoria : Form
    {
        public formCategoria()
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
            if(txtNome.Text != "")
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE AS INFORMAÇÕES DIGITADAS PELO USUARIO NO FORMULARIO 
                //tem que enxergar a classe cliente - chamá-la:

                classCategoria cCategoria = new classCategoria();
                cCategoria.nome = txtNome.Text;

                //CHAMAR O MÉTODO CADASTRAR DA CLASSE
                int resp = cCategoria.CadastroCategoria();

                //EXIBIR MENSAGEM DE CADASTRO REALIZADO 

                if(resp == 1)
                {
                    MessageBox.Show("Categoria " + cCategoria.nome + " Cadastrada com Sucesso.", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //criar private void limpar
                    Limpar();
                }
                else
                {
                    MessageBox.Show("Esta categoria já existe.", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } //ERRO



            }
            else
            {
                MessageBox.Show("FAVOR PREENCHER O CAMPO OBRIGATÓRIO.", "Sistema Loja J.D Modas - ATENÇÃO:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.BackColor = Color.MistyRose;
                txtNome.Focus();
            }










        }

        private void formCategoria_Load(object sender, EventArgs e)
        {
            //CARREGAR DATA NA LABEL
            lbData.Text = DateTime.Now.ToShortDateString();

            //----------------------------
            //11.QUANDO O FORMULARIO ABRIR
            //ATUALIZAÇÃO
            if(tipo == "Atualização")
            {
                lbTitulo.Text = "Atualização de Categoria";
                btCadastrar.Enabled = false;
                panel1.Enabled = true;
                txtID_categoria.Enabled = false;
                ckbStatus.Enabled = true;
                lbData.Text = datacad.ToString();
            }
            else
            {
                btAtualizar.Enabled = false;
                btExcluir.Enabled = false;
            }



        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            //13.
            //verificar campos obrigatorios
            if (txtNome.Text != "")
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE AS INFORMAÇÕES DIGITADAS PELO USUARIO NO FORMULARIO 
                //tem que enxergar a classe cliente - chamá-la:

                classCategoria cCategoria = new classCategoria();
                cCategoria.nome = txtNome.Text;

                //-------------------------------------------------
                //STATUS
                if(ckbStatus.Checked == true)
                {
                    cCategoria.status = 1;
                }
                else
                {
                    cCategoria.status = 0;
                }

                cCategoria.id_categoria = Convert.ToInt32(txtID_categoria.Text);

                //CHAMAR O MÉTODO ATUALIZAR DA CLASSE categoria  - O METODO PODE SER INT IGUAL AO BOTAO CADASTRAR, OU BOOLEANO.
                bool resp = cCategoria.AtualizarCategoria();

                if (resp)
                {
                    MessageBox.Show("Categoria " + cCategoria.nome + " Atualizada com Sucesso.", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERRO AO REALIZAR A ATUALIZAÇÃO", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } //ERRO



            }
            else
            {
                MessageBox.Show("FAVOR PREENCHER O CAMPO OBRIGATÓRIO.", "Sistema Loja J.D Modas - ATENÇÃO:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.BackColor = Color.MistyRose;
                txtNome.Focus();
            }


        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja excluir a categoria?", "Sistema Loja J.D Modas",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                classCategoria cCategoria = new classCategoria();
                cCategoria.id_categoria = Convert.ToInt32(txtID_categoria.Text);

                bool resp = cCategoria.ExcluirCategoria();

                if(resp == true) //ou if(resp)
                {
                    MessageBox.Show("Categoria " + cCategoria.nome + " excluída com sucesso.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Esta Categoria não pode ser excluída, há registros em outras tabelas!", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
