using DevCars.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.InputModels
{
    public class AutorInputModel
    {
        public string Nome { get; set; }

        public int  CodigoObra { get; private set; }
    }
}
