using Porjeto_Controle_Vendas.br.com.projeto.DAO;
using Porjeto_Controle_Vendas.br.com.projeto.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Porjeto_Controle_Vendas.br.com.projeto.VIEW
{
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();
        }
        #region Botoes
        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void bubtnbuscarCep_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = txtCep.Text;
                string xml = $"https://viacep.com.br/ws/{cep}/xml";

                DataSet dados = new DataSet();

                dados.ReadXml(xml);

                txtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString();
                txtComplemento.Text = dados.Tables[0].Rows[0]["complemento"].ToString();
                txtUF.Text = dados.Tables[0].Rows[0]["uf"].ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Endereço não encodntrado");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //1 passo - receber os dados dentro do objeto modelo cleinte
            Funcionario obj = new Funcionario();
            obj.nome = txtNome.Text;
            obj.rg = txtIERG.Text;
            obj.cpf = txtCNPJCPF.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCep.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = txtUF.Text;
            obj.complemento = txtComplemento.Text;
            obj.senha = txtsenha.Text;
            obj.cargo = txtcargo.Text;
            obj.nivel_acesso = txtnivelacesso.Text;

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastrarcliente
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.CadastrarFuncionario(obj);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Botao excluir
            Funcionario obj = new Funcionario();

            //pegar o codigo
            obj.codigo = int.Parse(txtCodigo.Text);

            FuncionarioDAO dao = new FuncionarioDAO();

            dao.excluirFuncionario(obj);

            //depois de escluir regarregar 
            tabelaFuncionario.DataSource = dao.listarFuncionarios();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //1 passo - receber os dados dentro do objeto modelo cleinte
            Funcionario obj = new Funcionario();
            obj.nome = txtNome.Text;
            obj.rg = txtIERG.Text;
            obj.cpf = txtCNPJCPF.Text;
            obj.email = txtEmail.Text;
            obj.telefone = txtTelefone.Text;
            obj.celular = txtCelular.Text;
            obj.cep = txtCep.Text;
            obj.endereco = txtEndereco.Text;
            obj.numero = int.Parse(txtNumero.Text);
            obj.bairro = txtBairro.Text;
            obj.cidade = txtCidade.Text;
            obj.estado = txtUF.Text;
            obj.complemento = txtComplemento.Text;
            obj.senha = txtsenha.Text;
            obj.cargo = txtcargo.Text;
            obj.nivel_acesso = txtnivelacesso.Text;

            obj.codigo = int.Parse(txtCodigo.Text);

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastrarcliente
            FuncionarioDAO dao = new FuncionarioDAO();
            dao.alterarFuncionario(obj);

            //recarregar dados 
            tabelaFuncionario.DataSource = dao.listarFuncionarios();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;
            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionario.DataSource = dao.BuscarFuncionarioPorNome(nome);

            //caso não encontre dados
            if (tabelaFuncionario.Rows.Count == 0)
                //recarregar dados 
                tabelaFuncionario.DataSource = dao.listarFuncionarios();
        }
        #endregion

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionario.DataSource = dao.listarFuncionarios();
        }

        private void tabelaFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             //Pegar os dados da linha selecionadas

            txtCodigo.Text = tabelaFuncionario.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFuncionario.CurrentRow.Cells[1].Value.ToString();
            txtIERG.Text = tabelaFuncionario.CurrentRow.Cells[2].Value.ToString();
            txtCNPJCPF.Text = tabelaFuncionario.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tabelaFuncionario.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text = tabelaFuncionario.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = tabelaFuncionario.CurrentRow.Cells[6].Value.ToString();
            txtCep.Text = tabelaFuncionario.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text = tabelaFuncionario.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = tabelaFuncionario.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text = tabelaFuncionario.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = tabelaFuncionario.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = tabelaFuncionario.CurrentRow.Cells[12].Value.ToString();
            txtUF.Text = tabelaFuncionario.CurrentRow.Cells[13].Value.ToString();

            //alterar para a guia dados pessoais
            tabFuncionarios.SelectedTab = tabPage1;
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";

            FuncionarioDAO dao = new FuncionarioDAO();
            tabelaFuncionario.DataSource = dao.BuscarFuncionarioPorNome(nome);
        }
    }
}
