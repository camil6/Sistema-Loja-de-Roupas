using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace loja_jd_modas
{
    internal class classProduto
    {
        // MÉTODO CONSTRUTOR DA CLASSE - serve para inicializar todas as variaveis e propriedades
        // precisa ter o mesmo nome da classe

        public classProduto()
        {
            id_produto = 0;
            nome = null;
            cor = null;
            descricao = null;
            estoque = 0;
            valor_custo = 0;
            valor_venda = 0;
            data_cadastro = DateTime.Now;
            status = 0;
            // FK
            id_categoria = 0;
            id_marca = 0;
            id_tamanho = 0;


        }

        // declarar as PROPRIEDADES - serve para ler e gravar as informações (mostra para o banco o que ele tem que gravar) 
        // ATALHO PRA CRIAR AS PROPRIEDADES: 'prop' + tab tab

        public int id_produto { get; set; }

        public string nome { get; set; }

        public string cor { get; set; }

        public string descricao { get; set; }

        public int estoque { get; set; }

        public decimal valor_custo { get; set; }

        public decimal valor_venda { get; set; }

        public DateTime data_cadastro { get; set; }

        public int status { get; set; }
        // FK
        public int id_categoria { get; set; }

        public int id_marca { get; set; }

        public int id_tamanho { get; set; }


        // criar os METODOS (funcionalidades do sistema) - CADASTRO - CONSULTA - ATUALIZAÇÃO - EXCLUSÃO
        //CRIAÇÃO: tipo do método - tipo de retorno (dado) - nome do método - parâmetros 

        //MÉTODO CADASTRAR - metodo de retorno - vai ser int pra 1 se retornar certo e 0 se nao



        // MÉTODO CADASTRAR PRODUTO
        // -----ADICIONAR AS CHAVES ESTRANGEIRAS NO METODO CONTRUTOR E PROPRIEDADES!!
        public int CadastroProduto()
        {
            //colocar na sequencia em que esta no CAMPO - ter a sequencia em maos: (cod_cliente, data_cadastro, nome_cliente...)

            //string query = "INSERT INTO produto VALUES (0, '" + nome + "', '" + cor + "', '" + descricao + "', '"+ estoque +"', '"+ valor_custo.ToString().Replace(",", ".") + "', '"+ valor_venda.ToString().Replace(",", ".") + "', now(), 1)";
            string query = "INSERT INTO produto VALUES (0, '" + nome + "', '" + cor + "', '" + descricao + "', '" + estoque + "', '" + valor_custo.ToString().Replace(",", ".") + "', '" + valor_venda.ToString().Replace(",", ".") + "', now(), 1, " + id_categoria + ", " + id_marca + ", " + id_tamanho + ")";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(query);

        }

        //--------------------------------------------------------------------------------------------------------------------------
        //MÉTODOS DE CONSULTA
        //2.CONSULTA DE PRODUTO POR nome, (início e contém), valor venda, tamanho, categoria, marca e status
        //CAMPOS EXIBIDOS NA CONSULTA: cod, nome, valor venda, estoque

        //DEFINIR using System.Data;!!
        //CONSULTA DE PRODUTO POR nome (início)

        public DataTable ConsultaProdutoNomeInicio(string nome_inicio)
        {
            string query = "SELECT id_produto, nome, valor_venda, estoque FROM produto WHERE status = 1 AND nome LIKE '" + nome_inicio + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //CONSULTA DE PRODUTO POR nome(contém)
        public DataTable ConsultaProdutoNomeContem(string nome_contem)
        {
            string query = "SELECT id_produto, nome, valor_venda, estoque FROM produto WHERE status = 1 AND nome LIKE '%" + nome_contem + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //CONSULTA DE PRODUTO POR status
        public DataTable ConsultaProdutoStatus(int status)
        {
            string query = "SELECT id_produto, nome, valor_venda, estoque FROM produto WHERE status = " + status + " ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //CONSULTA DE PRODUTO POR valor venda
        public DataTable ConsultaProdutoValorVenda(decimal valor_venda)
        {
            string query = "SELECT id_produto, nome, valor_venda, estoque FROM produto WHERE valor_venda = " + valor_venda.ToString().Replace(",", ".") + " ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }


        //CONSULTA DE PRODUTO POR categoria
        public DataTable ConsultaProdutoCategoria(int categoria)
        {
            string query = "SELECT produto.id_produto, produto.nome 'Nome Produto', produto.valor_venda, produto.estoque, categoria.nome 'Nome Categoria' FROM produto JOIN categoria ON produto.id_categoria = categoria.id_categoria WHERE produto.status = 1 AND categoria.id_categoria = '" + categoria + "' ORDER BY produto.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }


        //CONSULTA DE PRODUTO POR marca
        public DataTable ConsultaProdutoMarca(int marca)
        {
            string query = "SELECT produto.id_produto, produto.nome 'Nome Produto' , produto.valor_venda, produto.estoque, marca.nome 'Nome Marca' FROM produto JOIN marca ON produto.id_marca = marca.id_marca WHERE produto.status = 1 AND marca.id_marca = '" + marca + "' ORDER BY produto.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }


        //CONSULTA DE PRODUTO POR tamanho
        public DataTable ConsultaProdutoTamanho(int tamanho)
        {
            string query = "SELECT produto.id_produto, produto.nome 'Nome Produto', produto.valor_venda, produto.estoque, tamanho.nome 'Tamanho' FROM produto JOIN tamanho ON produto.id_tamanho = tamanho.id_tamanho WHERE produto.status = 1 AND tamanho.id_tamanho = '" + tamanho + "' ORDER BY produto.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------
        //3.MÉTODO PARA BUSCAR OS DADOS DO BANCO QUANDO O USUARIO ESCOLHE O PRODUTO NA GRID
        public bool ConsultarProduto(int id)
        {
            string query = "SELECT * FROM produto WHERE id_produto = " + id + " ";
            classConexao cConexao = new classConexao();
            DataTable dt = cConexao.RetornaDataTable(query);

            if(dt.Rows.Count > 0)
            {
                id_produto = Convert.ToInt32(dt.Rows[0]["id_produto"]); // --> nome NO banco
                nome = dt.Rows[0]["nome"].ToString();
                cor = dt.Rows[0]["cor"].ToString();
                descricao = dt.Rows[0]["descricao"].ToString();
                estoque = Convert.ToInt32(dt.Rows[0]["estoque"]);
                valor_custo = Convert.ToDecimal(dt.Rows[0]["valor_custo"]);
                valor_venda = Convert.ToDecimal(dt.Rows[0]["valor_venda"]);
                data_cadastro = Convert.ToDateTime(dt.Rows[0]["data_cadastro"]);
                status = Convert.ToInt32(dt.Rows[0]["status"]);
                id_categoria = Convert.ToInt32(dt.Rows[0]["id_categoria"]);
                id_marca = Convert.ToInt32(dt.Rows[0]["id_marca"]);
                id_tamanho = Convert.ToInt32(dt.Rows[0]["id_tamanho"]);

                return true;
            }
            else
            {
                return false;
            }

        }

        //------------------------------------------------------------------------------------------------------------------------------------------
        //4.MÉTODO ATUALIZAR PRODUTO

        public bool AtualizarProduto()
        {
            string query = "UPDATE produto SET nome = '" + nome + "', cor = '" + cor + "', descricao = '" + descricao + "', estoque = '" + estoque + "', valor_custo = '" + valor_custo.ToString().Replace(",", ".") + "', valor_venda = '" + valor_venda.ToString().Replace(",", ".") + "', status = " + status + ", id_categoria = " + id_categoria + ", id_marca = " + id_marca + ", id_tamanho = " + id_tamanho + " WHERE id_produto = " + id_produto + " ";

            classConexao cConexao = new classConexao();
            int resp = cConexao.ExecutaQuery(query);

            if (resp != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //---------------------------
        //5.MÉTODO EXCLUIR
        public bool ExcluirProduto()
        {
            string query = "DELETE FROM produto WHERE id_produto = " + id_produto + " ";

            classConexao cConexao = new classConexao();
            int resp = cConexao.ExecutaQuery(query);

            if (resp != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //___________________________________________________________
        //RELATÓRIO DE PRODUTO SIMPLES - métodos
        //2.
        //relatorio de produto por categoria
        public DataTable RelatorioProdutoCategoria(int categoria)
        {
            string query = "SELECT produto.nome, produto.estoque, categoria.nome 'id_categoria', marca.nome 'id_marca', tamanho.nome 'id_tamanho', produto.valor_venda FROM produto JOIN categoria ON produto.id_categoria = categoria.id_categoria JOIN marca ON produto.id_marca = marca.id_marca JOIN tamanho ON produto.id_tamanho = tamanho.id_tamanho WHERE produto.status = 1 AND categoria.id_categoria = " + categoria + " ORDER BY produto.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //relatorio de produto por marca

        public DataTable RelatorioProdutoMarca(int marca)
        {
            string query = "SELECT produto.nome, produto.estoque, categoria.nome 'id_categoria', marca.nome 'id_marca', tamanho.nome 'id_tamanho', produto.valor_venda FROM produto JOIN categoria ON produto.id_categoria = categoria.id_categoria JOIN marca ON produto.id_marca = marca.id_marca JOIN tamanho ON produto.id_tamanho = tamanho.id_tamanho WHERE produto.status = 1 AND marca.id_marca = " + marca + " ORDER BY produto.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }



        //relatorio de produto por tamanho
        public DataTable RelatorioProdutoTamanho(int tamanho)
        {
            string query = "SELECT produto.nome, produto.estoque, categoria.nome 'id_categoria', marca.nome 'id_marca', tamanho.nome 'id_tamanho', produto.valor_venda FROM produto JOIN categoria ON produto.id_categoria = categoria.id_categoria JOIN marca ON produto.id_marca = marca.id_marca JOIN tamanho ON produto.id_tamanho = tamanho.id_tamanho WHERE produto.status = 1 AND tamanho.id_tamanho = " + tamanho + " ORDER BY produto.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //relatorio de produto por status
        public DataTable RelatorioProdutoStatus(int status)
        {
            string query = "SELECT produto.nome, produto.estoque, categoria.nome 'id_categoria', marca.nome 'id_marca', tamanho.nome 'id_tamanho', produto.valor_venda FROM produto JOIN categoria ON produto.id_categoria = categoria.id_categoria JOIN marca ON produto.id_marca = marca.id_marca JOIN tamanho ON produto.id_tamanho = tamanho.id_tamanho WHERE produto.status = " + status + " ORDER BY produto.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }


        //relatorio de produto por estoque
        public DataTable RelatorioProdutoEstoque(decimal estoque)
        {
            string query = "SELECT produto.nome, produto.estoque, categoria.nome 'id_categoria', marca.nome 'id_marca', tamanho.nome 'id_tamanho', produto.valor_venda FROM produto JOIN categoria ON produto.id_categoria = categoria.id_categoria JOIN marca ON produto.id_marca = marca.id_marca JOIN tamanho ON produto.id_tamanho = tamanho.id_tamanho WHERE produto.status = 1 AND produto.estoque <= " + estoque + " ORDER BY produto.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //relatorio de produto por valor
        public DataTable RelatorioProdutoValor(decimal valor1, decimal valor2)
        {
            string query = "SELECT produto.nome, produto.estoque, categoria.nome 'id_categoria', marca.nome 'id_marca', tamanho.nome 'id_tamanho', produto.valor_venda FROM produto JOIN categoria ON produto.id_categoria = categoria.id_categoria JOIN marca ON produto.id_marca = marca.id_marca JOIN tamanho ON produto.id_tamanho = tamanho.id_tamanho WHERE produto.status = 1 AND produto.valor_venda BETWEEN " + valor1.ToString().Replace(",", ".") + " AND " + valor2.ToString().Replace(",", ".") + " ORDER BY produto.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }






        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-
        //PESQUISAR PRODUTO NA VENDA
        public DataTable PesquisarProdutoVenda(string nome)
        {
            string query = "SELECT produto.id_produto 'Código', produto.nome 'Produto', produto.estoque 'Estoque', marca.nome 'Marca', produto.valor_venda 'Preço' FROM produto JOIN marca ON produto.id_marca = marca.id_marca WHERE produto.status = 1 AND produto.nome LIKE '%" + nome + "%' ORDER BY produto.nome;";
            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }


        //METODO PRA LEVAR NOME DO PRODUTO PARA A LISTA DE ITENS (GRID DE PRODUTOS VENDIDOS)
        public string BuscarNomeProduto(int id)
        {
            string query = "SELECT nome FROM produto WHERE id_produto = " + id + " ";

            classConexao cConexao = new classConexao();
            DataTable dt = cConexao.RetornaDataTable(query);

            if(dt.Rows.Count > 0)
            {
                nome = dt.Rows[0]["nome"].ToString();
            }
            return nome;
        }


        //METODO PARA ATUALIZAR QTDE_ESTOQUE QUANDO UMA VENDA FOR FINALIZADA
        public bool AtualizarQtde(int qtde, int id)
        {
            string query = "UPDATE produto SET estoque = " + qtde + " WHERE id_produto = " + id + "";
            classConexao cConexao = new classConexao();

            int resp = cConexao.ExecutaQuery(query);

            if(resp != 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }




    }
}
