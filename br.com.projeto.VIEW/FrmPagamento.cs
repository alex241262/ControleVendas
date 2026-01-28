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
    public partial class FrmPagamento : Form
    {
        Cliente cliente = new Cliente();
        DataTable carrinho = new DataTable();
        DateTime dtAtual;
        public FrmPagamento(Cliente cliente,DataTable carrinho, DateTime dtAtual)
        {
            this.cliente = cliente;
            this.carrinho = carrinho;
            this.dtAtual = dtAtual;

            InitializeComponent();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                // variaveis dos campos de valores
                decimal v_Dinheiro, v_Cartao, troco, totalPago, total;

                ProdutoDAO dao_Produto = new ProdutoDAO();
                int qtd_estoque, qtd_comprada, estoque_atualizado;

                v_Dinheiro = decimal.Parse(txtDinheiro.Text);
                v_Cartao = decimal.Parse(txtCartao.Text);
                total = decimal.Parse(txtTotal.Text);

                // calcular total pago
                totalPago = v_Dinheiro + v_Cartao;
                if (totalPago < total)
                {
                    MessageBox.Show("O Total pago é menor que o valor total da venda!");
                }
                else
                {
                    //calcular troco
                    troco = totalPago - total;
                    
                    txtTroco.Text = troco.ToString();
                    // salvando no banco de dados

                    Venda vendas = new Venda();
                    vendas.cliente_id = cliente.codigo;
                    vendas.data_venda = dtAtual;
                    vendas.total_venda = total;
                    vendas.observacoes = txtObs.Text;

                    VendaDAO vdao = new VendaDAO();
                    vdao.CadastrarVenda(vendas);

                    //salvando os itens na tabela tb_itensvendas
                    foreach(DataRow linhas in carrinho.Rows)
                    {
                        ItemVenda itenv = new ItemVenda();
                        itenv.venda_id   = vdao.RetornaIdUltimaVenda();
                        itenv.produto_id = int.Parse(linhas["Codigo"].ToString());
                        itenv.qtd = int.Parse(linhas["Qtd"].ToString());
                        itenv.subtotal = decimal.Parse(linhas["SubTotal"].ToString());

                        //dar baixa no estqoue dos itens
                        qtd_estoque = dao_Produto.retornaEstoqueAtual(itenv.produto_id);
                        qtd_comprada = itenv.qtd;
                        estoque_atualizado = qtd_estoque - qtd_comprada;

                        dao_Produto.baixaEstoque(itenv.produto_id, estoque_atualizado);

                        ItemVendaDAO itemVendaDAO = new ItemVendaDAO();
                        itemVendaDAO.CadastrarItemVenda(itenv);
                    }
                    MessageBox.Show("Venda finalizada com sucesso!");

                    this.Dispose();
                    new FrmVenda().ShowDialog(); 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("erro" + ex);
            }

        }

        private void FrmPagamento_Load(object sender, EventArgs e)
        {
            // par começar com os campos 0,00
            txtDinheiro.Text = "0,00";
            txtCartao.Text = "0,00";
            txtTroco.Text = "0,00";
        }
    }
}
