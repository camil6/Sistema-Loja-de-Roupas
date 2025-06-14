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
    public partial class formRelatorioProduto : Form
    {
        public formRelatorioProduto()
        {
            InitializeComponent();
        }

        private void formRelatorioProduto_Load(object sender, EventArgs e)
        {
            //CARREGAR AS OPÇÕES DE PESQUISA
            cbTipo_relatorio.Items.Add("Categoria");
            cbTipo_relatorio.Items.Add("Marca");
            cbTipo_relatorio.Items.Add("Tamanho");
            cbTipo_relatorio.Items.Add("Status");
            cbTipo_relatorio.Items.Add("Estoque em baixa");
            cbTipo_relatorio.Items.Add("Valor na faixa de");

            //DEIXAR SELECIONADA A OPÇÃO nome
            cbTipo_relatorio.SelectedItem = "Status";


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

        private void cbTipo_relatorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dar 2 clicks na combo de tipo consulta, tambem nomear todas as caixinhas do form
            //ATIVAR/DESATIVAR OS ELEMENTOS DO FORM CONFORME A ESCOLHA DO USUARIO

            //categoria
            if (cbTipo_relatorio.SelectedIndex == 0)
            {
                gbCategoria.Enabled = true;
                gbMarca.Enabled = false;
                gbTamanho.Enabled = false;
                gbStatus.Enabled = false;
                gbEstoque.Enabled = false;
                gbValor.Enabled = false;

            }

            //marca
            if (cbTipo_relatorio.SelectedIndex == 1)
            {
                gbCategoria.Enabled = false;
                gbMarca.Enabled = true;
                gbTamanho.Enabled = false;
                gbStatus.Enabled = false;
                gbEstoque.Enabled = false;
                gbValor.Enabled = false;

            }

            //tamanho
            if (cbTipo_relatorio.SelectedIndex == 2)
            {
                gbCategoria.Enabled = false;
                gbMarca.Enabled = false;
                gbTamanho.Enabled = true;
                gbStatus.Enabled = false;
                gbEstoque.Enabled = false;
                gbValor.Enabled = false;

            }

            //status
            if (cbTipo_relatorio.SelectedIndex == 3)
            {
                gbCategoria.Enabled = false;
                gbMarca.Enabled = false;
                gbTamanho.Enabled = false;
                gbStatus.Enabled = true;
                gbEstoque.Enabled = false;
                gbValor.Enabled = false;

            }

            //estoque
            if (cbTipo_relatorio.SelectedIndex == 4)
            {
                gbCategoria.Enabled = false;
                gbMarca.Enabled = false;
                gbTamanho.Enabled = false;
                gbStatus.Enabled = false;
                gbEstoque.Enabled = true;
                gbValor.Enabled = false;

            }

            //valor entre
            if (cbTipo_relatorio.SelectedIndex == 5)
            {
                gbCategoria.Enabled = false;
                gbMarca.Enabled = false;
                gbTamanho.Enabled = false;
                gbStatus.Enabled = false;
                gbEstoque.Enabled = false;
                gbValor.Enabled = true;

            }

        }

        private void btRelatorio_Click(object sender, EventArgs e)
        {
            //INSTANCIAR A CLASSE PARA USAR OS METODOS DE CONSULTA
            classProduto cProduto = new classProduto();

            //CRIAR UMA VARIAVEL PARA RECEBER A OPÇAO ESCOLHIDA PELO USUARIO NA COMBO
            string relatorio = cbTipo_relatorio.SelectedItem.ToString();


            switch (relatorio)
            {

                //categoria
                case "Categoria":
                    if (cbCategoria.Text != "")
                    {
                        //se não aparecer o binding source- ir no formulario - clicar na setinha do reportviwer - e ligar com o binding source 
                        //datasource le select
                        classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoCategoria(Convert.ToInt32(cbCategoria.SelectedValue));
                        this.rptvProduto.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar uma categoria.", "Sistema J.D Modas - Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                //marca
                case "Marca":
                    if (cbMarca.Text != "")
                    {
                        //se não aparecer o binding source- ir no formulario - clicar na setinha do reportviwer - e ligar com o binding source 
                        //datasource le select
                        classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoMarca(Convert.ToInt32(cbMarca.SelectedValue));
                        this.rptvProduto.RefreshReport();
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

                        classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoTamanho(Convert.ToInt32(cbTamanho.SelectedValue));
                        this.rptvProduto.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar um tamanho.", "Sistema J.D Modas - Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                //status
                case "Status":
                    if (rbAtivo.Checked == true)
                    {

                        classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoStatus(1);
                        this.rptvProduto.RefreshReport();
                    }
                    else
                    {
                        classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoStatus(0);
                        this.rptvProduto.RefreshReport();
                    }
                    break;



                //estoque
                case "Estoque em baixa":
                    if(txtEstoque.Text != "")
                    {
                        classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoEstoque(Convert.ToInt32(txtEstoque.Text));
                        this.rptvProduto.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Favor preencher o estoque.", "Sistema J.D Modas - Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    break;

                    //valor
                case "Valor na faixa de":
                    if (txtValor1.Text != "" && txtValor2.Text != "")
                    {
                        classProdutoBindingSource.DataSource = cProduto.RelatorioProdutoValor(Convert.ToDecimal(txtValor1.Text), Convert.ToDecimal(txtValor2.Text));
                        this.rptvProduto.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Favor preencher os valores.", "Sistema J.D Modas - Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    break;


            }

            

        }

        //ESCREVER APENAS NUMEROS NO TXT - eventos - TextChanged
        private void txtValor1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtValor1.Text, "[^0-9,]"))
            {
                MessageBox.Show("Favor escrever apenas números.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValor1.Text = txtValor1.Text.Remove(txtValor1.Text.Length - 1);
            }
        }

        private void txtValor2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtValor2.Text, "[^0-9,]"))
            {
                MessageBox.Show("Favor escrever apenas números.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtValor2.Text = txtValor2.Text.Remove(txtValor2.Text.Length - 1);
            }
        }

        private void txtEstoque_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtEstoque.Text, "[^0-9]"))
            {
                MessageBox.Show("Favor escrever apenas números.", "Sistema Loja J.D Modas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEstoque.Text = txtEstoque.Text.Remove(txtEstoque.Text.Length - 1);
            }
        }

        private void txtValor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Numeros com virgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44)
                e.Handled = true;

        }

        private void txtValor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Numeros com virgula
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != 44)
                e.Handled = true;

        }

        private void txtEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Numeros

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
