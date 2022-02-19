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

namespace APIBiblioteca
{
    [Route("api/autor")]
    public class AutorController : ControllerBase
    {
        private readonly APIDbContext _dbContext;
        private readonly string _connectionString;

        public AutorController(APIDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BibliotecaCs");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var autor = _dbContext.Autor;

            var autorsViewModel = autor
                .Select(c => new AutorViewModel(c.Id, c.Nome))
                .ToList();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Id, Nome, CodigoObra FROM Autor";

                var autorViewModelTest = sqlConnection.Query<AssuntoViewModel>(query);
            }

            return Ok(autorsViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var autor = _dbContext.Autor.SingleOrDefault(c => c.Id == id);

            if (autor == null)
                return NotFound();

            var DetailsViewModel = new AssuntoViewModel(
                autor.Id,
                autor.Nome
                );

            return Ok(DetailsViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] AutorInputModel model)
        {
            // Se o cadastro funcionar, created 201, se dados incorretos, badrequest (400)
            var autor = new Autor(model.Nome);
            var autorObra = new Autor_Obra(model.CodigoObra);


            _dbContext.Autor.Add(autor);
            _dbContext.Autor_Obra.Add(autor);

            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = autor.Id },
                model
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var autor = _dbContext.Autor.SingleOrDefault(c => c.Id == id);

            if (autor == null)
                return NotFound();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Autor WHERE Id = @id";

                sqlConnection.Execute(query, new { id = autor.Id });
            }

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
