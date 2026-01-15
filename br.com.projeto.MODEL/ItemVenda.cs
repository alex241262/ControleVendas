using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjeto_Controle_Vendas.br.com.projeto.MODEL
{
    public class ItemVenda
    {
        public int id { get; set; }
        public int venda_id { get; set; }
        public int produto_id { get; set; }
        public int qtd { get; set; }
        public decimal subtotal { get; set; }
    }
}
