using DevCars.API.Entities;
using DevCars.API.InputModels;
using DevCars.API.Persistence;
using DevCars.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace DevCars.API.Controllers
{
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        private readonly string _connectionString;

        public UsuarioController(DevCarsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BibliotecaCs");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = _dbContext.Usuario;

            var viewModel = entity
                .Select(c => new UsuarioViewModel(c.Id, c.Nome, c.Endereco, c.Tipo, c.Email, c.Horario, c.MatriculaAluno, c.CodigoProfessor, c.Assunto))
                .ToList();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Usuario";

                var ViewModelTest = sqlConnection.Query<UsuarioViewModel>(query);
            }

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _dbContext.Usuario.SingleOrDefault(c => c.Id == id);

            if (entity == null)
                return NotFound();

            var DetailsViewModel = new UsuarioViewModel(
               entity.Id,
               entity.Nome,
               entity.Endereco,
               entity.Tipo,
               entity.Email,
               entity.Horario,
               entity.MatriculaAluno,
               entity.CodigoProfessor,
               entity.Assunto
                );

            return Ok(DetailsViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] UsuarioInputModel model)
        {
            // Se o cadastro funcionar, created 201, se dados incorretos, badrequest (400)
            var entity = new Usuario(
               model.Id,
               model.Nome,
               model.Endereco,
               model.Tipo,
               model.Email,
               model.Horario,
               model.MatriculaAluno,
               model.CodigoProfessor,
               model.Assunto);

            _dbContext.Usuario.Add(entity);

            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = entity.Id },
                model
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _dbContext.Usuario.SingleOrDefault(c => c.Id == id);

            if (entity == null)
                return NotFound();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Usuario WHERE Id = @id";

                sqlConnection.Execute(query, new { id = entity.Id });
            }

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
