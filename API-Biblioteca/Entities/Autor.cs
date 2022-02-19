using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Autor
    {
        public Autor(string nome)
        {
            Nome = nome;
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public int CodigoObra { get; private set; }

        public void Update(string nome)
        {
            Nome = nome;
        }
    }
}
