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
    public class FornecedorDAO
    {
        private MySqlConnection conexao;
        public FornecedorDAO() 
        { 
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region Metodo cadastrar Fornecedor
        public void CadastrarFornecedor(Fornecedor obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"insert into tb_fornecedores (nome, cnpj, email, telefone, celular,cep, endereco, numero, complemento, bairro, cidade, estado)
                                value (@nome, @cnpj, @email, @telefone, @celular, @cep, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor cadastrado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Alterar Fornecedor
        public void alterarFornecedor(Fornecedor obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"update tb_fornecedores set nome=@nome, cnpj=@cnpj, email=@email, telefone=@telefone, celular=@celular,cep=@cep, endereco=@endereco, numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado
                                where id=@id";
                                

                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@cnpj", obj.cnpj);
                executacmd.Parameters.AddWithValue("@cep", obj.cep);
                executacmd.Parameters.AddWithValue("@email", obj.email);
                executacmd.Parameters.AddWithValue("@telefone", obj.telefone);
                executacmd.Parameters.AddWithValue("@celular", obj.celular);
                executacmd.Parameters.AddWithValue("@endereco", obj.endereco);
                executacmd.Parameters.AddWithValue("@numero", obj.numero);
                executacmd.Parameters.AddWithValue("@complemento", obj.complemento);
                executacmd.Parameters.AddWithValue("@bairro", obj.bairro);
                executacmd.Parameters.AddWithValue("@cidade", obj.cidade);
                executacmd.Parameters.AddWithValue("@estado", obj.estado);
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor alterado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Excluir Fornecedor
        public void excluirFornecedor(Fornecedor obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"delete from tb_fornecedores where id = @id";


                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
               
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Fornecedor excluido com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Listr Fornecedor
        public DataTable listarFornecedores()
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelafornecedor = new DataTable();

                string sql = "select * from tb_fornecedores";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);                
                conexao.Open();
                executacmd.ExecuteNonQuery() ;

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);

                conexao.Close();
                return tabelafornecedor;
                

            }
            catch (Exception error)
            {

                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
        }
        #endregion

        //Metodo buscar cliente por Nome
        #region Metodo Buscar Fornecedor por nome
        public DataTable BuscarFornecedorPorNome(string nome)
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelafornecedor = new DataTable();

                string sql = "select * from tb_fornecedores where nome = @nome";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);
                conexao.Close();
                return tabelafornecedor;


            }
            catch (Exception error)
            {

                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
        }
        #endregion

        #region Metodo Listar Fornecedor por nome like
        public DataTable ListarFornecedorPorNome(string nome)
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelafornecedor = new DataTable();

                string sql = "select * from tb_fornecedores where nome like @nome";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafornecedor);
                conexao.Close();
                return tabelafornecedor;


            }
            catch (Exception error)
            {

                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
        }
        #endregion
    }
}
