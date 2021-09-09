using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexao.Models
{
    // Classe que representa um usuário e suas características
    class Usuario
    {
        // Propriedades
        private static BancoDados bd = new BancoDados();
        public int id { get; }
        public string nome { get;}

        // Construtor
        // O construtor ja adiciona o novo usuario ao banco de dados
        public Usuario(string nome)
        {
            this.nome = nome;
            bd.inserirUsuario(nome);
            this.id = bd.getUsuarioId(nome);

        }
    }
}
