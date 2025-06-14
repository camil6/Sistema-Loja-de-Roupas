using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace loja_jd_modas
{
    class classRelatorioVenda
    {


        //METODO CONSTRUTOR
        public classRelatorioVenda()
        {
            //VENDA
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

            //ITENS VENDA

            id_itens_venda = 0;
            preco = 0;
            quantidade = 0;
            desconto_unitario = 0;
            //FK
            id_produto = 0;
            


        }

        //VENDA
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

        //ITENS VENDA

        public int id_itens_venda { get; set; }

        public decimal preco { get; set; }

        public int quantidade { get; set; }

        public decimal desconto_unitario { get; set; }

        public int id_produto { get; set; }


        public DataTable RelVendaDetalhadoPeriodo(DateTime dinicio, DateTime dfinal)
        {
            string query = "SELECT venda.id_venda, venda.data_venda, venda.valor_total, venda.desconto_total, venda.pix, venda.dinheiro, venda.cartao_debito, venda.cartao_credito, itens_venda.preco, itens_venda.quantidade, itens_venda.desconto_unitario, cliente.nome'id_cliente', funcionario.nome'id_funcionario', produto.nome'id_produto' FROM cliente JOIN venda ON cliente.id_cliente = venda.id_cliente JOIN funcionario ON funcionario.id_funcionario = venda.id_funcionario JOIN itens_venda ON itens_venda.id_venda = venda.id_venda JOIN produto ON produto.id_produto = itens_venda.id_produto WHERE CAST(venda.data_venda AS DATE) BETWEEN '" + dinicio.ToString("yyyy-MM-dd") + "' AND '" + dfinal.ToString("yyyy-MM-dd") + "' ORDER BY venda.id_venda";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);


        }

        //METODO RETORNAR AS VENDAS POR CLIENTE
        public DataTable RelVendaCliente(int cliente)
        {
            string query = "SELECT venda.id_venda, venda.data_venda, venda.valor_total, venda.desconto_total, venda.pix, venda.cartao_debito, venda.cartao_credito, venda.dinheiro, itens_venda.quantidade, itens_venda.preco, itens_venda.desconto_unitario, cliente.nome'id_cliente', funcionario.nome'id_funcionario', produto.nome'id_produto' FROM cliente JOIN venda ON cliente.id_cliente = venda.id_cliente JOIN funcionario ON funcionario.id_funcionario = venda.id_funcionario JOIN itens_venda ON venda.id_venda = itens_venda.id_venda JOIN produto ON produto.id_produto = itens_venda.id_produto WHERE cliente.id_cliente = '" + cliente + "' ORDER BY venda.id_venda;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //METODO RETORNAR AS VENDAS POR FUNCIONARIO
        public DataTable RelVendaFuncionario(int funcionario)
        {
            string query = "SELECT venda.id_venda, venda.data_venda, venda.valor_total, venda.desconto_total, venda.pix, venda.cartao_debito, venda.cartao_credito, venda.dinheiro, itens_venda.quantidade, itens_venda.preco, itens_venda.desconto_unitario, cliente.nome'id_cliente', funcionario.nome'id_funcionario', produto.nome'id_produto' FROM cliente JOIN venda ON cliente.id_cliente = venda.id_cliente JOIN funcionario ON funcionario.id_funcionario = venda.id_funcionario JOIN itens_venda ON venda.id_venda = itens_venda.id_venda JOIN produto ON produto.id_produto = itens_venda.id_produto WHERE funcionario.id_funcionario = '" + funcionario + "' ORDER BY venda.id_venda;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }

        //METODO RETORNAR AS VENDAS DE FUNCIONARIO POR PERIODO
        public DataTable RelVendaFuncionarioPeriodo(int funcionario, DateTime dinicio, DateTime dfinal)
        {
            string query = "SELECT venda.id_venda, venda.data_venda, venda.valor_total, venda.desconto_total, venda.pix, venda.cartao_debito, venda.cartao_credito, venda.dinheiro, itens_venda.quantidade, itens_venda.preco, itens_venda.desconto_unitario, cliente.nome'id_cliente', funcionario.nome'id_funcionario', produto.nome'id_produto' FROM cliente JOIN venda ON cliente.id_cliente = venda.id_cliente JOIN funcionario ON funcionario.id_funcionario = venda.id_funcionario JOIN itens_venda ON venda.id_venda = itens_venda.id_venda JOIN produto ON produto.id_produto = itens_venda.id_produto WHERE funcionario.id_funcionario = '" + funcionario + "' AND CAST(venda.data_venda AS DATE) BETWEEN '" + dinicio.ToString("yyyy-MM-dd") + "' AND '" + dfinal.ToString("yyyy-MM-dd") + "' ORDER BY venda.id_venda;";

            classConexao cConexao = new classConexao();
            return cConexao.RetornaDataTable(query);
        }







    }
}
