using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.ViewModels
{
    public class MultaViewModel
    {
        public MultaViewModel(int codigoMulta, int codEmprestimo, decimal valor, int idUsuario)
        {
            CodMulta = codigoMulta;
            CodEmprestimo = codEmprestimo;
            Valor = valor;
            IdUsuarioG = idUsuario;
        }

        public int CodMulta { get; private set; }

        public int IdUsuarioG { get; private set; }

        public int CodEmprestimo { get; private set; }

        public string StatusMulta { get; private set; }

        public decimal Valor { get; private set; }
    }
}
