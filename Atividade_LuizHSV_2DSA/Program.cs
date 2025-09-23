using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_LuizHSV_2DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fila = new string[15];
            int filaT = 0;
            string op = "";
            while (op != "Q")
            {
                Console.WriteLine("Bem vindo(a)!");
                Console.WriteLine("            MENU             ");
                Console.WriteLine("Escolha um entre os seguintes: \n\n 1 - Cadastrar paciente \n\n 2 - Listar paciente \n\n 3 - Atender os pacientes \n\n Q - Sair \n");
                op = Console.ReadLine().ToUpper();
                switch (op)
                {
                    case "1":
                        Console.WriteLine("Cadatrou paciente!");
                        break;

                    case "2":
                        Console.WriteLine("\n---Lista---\n");
                        for (int i = 0; i < filaT; i++)
                        {
                        }
                        break;
                    case "3":
                        Console.WriteLine("Atendimento");
                        break;

                    case "4":
                        Console.WriteLine("Encerrando...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida (ou inexistente)!!");
                        break;


                        
                }

                
            }
            




        }
    }
}
