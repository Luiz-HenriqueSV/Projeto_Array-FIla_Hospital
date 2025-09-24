using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_LuizHSV_2DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pessoa[] fila = new Pessoa[15];
            int filaT = 0;
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
                        if (filaT < 15)
                        {
                            Pessoa paciente = new Pessoa();
                            paciente.Dados();

                            if (paciente.Pref)
                            {
                                for (int i = filaT; i > 0; i--)
                                    fila[i] = fila[i - 1];
                                fila[0] = paciente;
                            }
                            else
                            {
                                fila[filaT] = paciente;
                            }

                            filaT++;
                        }
                        else
                        {
                            Console.WriteLine("Fila cheia!");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n---Lista---\n");
                        for (int i = 0; i < filaT; i++)
                        {
                            if (fila[i].Pref)
                                Console.WriteLine((i + 1) + " - " + fila[i].nome + " (Pref)");
                            else Console.WriteLine((i + 1) + " - " + fila[i].nome);
                        }
                        break;

                    case "3":
                        if (filaT > 0)
                        {
                            Console.WriteLine("Atendido: " + fila[0].nome);
                            for (int i = 0; i < filaT - 1; i++)
                                fila[i] = fila[i + 1];
                            fila[filaT - 1] = null; 
                            filaT--;
                        }
                        else
                        {
                            Console.WriteLine("Fila Vazia!");
                        }
                        break;


                    case "4":
                        if (filaT > 0)
                        {
                            Console.WriteLine("Digite o nome do paciente para a alteração: ");
                            string Busca = Console.ReadLine();
                            bool encontrado = false;
                            for (int i = 0; i < filaT; i++)
                            {
                                if (fila[i].nome == Busca)
                                {
                                    Console.WriteLine("Paciente encontrado, digite os novos dados. \n");
                                    fila[i].Dados();
                                    encontrado = true;
                                    if (fila[i].Pref)
                                    {
                                        int j = i;
                                        while (j > 0 && !fila[j - 1].Pref)
                                        {
                                            Pessoa aux = fila[j - 1];
                                            fila[j - 1] = fila[j];
                                            fila[j] = aux;
                                            j--;
                                        }
                                    }

                                    break;
                                }
                            }
                            if (!encontrado)
                                Console.WriteLine("Paciente não encontrado.");
                        }

                        break;

                    case "Q":
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
