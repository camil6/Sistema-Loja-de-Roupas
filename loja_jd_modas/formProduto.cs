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
    public partial class formProduto : Form
    {
        public formProduto()
        {
            InitializeComponent();

        }

        //10.

        //VARIAVEL tipo: GUARDAR COMO O FORMULÁRIO DEVE SER ABERTO SE PARA CADASTRO OU ATUALIZAÇÃO/EXCLUSÃO
        public string tipo, categoria, marca, tamanho;
        //VARIAVEL datacad: MOSTRAR INFORMAÇÃO GUARDADA NO BD E NÃO A DATA ATUAL, COMO PROGRAMADO NO LOAD DO FORM
        public DateTime datacad;


        private void Limpar()
        {
            //limpar as caixinhas
            txtNome.Clear();
            txtCor.Clear();
            txtDescricao.Clear();
            txtEstoque.Clear();
            txtValor_custo.Clear();
            txtValor_venda.Clear();
            

        }

        //14.BOTAO EXCLUIR
        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o produto?", "Sistema Loja J.D Modas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                classProduto cProduto = new classProduto();
                cProduto.id_produto = Convert.ToInt32(txtID_Produto.Text);

                bool resp = cProduto.ExcluirProduto();

                if (resp == true)
                {
                    MessageBox.Show("Produto " + cProduto.nome + " excluído com sucesso.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Este Produto não pode ser excluído, há registros em outras tabelas!", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }




            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ESCREVER APENAS NUMEROS NO TXT - eventos - TextChanged
        private void txtEstoque_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtEstoque.Text, "[^0-9-]"))
            {
                MessageBox.Show("Favor escrever apenas números.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEstoque.Text = txtEstoque.Text.Remove(txtEstoque.Text.Length - 1);
            }

        }

        
        private void txtValor_custo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtValor_custo.Text, "[^0-9,]"))
            {
                MessageBox.Show("Favor escrever apenas números.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValor_custo.Text = txtValor_custo.Text.Remove(txtValor_custo.Text.Length - 1);
            }

        }

        private void txtValor_venda_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtValor_venda.Text, "[^0-9,]"))
            {
                MessageBox.Show("Favor escrever apenas números.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValor_venda.Text = txtValor_venda.Text.Remove(txtValor_venda.Text.Length - 1);
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Numeros

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtCor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;

        }

        private void txtValor_custo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Numeros com virgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44)
                e.Handled = true;
        }

        private void txtValor_venda_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Numeros com virgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44)
                e.Handled = true;
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            //verificar campos obrigatorios
            if(txtNome.Text != "" && cbCategoria.Text != "" && cbMarca.Text != "" && cbTamanho.Text != "" && txtEstoque.Text != "" && txtValor_custo.Text != "" && txtValor_venda.Text != "")
            {

                //PASSAR PARA AS PROPRIEDADES DA CLASSE AS INFORMAÇÕES DIGITADAS PELO USUARIO NO FORMULARIO 
                //tem que enxergar a classe cliente - chamá-la:

                classProduto cProduto = new classProduto();
                cProduto.nome = txtNome.Text;
                cProduto.cor = txtCor.Text;
                cProduto.estoque = Convert.ToInt32 (txtEstoque.Text);
                cProduto.descricao = txtDescricao.Text;
                cProduto.valor_custo = Convert.ToDecimal(txtValor_custo.Text);
                cProduto.valor_venda = Convert.ToDecimal(txtValor_venda.Text);
                //FK
                cProduto.id_categoria = Convert.ToInt32(cbCategoria.SelectedValue);
                cProduto.id_marca = Convert.ToInt32(cbMarca.SelectedValue);
                cProduto.id_tamanho = Convert.ToInt32(cbTamanho.SelectedValue);

                //CHAMAR O MÉTODO CADASTRAR DA CLASSE
                int resp = cProduto.CadastroProduto();

                //EXIBIR MENSAGEM DE CADASTRO REALIZADO 

                if (resp == 1)
                {
                    MessageBox.Show("Produto " + cProduto.nome + " Cadastrado com Sucesso.", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
                else
                {
                    MessageBox.Show("ERRO AO REALIZAR O CADASTRO", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } //ERRO





            }
            else
            {
                MessageBox.Show("FAVOR PREENCHER OS CAMPOS OBRIGATÓRIOS.", "Sistema Loja J.D Modas - ATENÇÃO:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                txtNome.BackColor = Color.MistyRose;
                cbCategoria.BackColor = Color.MistyRose;
                cbMarca.BackColor = Color.MistyRose;
                cbTamanho.BackColor = Color.MistyRose;
                txtEstoque.BackColor = Color.MistyRose;
                txtValor_custo.BackColor = Color.MistyRose;
                txtValor_venda.BackColor = Color.MistyRose;

                txtNome.Focus();

            }



        }

        private void formProduto_Load(object sender, EventArgs e)
        {
            //CARREGAR DATA NA LABEL
            lbData.Text = DateTime.Now.ToShortDateString();

            //CARREGAR COMBO DE CATEGORIA
            classCategoria cCategoria = new classCategoria();
            cbCategoria.DataSource = cCategoria.BuscarCategoria(); // EXECUTAR METODO CRIADO NA CLASSSE CATEGORIA
            cbCategoria.DisplayMember = "nome";     // EXIBIR NA COMBO (NOME)
            cbCategoria.ValueMember = "id_categoria";  // GUARDAR NO BD (CODIGO)
            cbCategoria.SelectedIndex = -1;  // LIMPAR A COMBO (NAO SELECIONAR NADA QUANDO ABRIR O FORM)

            //CARREGAR COMBO DE MARCA
            classMarca cMarca = new classMarca();
            cbMarca.DataSource = cMarca.BuscarMarca();
            cbMarca.DisplayMember = "nome";
            cbMarca.ValueMember = "id_marca";
            cbMarca.SelectedIndex = -1;

            //CARREGAR COMBO DE TAMANHO
            classTamanho cTamanho = new classTamanho();
            cbTamanho.DataSource = cTamanho.BuscarTamanho();
            cbTamanho.DisplayMember = "nome";
            cbTamanho.ValueMember = "id_tamanho";
            cbTamanho.SelectedIndex = -1;

            //----------------------------
            //11.QUANDO O FORMULARIO ABRIR
            //ATUALIZAÇÃO
            if (tipo == "Atualização")
            {
                lbTitulo.Text = "Atualização de Produto";
                btCadastrar.Enabled = false;
                panel1.Enabled = true;
                txtID_Produto.Enabled = false;
                ckbStatus.Enabled = true;
                lbData.Text = datacad.ToString();
                //fk~~~~~~
                cbCategoria.SelectedValue = categoria.ToString();
                cbMarca.SelectedValue = marca.ToString();
                cbTamanho.SelectedValue = tamanho.ToString();
            }
            else
            {
                btAtualizar.Enabled = false;
                btExcluir.Enabled = false;
                btCadastrar.Enabled = true;
            }

        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            //13.
            //verificar campos obrigatorios
            if (txtNome.Text != "" && cbCategoria.Text != "" && cbMarca.Text != "" && cbTamanho.Text != "" && txtEstoque.Text != "" && txtValor_custo.Text != "" && txtValor_venda.Text != "")
            {
                //PASSAR PARA AS PROPRIEDADES DA CLASSE AS INFORMAÇÕES DIGITADAS PELO USUARIO NO FORMULARIO 
                //tem que enxergar a classe - chamá-la:

                classProduto cProduto = new classProduto();
                cProduto.nome = txtNome.Text;
                cProduto.cor = txtCor.Text;
                cProduto.estoque = Convert.ToInt32(txtEstoque.Text);
                cProduto.descricao = txtDescricao.Text;
                cProduto.valor_custo = Convert.ToDecimal(txtValor_custo.Text);
                cProduto.valor_venda = Convert.ToDecimal(txtValor_venda.Text);
                //FK
                cProduto.id_categoria = Convert.ToInt32(cbCategoria.SelectedValue);
                cProduto.id_marca = Convert.ToInt32(cbMarca.SelectedValue);
                cProduto.id_tamanho = Convert.ToInt32(cbTamanho.SelectedValue);

                //-------------------------------------------------
                //STATUS
                if (ckbStatus.Checked == true)
                {
                    cProduto.status = 1;
                }
                else
                {
                    cProduto.status = 0;
                }

                cProduto.id_produto = Convert.ToInt32(txtID_Produto.Text);

                //CHAMAR O MÉTODO ATUALIZAR DA CLASSE produto  - O METODO PODE SER INT IGUAL AO BOTAO CADASTRAR, OU BOOLEANO.
                bool resp = cProduto.AtualizarProduto();

                if (resp == true)
                {
                    MessageBox.Show("Produto " + cProduto.nome + " Atualizado com Sucesso.", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERRO AO REALIZAR A ATUALIZAÇÃO.", "Sistema J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } //ERRO

            }
            else
            {
                MessageBox.Show("FAVOR PREENCHER O CAMPO OBRIGATÓRIO.", "Sistema Loja J.D Modas - ATENÇÃO.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.BackColor = Color.MistyRose;
                cbCategoria.BackColor = Color.MistyRose;
                cbMarca.BackColor = Color.MistyRose;
                cbTamanho.BackColor = Color.MistyRose;
                txtEstoque.BackColor = Color.MistyRose;
                txtValor_custo.BackColor = Color.MistyRose;
                txtValor_venda.BackColor = Color.MistyRose;

                txtNome.Focus();
            }
        }
    }
}
