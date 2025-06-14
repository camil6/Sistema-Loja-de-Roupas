using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace loja_jd_modas
{
    class classCategoria
    {
        // MÉTODO CONSTRUTOR DA CLASSE - serve para inicializar todas as variaveis e propriedades 
        //precisa ter o mesmo nome da classe 

        public classCategoria()
        {
            id_categoria = 0;
            nome = null;
            data_cadastro = DateTime.Now;
            status = 0;
            //contar pra ver se todos os campos da tabela estão aqui
        }

        // declarar as PROPRIEDADES - serve para ler e gravar as informações (mostra para o banco o que ele tem que gravar) 
        // ATALHO PRA CRIAR AS PROPRIEDADES: 'prop' + tab tab

        public int id_categoria { get; set; }

        public string nome { get; set; }

        public DateTime data_cadastro { get; set; }

        public int status { get; set; }

        // criar os METODOS (funcionalidades do sistema) - CADASTRO - CONSULTA - ATUALIZAÇÃO - EXCLUSÃO
        //CRIAÇÃO: tipo do método - tipo de retorno (dado) - nome do método - parâmetros 

        //MÉTODO CADASTRAR - metodo de retorno - vai ser int pra 1 se retornar certo e 0 se nao

        public int CadastroCategoria()
        {
            //colocar na sequencia em que esta no CAMPO - ter a sequencia em maos: (cod_cliente, data_cadastro, nome_cliente...)
            string query = "INSERT INTO categoria VALUES (0, '" + nome + "', now(), 1)";

            //CRIAR OBJETO DA CLASSE CONEXAO
            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(query);
        }



        //MÉTODO PARA BUSCAR OS DADOS (CÓDIGO E NOME DA CATEGORIA) DA TABELA CATEGORIA
        //PARA POPULAR A COMBO DE CATEGORIA DO FORMULÁRIO DE CADASTRO DE PRODUTOS
        // ANTES ADICIONAR EM CIMA "using System.Data;"
        public DataTable BuscarCategoria()
        {
            string query = "SELECT id_categoria, nome FROM categoria WHERE status = 1 ORDER BY nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //--------------------------------------------------------------------------------------------------------------------------
        //MÉTODOS DE CONSULTA
        //2.CONSULTA DE categoria POR nome (início e contém), e status
        //CAMPOS EXIBIDOS NA CONSULTA: id_categoria, nome.
        //DEFINIR using System.Data;!!

        //CONSULTA DE categoria POR nome (início)

        public DataTable ConsultaCategoriaNomeInicio(string nome_inicio) //todos os parametros do WHERE ficam dentro deste parenteses - e definir o tipo de dado (parametro por data: datetime, parametro por preço: decimal)
        {
            string query = "SELECT id_categoria, nome FROM categoria WHERE status = 1 AND nome LIKE '" + nome_inicio + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //CONSULTA DE categoria POR nome(contém)
        public DataTable ConsultaCategoriaNomeContem(string nome_contem)
        {
            string query = "SELECT id_categoria, nome FROM categoria WHERE status = 1 AND nome LIKE '%" + nome_contem + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //CONSULTA DE categoria POR status
        public DataTable ConsultaCategoriaStatus(int status)
        {
            string query = "SELECT id_categoria, nome FROM categoria WHERE status = " + status + " ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //--------------------------------------------------------------------------------
        //3.MÉTODO PARA BUSCAR OS DADOS DO BANCO QUANO O USUARIO ESCOLHE A categoria NA GRID
        public bool ConsultarCategoria(int id)
        {
            string query = "SELECT * FROM categoria WHERE id_categoria = " + id + " ";
            classConexao cConexao = new classConexao();
            DataTable dt = cConexao.RetornaDataTable(query);

            if(dt.Rows.Count > 0)
            {                                                 
                id_categoria = Convert.ToInt32(dt.Rows[0]["id_categoria"]); // --> nome NO banco
                nome = dt.Rows[0]["nome"].ToString();
                data_cadastro = Convert.ToDateTime(dt.Rows[0]["data_cadastro"]);
                status = Convert.ToInt32(dt.Rows[0]["status"]);

                return true;
            }
            else
            {
                return false;
            }
        }

        //--------------------------
        //4.MÉTODO ATUALIZAR
        public bool AtualizarCategoria()
        {
            string query = "UPDATE categoria SET nome = '" + nome + "', status = " + status + " WHERE id_categoria = " + id_categoria + " ";

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

        //----------------
        //5.MÉTODO EXCLUIR
        public bool ExcluirCategoria()
        {
            string query = "DELETE FROM categoria WHERE id_categoria = " + id_categoria + " ";
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

        //___________________________________________________________
        //RELATÓRIO DE CATEGORIA SIMPLES - métodos
       //2.
        public DataTable RelatorioCategoria()
        {
            string query = "SELECT nome, data_cadastro, status FROM categoria WHERE status = 1 ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }











    }
}
