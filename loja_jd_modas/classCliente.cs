using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace loja_jd_modas
{
    class classCliente
    {
        public classCliente()
        {
            id_cliente = 0;
            nome = null;
            cpf = null;
            data_nascimento = DateTime.Now;
            sexo = null;
            email = null;
            rg = null;
            telefone = null;
            celular = null;
            cep = null;
            rua = null;
            bairro = null;
            numero = 0;
            cidade = null;
            estado = null;
            complemento = null;
            data_cadastro = DateTime.Now;
            status = 0;


        }

        public int id_cliente { get; set; }

        public string nome { get; set; }

        public string cpf { get; set; }

        public DateTime data_nascimento { get; set; }

        public string sexo { get; set; }

        public string email { get; set; }

        public string rg { get; set; }

        public string telefone { get; set; }

        public string celular { get; set; }

        public string cep { get; set; }

        public string rua { get; set; }

        public string bairro { get; set; }

        public int numero { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }

        public string complemento { get; set; }

        public DateTime data_cadastro { get; set; }

        public int status { get; set; }


        public int CadastroCliente()
        {

            string query = "INSERT INTO cliente VALUES (0, '" + nome + "','"+ cpf +"','"+ data_nascimento.ToString("yyyy-MM-dd") +"','" + sexo + "','" + email + "','" + rg + "','" + telefone+"','" + celular + "','" + cep + "','" + rua + "','" + bairro + "','" + numero + "','" + cidade + "','" + estado + "','" + complemento + "',now(),1)";

            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(query);
            
        }

        //MÉTODO PARA BUSCAR OS DADOS (CÓDIGO E NOME) DA TABELA CLIENTE
        //PARA POPULAR UMA COMBO
        public DataTable BuscarCliente()
        {
            string query = "SELECT id_cliente, nome FROM cliente WHERE status = 1 ORDER BY nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }


        // 2- METODOS DE CONSULTA 
        //CONSULTA DE CLIENTE POR NOME,CPF,SEXO E STATUS 
        //CAMPOS EXIBIDOS NA CONSULTA: COD, NOME, CPF, DATA NASCIMENTO, SEXO E TELEFONE

        //DEFINIR using System.Data;
        //CONSULTA DE CLIENTE POR NOME (INÍCIO)

        public DataTable ConsultaClienteInicio(string nome_inicio)
        {
            string query = "SELECT id_cliente, nome, cpf , data_nascimento, sexo, email, telefone , celular FROM cliente WHERE Status = 1 AND nome LIKE '" + nome_inicio + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //CONSULTA DE CLIENTE POR NOME (CONTEM)
        public DataTable ConsultaClienteContem(string nome_contem)
        {
            string query = "SELECT id_cliente, nome, cpf , data_nascimento, sexo, email, telefone , celular FROM cliente WHERE Status = 1 AND nome LIKE '%" + nome_contem + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //CONSULTA DE CLIENTE POR CPF
        public DataTable ConsultaClienteCPF(string CPF)
        {
            string query = "SELECT id_cliente, nome, cpf , data_nascimento, sexo, email, telefone , celular FROM cliente WHERE Status = 1 AND cpf = '" + CPF + "' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //CONSULTA DE CLIENTE POR SEXO
        public DataTable ConsultaClienteSexo(string Sexo)
        {
            string query = "SELECT id_cliente, nome, cpf , data_nascimento, sexo, email, telefone , celular FROM cliente WHERE Status = 1 AND sexo = '" + Sexo + "' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //CONSULTA DE CLIENTE POR STATUS
        public DataTable ConsultaClienteStatus(int Status)
        {
            string query = "SELECT id_cliente, nome, cpf , data_nascimento, sexo, email, telefone , celular FROM cliente WHERE status = " + Status + " ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //3- Método para buscar os dados do banco quando o usuario escolhe o cliente na grid
        public bool ConsultarCliente(int id)
        {
            string query = "SELECT * FROM cliente WHERE id_cliente = " + id + " ";
            classConexao cConexao = new classConexao();
            DataTable dt = cConexao.RetornaDataTable(query);

            if (dt.Rows.Count > 0) //COLOCAR TODOS OS CAMPOS DA TABELA CLIENTE (NÃO E OBRIGADO ESTAR NA ORDÉM)
            {
                id_cliente = Convert.ToInt32(dt.Rows[0]["id_cliente"]);
                nome = dt.Rows[0]["nome"].ToString();
                data_cadastro = Convert.ToDateTime(dt.Rows[0]["data_cadastro"]);
                cpf = dt.Rows[0]["cpf"].ToString();
                data_nascimento = Convert.ToDateTime(dt.Rows[0]["data_nascimento"]);
                sexo = dt.Rows[0]["sexo"].ToString();
                email = dt.Rows[0]["email"].ToString();
                rg = dt.Rows[0]["rg"].ToString();
                telefone = dt.Rows[0]["telefone"].ToString();
                celular = dt.Rows[0]["celular"].ToString();
                cep = dt.Rows[0]["cep"].ToString();
                rua = dt.Rows[0]["rua"].ToString();
                bairro = dt.Rows[0]["bairro"].ToString();
                numero = Convert.ToInt32(dt.Rows[0]["numero"]);
                cidade = dt.Rows[0]["cidade"].ToString();
                estado = dt.Rows[0]["estado"].ToString();
                complemento = dt.Rows[0]["complemento"].ToString();
                status = Convert.ToInt32(dt.Rows[0]["status"]);

                return true;
            }
            else
                return false;


        }

        //METODO ATUALIZAR
        public bool AtualizarCliente()
        {
            string query = "UPDATE cliente SET nome = '" + nome + "', cpf = '" + cpf + "', data_nascimento = '" + data_nascimento.ToString("yyyy-MM-dd") + "',sexo = '" + sexo + "',email = '" + email + "',rg = '" + rg + "',telefone = '" + telefone + "',celular = '" + celular + "',cep = '" + cep + "',rua = '" + rua + "',bairro = '" + bairro + "',numero = '" + numero + "',cidade = '" + cidade + "',estado = '" + estado + "',complemento = '" + complemento + "',status = " + status + " WHERE id_cliente = " + id_cliente + " ";

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
        public bool ExcluirCliente()
        {
            string query = "DELETE FROM cliente WHERE id_cliente = " + id_cliente + " ";

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

        //METODOS RELATORIO

        public DataTable BuscarCidade()
        {
            string query = "SELECT DISTINCT cidade FROM cliente WHERE status = 1 ORDER BY cidade";
            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //RELATORIO DE CLIENTE POR IDADE (INTERVALO)
        public DataTable RelatorioClienteIdade(int idade1, int idade2)
        {
            string query = "SELECT nome, cpf, data_nascimento ,sexo ,celular, status, timestampdiff(YEAR, data_nascimento,now()) FROM cliente WHERE status = 1 AND timestampdiff(YEAR, data_nascimento, now()) BETWEEN " + idade1 + " AND " + idade2 + ", ORDER BY nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);



        }


        //RELATORIO DE CLIENTE MAORES DE ????????
        public DataTable RelatorioClienteMaiorDe(int idade)
        {
            string query = "SELECT nome, cpf, data_nascimento ,sexo ,celular, status, timestampdiff(YEAR, data_nascimento,now()) FROM cliente WHERE status = 1 AND timestampdiff(YEAR, data_nascimento, now()) > " + idade + " ORDER BY nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }


        //RELATORIO DE CLIENTE POR CIDADE
        public DataTable RelatorioClienteCidade(String cidade)
        {
            string query = "SELECT nome, cpf, data_nascimento ,sexo ,celular ,cidade, status FROM cliente WHERE status = 1 AND cidade = '" + cidade + "' ORDER BY nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }


        public DataTable RelatorioClienteSexo(string sexo)
        {
            string query = "SELECT nome, cpf, data_nascimento ,sexo ,celular ,cidade, status FROM cliente WHERE status = 1 AND sexo = '" + sexo + "' ORDER BY nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        public DataTable RelatorioClienteStatus(int status)
        { 
            string query = "SELECT nome, cpf, data_nascimento ,sexo ,celular ,cidade, status FROM cliente WHERE status = " + status + " ORDER BY nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        public DataTable RelatorioClienteMes(int mes)
        {

            string query = "SELECT nome, cpf, data_nascimento, status, sexo, cidade , celular FROM cliente  WHERE status = 1 AND MONTH(data_nascimento) = " + mes + " ORDER BY nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);


        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_
        //PESQUISAR CLIENTE NA VENDA
        public DataTable PesquisarClienteVenda(string nome)
        {
            string query = "SELECT id_cliente 'Código', nome 'Cliente', cpf 'CPF' FROM cliente WHERE status = 1 AND nome LIKE '%" +  nome + "%' ORDER BY nome;";
            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);


        }




    }
}
