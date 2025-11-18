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
                Console.WriteLine("Escolha um entre os seguintes: \n\n 1 - Cadastrar paciente \n\n 2 - Listar paciente \n\n 3 - Listar Pacientes Atendidos \n\n 4 - Atender Paciente \n\n 5 - Alterar Paciente \n\n Q - Sair \n");
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
                        ListarAtendidos();
                        break;
                    case "4":
                        Atender();
                        break;
                    case "5":
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
                var cmd = new MySqlCommand("insert into Pacientes (nome, idade, preferencial) values (@n, @i, @p)", con);
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
                string sql = "select * from Pacientes where lugar_fila='Aguardando' order by preferencial DESC, ID_Paciente ASC;";
                var cmd = new MySqlCommand(sql, con);
                var reader = cmd.ExecuteReader();

                Console.WriteLine("\n      FILA DE PACIENTES       ");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID_Paciente"]} | Nome: {reader["nome"]} | Idade: {reader["idade"]} | Preferencial: {(Convert.ToBoolean(reader["preferencial"]) ? "Sim" : "Não")}");
                }
            }

        }

        static void ListarAtendidos()
        {
            using (var con = new MySqlConnection(connection))
            {
                con.Open();
                string sql = "select * from Pacientes where lugar_fila='Atendido' order by preferencial DESC, ID_Paciente ASC;";
                var cmd = new MySqlCommand(sql, con);
                var reader = cmd.ExecuteReader();

                Console.WriteLine("\n      FILA DE PACIENTES ATENDIDOS       ");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID_Paciente"]} | Nome: {reader["nome"]} | Idade: {reader["idade"]} | Preferencial: {(Convert.ToBoolean(reader["preferencial"]) ? "Sim" : "Não")}");
                }
            }
        }

        static void Atender()
        {
            using (var con = new MySqlConnection(connection))
            {
                con.Open();
                string sql = "select * from Pacientes where lugar_fila='Aguardando' order by preferencial DESC, ID_Paciente ASC LIMIT 1";
                var cmd = new MySqlCommand(sql, con);
                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID_Paciente"]);
                    string nome = reader["nome"].ToString();
                    reader.Close(); var cmd2 = new MySqlCommand("update Pacientes set lugar_fila='Atendido' where ID_Paciente=@id", con);
                    cmd2.Parameters.AddWithValue("@id", id);
                    cmd2.ExecuteNonQuery();

                    Console.WriteLine($"Paciente {nome} foi atendido!");
                }
                else
                {
                    Console.WriteLine("Nenhum paciente na fila.");
                    string sql2 = "alter table Pacientes auto_increment =1";

                    try
                    {
                        var cmd3 = new MySqlCommand(sql2, con);
                        cmd3.ExecuteNonQuery();
                    } catch (Exception ex)
                    {
                        Console.WriteLine("Erro inesperado.");
                    }
                }

            }
        }

        static void Alterar()
        {
            Console.Write("Digite o ID do paciente: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Alterando nome: ");
            string nome = Console.ReadLine();
            Console.Write("Alterando idade: ");
            int idade = int.Parse(Console.ReadLine());
            Console.Write("É preferencial? (s/n): ");
            bool preferencial = Console.ReadLine().ToLower() == "s";

            using (var con = new MySqlConnection(connection))
            {
                con.Open();
                var cmd = new MySqlCommand("update pacientes set nome=@n, idade=@i, preferencial=@p where ID_Paciente=@id;", con);
                cmd.Parameters.AddWithValue("@n", nome);
                cmd.Parameters.AddWithValue("@i", idade);
                cmd.Parameters.AddWithValue("@p", preferencial);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Dados atualizados com sucesso!");
        }
    }
}

