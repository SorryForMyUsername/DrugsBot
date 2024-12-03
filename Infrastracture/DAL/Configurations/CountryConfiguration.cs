using Domain.Entities;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastracture.DAL.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable(nameof(Country));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasAnnotation("Name", XML.GetPropertySummary(typeof(Country), nameof(Country.Name)));

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(2)
            .HasAnnotation("Code", XML.GetPropertySummary(typeof(Country), nameof(Country.Code)));
    }
}