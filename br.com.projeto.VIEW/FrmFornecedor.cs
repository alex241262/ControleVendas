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
    public partial class FrmFornecedor : Form
    {
        public FrmFornecedor()
        {
            InitializeComponent();
        }

        #region Botoes
        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //1 passo - receber os dados dentro do objeto modelo cleinte
            Fornecedor obj = new Fornecedor();
            obj.nome = txtNome.Text;
            obj.cnpj = txtcnpj.Text;
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

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastrarcliente
            FornecedorDAO dao = new FornecedorDAO();
            dao.CadastrarFornecedor(obj);
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Botao excluir
            Fornecedor obj = new Fornecedor();

            //pegar o codigo
            obj.codigo = int.Parse(txtCodigo.Text);

            FornecedorDAO dao = new FornecedorDAO();

            dao.excluirFornecedor(obj);

            //depois de escluir regarregar 
            tabelaFornecedor.DataSource = dao.listarFornecedores();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            //1 passo - receber os dados dentro do objeto modelo cleinte
            Fornecedor obj = new Fornecedor();
            obj.nome = txtNome.Text;
            obj.cnpj = txtcnpj.Text;
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

            obj.codigo = int.Parse(txtCodigo.Text);

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastrarcliente
            FornecedorDAO dao = new FornecedorDAO();
            dao.alterarFornecedor(obj);

            //recarregar dados 
            tabelaFornecedor.DataSource = dao.listarFornecedores();
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
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;
            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedor.DataSource = dao.BuscarFornecedorPorNome(nome);

            //caso não encontre dados
            if (tabelaFornecedor.Rows.Count == 0)
                //recarregar dados 
                tabelaFornecedor.DataSource = dao.listarFornecedores();
        }


        #endregion

        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedor.DataSource = dao.listarFornecedores();
        }

        private void tabelaFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar os dados da linha selecionadas

            txtCodigo.Text = tabelaFornecedor.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaFornecedor.CurrentRow.Cells[1].Value.ToString();
            txtcnpj.Text = tabelaFornecedor.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = tabelaFornecedor.CurrentRow.Cells[3].Value.ToString();
            txtTelefone.Text = tabelaFornecedor.CurrentRow.Cells[4].Value.ToString();
            txtCelular.Text = tabelaFornecedor.CurrentRow.Cells[5].Value.ToString();
            txtCep.Text = tabelaFornecedor.CurrentRow.Cells[6].Value.ToString();
            txtEndereco.Text = tabelaFornecedor.CurrentRow.Cells[7].Value.ToString();
            txtNumero.Text = tabelaFornecedor.CurrentRow.Cells[8].Value.ToString();
            txtComplemento.Text = tabelaFornecedor.CurrentRow.Cells[9].Value.ToString();
            txtBairro.Text = tabelaFornecedor.CurrentRow.Cells[10].Value.ToString();
            txtCidade.Text = tabelaFornecedor.CurrentRow.Cells[11].Value.ToString();
            txtUF.Text = tabelaFornecedor.CurrentRow.Cells[12].Value.ToString();

            //alterar para a guia dados pessoais
            tabFornecedores.SelectedTab = tabPage1;
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";

            FornecedorDAO dao = new FornecedorDAO();
            tabelaFornecedor.DataSource = dao.BuscarFornecedorPorNome(nome);
        }
    }
}
