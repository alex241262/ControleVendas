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
    public class ProdutoDAO
    {
        private MySqlConnection conexao;
        public ProdutoDAO() 
        { 
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region Metodo cadastrar produto
        public void CadastrarProduto(Produto obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"insert into tb_produtos (descricao, preco, qtd_estoque, for_id)
                                value (@descricao, @preco, @qtdestoque, @forid)";

                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@descricao", obj.descricao);
                executacmd.Parameters.AddWithValue("@preco", obj.preco);
                executacmd.Parameters.AddWithValue("@qtdestoque", obj.qtdestoque);
                executacmd.Parameters.AddWithValue("@forid", obj.for_id);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Produto cadastrado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Alterar Produto
        public void alterarProduto(Produto obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"update tb_produtos set descricao=@descricao, preco=@preco, qtd_estoque=@qtdestoque, for_id=@forid
                                where id=@id";
                                

                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@descricao", obj.descricao);
                executacmd.Parameters.AddWithValue("@preco", obj.preco);
                executacmd.Parameters.AddWithValue("@qtdestoque", obj.qtdestoque);
                executacmd.Parameters.AddWithValue("@forid", obj.for_id);

                executacmd.Parameters.AddWithValue("@id", obj.id);
                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Produto alterado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Excluir Produto
        public void excluirProduto(Produto obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"delete from tb_produtos where id = @id";


                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
               
                executacmd.Parameters.AddWithValue("@id", obj.id);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Produto excluido com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Listr Produto
        public DataTable listarProdutos()
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelaproduto = new DataTable();

                string sql = @"select p.id as Codigo,
                                      p.descricao as Decrição,
                                      p.preco as Valor,
                                      p.qtd_estoque as Estoque, 
                                      f.nome as Fornecedor 
                               from tb_produtos as p 
                               join tb_fornecedores as f on (p.for_id = f.id)";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);                
                conexao.Open();
                executacmd.ExecuteNonQuery() ;

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaproduto);

                conexao.Close();
                return tabelaproduto;
                

            }
            catch (Exception error)
            {

                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
        }
        #endregion

        //Metodo buscar cliente por Nome
        #region Metodo Buscar Produto por nome
        public DataTable BuscarProdutoPorNome(string nome)
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelaproduto = new DataTable();

                string sql = @"select p.id as Codigo,
                                      p.descricao as Decrição,
                                      p.preco as Valor,
                                      p.qtd_estoque as Estoque, 
                                      f.nome as Fornecedor 
                               from tb_produtos as p 
                               join tb_fornecedores as f on (p.for_id = f.id) where p.descricao = @nome;";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaproduto);
                conexao.Close();
                return tabelaproduto;


            }
            catch (Exception error)
            {

                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
        }
        #endregion

        #region Metodo Listar Produto por nome like
        public DataTable ListarProdutoPorNome(string nome)
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelaproduto = new DataTable();

                string sql = @"select p.id as Codigo,
                                      p.descricao as Decrição,
                                      p.preco as Valor,
                                      p.qtd_estoque as Estoque, 
                                      f.nome as Fornecedor 
                               from tb_produtos as p 
                               join tb_fornecedores as f on (p.for_id = f.id) where p.descricao like @nome;";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelaproduto);
                conexao.Close();
                return tabelaproduto;


            }
            catch (Exception error)
            {

                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
        }
        #endregion

        #region retorna Produto por Codigo
        public Produto RetornaProdutoPorCodigo(int codigo)
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                Produto obj = new Produto();

                string sql = "select * from tb_produtos where id = @codigo";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@codigo", codigo);
                conexao.Open();
                MySqlDataReader rs = executacmd.ExecuteReader();

                if (rs.Read())
                {
                    obj.id = rs.GetInt32("id");
                    obj.descricao = rs.GetString("descricao");
                    obj.preco = rs.GetDecimal("preco");

                    conexao.Close();

                    return obj;
                }
                else
                {
                    MessageBox.Show($"Produto não encontrado");

                    conexao.Close();

                    return null;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
#endregion
        }
    }
}
