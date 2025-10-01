using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_LuizHSV_2DSA
{
    class Pessoa
    {
        public string nome;
        public bool Pref;

        public void Dados()
        {
            Console.WriteLine("Digite o seu Nome: \n");
            nome = Console.ReadLine();
            Console.WriteLine("Preferencial? (s/n): ");
            string resp = Console.ReadLine().ToLower();

            if (resp == "s")
            {
                Pref = true;
            }
            else if (resp == "n")
            {
                Pref = false;
            }
            else
            {
                Console.WriteLine("Opção Inválida! Digite apenas 's' ou 'n'");
            }
        }
    }
}
