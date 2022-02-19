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
    [Route("api/pedidoEmprestimo")]
    public class PedidoEmprestimoController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        private readonly string _connectionString;

        public PedidoEmprestimoController(DevCarsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BibliotecaCs");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = _dbContext.Pedido_Emprestimo;

            var viewModel = entity
                .Select(c => new PedidoEmprestimoViewModel(c.CodPedido, c.CodObra, c.IdUsuarioG, c.StatusEmprestimo, c.DataHora, c.Prioridade))
                .ToList();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Pedido_Emprestimo";

                var ViewModelTest = sqlConnection.Query<PedidoEmprestimoViewModel>(query);
            }

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _dbContext.Pedido_Emprestimo.SingleOrDefault(c => c.CodPedido == id);

            if (entity == null)
                return NotFound();

            var DetailsViewModel = new PedidoEmprestimoViewModel(
                entity.CodPedido,
                entity.CodObra,
                entity.IdUsuarioG,
                entity.StatusEmprestimo,
                entity.DataHora,
                entity.Prioridade
                );

            return Ok(DetailsViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] PedidoEmprestimoInputModel model)
        {
            // Se o cadastro funcionar, created 201, se dados incorretos, badrequest (400)
            var entity = new Pedido_Emprestimo(
                model.CodPedido,
                model.CodObra,
                model.IdUsuarioG,
                model.StatusEmprestimo,
                model.DataHora,
                model.Prioridade);

            _dbContext.Pedido_Emprestimo.Add(entity);

            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = entity.CodPedido },
                model
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _dbContext.Pedido_Emprestimo.SingleOrDefault(c => c.CodPedido == id);

            if (entity == null)
                return NotFound();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Pedido_Emprestimo WHERE Id = @id";

                sqlConnection.Execute(query, new { id = entity.CodObra });
            }

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
