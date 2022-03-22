using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pokemon
{
    class Usuario
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        

        public void mostrarNome()
        {
            Console.WriteLine(Nome);
        }
    }
}
