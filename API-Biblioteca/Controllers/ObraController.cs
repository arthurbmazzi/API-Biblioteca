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
    [Route("api/obra")]
    public class ObraController : ControllerBase
    {
        private readonly APIDbContext _dbContext;
        private readonly string _connectionString;

        public ObraController(APIDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BibliotecaCs");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = _dbContext.Obra;

            var viewModel = entity
                .Select(c => new ObraViewModel(c.CodigoObraProp, c.Tipo, c.Titulo, c.DescFisica, c.ExDisponiveis, c.Publicacao, c.Edicao, c.Isbn, c.DescTrab))
                .ToList();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Obra";

                var ViewModelTest = sqlConnection.Query<ObraViewModel>(query);
            }

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _dbContext.Obra.SingleOrDefault(c => c.CodigoObraProp == id);

            if (entity == null)
                return NotFound();

            var DetailsViewModel = new ObraViewModel(
                entity.CodigoObraProp,
                entity.Tipo,
                entity.Titulo,
                entity.DescFisica,
                entity.ExDisponiveis,
                entity.Publicacao,
                entity.Edicao,
                entity.Isbn,
                entity.DescTrab
                );

            return Ok(DetailsViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] ObraInputModel model)
        {
            // Se o cadastro funcionar, created 201, se dados incorretos, badrequest (400)
            var entity = new Obra(
                model.CodObra,
                model.Tipo,
                model.Titulo,
                model.DescFisica,
                model.ExDisponiveis,
                model.Publicacao,
                model.Edicao,
                model.ISBN,
                model.DescTrab);

            _dbContext.Obra.Add(entity);

            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = entity.CodigoObraProp },
                model
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _dbContext.Obra.SingleOrDefault(c => c.CodigoObraProp == id);

            if (entity == null)
                return NotFound();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Obra WHERE Id = @id";

                sqlConnection.Execute(query, new { id = entity.CodigoObraProp });
            }

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
