using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.InputModels
{
    public class UsuarioInputModel
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Tipo { get; private set; }
        public string Email { get; private set; }
        public DateTime Horario { get; private set; }
        public string MatriculaAluno { get; private set; }
        public string CodigoProfessor { get; private set; }
        public string Assunto { get; private set; }
    }
}
