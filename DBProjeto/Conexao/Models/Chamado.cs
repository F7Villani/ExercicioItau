using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexao.Models
{
    class Chamado
    {
        // Propriedades 
        private static BancoDados bd = new BancoDados();
        public int id { get; }
        public int usuarioId { get; }
        public Estado estado { get; set; }
        public string descricao { get; set; }

        // Construtor
        public Chamado(int usuarioId, string descricao)
        {
            this.usuarioId = usuarioId;
            this.estado = Estado.Aberto;
            this.descricao = descricao;
            bd.inserirChamado(usuarioId, "Aberto", descricao);
        }
    }
}
