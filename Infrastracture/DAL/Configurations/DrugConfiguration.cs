using System.Xml;
using Domain.Entities;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastracture.DAL.Configurations;

public class DrugConfiguration : IEntityTypeConfiguration<Drug>
{
    public void Configure(EntityTypeBuilder<Drug> builder)
    {
        builder.ToTable(nameof(Drug));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(150)
            .HasAnnotation("Name", XML.GetPropertySummary(typeof(Drug), nameof(Drug.Name)));

        builder.Property(x => x.Manufacturer)
            .IsRequired()
            .HasMaxLength(100)
            .HasAnnotation("Manufacturer", XML.GetPropertySummary(typeof(Drug), nameof(Drug.Manufacturer)));

        builder.Property(x => x.CountryCodeId)
            .IsRequired()
            .HasMaxLength(2)
            .HasAnnotation("CountryCodeId", XML.GetPropertySummary(typeof(Drug), nameof(Drug.CountryCodeId)));
    }
}