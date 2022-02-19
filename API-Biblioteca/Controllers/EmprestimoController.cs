using Microsoft.Data.SqlClient;
using DevCars.API.Entities;
using DevCars.API.InputModels;
using DevCars.API.Persistence;
using DevCars.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace APIBiblioteca
{
    [Route("api/emprestimo")]

    public class EmprestimoController : ControllerBase
    {
        private readonly APIDbContext _dbContext;
        private readonly string _connectionString;

        public EmprestimoController(APIDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BibliotecaCs");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var emprestimo = _dbContext.Emprestimo;

            var emprestimoViewModel = emprestimo
                .Select(c => new EmprestimoViewModel(c.Id, c.CodExemplar))
                .ToList();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT CodEmprestimo, IdUsuarioGeral, CodExemplar FROM Emprestimo";

                var ViewModelTest = sqlConnection.Query<EmprestimoViewModel>(query);
            }

            return Ok(emprestimoViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emprestimo = _dbContext.Emprestimo.SingleOrDefault(c => c.CodEmprestimo == id);

            if (emprestimo == null)
                return NotFound();

            var DetailsViewModel = new EmprestimoViewModel(
                emprestimo.Id,
                emprestimo.CodExemplar
                );

            return Ok(DetailsViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] EmprestimoInputModel model)
        {
            // Se o cadastro funcionar, created 201, se dados incorretos, badrequest (400)
            var emprestimo = new Emprestimo(model.Id, model.CodExemplar);

            _dbContext.Emprestimo.Add(emprestimo);

            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = emprestimo.CodEmprestimo },
                model
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emprestimo = _dbContext.Emprestimo.SingleOrDefault(c => c.CodEmprestimo == id);

            if (emprestimo == null)
                return NotFound();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Emprestimo WHERE Id = @id";

                sqlConnection.Execute(query, new { id = emprestimo.CodEmprestimo });
            }

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
