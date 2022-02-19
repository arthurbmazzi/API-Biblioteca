using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.InputModels
{
    public class PosicaoFilaInputModel
    {
        public int IdPosicao { get; private set; }

        public int CodPedido { get; private set; }

        public DateTime Entrada { get; private set; }

        public DateTime Prazo { get; private set; }
    }
}
