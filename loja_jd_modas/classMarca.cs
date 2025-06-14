using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace loja_jd_modas
{
    class classMarca
    {
        // MÉTODO CONSTRUTOR DA CLASSE - serve para inicializar todas as variaveis e propriedades 
        //precisa ter o mesmo nome da classe 
        public classMarca()
        {
            id_marca = 0;
            nome = null;
            data_cadastro = DateTime.Now;
            status = 0;

            //contar pra ver se todos os campos da tabela estão aqui

        }

        // declarar as PROPRIEDADES - serve para ler e gravar as informações (mostra para o banco o que ele tem que gravar) 
        // ATALHO PRA CRIAR AS PROPRIEDADES: 'prop' + tab tab

        public int id_marca { get; set; }


        public string nome { get; set; }

        public DateTime data_cadastro { get; set; }

        public int status { get; set; }

        // criar os METODOS (funcionalidades do sistema) - CADASTRO - CONSULTA - ATUALIZAÇÃO - EXCLUSÃO
        //CRIAÇÃO: tipo do método - tipo de retorno (dado) - nome do método - parâmetros 

        //MÉTODO CADASTRAR CLIENTE - metodo de retorno - vai ser int pra 1 se retornar certo e 0 se nao
        public int CadastroMarca()
        {
            //colocar na sequencia em que esta no CAMPO - ter a sequencia em maos: (cod_cliente, data_cadastro, nome_cliente...)                                     
            string query = "INSERT INTO marca VALUES (0, '"+ nome +"',now(), 1)";

            //CRIAR OBJETO DA CLASSE CONEXAO
            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(query);
            //                   => vai ser o botao Executar do banco



        }

        //MÉTODO PARA BUSCAR OS DADOS (CÓDIGO E NOME DA MARCA) DA TABELA MARCA
        //PARA POPULAR A COMBO DE MARCA DO FORMULÁRIO DE CADASTRO DE PRODUTOS
        // ANTES ADICIONAR EM CIMA "using System.Data;"
        public DataTable BuscarMarca()
        {
            string query = "SELECT id_marca, nome FROM marca WHERE status = 1 ORDER BY nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //--------------------------------------------------------------------------------------------------------------------------
        //MÉTODOS DE CONSULTA
        //2.CONSULTA DE CLIENTE POR nome, (início e contém), cpf, sexo e status
        //CAMPOS EXIBIDOS NA CONSULTA: cod, nome, cpf, data nascimento, sexo e telefone

        //DEFINIR using System.Data;!!
        //CONSULTA DE marca POR nome (início)

        public DataTable ConsultaMarcaNomeInicio(string nome_inicio) //todos os parametros do WHERE ficam dentro deste parenteses - e definir o tipo de dado (parametro por data: datetime, parametro por preço: decimal)
        {
            string query = "SELECT id_marca, nome FROM marca WHERE status = 1 AND nome LIKE '" + nome_inicio + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //CONSULTA DE marca POR nome(contém)
        public DataTable ConsultaMarcaNomeContem(string nome_contem)
        {
            string query = "SELECT id_marca, nome FROM marca WHERE status = 1 AND nome LIKE '%" + nome_contem + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //CONSULTA DE marca POR status
        public DataTable ConsultaMarcaStatus(int status)
        {
            string query = "SELECT id_marca, nome FROM marca WHERE status = " + status + " ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }
        //SEMPRE MUDAR: Nome do método, Parametro e Clausula WHERE


        //-----------------------------------------------------------------------------------------------------------------------------------------
        //3.MÉTODO PARA BUSCAR OS DADOS DO BANCO QUANDO O USUARIO ESCOLHE A MARCA NA GRID

        public bool ConsultarMarca(int id)
        {
            string query = "SELECT * FROM marca WHERE id_marca = " + id + " ";
            classConexao cConexao = new classConexao();
            DataTable dt = cConexao.RetornaDataTable(query);

            if(dt.Rows.Count > 0)
            {
                id_marca = Convert.ToInt32(dt.Rows[0]["id_marca"]); // --> nome NO banco
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

        //------------------------------------------------------------------------------------------------------------------------------------------
        //4.MÉTODO ATUALIZAR MARCA
        public bool AtualizarMarca()
        {
            string query = "UPDATE marca SET nome = '" + nome + "', status = " + status + " WHERE id_marca = " + id_marca + " ";

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
        public bool ExcluirMarca()
        {
            string query = "DELETE FROM marca WHERE id_marca = " + id_marca + " ";

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
            //6.desenhar o formulario de consulta
        }

        //___________________________________________________________
        //RELATÓRIO DE MARCA SIMPLES - métodos
        //2.
        public DataTable RelatorioMarca()
        {
            string query = "SELECT nome, data_cadastro,  status FROM marca WHERE status = 1 ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

    }













}

