using Domain.Entities;
using Infrastracture.DAL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.DAL;

public class DrugsBotDbContext : DbContext
{
    public DrugsBotDbContext(DbContextOptions<DrugsBotDbContext> options) : base(options)
    {
        
    }
    
    /// <summary>
    /// Таблица препаратов.
    /// </summary>
    public DbSet<Drug> Drugs { get; set; }
    
    /// <summary>
    /// Таблица стран.
    /// </summary>
    public DbSet<Country> Countries { get; set; }
    
    /// <summary>
    /// Таблица связей препаратов с аптеками.
    /// </summary>
    public DbSet<DrugItem> DrugItems { get; set; }
    
    /// <summary>
    /// Таблица аптек.
    /// </summary>
    public DbSet<DrugStore> DrugStores { get; set; }
    
    /// <summary>
    /// Таблица избранных препаратов.
    /// </summary>
    public DbSet<FavouriteDrug> FavouriteDrugs { get; set; }
    
    /// <summary>
    /// Таблица профилей пользователей.
    /// </summary>
    public DbSet<Profile> Profiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DrugConfiguration());
        modelBuilder.ApplyConfiguration(new DrugStoreConfiguration());
        modelBuilder.ApplyConfiguration(new DrugItemConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileConfiguration());
    }
}