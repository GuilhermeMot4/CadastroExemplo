using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque
{
    class conexao
    {
        public static SqlConnection conectar() { //método que abre uma conexão
            String str = "Data Source=localhost;Initial Catalog=estoqueBD;Integrated Security=True"; //string de conexão
            SqlConnection connection = new SqlConnection(str);
            connection.Open(); //abre conexão
            return connection; //retorna conexão criada
        } 
    }
}
