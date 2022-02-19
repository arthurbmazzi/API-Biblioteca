using DevCars.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DevCars.API.Persistence.Configurations
{
    public class PosicaoFilaDbConfiguration : IEntityTypeConfiguration<Posicao_Fila>
    {
        public void Configure(EntityTypeBuilder<Posicao_Fila> builder)
        {
            builder.HasKey(c => c.IdPosicao);
        }
    }
}
