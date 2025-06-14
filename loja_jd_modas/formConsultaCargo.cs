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
    public partial class formConsultaCargo : Form
    {
        public formConsultaCargo()
        {
            InitializeComponent();
        }

        //PASSO 7 PROGRAMAR O LOAD DO FORMULÁRIO DE CONSULTA (CARREGAR AS COMBOS);
        private void formConsultaCargo_Load(object sender, EventArgs e)
        {

            cbopcoes.Items.Add("nome");
            cbopcoes.Items.Add("status");

            //DEIXAR A OPÇÃO SELECIONADA

            cbopcoes.SelectedItem = "nome";




        }

        private void cbopcoes_SelectedIndexChanged(object sender, EventArgs e)
        {

            //8- ATIVAR/DESATIVAR OS ELEMENTOS DO FORM CONFORME A ESCOLHA DO USUÁRIO

            //NOME
            if (cbopcoes.SelectedIndex == 0)
            {
                txtpesquisar.Enabled = true;
                gbtipopesquisa.Enabled = true;
                gbstatus.Enabled = false;
                
            }

            //STATUS
            if (cbopcoes.SelectedIndex == 1)
            {
                txtpesquisar.Enabled = false;
                gbtipopesquisa.Enabled = false;
                gbstatus.Enabled = true;

            }



        }

        //9
        private void btpesquisar_Click(object sender, EventArgs e)
        {

            //INSTANCIAR A CLASSE CLIENTE PARA OS MÉTODOS DE CONSULTA
            classCargo cCargo = new classCargo();

            //CRIAR UMA VARIAVEL PARA RECEBER A OPÇÃO ESCOLHIDA DO USUÁRIO NA COMBO
            string consulta = cbopcoes.SelectedItem.ToString();



            switch (consulta)
            {
                //NOME

                case "nome":
                    if (txtpesquisar.Text != "")
                    {
                        if (rbinicio.Checked == true)
                        {
                            dgvcargo.DataSource = cCargo.ConsultaCargoInicio(txtpesquisar.Text);
                        }
                        else //CAMPOS PESQUISAR VALIDAÇÃO
                        {
                            dgvcargo.DataSource = cCargo.ConsultaCargoContem(txtpesquisar.Text);
                        }
                    }

                    else //CAMPOS DE PESQUISAR VALIDAÇÃO
                    {
                        MessageBox.Show("Favor informar um cargo", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    break;



                //STATUS
                case "status":
                    if (rbativo.Checked == true)
                    {
                        dgvcargo.DataSource = cCargo.ConsultaCargoStatus(1);
                    }
                    else
                    {
                        dgvcargo.DataSource = cCargo.ConsultaCargoStatus(0);
                    }
                    break;



            }


        }



        //12- CLICAR NA GRID DE CARGO E EDITAR OU EXCLUIR UM CLIENTE
        //USAR O EVENTO CellClick (PODE CLICAR EM QUALQUER LUGAR NA CÉLULAR, NÃO SOMENTE NO TEXTO)
        //USANDO O EVENTO CellContentClick (TEM QUE CLICAR NO CONTÉUDO(TEXTO))
        private void dgvcargo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //NÃO DEIXAR SELECIONAR A GRID QUANDO VAZIA
            if (dgvcargo.Rows.Count > 0)
            {

                if (MessageBox.Show("Deseja alterar o cargo selecionado?", "Sistema Loja J.D Modas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //INSTANCIAR A CLASSE CARGO PARA USAR MÉTODOS E PROPRIEDADES
                    classCargo cCargo = new classCargo();

                    //INSTANCIAR O FORMULARIO DE CADASTRO/ATUALIZAÇÃO DE CLIENTE PARA USAR OS CONTROLES DO FORM
                    formCargo fCargo = new formCargo();

                    //PEGAR O CODIGO DO CLIENTE SELECIONADO PELO USUARIO NA GRID
                    cCargo.ConsultarCargo(Convert.ToInt32(dgvcargo.SelectedRows[0].Cells[0].Value));

                    //PASSAR OS DADOS DO BD PARA OS CONTROLES DO FORM DE CARGO
                    fCargo.txtID_cargo.Text = cCargo.id_cargo.ToString();
                    fCargo.txtNome.Text = cCargo.nome.ToString();
                    fCargo.datacad = cCargo.data_cadastro;


                    if (cCargo.status == 1)
                    {
                        fCargo.ckbStatus.Checked = true;
                    }
                    else
                    {
                        fCargo.ckbStatus.Checked = false;
                    }

                    //MANDAR A INFORMAÇÃO DE UPDATE
                    fCargo.tipo = "Atualização";
                    //ABRIR O FORMULARIO DE CADASTRO EM MODO EXCLUSIVO
                    fCargo.ShowDialog();
                    //CHAMAR METODO DE PESQUISAR
                    btpesquisar_Click(this, new EventArgs());


                }

            }














        }

        private void btsair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Apenas Letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}
