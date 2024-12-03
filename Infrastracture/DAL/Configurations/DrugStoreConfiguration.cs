using Domain.Entities;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastracture.DAL.Configurations;

public class DrugStoreConfiguration : IEntityTypeConfiguration<DrugStore>
{
    public void Configure(EntityTypeBuilder<DrugStore> builder)
    {
        builder.ToTable(nameof(DrugStore));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DrugNetwork)
            .IsRequired()
            .HasMaxLength(100)
            .HasAnnotation("DrugNetwork", XML.GetPropertySummary(typeof(DrugStore), nameof(DrugStore.DrugNetwork)));

        builder.Property(x => x.Number)
            .HasAnnotation("Number", XML.GetPropertySummary(typeof(DrugStore), nameof(DrugStore.Number)));
        
        builder.Property(x => x.Address)
            .IsRequired()
            .HasAnnotation("Address", XML.GetPropertySummary(typeof(DrugStore), nameof(DrugStore.Address)));
    }
}