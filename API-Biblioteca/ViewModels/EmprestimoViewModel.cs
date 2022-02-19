using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.ViewModels
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel(int idUsuario, int codExemplar)
        {
            IdUsuarioGeral = idUsuario;
            CodExemplar = codExemplar;
        }

        public int CodEmprestimo { get; private set; }

        public int IdUsuarioGeral { get; private set; }

        public int CodExemplar { get; private set; }
    }
}
