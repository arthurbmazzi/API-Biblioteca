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

namespace APIBiblioteca.API
{
    [Route("api/assuntos")]
    public class AssuntoController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        private readonly string _connectionString;

        public AssuntoController(DevCarsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BibliotecaCs");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var assuntos = _dbContext.Assuntos;

            var assuntosViewModel = assuntos
                .Select(c => new AssuntoViewModel(c.IdAssunto, c.Nome))
                .ToList();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT IdAssunto, Nome FROM Assuntos";

                var ASsuntosViewModelTest = sqlConnection.Query<AssuntoViewModel>(query);
            }

            return Ok(assuntosViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Se o assunto não existir, retornar notfound, senão ok
            var assunto = _dbContext.Assuntos.SingleOrDefault(c => c.IdAssunto == id);

            if (assunto == null)
                return NotFound();

            var DetailsViewModel = new AssuntoViewModel(
                assunto.IdAssunto,
                assunto.Nome
                );

            return Ok(DetailsViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] AddAssuntoInputModel model)
        {
            // Se o cadastro funcionar, created 201, se dados incorretos, badrequest (400)
            var assunto = new Assunto(model.Nome);

            _dbContext.Assuntos.Add(assunto);
            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = assunto.IdAssunto },
                model
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var assunto = _dbContext.Assuntos.SingleOrDefault(c => c.IdAssunto == id);

            if (assunto == null)
                return NotFound();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Assuntos WHERE IdAssunto = @id";

                sqlConnection.Execute(query, new { id = assunto.IdAssunto });
            }

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
