using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.InputModels
{
    public class PedidoEmprestimoInputModel
    {
        public int CodPedido { get; private set; }

        public int CodObra { get; private set; }

        public int IdUsuarioG { get; private set; }

        public string StatusEmprestimo { get; private set; }

        public DateTime DataHora { get; private set; }

        public bool Prioridade { get; private set; }
    }
}
