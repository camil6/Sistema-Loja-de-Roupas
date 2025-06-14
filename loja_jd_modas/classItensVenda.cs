using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace loja_jd_modas
{
    //add using system.data;
    class classItensVenda
    {
        //METODO CONSTRUTOR
        public classItensVenda()
        {
            id_itens_venda = 0;
            preco = 0;
            quantidade = 0;
            desconto_unitario = 0;
            //FK
            id_produto = 0;
            id_venda = 0;

        }

        // declarar as PROPRIEDADES - serve para ler e gravar as informações (mostra para o banco o que ele tem que gravar) 
        // ATALHO PRA CRIAR AS PROPRIEDADES: 'prop' + tab tab

        public int id_itens_venda { get; set; }

        public decimal preco { get; set; }

        public int quantidade { get; set; }

        public decimal desconto_unitario { get; set; }

        public int id_produto{ get; set; }

        public int id_venda { get; set; }

        //METODO DE CADASTRAR ITENS_VENDA

        public bool CadastrarItenVenda()
        {
            string query = "INSERT INTO itens_venda VALUES (0, '" + preco.ToString().Replace(",", ".") + "', '" + quantidade + "', '" + desconto_unitario.ToString().Replace(",", ".") + "', " + id_produto + ", " + id_venda + ")";

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


    }
}
