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
    public partial class formConsultaCategoria : Form
    {
        public formConsultaCategoria()
        {
            InitializeComponent();
        }

        private void formConsultaCategoria_Load(object sender, EventArgs e)
        {
            //7.
            //CARREGAR AS OPÇÕES DE PESQUISA
            cbTipo_consulta.Items.Add("Nome");
            cbTipo_consulta.Items.Add("Status");

            //DEIXAR SELECIONADA A OPÇÃO nome
            cbTipo_consulta.SelectedItem = "Nome";



        }

        private void cbTipo_consulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ir em PROPRIEDADES - EVENTOS e selecionar SelectedIndex
            //8.ATIVAR/DESATIVAR OS ELEMENTOS DO FORM CONFORME A ESCOLHA DO USUARIO

            //nome
            if(cbTipo_consulta.SelectedIndex == 0)
            {
               txtPesquisar.Enabled = true;
                gbTipo_pesquisa.Enabled = true;
                gbStatus.Enabled = false;
            }

            //status
            if(cbTipo_consulta.SelectedIndex == 1)
            {
                txtPesquisar.Enabled = false;
                gbTipo_pesquisa.Enabled = false;
                gbStatus.Enabled = true;
            }


        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            //9.
            //INSTANCIAR A CLASSE CLIENTE PARA USAR OS METODOS DE CONSULTA
            classCategoria cCategoria = new classCategoria();

            //CRIAR UMA VARIAVEL PARA RECEBER A OPÇAO ESCOLHIDA PELO USUARIO NA COMBO
            string consulta = cbTipo_consulta.SelectedItem.ToString();

            //nome
            switch(consulta)
            {
                case "Nome": //mesmo nome da combo
                    if(txtPesquisar.Text != "")
                    {
                        if(rbInicio.Checked == true)
                        {
                            dataGrid_Categoria.DataSource = cCategoria.ConsultaCategoriaNomeInicio(txtPesquisar.Text);
                        }
                        else
                        {
                            dataGrid_Categoria.DataSource = cCategoria.ConsultaCategoriaNomeContem(txtPesquisar.Text);
                        }


                    }
                    else //campo pesquisar validação
                    {
                        MessageBox.Show("Favor informar um nome.", "Sistema J.D Modas - Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;

                //status
                case "Status":
                    if(rbAtivo.Checked == true)
                    {
                        dataGrid_Categoria.DataSource = cCategoria.ConsultaCategoriaStatus(1);
                    }
                    else
                    {
                        dataGrid_Categoria.DataSource = cCategoria.ConsultaCategoriaStatus(0);
                    }
                    break;


            }



        }

        private void dataGrid_Categoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //12.
            //CLICAR NA GRID DE CLIENTES E EDITAR OU EXCLUIR UM CLIENTE
            //eventos - USAR O EVENTO CellClick (que permite clicar em qualquer lugar da celula pra abrir) - se usar o default CellContentClick, teria que clicar EM CIMA do TEXTO..


            //NÃO DEIXAR SELECIONAR A GRID QUANDO VAZIA
            if (dataGrid_Categoria.Rows.Count > 0)
            {
                if (MessageBox.Show("Deseja alterar a categoria selecionada?", "Sistema Loja J.D Modas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //INSTANCIAR A CLASSE categoria PARA USAR OS MÉTODOS E PROPRIEDADES
                    classCategoria cCategoria = new classCategoria();

                    //INSTANCIAR O FORMULÁRIO DE CADASTRO/ATUALIZAÇÃO DE categoria PARA USAR OS CONTROLES DE FORM
                    formCategoria fCategoria = new formCategoria();


                    //PEGAR O CODIGO DA categoria SELECIONADO PELO USUARIO NA GRID
                    cCategoria.ConsultarCategoria(Convert.ToInt32(dataGrid_Categoria.SelectedRows[0].Cells[0].Value));

                    //mudar a propriedade Modifiers para Public, em cada caixinha do form
                    //PASSAR OS DADOS DO BD PARA OS CONTROLES DO FORM DE categoria
                    fCategoria.txtID_categoria.Text = cCategoria.id_categoria.ToString();
                    fCategoria.datacad = cCategoria.data_cadastro; //PASSAR A VARIAVEL GLOBAL CRIADA NO FORM DE CADASTRO DE categoria
                    fCategoria.txtNome.Text = cCategoria.nome.ToString();

                    //CHECKBOX
                    if (cCategoria.status == 1)
                    {
                        fCategoria.ckbStatus.Checked = true;
                    }
                    else
                    {
                        fCategoria.ckbStatus.Checked = false;
                    }

                    //MANDAR A INFORMAÇÃO DE UPDATE
                    fCategoria.tipo = "Atualização";
                    //ABRIR O FORMULARIO DE CADASTRO EM MODO EXCLUSIVO
                    fCategoria.ShowDialog();
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
    }
}
