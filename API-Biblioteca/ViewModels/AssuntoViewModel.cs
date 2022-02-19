using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.ViewModels
{
    public class AssuntoViewModel
    {
        public AssuntoViewModel(int idAssunto, string nome)
        {
            IdAssunto = idAssunto;
            Nome = nome;
        }

        public int IdAssunto { get; private set; }

        public string Nome { get; private set; }
    }
}
