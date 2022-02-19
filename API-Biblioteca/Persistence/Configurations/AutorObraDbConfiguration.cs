using DevCars.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Persistence.Configurations
{
    public class AutorObraDbConfiguration : IEntityTypeConfiguration<Autor_Obra>
    {
        public void Configure(EntityTypeBuilder<Autor_Obra> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
