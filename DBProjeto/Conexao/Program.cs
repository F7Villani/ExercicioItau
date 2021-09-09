using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexao.Models;

namespace Conexao
{
    class Program
    {
        static void Main(string[] args)   
        {
            Sistema sistema = new Sistema();
            sistema.Iniciar();
            
        }

        
    }
}
