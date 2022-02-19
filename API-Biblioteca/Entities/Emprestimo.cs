using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Emprestimo
    {
        public Emprestimo(int id, int codExemplar)
        {
            Id = id;
            CodExemplar = codExemplar;
        }

        public int CodEmprestimo { get; private set; }

        public int Id { get; private set; }

        public int CodExemplar { get; private set; }

    }
}
