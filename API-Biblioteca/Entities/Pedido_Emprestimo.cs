using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Pedido_Emprestimo
    {
        public Pedido_Emprestimo()
        {
        }

        public Pedido_Emprestimo(int codigoPedido, int codigoObra, int idUsuarioG, string statusEmprestimo, DateTime dataHora, bool prioridade)
        {
            CodPedido = codigoPedido;
            CodObra = codigoObra;
            IdUsuarioG = idUsuarioG;
            StatusEmprestimo = statusEmprestimo;
            DataHora = dataHora;
            Prioridade = prioridade;
        }

        public int CodPedido { get; private set; }

        public int CodObra { get; private set; }

        public int IdUsuarioG { get; private set; }

        public string StatusEmprestimo { get; private set; }

        public DateTime DataHora { get; private set; }

        public bool Prioridade { get; private set; }
    }
}
