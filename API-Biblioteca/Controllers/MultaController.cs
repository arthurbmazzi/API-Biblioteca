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
    [Route("api/multa")]
    public class MultaController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        private readonly string _connectionString;

        public MultaController(DevCarsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BibliotecaCs");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = _dbContext.Multa;

            var viewModel = entity
                .Select(c => new MultaViewModel(c.CodMultaProp, c.CodEmprestimo, c.Valor, c.IdUsuarioMulta))
                .ToList();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT CodMulta, CodEmprestimo, Valor, IdUsuarioG FROM Multa";

                var ViewModelTest = sqlConnection.Query<MultaViewModel>(query);
            }

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _dbContext.Multa.SingleOrDefault(c => c.CodMultaProp == id);

            if (entity == null)
                return NotFound();

            var DetailsViewModel = new MultaViewModel(
                entity.CodMultaProp,
                entity.CodEmprestimo,
                entity.Valor, 
                entity.IdUsuarioMulta
                );

            return Ok(DetailsViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] MultaInputModel model)
        {
            // Se o cadastro funcionar, created 201, se dados incorretos, badrequest (400)
            var entity = new Multa(model.CodMulta, model.CodEmprestimo, model.Valor, model.IdUsuarioG);

            _dbContext.Multa.Add(entity);

            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = entity.CodMultaProp },
                model
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _dbContext.Multa.SingleOrDefault(c => c.CodMultaProp == id);

            if (entity == null)
                return NotFound();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Multa WHERE CodMultaProp = @id";

                sqlConnection.Execute(query, new { id = entity.CodMultaProp });
            }

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
