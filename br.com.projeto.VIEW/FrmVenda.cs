using Porjeto_Controle_Vendas.br.com.projeto.DAO;
using Porjeto_Controle_Vendas.br.com.projeto.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Porjeto_Controle_Vendas.br.com.projeto.VIEW
{
    public partial class FrmVenda : Form
    {
        Cliente cliente = new Cliente();
        ClienteDAO clientedao = new ClienteDAO();
        Produto produto = new Produto();
        ProdutoDAO produtoDAO = new ProdutoDAO();

        int qtd;
        decimal preco, subtotal, totalvenda;

        DataTable carrinho = new DataTable();
        public FrmVenda()
        {
            InitializeComponent();
            txtdata.Text = DateTime.Now.ToShortDateString();
        }

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            carrinho.Columns.Add("Codigo", typeof(int));
            carrinho.Columns.Add("Descricao", typeof(string));
            carrinho.Columns.Add("Qtd", typeof(int));
            carrinho.Columns.Add("Preco", typeof(decimal));
            carrinho.Columns.Add("SubTotal", typeof(decimal));

            TabelaProdutos.DataSource = carrinho;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
                qtd = int.Parse(txtQuantidade.Text);
                preco = decimal.Parse(txtValor.Text);

                subtotal = qtd * preco;
                totalvenda += subtotal;

            txtValorTotal.Text = totalvenda.ToString();



            //adicionar no datagrid de produtos

                carrinho.Rows.Add(int.Parse(txtCodigo.Text), txtDescricao.Text, qtd, preco, subtotal);
            
            

            txtCodigo.Clear();
            txtDescricao.Clear();
            txtValor.Clear();
            txtQuantidade.Clear();
            txtCodigo.Focus();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            // pegar o valor total da coluna desse item
            decimal subproduto = decimal.Parse(TabelaProdutos.CurrentRow.Cells[4].Value.ToString());
            // pegar o indice dessa linha
            int indice = TabelaProdutos.CurrentRow.Index;

            DataRow linha = carrinho.Rows[indice];

            carrinho.Rows.Remove(linha);
            carrinho.AcceptChanges();

            //agora ajustas o valor total
            totalvenda -= subproduto;

            txtValorTotal.Text = totalvenda.ToString();
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            DateTime dtAtual = DateTime.Parse(txtdata.Text);
            FrmPagamento frmPagamento = new FrmPagamento(cliente, carrinho, dtAtual);
            //passando o total para tela de pagamento
            frmPagamento.txtTotal.Text = totalvenda.ToString();
            frmPagamento.ShowDialog();
        }

        private void txtCNPJCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verificar se foi apertado o entrer, pois nossa ação só pode ser executado depois dele
            if(e.KeyChar == 13)
            {
                //alterao 15/01/2026 agoraaaaaaaaaaa
                
                    cliente = clientedao.RetornaClientePorCpfCnpj(txtCNPJCPF.Text);
                if (cliente != null)
                {
                    txtNome.Text = cliente.nome;
                }
                else
                {
                    txtCNPJCPF.Clear();
                    txtCNPJCPF.Focus();
                }
            }

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //verificar se foi apertado o entrer, pois nossa ação só pode ser executado depois dele
            
            if(e.KeyChar == 13)
            {
                produto = produtoDAO.RetornaProdutoPorCodigo(int.Parse(txtCodigo.Text));
                if (produto != null)
                {
                    txtDescricao.Text = produto.descricao;
                    txtValor.Text = produto.preco.ToString();
                    txtQuantidade.Focus();
                }
                else
                {
                    txtCodigo.Clear();
                    txtCodigo.Focus();
                }
            }
        }
    }
}
