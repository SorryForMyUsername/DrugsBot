using Domain.Entities;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastracture.DAL.Configurations;

public class DrugItemConfiguration : IEntityTypeConfiguration<DrugItem>
{
    public void Configure(EntityTypeBuilder<DrugItem> builder)
    {
        builder.ToTable(nameof(DrugItem));
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Cost)
            .HasPrecision(18, 2)
            .HasAnnotation("Cost", XML.GetPropertySummary(typeof(DrugItem), nameof(DrugItem.Cost)));

        builder.Property(x => x.Count)
            .HasAnnotation("Count", XML.GetPropertySummary(typeof(DrugItem), nameof(DrugItem.Count)));
    }
}