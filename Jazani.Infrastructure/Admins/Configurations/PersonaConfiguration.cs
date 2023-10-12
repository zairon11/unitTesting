using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jazani.Infrastructure.Admins.Configurations
{
    // revisar de internal a public
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {

            var toDateTime = new ValueConverter<DateTime, DateTimeOffset>(
                dateTime => DateTimeOffset.UtcNow,
                DateTimeOffset => DateTimeOffset.DateTime
                );

            builder.ToTable("persontype", "ge");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate").HasConversion(toDateTime);
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
