using MySql.Data.MySqlClient;
using Mysqlx;
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
    public class ClienteDAO
    {
        private MySqlConnection conexao;
        public ClienteDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region Metodo cadastrar cleinte
        public void CadastrarCliente(Cliente obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"insert into tb_clientes (nome, rg, cpf, email, telefone, celular,cep, endereco, numero, complemento, bairro, cidade, estado)
                                value (@nome, @rg, @cpf, @email, @telefone, @celular, @cpf, @endereco, @numero, @complemento, @bairro, @cidade, @estado)";

                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
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

                MessageBox.Show("Cliente cadastrado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Alterar Cliente
        public void alterarCliente(Cliente obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"update tb_clientes set nome=@nome, rg=@rg, cpf=@cpf, email=@email, telefone=@telefone, celular=@celular,cep=@cep, endereco=@endereco, numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado
                                where id=@id";


                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", obj.nome);
                executacmd.Parameters.AddWithValue("@rg", obj.rg);
                executacmd.Parameters.AddWithValue("@cpf", obj.cpf);
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

                MessageBox.Show("Cliente alterado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Excluir Cliente
        public void excluirCliente(Cliente obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"delete from tb_clientes where id = @id";


                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);

                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Cliente excluido com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Listr Cliente
        public DataTable listarClientes()
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();

                string sql = "select * from tb_clientes";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);

                conexao.Close();
                return tabelacliente;


            }
            catch (Exception error)
            {

                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
        }
        #endregion

        //Metodo buscar cliente por Nome
        #region Metodo Buscar Cliente por nome
        public DataTable BuscarClientePorNome(string nome)
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();

                string sql = "select * from tb_clientes where nome = @nome";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);
                conexao.Close();
                return tabelacliente;


            }
            catch (Exception error)
            {

                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
        }
        #endregion

        #region Metodo Listar Cliente por nome like
        public DataTable ListarClientesPorNome(string nome)
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelacliente = new DataTable();

                string sql = "select * from tb_clientes where nome like @nome";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelacliente);
                conexao.Close();
                return tabelacliente;


            }
            catch (Exception error)
            {

                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
        }
        #endregion

        #region retorna cliente por Cpf Cnpj
        public Cliente RetornaClientePorCpfCnpj(string cpf)
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                Cliente obj = new Cliente();

                string sql = "select * from tb_clientes where cpf = @cpf";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@cpf", cpf);
                conexao.Open();
                MySqlDataReader rs = executacmd.ExecuteReader();

                if (rs.Read())
                {
                    obj.codigo = rs.GetInt32("id");
                    obj.nome = rs.GetString("nome");

                    return obj;
                }
                else
                {
                    MessageBox.Show($"Cliente não encontrado");
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
