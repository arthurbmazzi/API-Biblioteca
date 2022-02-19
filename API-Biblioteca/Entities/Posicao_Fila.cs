using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Posicao_Fila
    {
        public Posicao_Fila(int idPosicao, int codPedido, DateTime entrada, DateTime prazo)
        {
            IdPosicao = idPosicao;
            CodPedido = codPedido;
            Entrada = entrada;
            Prazo = prazo;
        }

        public int IdPosicao { get; private set; }

        public int CodPedido { get; private set; }

        public DateTime Entrada { get; private set; }

        public DateTime Prazo { get; private set; }
    }
}
