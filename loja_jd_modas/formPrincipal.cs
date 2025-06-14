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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ANTES - ATIVAR O MDI Container no formulario principal (IsMdiContainer = true)
            //CHAMADA FORM CADASTRO - CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL

            //formCliente fcliente = new formCliente();
            //fcliente.MdiParent = this;
            //fcliente.Show();


            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)

            if (Application.OpenForms.OfType<formMarca>().Count() > 0)
            {
                MessageBox.Show("O formulário Cadastro de Marcas já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formMarca fmarca = new formMarca();
                fmarca.MdiParent = this;
                fmarca.Show();
            }


        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // CHAMADA FORM CADASTRO -CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL
            //formCliente fcliente = new formCliente();
            //fcliente.MdiParent = this;
            //fcliente.Show();


            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)

            if (Application.OpenForms.OfType<formCategoria>().Count() > 0)
            {
                MessageBox.Show("O formulário já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formCategoria fCategoria = new formCategoria();
                fCategoria.MdiParent = this;
                fCategoria.Show();
            }
        }

        private void tamanhosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // CHAMADA FORM CADASTRO -CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL
            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)

            if (Application.OpenForms.OfType<formTamanho>().Count() > 0)
            {
                MessageBox.Show("O formulário já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formTamanho fTamanho = new formTamanho();
                fTamanho.MdiParent = this;
                fTamanho.Show();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MENSAGEM PARA SAIR DO SISTEMA
            if (MessageBox.Show("Tem certeza que deseja sair do sistema?", "Loja J.D Modas - Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //DATA E HORA NA BARRA DE STATUS
            statuslbData.Text = DateTime.Now.ToShortDateString();
            statuslbHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // CHAMADA FORM CADASTRO -CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL
            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)

            if(Application.OpenForms.OfType<formProduto>().Count() > 0)
            {
                MessageBox.Show("O formulário já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formProduto fProduto = new formProduto();
                fProduto.MdiParent = this;
                fProduto.Show();


            }





        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // CHAMADA FORM CADASTRO -CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL
            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)
            if(Application.OpenForms.OfType<formConsultaCategoria>().Count() > 0)
            {
                MessageBox.Show("O formulário já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formConsultaCategoria fConsultaCategoria = new formConsultaCategoria();
                fConsultaCategoria.MdiParent = this;
                fConsultaCategoria.Show();
            }

        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // CHAMADA FORM CADASTRO -CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL
            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)
            if (Application.OpenForms.OfType<formConsultaMarca>().Count() > 0)
            {
                MessageBox.Show("O formulário já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formConsultaMarca fConsultaMarca = new formConsultaMarca();
                fConsultaMarca.MdiParent = this;
                fConsultaMarca.Show();
            }
        }

        private void tamanhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // CHAMADA FORM CADASTRO -CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL
            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)
            if (Application.OpenForms.OfType<formConsultaTamanho>().Count() > 0)
                {
                MessageBox.Show("O formulário já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formConsultaTamanho fConsultaTamanho = new formConsultaTamanho();
                fConsultaTamanho.MdiParent = this;
                fConsultaTamanho.Show();
            }




        }

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // CHAMADA FORM -CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL
            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)
            if (Application.OpenForms.OfType<formConsultaProduto>().Count() > 0)
            {
                MessageBox.Show("O formulário já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formConsultaProduto fConsultaProduto = new formConsultaProduto();
                fConsultaProduto.MdiParent = this;
                fConsultaProduto.Show();
            }



        }

        private void categoriasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // CHAMADA DO FORM -CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL
            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)
            if (Application.OpenForms.OfType<formRelatorioCategoria>().Count() > 0)
            {
                MessageBox.Show("O formulário já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formRelatorioCategoria fRelatorioCategoria = new formRelatorioCategoria();
                fRelatorioCategoria.MdiParent = this;
                fRelatorioCategoria.Show();
            }

        }

        private void marcasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // CHAMADA DO FORM -CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL
            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)
            if (Application.OpenForms.OfType<formRelatorioMarca>().Count() > 0)
            {
                MessageBox.Show("O formulário já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formRelatorioMarca fRelatorioMarca = new formRelatorioMarca();
                fRelatorioMarca.MdiParent = this;
                fRelatorioMarca.Show();
            }


        }

        private void tamanhosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // CHAMADA DO FORM -CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL
            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)
            if (Application.OpenForms.OfType<formRelatorioTamanho>().Count() > 0)
            {
                MessageBox.Show("O formulário já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formRelatorioTamanho fRelatorioTamanho = new formRelatorioTamanho();
                fRelatorioTamanho.MdiParent = this;
                fRelatorioTamanho.Show();
            }

        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // CHAMADA DO FORM -CRIAR OBJETO E INSTANCIAR - DIZER QUE O OBJETO É FILHO DO FORM PRINCIPAL
            //Nao deixar o usuario abrir o mesmo formulario mais de 1 vez (com IF)
            if (Application.OpenForms.OfType<formRelatorioProduto>().Count() > 0)
            {
                MessageBox.Show("O formulário já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                formRelatorioProduto fRelatorioProduto = new formRelatorioProduto();
                fRelatorioProduto.MdiParent = this;
                fRelatorioProduto.Show();
            }



        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formClientecs>().Count() > 0)
            {
                MessageBox.Show("O formulário Cadastro de Clientes já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                formClientecs fcliente = new formClientecs();
                fcliente.MdiParent = this;
                fcliente.Show();
            }


        }

        private void funcionáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formFuncionario>().Count() > 0)
            {
                MessageBox.Show("O formulário Cadastro de Clientes já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                formFuncionario fFuncionario = new formFuncionario();
                fFuncionario.MdiParent = this;
                fFuncionario.Show();
            }


        }

        private void cargosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formCargo>().Count() > 0)
            {
                MessageBox.Show("O formulário Cadastro de Clientes já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                formCargo fCargo = new formCargo();
                fCargo.MdiParent = this;
                fCargo.Show();
            }
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formConsultaFuncionario>().Count() > 0)
            {
                MessageBox.Show("O formulário cadastro de Funcionario já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                formConsultaFuncionario fconsulta = new formConsultaFuncionario();
                fconsulta.MdiParent = this;
                fconsulta.Show();
            }

        }

        private void cargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formConsultaCargo>().Count() > 0)
            {
                MessageBox.Show("O formulário cadastro de Cargo já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                formConsultaCargo fconsulta = new formConsultaCargo();
                fconsulta.MdiParent = this;
                fconsulta.Show();
            }

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formConsultaCliente>().Count() > 0)
            {
                MessageBox.Show("O formulário cadastro de Clientes já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                formConsultaCliente fconsulta = new formConsultaCliente();
                fconsulta.MdiParent = this;
                fconsulta.Show();
            }

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formRelatorioCliente>().Count() > 0)
            {
                MessageBox.Show("O Relatorio Cliente já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                formRelatorioCliente fRelatorioCliente = new formRelatorioCliente();
                fRelatorioCliente.MdiParent = this;
                fRelatorioCliente.Show();

            }
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formRelatorioFuncionario>().Count() > 0)
            {
                MessageBox.Show("O Relatorio Funcionario já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                formRelatorioFuncionario fRelatorioFuncionario = new formRelatorioFuncionario();
                fRelatorioFuncionario.MdiParent = this;
                fRelatorioFuncionario.Show();

            }
        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formRelatorioCargo>().Count() > 0)
            {
                MessageBox.Show("O Relatorio Cargo já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                formRelatorioCargo fRelatorioCargo = new formRelatorioCargo();
                fRelatorioCargo.MdiParent = this;
                fRelatorioCargo.Show();

            }
        }

        private void vendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formVenda43>().Count() > 0)
            {
                MessageBox.Show("O Formulário de Venda já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                formVenda43 fVenda43 = new formVenda43();
                fVenda43.MdiParent = this;
                fVenda43.Show();

            }
        }

        private void vendaToolStripMenuItemRelatorio_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<formVenda43>().Count() > 0)
            {
                MessageBox.Show("O Formulário de Venda já está aberto.", "Loja J.D Modas - Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                formRelatorioVenda fRelatorioVenda = new formRelatorioVenda();
                fRelatorioVenda.MdiParent = this;
                fRelatorioVenda.Show();
            }

        }
    }
    
}
