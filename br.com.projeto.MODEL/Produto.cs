using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjeto_Controle_Vendas.br.com.projeto.MODEL
{
    public class Produto
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public decimal qtdestoque { get; set; }
        public int for_id { get; set; }
    }
}
