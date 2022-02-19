using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.InputModels
{
    public class ObraInputModel
    {
        public int CodObra { get; private set; }

        public string Tipo { get; private set; }

        public string Titulo { get; private set; }

        public string DescFisica { get; private set; }

        public int ExDisponiveis { get; private set; }

        public DateTime Publicacao { get; private set; }

        public string Edicao { get; private set; }

        public string ISBN { get; private set; }

        public string DescTrab { get; private set; }
    }
}
