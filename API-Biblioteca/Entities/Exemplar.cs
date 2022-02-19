using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Exemplar
    {
        public Exemplar(int idExemplar, int codigoObra)
        {
            IdExemplar = idExemplar;
            CodigoObra = codigoObra;
        }

        public int IdExemplar { get; private set; }

        public int CodigoObra { get; private set; }
    }
}
