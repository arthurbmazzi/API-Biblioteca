using DevCars.API.Entities;
using DevCars.API.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DevCars.API.Persistence
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
           
        }

        public DbSet<Assunto> Assuntos { get; set; }

        public DbSet<Autor> Autor { get; set; }

        public DbSet<Emprestimo> Emprestimo { get; set; }

        public DbSet<Exemplar> Exemplar { get; set; }

        public DbSet<Multa> Multa { get; set; }

        public DbSet<Obra> Obra { get; set; }

        public DbSet<Pedido_Emprestimo> Pedido_Emprestimo { get; set; }

        public DbSet<Posicao_Fila> Posicao_Fila { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Autor> Autor_Obra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.ApplyConfiguration(new CarDbConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomerDbConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderDbConfiguration());
            //modelBuilder.ApplyConfiguration(new ExtraOrderItemDbConfiguration());
        }
    }
}
