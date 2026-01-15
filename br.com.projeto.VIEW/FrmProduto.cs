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
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            ProdutoDAO dao = new ProdutoDAO();
            tabelaProduto.DataSource = dao.listarProdutos();

            FornecedorDAO f_dao = new FornecedorDAO();
            cbFornecedores.DataSource = f_dao.listarFornecedores();
            cbFornecedores.DisplayMember = "nome";
            cbFornecedores.ValueMember = "id";
        }

        private void tabelaProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar os dados da linha selecionadas

            txtCodigo.Text = tabelaProduto.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = tabelaProduto.CurrentRow.Cells[1].Value.ToString();
            txtValor.Text = tabelaProduto.CurrentRow.Cells[2].Value.ToString();
            txtQuantidade.Text = tabelaProduto.CurrentRow.Cells[3].Value.ToString();
            cbFornecedores.Text = tabelaProduto.CurrentRow.Cells[4].Value.ToString();

            //alterar para a guia dados pessoais
            tabProdutos.SelectedTab = tabPage1;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //1 passo - receber os dados dentro do objeto modelo cleinte
            Produto obj = new Produto();
            obj.descricao = txtDescricao.Text;
            obj.preco = decimal.Parse(txtValor.Text);
            obj.qtdestoque = decimal.Parse(txtQuantidade.Text);
            obj.for_id = int.Parse(cbFornecedores.SelectedValue.ToString());

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastrarcliente
            ProdutoDAO dao = new ProdutoDAO();
            dao.CadastrarProduto(obj);

            //limpar a tela de cadastro quando terminar
            new Helpers().LimparTela(this);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Botao excluir
            Produto obj = new Produto();

            //pegar o codigo
            obj.id = int.Parse(txtCodigo.Text);

            ProdutoDAO dao = new ProdutoDAO();

            dao.excluirProduto(obj);

            //depois de escluir regarregar 
            tabelaProduto.DataSource = dao.listarProdutos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Produto obj = new Produto();
            obj.descricao = txtDescricao.Text;
            obj.preco = decimal.Parse(txtValor.Text);
            obj.qtdestoque = decimal.Parse(txtQuantidade.Text);
            obj.for_id = int.Parse(cbFornecedores.SelectedValue.ToString());

            obj.id = int.Parse(txtCodigo.Text);

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastrarcliente
            ProdutoDAO dao = new ProdutoDAO();
            dao.alterarProduto(obj);

            //recarregar dados 
            tabelaProduto.DataSource = dao.listarProdutos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;
            ProdutoDAO dao = new ProdutoDAO();
            tabelaProduto.DataSource = dao.BuscarProdutoPorNome(nome);

            //caso não encontre dados
            if (tabelaProduto.Rows.Count == 0)
                //recarregar dados 
                tabelaProduto.DataSource = dao.listarProdutos();
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";

            ProdutoDAO dao = new ProdutoDAO();
            tabelaProduto.DataSource = dao.ListarProdutoPorNome(nome);
        }
    }
}
