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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        #region botoes
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //1 passo - receber os dados dentro do objeto modelo cleinte
            Cliente obj = new Cliente();
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

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastrarcliente
            ClienteDAO dao = new ClienteDAO();
            dao.CadastrarCliente(obj);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Botao excluir
            Cliente obj = new Cliente();

            //pegar o codigo
            obj.codigo = int.Parse(txtCodigo.Text);

            ClienteDAO dao = new ClienteDAO();

            dao.excluirCliente(obj);

            //depois de escluir regarregar 
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //1 passo - receber os dados dentro do objeto modelo cleinte
            Cliente obj = new Cliente();
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

            obj.codigo = int.Parse(txtCodigo.Text);

            //2 passo - Criar um objeto da classe ClienteDAO e chamar o metodo cadastrarcliente
            ClienteDAO dao = new ClienteDAO();
            dao.alterarCliente(obj);

            //recarregar dados 
            tabelaCliente.DataSource = dao.listarClientes();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            new Helpers().LimparTela(this);
        }
        private void buscarCep_Click_Click(object sender, EventArgs e)
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

        #endregion
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void tabelaCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegar os dados da linha selecionadas

            txtCodigo.Text = tabelaCliente.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = tabelaCliente.CurrentRow.Cells[1].Value.ToString();
            txtIERG.Text = tabelaCliente.CurrentRow.Cells[2].Value.ToString();
            txtCNPJCPF.Text = tabelaCliente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = tabelaCliente.CurrentRow.Cells[4].Value.ToString();
            txtTelefone.Text = tabelaCliente.CurrentRow.Cells[5].Value.ToString();
            txtCelular.Text = tabelaCliente.CurrentRow.Cells[6].Value.ToString();
            txtCep.Text = tabelaCliente.CurrentRow.Cells[7].Value.ToString();
            txtEndereco.Text = tabelaCliente.CurrentRow.Cells[8].Value.ToString();
            txtNumero.Text = tabelaCliente.CurrentRow.Cells[9].Value.ToString();
            txtComplemento.Text = tabelaCliente.CurrentRow.Cells[10].Value.ToString();
            txtBairro.Text = tabelaCliente.CurrentRow.Cells[11].Value.ToString();
            txtCidade.Text = tabelaCliente.CurrentRow.Cells[12].Value.ToString();
            txtUF.Text = tabelaCliente.CurrentRow.Cells[13].Value.ToString();

            //alterar para a guia dados pessoais
            tabClientes.SelectedTab = tabPage1;
        }       

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nome = txtPesquisa.Text;
            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.BuscarClientePorNome(nome);

            //caso não encontre dados
            if(tabelaCliente.Rows.Count == 0)
                //recarregar dados 
                tabelaCliente.DataSource = dao.listarClientes();
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            string nome = "%" + txtPesquisa.Text + "%";

            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.ListarClientesPorNome(nome);

        }

       

        
    }
}
