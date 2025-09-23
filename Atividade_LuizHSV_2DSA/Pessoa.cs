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
            Pref = Console.ReadLine().ToLower() == "s";
        }
    }
}
