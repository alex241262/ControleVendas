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
    public class FuncionarioDAO
    {
        private MySqlConnection conexao;
        public FuncionarioDAO() 
        { 
            this.conexao = new ConnectionFactory().getconnection();
        }

        #region Metodo cadastrar Funcionario
        public void CadastrarFuncionario(Funcionario obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"insert into tb_funcionarios (nome, rg, cpf, email, telefone, celular,cep, endereco, numero, complemento, bairro, cidade, estado, senha, cargo, nivel_acesso)
                                value (@nome, @rg, @cpf, @email, @telefone, @celular, @cpf, @endereco, @numero, @complemento, @bairro, @cidade, @estado, @senha, @cargo, @nivelacesso)";

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
                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivelacesso", obj.nivel_acesso);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionario cadastrado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Alterar Funcionario
        public void alterarFuncionario(Funcionario obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"update tb_funcionarios set nome=@nome, rg=@rg, cpf=@cpf, email=@email, telefone=@telefone, celular=@celular,cep=@cep, endereco=@endereco, numero=@numero, complemento=@complemento, bairro=@bairro, cidade=@cidade, estado=@estado, senha=@senha, cargo=@cargo, nivel_acesso=@nivelacesso
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
                executacmd.Parameters.AddWithValue("@senha", obj.senha);
                executacmd.Parameters.AddWithValue("@cargo", obj.cargo);
                executacmd.Parameters.AddWithValue("@nivelacesso", obj.nivel_acesso);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionario alterado com sucesso!");
                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Excluir Funcionario
        public void excluirFuncionario(Funcionario obj)
        {
            try
            {
                //1 passo - definir o comando sql - Inser Into
                string sql = @"delete from tb_funcionarios where id = @id";


                //2 passo - organizar o comando sql
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
               
                executacmd.Parameters.AddWithValue("@id", obj.codigo);

                //3 passo - Abrir aconexao e executar comando sql
                conexao.Open();
                executacmd.ExecuteNonQuery();

                MessageBox.Show("Funcionario excluido com sucesso!");

                conexao.Close();
            }
            catch (Exception erro)
            {

                MessageBox.Show($"Aconteceu erro : {erro}");
            }
        }
        #endregion

        #region Metodo Listr Funcionario
        public DataTable listarFuncionarios()
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelafuncionario = new DataTable();

                string sql = "select * from tb_funcionarios";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);                
                conexao.Open();
                executacmd.ExecuteNonQuery() ;

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafuncionario);

                conexao.Close();
                return tabelafuncionario;
                

            }
            catch (Exception error)
            {

                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
        }
        #endregion

        //Metodo buscar cliente por Nome
        #region Metodo Buscar Funcionario por nome
        public DataTable BuscarFuncionarioPorNome(string nome)
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelafuncionario = new DataTable();

                string sql = "select * from tb_funcionarios where nome = @nome";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafuncionario);
                conexao.Close();
                return tabelafuncionario;


            }
            catch (Exception error)
            {

                MessageBox.Show($"Erro ao executar o comando sql: {error}");
                return null;
            }
        }
        #endregion

        #region Metodo Listar Funcionario por nome like
        public DataTable ListarFuncionarioPorNome(string nome)
        {
            try
            {
                //1 passo - criar o DataTable e o comando sql
                DataTable tabelafuncionario = new DataTable();

                string sql = "select * from tb_funcionarios where nome like @nome";
                //2 passo - organizar o comando sql e executar
                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@nome", nome);
                conexao.Open();
                executacmd.ExecuteNonQuery();

                //3 passo - Criar MYsqlDataAdapter para preencher os dados no DataTable
                MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                da.Fill(tabelafuncionario);
                conexao.Close();
                return tabelafuncionario;


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
