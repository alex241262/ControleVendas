using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Porjeto_Controle_Vendas.br.com.projeto.CONEXAO
{
    public class ConnectionFactory
    {
        public MySqlConnection getconnection()
            {
                string conexao = ConfigurationManager.ConnectionStrings["bdvendas"].ConnectionString;

                return new MySqlConnection(conexao);
            }
    }
}
