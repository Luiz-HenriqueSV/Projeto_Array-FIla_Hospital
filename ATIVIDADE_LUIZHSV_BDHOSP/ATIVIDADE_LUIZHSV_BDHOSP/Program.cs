using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace ATIVIDADE_LUIZHSV_BDHOSP
{
    internal class Program
    {
        static string conexao = "server=localhost;database=banco_Hospital;user=root;password=root";
        static void Main(string[] args)
        {
            string op = "";
            Console.WriteLine("Bem vindo(a)!");
            while (op != "Q")
            {
                Console.WriteLine("            MENU             ");
                Console.WriteLine("Escolha um entre os seguintes: \n\n 1 - Cadastrar paciente \n\n 2 - Listar paciente \n\n 3 - Atender os pacientes \n\n 4 - Alterar paciente \n\n Q - Sair \n");
                op = Console.ReadLine().ToUpper();
                switch (op)
                {
                    case "1":
                        Cadastrar();
                        break;
                    case "2":
                        Listar();
                        break;
                    case "3":
                        Atender();
                        break;
                    case "4":
                        Alterar();
                        break;
                    case "Q":
                        break;
                    default:
                        Console.WriteLine("Opção inválida (ou inexistente)!!");
                        break;
                }
            }
        }
        void Cadastrar()
        {

        }
         void Listar()
        {

        }
    }
}

