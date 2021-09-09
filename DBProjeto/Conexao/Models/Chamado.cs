using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexao.Models
{
    // Classe que representa um chamado e suas caracteristicas
    class Chamado
    {
        // Propriedades 
        private static BancoDados bd = new BancoDados();
        public int id { get; }
        public int usuarioId { get; }
        public Estado estado { get; set; }
        public string descricao { get; set; }

        // Construtor
        // O construtor já adiciona o novo chamado no banco de dados
        public Chamado(int usuarioId, string descricao)
        {
            this.usuarioId = usuarioId;
            this.estado = Estado.Aberto;
            this.descricao = descricao;
            bd.inserirChamado(usuarioId, "Aberto", descricao);
        }
    }
}
