using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Multa
    {
        public Multa(int codMultaProp, int codEmprestimo, decimal valor, int idUsuarioMulta)
        {
            CodMultaProp = codMultaProp;
            CodEmprestimo = codEmprestimo;
            Valor = valor;
            IdUsuarioMulta = idUsuarioMulta;
        }

        public int CodMultaProp { get; private set; }

        public int IdUsuarioMulta { get; private set; }

        public int CodEmprestimo { get; private set; }

        public string StatusMulta { get; private set; }

        public decimal Valor { get; private set; }
    }
}
