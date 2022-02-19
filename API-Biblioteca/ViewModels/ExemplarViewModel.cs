using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.ViewModels
{
    public class ExemplarViewModel
    {
        public ExemplarViewModel(int codigoExemplar, int codigoObra)
        {
            CodExemplar = codigoExemplar;
            CodigoObra = codigoObra;
        }

        public int CodExemplar { get; private set; }

        public int CodigoObra { get; private set; }
    }
}
