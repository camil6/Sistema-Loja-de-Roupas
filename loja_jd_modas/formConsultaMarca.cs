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
    public partial class formConsultaMarca : Form
    {
        public formConsultaMarca()
        {
            InitializeComponent();
        }

        private void formConsultaMarca_Load(object sender, EventArgs e)
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
            //dar 2 clicks na combo de tipo consulta, tambem nomear todas as caixinhas do form
            //8.ATIVAR/DESATIVAR OS ELEMENTOS DO FORM CONFORME A ESCOLHA DO USUARIO

            //nome
            if (cbTipo_consulta.SelectedIndex == 0)
            {
                txtPesquisar.Enabled = true;
                gbTipo_pesquisa.Enabled = true;
                gbStatus.Enabled = false;
            }

            //status
            if (cbTipo_consulta.SelectedIndex == 1)
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
            classMarca cMarca = new classMarca();

            //CRIAR UMA VARIAVEL PARA RECEBER A OPÇAO ESCOLHIDA PELO USUARIO NA COMBO
            string consulta = cbTipo_consulta.SelectedItem.ToString();

            //nome
            switch (consulta)
            {
                case "Nome": //mesmo nome da combo
                    if (txtPesquisar.Text != "")
                    {
                        if (rbInicio.Checked == true)
                        {
                            dataGrid.DataSource = cMarca.ConsultaMarcaNomeInicio(txtPesquisar.Text);
                        }
                        else
                        {
                            dataGrid.DataSource = cMarca.ConsultaMarcaNomeContem(txtPesquisar.Text);
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
                        dataGrid.DataSource = cMarca.ConsultaMarcaStatus(1);
                    }
                    else
                    {
                        dataGrid.DataSource = cMarca.ConsultaMarcaStatus(0);
                    }
                    break;

            }






        }

        private void dataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //12.
            //CLICAR NA GRID DE MARCA E EDITAR OU EXCLUIR UMA MARCA
            //eventos - USAR O EVENTO CellClick (que permite clicar em qualquer lugar da celula pra abrir) - se usar o default CellContentClick, teria que clicar EM CIMA do TEXTO..

            //NÃO DEIXAR SELECIONAR A GRID QUANDO VAZIA
            if (dataGrid.Rows.Count > 0)
            {
                if (MessageBox.Show("Deseja alterar a categoria selecionada?", "Sistema Loja J.D Modas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //INSTANCIAR A CLASSE marca PARA USAR OS MÉTODOS E PROPRIEDADES
                    classMarca cMarca = new classMarca();

                    //INSTANCIAR O FORMULÁRIO DE CADASTRO/ATUALIZAÇÃO DE marca PARA USAR OS CONTROLES DE FORM
                    formMarca fMarca = new formMarca();

                    //PEGAR O CODIGO DA marca SELECIONADO PELO USUARIO NA GRID
                    cMarca.ConsultarMarca(Convert.ToInt32(dataGrid.SelectedRows[0].Cells[0].Value));


                    //mudar a propriedade Modifiers para Public, em cada caixinha do FORM marca
                    //PASSAR OS DADOS DO BD PARA OS CONTROLES DO FORM DE marca
                    fMarca.txtID_marca.Text = cMarca.id_marca.ToString();
                    fMarca.lbData.Text = cMarca.data_cadastro.ToString();
                    fMarca.txtNome.Text = cMarca.nome.ToString();

                    //CHECKBOX
                    if (cMarca.status == 1)
                    {
                        fMarca.ckbStatus.Checked = true;
                    }
                    else
                    {
                        fMarca.ckbStatus.Checked = false;
                    }

                    //MANDAR A INFORMAÇÃO DE UPDATE
                    fMarca.tipo = "Atualização";
                    //ABRIR O FORMULARIO DE CADASTRO EM MODO EXCLUSIVO
                    fMarca.ShowDialog();
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
