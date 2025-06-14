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
    public partial class formConsultaProduto : Form
    {
        public formConsultaProduto()
        {
            InitializeComponent();
        }

        private void formConsultaProduto_Load(object sender, EventArgs e)
        {

            //7.
            //CARREGAR AS OPÇÕES DE PESQUISA
            cbTipo_consulta.Items.Add("Nome");
            cbTipo_consulta.Items.Add("Status");
            cbTipo_consulta.Items.Add("Categoria");
            cbTipo_consulta.Items.Add("Marca");
            cbTipo_consulta.Items.Add("Tamanho");
            cbTipo_consulta.Items.Add("Valor Venda");


            //DEIXAR SELECIONADA A OPÇÃO nome
            cbTipo_consulta.SelectedItem = "Nome";

            //copiar as combos de fk da de cadastro!!~~~~~~~~~~~~
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

        }

        private void cbTipo_consulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dar 2 clicks na combo de tipo consulta, tambem nomear todas as caixinhas do form
            //8.ATIVAR/DESATIVAR OS ELEMENTOS DO FORM CONFORME A ESCOLHA DO USUARIO

            //nome
            if(cbTipo_consulta.SelectedIndex == 0)
            {
                txtPesquisar.Enabled = true;
                gbStatus.Enabled = false;
                gbTipo_pesquisa.Enabled = true;
                gbCategoria.Enabled = false;
                gbMarca.Enabled = false;
                gbTamanho.Enabled = false;
                gbValor_venda.Enabled = false;

            }

            //status
            if (cbTipo_consulta.SelectedIndex == 1)
            {
                txtPesquisar.Enabled = false;
                gbStatus.Enabled = true;
                gbTipo_pesquisa.Enabled = false;
                gbCategoria.Enabled = false;
                gbMarca.Enabled = false;
                gbTamanho.Enabled = false;
                gbValor_venda.Enabled = false;

            }

            //categoria
            if (cbTipo_consulta.SelectedIndex == 2)
            {
                txtPesquisar.Enabled = false;
                gbStatus.Enabled = false;
                gbTipo_pesquisa.Enabled = false;
                gbCategoria.Enabled = true;
                gbMarca.Enabled = false;
                gbTamanho.Enabled = false;
                gbValor_venda.Enabled = false;

            }

            //marca
            if (cbTipo_consulta.SelectedIndex == 3)
            {
                txtPesquisar.Enabled = false;
                gbStatus.Enabled = false;
                gbTipo_pesquisa.Enabled = false;
                gbCategoria.Enabled = false;
                gbMarca.Enabled = true;
                gbTamanho.Enabled = false;
                gbValor_venda.Enabled = false;

            }

            //tamanho
            if (cbTipo_consulta.SelectedIndex == 4)
            {
                txtPesquisar.Enabled = false;
                gbStatus.Enabled = false;
                gbTipo_pesquisa.Enabled = false;
                gbCategoria.Enabled = false;
                gbMarca.Enabled = false;
                gbTamanho.Enabled = true;
                gbValor_venda.Enabled = false;

            }

            //valor venda
            if (cbTipo_consulta.SelectedIndex == 5)
            {
                txtPesquisar.Enabled = false;
                gbStatus.Enabled = false;
                gbTipo_pesquisa.Enabled = false;
                gbCategoria.Enabled = false;
                gbMarca.Enabled = false;
                gbTamanho.Enabled = false;
                gbValor_venda.Enabled = true;

            }

        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            //9.
            //INSTANCIAR A CLASSE CLIENTE PARA USAR OS METODOS DE CONSULTA
            classProduto cProduto = new classProduto();

            //CRIAR UMA VARIAVEL PARA RECEBER A OPÇAO ESCOLHIDA PELO USUARIO NA COMBO
            string consulta = cbTipo_consulta.SelectedItem.ToString();

            //nome
            switch(consulta)
            {
                case "Nome": //mesmo nome da combo
                    if(txtPesquisar.Text != "")
                    {
                        if (rbInicio.Checked == true)
                        {
                            dataGrid.DataSource = cProduto.ConsultaProdutoNomeInicio(txtPesquisar.Text);
                        }
                        else
                        {
                            dataGrid.DataSource = cProduto.ConsultaProdutoNomeContem(txtPesquisar.Text);
                        }




                    }
                    else //campo pesquisar validação
                    {
                        MessageBox.Show("Favor informar um nome.", "Sistema J.D Modas - Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                //status
                case "Status":
                    if (rbAtivo.Checked == true)
                    {
                        dataGrid.DataSource = cProduto.ConsultaProdutoStatus(1);
                    }
                    else
                    {
                        dataGrid.DataSource = cProduto.ConsultaProdutoStatus(0);
                    }
                    break;

                //valor venda
                case "Valor Venda":
                    if (txtValor_venda.Text != "")
                    {
                        dataGrid.DataSource = cProduto.ConsultaProdutoValorVenda(Convert.ToDecimal(txtValor_venda.Text));
                    }
                    else
                    {
                        dataGrid.DataSource = cProduto.ConsultaProdutoValorVenda(Convert.ToDecimal(txtValor_venda.Text));
                    }
                    break;


                //~~~~~~~~~~~~~~~~
                //categoria
                case "Categoria":
                    if(cbCategoria.Text != "")
                    {
                        dataGrid.DataSource = cProduto.ConsultaProdutoCategoria(Convert.ToInt32(cbCategoria.SelectedValue));
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar uma categoria.", "Sistema J.D Modas - Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                //marca
                case "Marca":
                    if(cbMarca.Text != "")
                    {
                        dataGrid.DataSource = cProduto.ConsultaProdutoMarca(Convert.ToInt32(cbMarca.SelectedValue));
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar uma marca.", "Sistema J.D Modas - Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                //tamanho
                case "Tamanho":
                    if (cbTamanho.Text != "")
                    {
                        dataGrid.DataSource = cProduto.ConsultaProdutoTamanho(Convert.ToInt32(cbTamanho.SelectedValue));
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar um tamanho.", "Sistema J.D Modas - Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;


            }








        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //12.
            //CLICAR NA GRID DE CLIENTES E EDITAR OU EXCLUIR UM CLIENTE
            //eventos - USAR O EVENTO CellClick (que permite clicar em qualquer lugar da celula pra abrir) - se usar o default CellContentClick, teria que clicar EM CIMA do TEXTO..
            //NÃO DEIXAR SELECIONAR A GRID QUANDO VAZIA
            if (dataGrid.Rows.Count > 0)
            {
                if (MessageBox.Show("Deseja alterar o produto selecionado?", "Sistema Loja J.D Modas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //INSTANCIAR A CLASSE categoria PARA USAR OS MÉTODOS E PROPRIEDADES
                    classProduto cProduto = new classProduto();

                    //INSTANCIAR O FORMULÁRIO DE CADASTRO/ATUALIZAÇÃO DE categoria PARA USAR OS CONTROLES DE FORM
                    formProduto fProduto = new formProduto();


                    //PEGAR O CODIGO DA categoria SELECIONADO PELO USUARIO NA GRID
                    cProduto.ConsultarProduto(Convert.ToInt32(dataGrid.SelectedRows[0].Cells[0].Value));

                    //mudar a propriedade Modifiers para Public, em cada caixinha do form
                    //PASSAR OS DADOS DO BD PARA OS CONTROLES DO FORM DE categoria
                    fProduto.txtID_Produto.Text = cProduto.id_produto.ToString();
                    fProduto.datacad = cProduto.data_cadastro; //PASSAR A VARIAVEL GLOBAL CRIADA NO FORM DE CADASTRO DE categoria
                    fProduto.txtNome.Text = cProduto.nome.ToString();
                    fProduto.txtCor.Text = cProduto.cor.ToString();
                    fProduto.txtEstoque.Text = cProduto.estoque.ToString();
                    fProduto.txtDescricao.Text = cProduto.descricao.ToString();
                    fProduto.txtValor_custo.Text = cProduto.valor_custo.ToString();
                    fProduto.txtValor_venda.Text = cProduto.valor_venda.ToString();
                    //FK~~~~
                    fProduto.categoria = cProduto.id_categoria.ToString();
                    fProduto.marca = cProduto.id_marca.ToString();
                    fProduto.tamanho = cProduto.id_tamanho.ToString();


                    //CHECKBOX
                    if (cProduto.status == 1)
                    {
                        fProduto.ckbStatus.Checked = true;
                    }
                    else
                    {
                        fProduto.ckbStatus.Checked = false;
                    }

                    //MANDAR A INFORMAÇÃO DE UPDATE
                    fProduto.tipo = "Atualização";
                    //ABRIR O FORMULARIO DE CADASTRO EM MODO EXCLUSIVO
                    fProduto.ShowDialog();
                    //CHAMAR METODO DE PESQUISA - vai dar reflesh no form de consulta (F5)
                    btPesquisar_Click(this, new EventArgs());


                }
            }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void txtValor_venda_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Numeros com virgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44)
                e.Handled = true;
        }
    }
}
