using DevCars.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Persistence.Configurations
{
    public class PedidoEmprestimoDbConfiguration : IEntityTypeConfiguration<Pedido_Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Pedido_Emprestimo> builder)
        {
            builder.HasKey(c => c.CodPedido);
        }
    }
}
