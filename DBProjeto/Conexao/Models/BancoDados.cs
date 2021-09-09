using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Conexao.Models;

namespace Conexao
{
    class BancoDados
    {
        private readonly SqlConnection conexao;

        // Construtor do BancoDados com uma string de conexao padrao
        public BancoDados()
        {

            conexao = new SqlConnection(@"data source=F7VILLANI-NOTE\SQLEXPRESS ;Integrated Security=SSPI ; Initial Catalog=ExemploBD");
            conexao.Open();
        }

        // Inseri um novo usuario no banco de dados
        public void inserirUsuario(string nome)
        {
            string strQueryInsert = string.Format("INSERT INTO usuariosDB(nome) VALUES ('{0}')",nome);
            SqlCommand cmdCommandInsert = new SqlCommand(strQueryInsert, conexao);
            cmdCommandInsert.ExecuteNonQuery();
        }

        // Inseri um novo chamado no banco de dados
        public void inserirChamado(int usuarioId, string estado, string descricao)
        {
            string strQueryInsert = string.Format("INSERT INTO chamadosDB(usuarioID, estado, descricao) VALUES ({0},'{1}','{2}' )", usuarioId,estado,descricao);
            SqlCommand cmdCommandInsert = new SqlCommand(strQueryInsert, conexao);
            cmdCommandInsert.ExecuteNonQuery();
        }

        // Retornar id do usuario
        public int getUsuarioId(string nome)
        {
            string strQuerySelect = string.Format("SELECT usuarioID FROM usuariosDB WHERE nome='{0}'",nome);
            SqlCommand cmdCommandSelect = new SqlCommand(strQuerySelect, conexao);
            SqlDataReader dados = cmdCommandSelect.ExecuteReader();
            if (dados.Read())
            {
                int id = dados.GetInt32(0);
                dados.Close();
                return id;
            }
            else
            {
                dados.Close();
                return 0;
            }
        }

        // Retornar nome do usuario
        public string getNomeUsuario(int usuarioId)
        {
            string strQuerySelect = string.Format("SELECT nome FROM usuariosDB WHERE usuarioID='{0}'", usuarioId);
            SqlCommand cmdCommandSelect = new SqlCommand(strQuerySelect, conexao);
            SqlDataReader dados = cmdCommandSelect.ExecuteReader();
            if (dados.Read())
            {
                string nome = dados.GetString(0);
                dados.Close();
                return nome;
            }
            else
            {
                dados.Close();
                return "Usuário não existe";
            }
        }

        // Retorna string com todos os usuarios
        public string getUsuarios()
        {
            string resp = string.Format(" == USUÁRIOS CADASTRADOS ==\n\n {0,-4}| {1}\n", "ID", "Nome");
            string strQuerySelect = string.Format("SELECT * FROM usuariosDB");
            SqlCommand cmdCommandSelect = new SqlCommand(strQuerySelect, conexao);
            SqlDataReader dados = cmdCommandSelect.ExecuteReader();
            while (dados.Read())
            {
                resp += string.Format(" {0,-4}- {1}\n", dados["usuarioID"], dados["nome"]);
            }
            dados.Close();
            return resp;
        }

        // Retorna string com os chamados de um usuario
        public string getChamados(int usuarioId)
        {
            string resp = string.Format(" == CHAMADOS FEITOS POR {0} ==\n {1,-4}| {2,-9}| {3}\n", getNomeUsuario(usuarioId), "ID", "Estado", "Descricao");
            string strQuerySelect = string.Format("SELECT * FROM chamadosDB");
            SqlCommand cmdCommandSelect = new SqlCommand(strQuerySelect, conexao);
            SqlDataReader dados = cmdCommandSelect.ExecuteReader();
            while (dados.Read())
            {
                resp += string.Format(" {0,-4}- {1,-9}- {2}\n", dados["chamadoID"], dados["estado"], dados["descricao"]);
            }
            dados.Close();
            return resp;
        }

        // Muda o estado de um chamado para fechado
        public void alterarEstado(int chamadoID)
        {
            string strQuerySelect = string.Format("UPDATE chamadosDB SET estado='Fechado' WHERE chamadoID={0}", chamadoID);
            SqlCommand cmdCommandSelect = new SqlCommand(strQuerySelect, conexao);
            SqlDataReader dados = cmdCommandSelect.ExecuteReader();
            dados.Close();
        }

        // Deleta um chamado
        public void deletarChamado(int chamadoID)
        {
            string strQuerySelect = string.Format("DELETE FROM chamadosDB WHERE chamadoID={0}", chamadoID);
            SqlCommand cmdCommandSelect = new SqlCommand(strQuerySelect, conexao);
            SqlDataReader dados = cmdCommandSelect.ExecuteReader();
            dados.Close();
        }
    }
}