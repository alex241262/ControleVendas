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
    public class VendaDAO
    {
        private MySqlConnection conexao;
        public VendaDAO() 
        { 
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region Metodo cadastrar venda
        public void CadastrarVenda(Venda obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"insert into tb_vendas (cliente_id, data_venda, total_venda, observacoes)
                                value (@cliente_id, @data_venda, @total_venda, @observacoes)";

                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@cliente_id", obj.cliente_id);
                executacmd.Parameters.AddWithValue("@data_venda", obj.data_venda);
                executacmd.Parameters.AddWithValue("@total_venda", obj.total_venda);
                executacmd.Parameters.AddWithValue("@observacoes", obj.observacoes);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //MessageBox.Show("Venda cadastrado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion
        #region Metodo retorna ultima venda
        public int RetornaIdUltimaVenda()
        {
            try
            {
                int idVenda = 0;
                //1 passo - definir o comando sql - Inser Into
                string sql = @"select max(id) as id from tb_vendas";

                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();

                MySqlDataReader rs = executacmd.ExecuteReader();
                if (rs.Read())
                {
                    idVenda = rs.GetInt32("id");
                }

                conexao.Close();
                return idVenda;               
                
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
                return 0;
            }
        }
        #endregion


    }
}
