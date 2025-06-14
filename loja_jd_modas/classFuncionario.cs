using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace loja_jd_modas
{
    internal class classFuncionario
    {
        //METODO CONSTRUTOR
        public classFuncionario()
        {

            id_funcionario = 0;
            nome = null;
            data_nascimento = DateTime.Now;
            cpf = null;
            email = null;
            sexo = null;
            salario = 0;
            telefone = null;
            celular = null;
            tipo_acesso = null;
            login = null;
            senha = null;
            data_cadastro = DateTime.Now;
            status = 0;

            //FK
            id_cargo = 0;

        }

        public int id_funcionario { get; set; }
        public string nome { get; set; }

        public DateTime data_nascimento { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        public decimal salario { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string tipo_acesso { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public DateTime data_cadastro { get; set; }
        public int status { get; set; }

        //FK
        public int id_cargo { get; set; }


        public int CadastroFuncionario()
        {
            string query = "INSERT INTO funcionario VALUES (0, '" + nome + "','" + data_nascimento.ToString("yyyy-MM-dd") + "','" + cpf + "','" + email + "','" + sexo + "','" + salario.ToString().Replace(",", ".") + "','" + telefone + "','" + celular + "','" + tipo_acesso + "','" + login + "','" + senha + "',now(),1," + id_cargo + ")";


            classConexao cConexao = new classConexao();
            return cConexao.ExecutaQuery(query);


        }

        // 2- METODOS DE CONSULTA 
        //CONSULTA DE CLIENTE POR NOME,CPF,SEXO E STATUS 
        //CAMPOS EXIBIDOS NA CONSULTA: COD, NOME, CPF, DATA NASCIMENTO, SEXO E TELEFONE

        //DEFINIR using System.Data;
        //CONSULTA DE CLIENTE POR NOME (INÍCIO)

        public DataTable ConsultaFuncionarioInicio(string nome_inicio)
        {
            string query = "SELECT id_funcionario, nome, cpf , data_nascimento, sexo, email, telefone , celular FROM funcionario WHERE Status = 1 AND nome LIKE '" + nome_inicio + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }


        //CONSULTA DE CLIENTE POR NOME (CONTEM)
        public DataTable ConsultaFuncionarioContem(string nome_contem)
        {
            string query = "SELECT id_funcionario, nome, cpf , data_nascimento, sexo, email, telefone , celular FROM funcionario WHERE Status = 1 AND nome LIKE '%" + nome_contem + "%' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }


        //CONSULTA DE CLIENTE POR CPF
        public DataTable ConsultaFuncionarioCPF(string CPF)
        {
            string query = "SELECT id_funcionario, nome, cpf , data_nascimento, sexo, email, telefone , celular FROM funcionario WHERE Status = 1 AND cpf = '" + CPF + "' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }


        //CONSULTA DE CLIENTE POR SEXO
        public DataTable ConsultaFuncionarioSexo(string Sexo)
        {
            string query = "SELECT id_funcionario, nome, cpf , data_nascimento, sexo, email, telefone , celular FROM funcionario WHERE Status = 1 AND sexo = '" + Sexo + "' ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //CONSULTA DE CLIENTE POR STATUS
        public DataTable ConsultaFuncionarioStatus(int Status)
        {
            string query = "SELECT id_funcionario, nome, cpf , data_nascimento, sexo, email, telefone , celular FROM funcionario WHERE status = " + Status + " ORDER BY nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        //CONSULTA DE CLIENTE POR CARGO
        public DataTable ConsultaFuncionarioCargo(int Cargo)
        {

            string query = "SELECT funcionario.id_funcionario, funcionario.nome, funcionario.cpf , funcionario.data_nascimento, funcionario.sexo, funcionario.email, funcionario.telefone, funcionario.celular,cargo.nome FROM funcionario JOIN cargo ON funcionario.id_cargo = cargo.id_cargo WHERE funcionario.status = 1 AND cargo.id_cargo = '" + Cargo + "' ORDER BY funcionario.nome;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }


        //3- Método para buscar os dados do banco quando o usuario escolhe o cliente na grid
        public bool ConsultarFuncionario(int id)
        {
            string query = "SELECT * FROM funcionario WHERE id_funcionario = " + id + " ";
            classConexao cConexao = new classConexao();
            DataTable dt = cConexao.RetornaDataTable(query);

            if (dt.Rows.Count > 0) //COLOCAR TODOS OS CAMPOS DA TABELA CLIENTE (NÃO E OBRIGADO ESTAR NA ORDÉM)
            {
                id_funcionario = Convert.ToInt32(dt.Rows[0]["id_funcionario"]);
                nome = dt.Rows[0]["nome"].ToString();
                data_nascimento = Convert.ToDateTime(dt.Rows[0]["data_nascimento"]);
                cpf = dt.Rows[0]["cpf"].ToString();
                email = dt.Rows[0]["email"].ToString();
                sexo = dt.Rows[0]["sexo"].ToString();
                salario = Convert.ToDecimal(dt.Rows[0]["salario"]);
                telefone = dt.Rows[0]["telefone"].ToString();
                celular = dt.Rows[0]["celular"].ToString();
                tipo_acesso = dt.Rows[0]["tipo_acesso"].ToString();
                login = dt.Rows[0]["login"].ToString();
                senha = dt.Rows[0]["tipo_acesso"].ToString();
                data_cadastro = Convert.ToDateTime(dt.Rows[0]["data_cadastro"]);
                status = Convert.ToInt32(dt.Rows[0]["status"]);
                id_cargo = Convert.ToInt32(dt.Rows[0]["id_cargo"]);

                return true;
            }
            else
                return false;


        }


        //METODO ATUALIZAR
        public bool AtualizarFuncionario()
        {

            string query = "UPDATE funcionario SET nome = '" + nome + "', data_nascimento = '" + data_nascimento.ToString("yyyy-MM-dd") + "',cpf = '" + cpf + "', email = '" + email + "', sexo = '" + sexo + "', salario = '" + salario.ToString().Replace(",", ".") + "', telefone = '" + telefone + "', celular = '" + celular + "', tipo_acesso = '" + tipo_acesso + "', login = '" + login + "', senha = '" + senha + "', id_cargo = " + id_cargo + "  WHERE id_funcionario = " + id_funcionario + " ";

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
        public bool ExcluirFuncionario()
        {
            string query = "DELETE FROM funcionario WHERE id_funcionario = " + id_funcionario + " ";

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



        public DataTable RelatorioFuncionarioSexo(string sexo)
        {
            string query = "SELECT funcionario.nome, funcionario.cpf, funcionario.data_nascimento, funcionario.status, funcionario.sexo, cargo.nome'id_cargo' FROM funcionario JOIN cargo ON funcionario.id_cargo = cargo.id_cargo WHERE funcionario.status = 1 AND funcionario.sexo = '" + sexo + "' ORDER BY funcionario.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        public DataTable RelatorioFuncionarioStatus(int status)
        {
            string query = "SELECT funcionario.nome, funcionario.cpf, funcionario.data_nascimento, funcionario.status, funcionario.sexo, cargo.nome'id_cargo' FROM funcionario JOIN cargo ON funcionario.id_cargo = cargo.id_cargo WHERE funcionario.status = " + status + " ORDER BY funcionario.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        public DataTable RelatorioFuncionarioCargo(int cargo)
        {

            string query = "SELECT funcionario.nome, funcionario.cpf, funcionario.data_nascimento, funcionario.status,  funcionario.sexo, cargo.nome'id_cargo' FROM funcionario JOIN cargo ON funcionario.id_cargo = cargo.id_cargo WHERE funcionario.status = 1 AND cargo.id_cargo = " + cargo + " ORDER BY funcionario.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);

        }

        public DataTable RelatorioFuncionarioMes(int mes)
        {

            string query = "SELECT funcionario.nome, funcionario.cpf, funcionario.data_nascimento, funcionario.status, funcionario.sexo, cargo.nome 'id_cargo' FROM funcionario JOIN cargo ON funcionario.id_cargo = cargo.id_cargo WHERE funcionario.status = 1 AND MONTH(funcionario.data_nascimento) = " + mes + " ORDER BY funcionario.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);


        }

        public DataTable RelatorioFuncionarioMaiorDe(int idade)
        {

            string query = "SELECT funcionario.nome, funcionario.cpf, funcionario.data_nascimento, funcionario.status, funcionario.sexo, cargo.nome 'id_cargo', timestampdiff(YEAR, funcionario.data_nascimento,now()) FROM funcionario JOIN cargo ON funcionario.id_cargo = cargo.id_cargo WHERE funcionario.status = 1 AND timestampdiff(YEAR, data_nascimento, now()) > " + idade + " ORDER BY funcionario.nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);


        }

        //-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-
        //METODO BUSCAR FUNCIONARIO
        public DataTable BuscarFuncionario()
        {
            string query = "SELECT id_funcionario, nome FROM funcionario WHERE status = 1 ORDER BY nome";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }








    }

}
