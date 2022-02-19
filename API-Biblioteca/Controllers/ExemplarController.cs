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
    [Route("api/exemplar")]
    public class ExemplarController : ControllerBase
    {
        private readonly APIDbContext _dbContext;
        private readonly string _connectionString;

        public ExemplarController(APIDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BibliotecaCs");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = _dbContext.Exemplar;

            var viewModel = entity
                .Select(c => new ExemplarViewModel(c.IdExemplar, c.CodigoObra))
                .ToList();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT CodExemplar, codigoObra FROM Exemplar";

                var ViewModelTest = sqlConnection.Query<ExemplarViewModel>(query);
            }

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _dbContext.Exemplar.SingleOrDefault(c => c.IdExemplar == id);

            if (entity == null)
                return NotFound();

            var DetailsViewModel = new ExemplarViewModel(
                entity.IdExemplar,
                entity.CodigoObra
                );

            return Ok(DetailsViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] ExemplarInputModel model)
        {
            // Se o cadastro funcionar, created 201, se dados incorretos, badrequest (400)
            var entity = new Exemplar(model.IdExemplar, model.CodigoObra);

            _dbContext.Exemplar.Add(entity);

            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = entity.IdExemplar },
                model
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _dbContext.Exemplar.SingleOrDefault(c => c.IdExemplar == id);

            if (entity == null)
                return NotFound();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Exemplar WHERE Id = @id";

                sqlConnection.Execute(query, new { id = entity.IdExemplar });
            }

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
