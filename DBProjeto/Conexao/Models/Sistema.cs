using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexao.Models
{
    class Sistema
    {
        private BancoDados bd;
        public Sistema()
        {
            this.bd = new BancoDados();
        }
        public void Iniciar()
        {
            Menu();
            string op = Console.ReadLine();
            string usuarioId;
            int usuarioIdInt;
            string chamadoId;
            int chamadoIdInt;
            string usuarios;
            string chamados;
            while(op != "0")
            {
                switch (op)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("-- Criar um novo usuário -- ");
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Usuario usuario = new Usuario(nome);                      
                        break;
                    case "2" :
                        Console.Clear();
                        Console.WriteLine("-- Criar um novo chamado -- \n");
                        usuarios = bd.getUsuarios();
                        Console.WriteLine(usuarios);
                        Console.Write("Digite seu ID de Usuário: ");
                        usuarioId = Console.ReadLine();
                        usuarioIdInt = int.Parse(usuarioId);
                        Console.WriteLine("Descreva seu problema: ");
                        string descricao = Console.ReadLine();
                        Chamado chamado = new Chamado(usuarioIdInt, descricao);                         
                        break;
                    case "3":
                        Console.Clear();
                        usuarios = bd.getUsuarios(); 
                        Console.WriteLine(usuarios);
                        Console.WriteLine("\n Digite qualquer tecla para voltar para o menu");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        usuarios = bd.getUsuarios();
                        Console.WriteLine(usuarios);
                        Console.Write("\nDigite seu ID de Usuário: ");
                        usuarioId = Console.ReadLine();
                        usuarioIdInt = int.Parse(usuarioId);
                        chamados = bd.getChamados(usuarioIdInt);
                        Console.WriteLine(chamados);
                        Console.WriteLine("\n Digite qualquer tecla para voltar para o menu");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();
                        usuarios = bd.getUsuarios();
                        Console.WriteLine(usuarios);
                        Console.Write("\nDigite seu ID de Usuário: ");
                        usuarioId = Console.ReadLine();
                        usuarioIdInt = int.Parse(usuarioId);
                        chamados = bd.getChamados(usuarioIdInt);
                        Console.WriteLine(chamados);
                        Console.Write("\nDigite o ID do chamado que deve ser FECHADO: ");
                        chamadoId = Console.ReadLine();
                        chamadoIdInt = int.Parse(chamadoId);
                        bd.alterarEstado(chamadoIdInt);
                        Console.WriteLine("\n Digite qualquer tecla para voltar para o menu");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Clear();
                        usuarios = bd.getUsuarios();
                        Console.WriteLine(usuarios);
                        Console.Write("\nDigite seu ID de Usuário: ");
                        usuarioId = Console.ReadLine();
                        usuarioIdInt = int.Parse(usuarioId);
                        chamados = bd.getChamados(usuarioIdInt);
                        Console.WriteLine(chamados);
                        Console.Write("\nDigite o ID do chamado que deve ser deletado: ");
                        chamadoId = Console.ReadLine();
                        chamadoIdInt = int.Parse(chamadoId);
                        bd.deletarChamado(chamadoIdInt);
                        Console.WriteLine("\n Digite qualquer tecla para voltar para o menu");
                        Console.ReadLine();
                        break;
                    default:
                        Menu();
                        break;
                }
                Menu();
                op = Console.ReadLine();
            }
        }
        public void Menu()
        {
            Console.Clear();
            Console.WriteLine(" == MENU == ");
            Console.WriteLine("[1] - Criar um novo Usuário");
            Console.WriteLine("[2] - Criar um novo Chamado");
            Console.WriteLine("[3] - Ver lista de usuários");
            Console.WriteLine("[4] - Ver lista de chamados de um usuário");
            Console.WriteLine("[5] - Alterar um chamado para 'Fechado'");
            Console.WriteLine("[6] - Deletar um chamado");
            Console.WriteLine("[0] - Sair");
            Console.Write("Digite uma opção válida: ");


        }
    }
}
