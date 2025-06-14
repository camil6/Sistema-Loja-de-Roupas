using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace loja_jd_modas
{
    internal class classCargo
    {
        public classCargo()
        {
            id_cargo = 0;
            nome = null;
            data_cadastro = DateTime.Now;
            status = 0;



        }

        public int id_cargo { get; set; }
        public string nome { get; set; }
        public DateTime data_cadastro { get; set; }
        public int status { get; set; }

        public int CadastroCargo()
        {
            string query = "INSERT INTO cargo VALUES (0, '" + nome + "',now(),1)";


                 classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(query);



        }




        //MÉTODO PARA BUSCAR OS DADOS (CÓDIGO E NOME DA CATEGORIA) DA TABELA CATEGORIA
        //PARA POPULAR A COMBO DE CATEGORIA DO FORMULÁRIO DE CADASTRO DE PRODUTOS
        // ANTES ADICIONAR EM CIMA "using System.Data;"
        public DataTable BuscarCargo()
        {
            string query = "SELECT id_cargo, nome FROM cargo WHERE status = 1 ORDER BY nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);



        }


        //2-
        public DataTable ConsultaCargoInicio(string nome_inicio)
        {
            string query = "SELECT id_cargo, nome FROM cargo WHERE status = 1 AND nome LIKE '" + nome_inicio + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        public DataTable ConsultaCargoContem(string nome_contem)
        {
            string query = "SELECT id_cargo, nome FROM cargo WHERE status = 1 AND nome LIKE '%" + nome_contem + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }


        public DataTable ConsultaCargoStatus(int status)
        {
            string query = "SELECT id_cargo, nome FROM cargo WHERE status = " + status + " ORDER BY nome;";
            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //3- Método para buscar os dados do banco quando o usuario escolhe o cliente na grid
        public bool ConsultarCargo(int id)
        {
            string query = "SELECT * FROM cargo WHERE id_cargo = " + id + " ";
            classConexao cConexao = new classConexao();
            DataTable dt = cConexao.RetornaDataTable(query);

            if (dt.Rows.Count > 0) //COLOCAR TODOS OS CAMPOS DA TABELA CARGO (NÃO E OBRIGADO ESTAR NA ORDÉM)
            {
                id_cargo = Convert.ToInt32(dt.Rows[0]["id_cargo"]);
                nome = dt.Rows[0]["nome"].ToString();
                data_cadastro = Convert.ToDateTime(dt.Rows[0]["data_cadastro"]);
                status = Convert.ToInt32(dt.Rows[0]["status"]);

                return true;

            }
            else
                return false;




        }


        //METODO ATUALIZAR
        public bool AtualizarCargo()
        {
           string query = "UPDATE cargo SET nome = '" + nome + "', status = " + status + "  WHERE id_cargo = " + id_cargo + " ";

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



        //METODO EXCLUIR
        public bool ExcluirCargo()
        {
            string query = "DELETE FROM cargo WHERE id_cargo = " + id_cargo + " ";

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

        //_______________________________________________________________
        //METODOS DE RELATORIO -----C A R G O
        public DataTable RelatorioCargo()
        {
            string query = "SELECT nome, data_cadastro, status FROM cargo WHERE status = 1 ORDER BY nome; ";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }












    }
}
