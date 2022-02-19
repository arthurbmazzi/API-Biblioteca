using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Assunto
    {
        public Assunto(string nome)
        {
            Nome = nome;
        }

        public int IdAssunto { get; private set; }

        public string Nome { get; private set; }

        public void Update(string nome)
        {
            Nome = nome;
        }
    }
}
