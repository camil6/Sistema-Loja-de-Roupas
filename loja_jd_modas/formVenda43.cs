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
    public partial class formVenda43 : Form
    {
        public formVenda43()
        {
            InitializeComponent();
        }

        private void formVenda43_Load(object sender, EventArgs e)
        {
            //CARREGAR COMBO DE FUNCIONARIO
            classFuncionario cFuncionario = new classFuncionario();
            cbFuncionario.DataSource = cFuncionario.BuscarFuncionario();
            cbFuncionario.DisplayMember = "nome";
            cbFuncionario.ValueMember = "id_funcionario";
            cbFuncionario.SelectedIndex = -1;
        }



        //PESQUISAR CLIENTE
        private void btBuscaCliente_Click(object sender, EventArgs e)
        {
            //VERIFICAR SE O USUARIO DIGITOU ALGUM NOME
            if(string.IsNullOrEmpty(txtPesqCliente.Text))
            {
                MessageBox.Show("Favor informar um cliente.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                classCliente cCliente = new classCliente();
                string pesquisar = txtPesqCliente.Text.ToString();
                dgvCliente.DataSource = cCliente.PesquisarClienteVenda(txtPesqCliente.Text);

            }

        }

        //PESQUISAR PORDUTO
        private void btBuscaProduto_Click(object sender, EventArgs e)
        {
            //VERIFICAR SE O USUARIO DIGITOU ALGUM NOME
            if (string.IsNullOrEmpty(txtPesqProduto.Text))
            {
                MessageBox.Show("Favor informar um produto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                classProduto cProduto = new classProduto();
                dgvProduto.DataSource = cProduto.PesquisarProdutoVenda(txtPesqProduto.Text);

            }
        }



        //CALCULAR VALOR TOTAL DO PRODUTO SELECIONADO PELO USUARIO DE ACORDO COM A QUANTIDADE DIGITADA
        private void txtQtde_TextChanged(object sender, EventArgs e)
        {
            if (txtQtde.Text == "")
            {
                MessageBox.Show("Favor informar uma quantidade.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQtde.Text = "01";
                txtQtde.SelectAll();
            }

            int qtde_vendida = Convert.ToInt32(txtQtde.Text);
            int qtde_estoque = Convert.ToInt32(txtQtdeEstoque.Text);

            //VERIFICAR SE A QUANTIDADE VENDIDA É MAIOR QUE A QUANTIDADE EM ESTOQUE

            if(qtde_vendida > qtde_estoque)
            {
                MessageBox.Show("A quantidade disponível no estoque é de " + qtde_estoque + " unidades!", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQtde.Text = "01";
                txtQtde.SelectAll();
            }
            else
            {
                qtde_vendida = Convert.ToInt32(txtQtde.Text);
                decimal valor = Convert.ToDecimal(txtValor.Text);
                txtTotal.Text = (qtde_vendida * valor).ToString();
                txtValorUnitario_TextChanged(this, new EventArgs());
            }

        }

        //SELECIONAR O PRODUTO ESCOLHIDO NA GRID E CARREGAR AS INFORMAÇOES NO FORM DE VENDA
        private void dgvProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {

          

            classProduto cProduto = new classProduto();

            //NÃO DEIXAR SELECIONAR A GRID QUANDO VAZIA
            if (dgvProduto.Rows.Count > 0)
            {
                bool resp = cProduto.ConsultarProduto(Convert.ToInt32(dgvProduto.SelectedRows[0].Cells[0].Value));

                    if (resp == true)
                    {
                        txtPesqProduto.Text = cProduto.nome;
                        txtQtdeEstoque.Text = cProduto.estoque.ToString();
                        txtValor.Text = cProduto.valor_venda.ToString("n2");
                        txtQtde.Text = "01";
                        txtQtde_TextChanged(this, new EventArgs());
                        txtQtde.Select();
                        txtProduto.Text = cProduto.nome;

                        txtValorUnitario.Text = "0";
                        txtValorUnitario_TextChanged(this, new EventArgs());

                        //DESABILITAR O TEXT DESCONTO QUANDO NÃO A PRODUTO SELECIONADO
                        txtValorUnitario.Enabled = true;

                        //DESABILITAR O TEXT QUANTIDADE QUANDO NÃO A PRODUTO SELECIONADO
                        txtQtde.Enabled = true;

                    }
            }
        }

       



        //CRIAR A LISTA QUE SERA USADA NA GRID DE PRODUTOS VENDIDOS
        private List<classItensVenda> Carrinho = new List<classItensVenda>();

        //VARIAVEL PARA CALCULAR VALOR TOTAL DA VENDA
        private decimal VendaTotal = 0;

        private decimal desconto = 0;

        //VARIAVEL PARA CONTAR QUANTAS LINHAS FORAM ACIONADAS NA GRID DE VENDA
        private int ItensVenda = 0;

        

          //METODO QUE SERA USADO PELA GRID DE VENDA COM OS PRODUTOS VENDIDOS
        private void AtualizarGrid()
        {
            //INSTANCIAR CLASSE PRODUTO PARA PEGAR METODO QUE TRAZ O NOME DO PRODUTO
            classProduto cProduto = new classProduto();

            //CRIAR UMA TABELA TEMPORARIA
            DataTable dt = new DataTable();

            //CRIAR AS COLUNAS DA GRID
            dt.Columns.Add(new DataColumn("Código"));
            dt.Columns.Add(new DataColumn("Produto"));
            dt.Columns.Add(new DataColumn("Quantidade"));
            dt.Columns.Add(new DataColumn("Valor"));
            dt.Columns.Add(new DataColumn("Valor com desconto"));

            //ADICIONAR AS LINHAS DA GRID
            foreach (classItensVenda item in Carrinho)
            {
                dt.Rows.Add(item.id_produto, cProduto.BuscarNomeProduto(item.id_produto), item.quantidade, item.preco, item.desconto_unitario);dt.AcceptChanges();
            }
            dgvItens.DataSource = dt;

        }

        //--------BOTAO ADICIONAR PRODUTO--------------------------
        private void btAddProduto_Click(object sender, EventArgs e)
        {
            classItensVenda cItensVenda = new classItensVenda();

            //SOMAR VALOR DO ITEM AO TOTAL DA VENDA
            decimal ValorItem = 0;

            //VERIFICAR SE ALGUM PRODUTO FOI SELECIONADO
            if (txtTotal.Text == "")
            {
                MessageBox.Show("Não há produto para ser inserido.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

               

                //SOMA VALOR DO ITEM SELECIONADO AO TOTAL DA VENDA
                ValorItem = Convert.ToDecimal(txtTotalDescontoUnitario.Text);
                VendaTotal = VendaTotal + ValorItem;
                desconto = desconto = ValorItem;
                txtValorTotal.Text = VendaTotal.ToString("n2");
                txtTotalVenda.Text = VendaTotal.ToString("n2");
                txtTotalDescontoUnitario.Text = desconto.ToString("n2");
                

                //CONTAR OS ITENS DA VENDA (quantidade de linhas da grid)
                ItensVenda++;

                //INFORMAÇAO DE PRODUTOS VENDIDOS
                cItensVenda.id_produto = Convert.ToInt32(dgvProduto.SelectedRows[0].Cells[0].Value);
                cItensVenda.quantidade = Convert.ToInt32(txtQtde.Text);
                cItensVenda.preco = Convert.ToDecimal(txtTotal.Text);
                cItensVenda.desconto_unitario = Convert.ToDecimal(txtTotalDescontoUnitario.Text);

                //ADICIONAR NA LISTA
                Carrinho.Add(cItensVenda);

                //PEGAR DA LISTA A QUANTIDADE DE ITENS
                txtQtdeItens.Text = ItensVenda.ToString();
                txtQtdeItens.Text = Carrinho.Count.ToString();

                //CHAMAR METODO QUE CRIA A GRID DE PRODUTOS
                AtualizarGrid();

                
                 
                

                //LIMPAR OS CAMPOS DE PRODUTO APOS ADICIONAR
                txtProduto.Clear();
                txtQtde.Text = "01";
                txtValor.Clear();
                txtTotal.Clear();
                txtTotalDescontoUnitario.Text = "0";
                txtQtdeEstoque.Clear();
                //
                txtValorDesconto.Text = "0";
                txtValorDesconto_TextChanged(this, new EventArgs());
                txtValorDesconto.Select();

                //DESABILITAR O TEXT DESCONTO QUANDO NÃO A PRODUTO SELECIONADO
                txtValorUnitario.Enabled = false;
                // txtValorUnitario.Clear();

                //DESABILITAR O TEXT QUANTIDADE QUANDO NÃO A PRODUTO SELECIONADO
                txtQtde.Enabled = false;

                //DESABILITAR O TEXT QUANTIDADE QUANDO NÃO A PRODUTO SELECIONADO
                txtDinheiro.Enabled = true;
                txtPix.Enabled = true;
                txtCartao_credito.Enabled = true;
                txtCartao_debito.Enabled = true;
                txtValorDesconto.Enabled = true;

            }

        }

        //METODO ATUALIZAR ESTOQUE (fazer conta para excluir do estoque)
        private void CalcularEstoque(int qtde, int id)
        {
            classProduto cProduto = new classProduto();
            cProduto.ConsultarProduto(id);
            int estoque = cProduto.estoque;
            cProduto.AtualizarQtde(estoque - qtde, id);
        }


        //METODO LIMPAR - CHAMADO QUANDO VENDA FINALIZADA
        private void Limpar()
        {
            cbFuncionario.SelectedIndex = -1;
            txtPesqCliente.Clear();
            dgvCliente.DataSource = null;
            txtPesqProduto.Clear();
            dgvProduto.DataSource = null;
 

            Carrinho.Clear();
            AtualizarGrid();
            dgvItens.Refresh();

            txtValorTotal.Text = "0";
            txtTotalVenda.Text = "0";
            txtValorDesconto.Text = "0";
            txtTotalDesconto.Text = "0";
            txtCartao_credito.Text = "0";
            txtCartao_debito.Text = "0";
            txtDinheiro.Text = "0";
            txtPix.Text = "0";


            txtQtdeItens.Clear();
            VendaTotal = 0;
        }

        //BOTÃO REMOVER PRODUTO
        private void btRemoveProduto_Click(object sender, EventArgs e)
        {
            if (dgvItens.Rows.Count > 0)
            {
                if (MessageBox.Show("Deseja Remover o Produto Selecionado?", "Sistema Loja J.D Modas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //RECALCULAR TOTAL DA VENDA
                    //PEGAR O VALOR DO ITEM SELECIONADO PELO USUARIO
                    decimal valor = Convert.ToDecimal(dgvItens.SelectedRows[0].Cells[3].Value);
                    VendaTotal = VendaTotal - valor;
                    txtTotalVenda.Text = VendaTotal.ToString();
                    txtValorTotal.Text = VendaTotal.ToString();

                    //REMOVER O ITEM SELECIONADO DA LISTA E ATUALIZAR GRID
                    Carrinho.RemoveAt(dgvItens.CurrentRow.Index);
                    AtualizarGrid();

                    //RECONTAR A LISTA DE PRODUTOS VENDIDOS
                    txtQtdeItens.Text = Carrinho.Count.ToString();
                    txtValorDesconto_TextChanged(this, new EventArgs());

                }


            }
            else
            {
                MessageBox.Show("Não há produtos para ser removido", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btFechaVenda_Click(object sender, EventArgs e)
        {

            //VERIFICAR CAMPOS OBRIGATÓRIOS
            if (cbFuncionario.SelectedIndex != -1 && dgvCliente.DataSource != null && dgvItens.DataSource != null && (txtCartao_credito.Text != "0" || txtCartao_debito.Text != "0" || txtPix.Text != "0" || txtDinheiro.Text != "0"))
            {
                classVenda cVenda = new classVenda();

                //MANDAR INFORMAÇÕES DA TABELA VENDA

                cVenda.valor_total = Convert.ToDecimal(txtTotalVenda.Text);
                cVenda.pix = Convert.ToDecimal(txtPix.Text);
                cVenda.cartao_debito = Convert.ToDecimal(txtCartao_debito.Text);
                cVenda.cartao_credito = Convert.ToDecimal(txtCartao_credito.Text);
                cVenda.dinheiro = Convert.ToDecimal(txtDinheiro.Text);
                cVenda.desconto_total = Convert.ToDecimal(txtTotalDesconto.Text);
                cVenda.id_funcionario = Convert.ToInt32(cbFuncionario.SelectedValue);
                cVenda.id_cliente = Convert.ToInt32(dgvCliente.SelectedRows[0].Cells[0].Value);

                decimal pix = Convert.ToDecimal(txtPix.Text);
                decimal dinheiro = Convert.ToDecimal(txtDinheiro.Text);
                decimal credito = Convert.ToDecimal(txtCartao_credito.Text);
                decimal debito = Convert.ToDecimal(txtCartao_debito.Text);
                decimal total;
                decimal valortotal = Convert.ToDecimal(txtTotalVenda.Text);
                total = pix + dinheiro + credito + debito;


                //VERIFICAÇÃO SE AS CAIXINHAS DO PAGAMENTO ESTA CORRETA CONFORME O VALOR DO PRODUTO

                if (valortotal == total)
                {

                    //CHAMAR MÉTODO CADASTRAR VENDA
                    bool resp = cVenda.CadastrarVenda();

                    if (resp == true)
                    {

                        foreach (classItensVenda item in Carrinho)
                        {
                            item.id_venda = cVenda.id_venda;
                            resp = item.CadastrarItenVenda();

                            //BAIXA ESTOQUE
                            CalcularEstoque(item.quantidade, item.id_produto);

                        }
                        if (resp == true)
                        {
                            MessageBox.Show("Venda realizada com Sucesso", "Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpar();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao realizar Venda", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }

                }
                else
                {

                    MessageBox.Show("Erro ao realizar Venda, o valor inserido não é compativel com o preço do produto", "Sistema Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            else
            {
                MessageBox.Show("Favor preencher todos os campos", "Sistema Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbFuncionario.BackColor = Color.LemonChiffon;
                txtPesqCliente.BackColor = Color.LemonChiffon;
                txtPesqProduto.BackColor = Color.LemonChiffon;
            }




        }

        //CONTA DO DESCONTO TOTAL
        private void txtValorDesconto_TextChanged(object sender, EventArgs e)
        {
            if (txtValorDesconto.Text == "")
            {
                txtValorDesconto.Text = "0";
                txtValorDesconto.SelectAll();
            }
            if (txtValor.Text != "0")
            {
                decimal valortotal = Convert.ToDecimal(txtValorTotal.Text);
                decimal desconto = Convert.ToDecimal(txtValorDesconto.Text);
                decimal totaldesconto = valortotal * desconto / 100;
                decimal totalvenda = valortotal - totaldesconto;
                txtTotalDesconto.Text = totaldesconto.ToString("n2");
                txtTotalVenda.Text = totalvenda.ToString("n2");
            }   


        }
        
        //CONTA DO DESCONTO UNITARIO
        private void txtValorUnitario_TextChanged(object sender, EventArgs e)
        {

            if (txtValorUnitario.Text == "")
            {
                txtValorUnitario.Text = "0";
                txtValorUnitario.SelectAll();
            }
            if (txtValor.Text != "0")
            {
                decimal desconto = Convert.ToDecimal(txtValorUnitario.Text);
                decimal valortotal = Convert.ToDecimal(txtTotal.Text);
                decimal totaldesconto = valortotal - ( valortotal * desconto / 100);
                decimal totalvenda = valortotal - totaldesconto;
                         

                txtTotalDescontoUnitario.Text = totaldesconto.ToString("n2");
                //txtTotal.Text = totalvenda.ToString();

               
            }
            
        }



        //PERMITIR APENAS LETRAS NAS TEXT BOX
        private void txtPesqCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;

            //PERMITIR APENAS NUMEROS NA TEXT BOX
           // if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
           //     e.Handled = true;

        }

        private void txtPesqProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }


        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

      
        private void txtValorDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        
        private void txtCartao_credito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44)
                e.Handled = true;
        }


        private void txtDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44)
                e.Handled = true;
        }


        private void txtCartao_debito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44)
                e.Handled = true;
        }


        private void txtPix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44)
                e.Handled = true;
        }


        private void txtValorUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }



        //NAO DEIXAR A TXTBOX DE FORMA PAGAMENTO FICAR VAZIA
        private void txtDinheiro_TextChanged(object sender, EventArgs e)
        {
            if (txtDinheiro.Text == "")
            {
                txtDinheiro.Text = "0";
                txtDinheiro.SelectAll();
                txtDinheiro_TextChanged(this, new EventArgs());     
            }
        }

        private void txtCartao_credito_TextChanged(object sender, EventArgs e)
        {
            if (txtCartao_credito.Text == "")
            {
                txtCartao_credito.Text = "0";
                txtCartao_credito.SelectAll();
                txtCartao_credito_TextChanged(this, new EventArgs());
            }
        }

        private void txtCartao_debito_TextChanged(object sender, EventArgs e)
        {
            if (txtCartao_debito.Text == "")
            {
                txtCartao_debito.Text = "0";
                txtCartao_debito.SelectAll();
                txtCartao_debito_TextChanged(this, new EventArgs());
            }
        }

        private void txtPix_TextChanged(object sender, EventArgs e)
        {
            if (txtPix.Text == "")
            {
                txtPix.Text = "0";
                txtPix.SelectAll();
                txtPix_TextChanged(this, new EventArgs());
            }
        }



    }
    
}
