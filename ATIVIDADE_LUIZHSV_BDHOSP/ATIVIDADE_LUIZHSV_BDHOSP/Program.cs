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
        static string connection = "server=localhost;database=banco_Hospital;user=root;password=root";
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
        static void Cadastrar()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Idade: ");
            int idade = int.Parse(Console.ReadLine());
            Console.Write("É preferencial? (s/n): ");
            bool preferencial = Console.ReadLine().ToLower() == "s";

            using (var con = new MySqlConnection(connection))
            {
                con.Open();
                var cmd = new MySqlCommand("INSERT INTO Pacientes (nome, idade, preferencial) VALUES (@n, @i, @p)", con);
                cmd.Parameters.AddWithValue("@n", nome);
                cmd.Parameters.AddWithValue("@i", idade);
                cmd.Parameters.AddWithValue("@p", preferencial);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Paciente cadastrado com sucesso!!");
        }
        static void Listar()
        {
            using (var con = new MySqlConnection(connection))
            {
                con.Open();
                string sql = "SELECT * FROM Pacientes WHERE lugar_fila='Aguardando' ORDER BY preferencial DESC, ID_Paciente ASC;";
                var cmd = new MySqlCommand(sql, con);
                var reader = cmd.ExecuteReader();

                Console.WriteLine("\n      FILA DE PACIENTES       ");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]} | Nome: {reader["nome"]} | Idade: {reader["idade"]} | Preferencial: {(Convert.ToBoolean(reader["preferencial"]) ? "Sim" : "Não")}");
                }
            }

        }

        static void Atender()
        {

        }

        static void Alterar()
        {

        }
    }
}

