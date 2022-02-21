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
    [Route("api/posicaoFila")]
    public class PosicaoFilaController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        private readonly string _connectionString;

        public PosicaoFilaController(DevCarsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("BibliotecaCs");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = _dbContext.Posicao_Fila;

            var viewModel = entity
                .Select(c => new PosicaoFilaViewModel(c.IdPosicao, c.CodPedido, c.Entrada, c.Prazo))
                .ToList();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Posicao_Fila";

                var ViewModelTest = sqlConnection.Query<PedidoEmprestimoViewModel>(query);
            }

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _dbContext.Posicao_Fila.SingleOrDefault(c => c.IdPosicao == id);

            if (entity == null)
                return NotFound();

            var DetailsViewModel = new PosicaoFilaViewModel(
                entity.IdPosicao,
                entity.CodPedido,
                entity.Entrada,
                entity.Prazo
                );

            return Ok(DetailsViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] PosicaoFilaInputModel model)
        {
            // Se o cadastro funcionar, created 201, se dados incorretos, badrequest (400)
            var entity = new Posicao_Fila(
                model.IdPosicao,
                model.CodPedido,
                model.Entrada,
                model.Prazo);

            _dbContext.Posicao_Fila.Add(entity);

            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = entity.IdPosicao },
                model
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _dbContext.Posicao_Fila.SingleOrDefault(c => c.IdPosicao == id);

            if (entity == null)
                return NotFound();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Posicao_Fila WHERE IdPosicao = @id";

                sqlConnection.Execute(query, new { id = entity.IdPosicao });
            }

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
