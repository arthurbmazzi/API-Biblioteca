using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.InputModels
{
    public class EmprestimoInputModel
    {
        public int CodEmprestimo { get; private set; }

        public int Id { get; private set; }

        public int CodExemplar { get; private set; }
    }
}
