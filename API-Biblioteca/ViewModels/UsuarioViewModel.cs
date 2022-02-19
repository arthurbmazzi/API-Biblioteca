using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(int id, string nome, string endereco, string tipo, string email, DateTime horario, string matricula, string cod, string assunto)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Tipo = tipo;
            Email = email;
            Horario = horario;
            MatriculaAluno = matricula;
            CodigoProfessor = cod;
            Assunto = assunto;
        }

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
