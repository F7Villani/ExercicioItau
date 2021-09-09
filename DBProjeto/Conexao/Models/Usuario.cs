using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexao.Models
{
    
    class Usuario
    {
        private static BancoDados bd = new BancoDados();
        public int id { get; }
        public string nome { get;}

        public Usuario(string nome)
        {
            this.nome = nome;
            bd.inserirUsuario(nome);
            this.id = bd.getUsuarioId(nome);

        }
    }
}
