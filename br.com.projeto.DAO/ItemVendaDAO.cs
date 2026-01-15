using MySql.Data.MySqlClient;
using Porjeto_Controle_Vendas.br.com.projeto.CONEXAO;
using Porjeto_Controle_Vendas.br.com.projeto.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Porjeto_Controle_Vendas.br.com.projeto.DAO
{
    public class ItemVendaDAO
    {
        private MySqlConnection conexao;
        public ItemVendaDAO() 
        { 
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region Metodo cadastrar Itemvenda
        public void CadastrarItemVenda(ItemVenda obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"insert into tb_itensvendas (venda_id, produto_id, qtd, subtotal)
                                value (@venda_id, @produto_id, @qtd, @subtotal)";

                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@venda_id", obj.venda_id);
                executacmd.Parameters.AddWithValue("@produto_id", obj.produto_id);
                executacmd.Parameters.AddWithValue("@qtd", obj.qtd);
                executacmd.Parameters.AddWithValue("@subtotal", obj.subtotal);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //MessageBox.Show("ItemVenda cadastrado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion
       


    }
}

