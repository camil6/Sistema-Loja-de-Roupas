using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace loja_jd_modas
{
    //add using system.data;
    class classVenda
    {
     //METODO CONSTRUTOR

        public classVenda()
        {
            id_venda = 0;
            valor_total = 0;
            pix = 0;
            cartao_debito = 0;
            cartao_credito = 0;
            dinheiro = 0;
            desconto_total = 0;
            data_venda = DateTime.Now;
            //FK
            id_funcionario = 0;
            id_cliente = 0;
 
        }

        // declarar as PROPRIEDADES - serve para ler e gravar as informações (mostra para o banco o que ele tem que gravar) 
        // ATALHO PRA CRIAR AS PROPRIEDADES: 'prop' + tab tab

        public int id_venda { get; set; }

        public decimal valor_total { get; set; }

        public decimal pix { get; set; }

        public decimal cartao_debito { get; set; }

        public decimal cartao_credito { get; set; }

        public decimal dinheiro { get; set; }

        public decimal desconto_total { get; set; }

        public DateTime data_venda { get; set; }

        public int id_funcionario { get; set; }

        public int id_cliente { get; set; }



        //METODO DE CADASTRAR A VENDA
        public bool CadastrarVenda()
        {
            string query = "INSERT INTO venda VALUES (0, '" + valor_total.ToString().Replace(",", ".") + "', '" + pix.ToString().Replace(",", ".") + "', '" + cartao_debito.ToString().Replace(",", ".") + "', '" + cartao_credito.ToString().Replace(",", ".") + "', '" + dinheiro.ToString().Replace(",", ".") + "', '" + desconto_total.ToString().Replace(",", ".") + "', now(), " + id_funcionario + ", " + id_cliente + "); SELECT LAST_INSERT_ID()";

            classConexao cConexao = new classConexao();

            id_venda = 0;
            id_venda = cConexao.ExecutaQueryID(query);

            if(id_venda != 0)
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
