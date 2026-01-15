using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porjeto_Controle_Vendas.br.com.projeto.MODEL
{
    public class Funcionario : Cliente
    {
        //criado a classe herdando atributos da classe cliente
        public string senha { get; set; }
        public string cargo { get; set; }
        public string nivel_acesso { get; set; }
    }
}
