using CoreData.Entities.LtCustomers;
using Microsoft.EntityFrameworkCore;

namespace ExcelStreamReader.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    // Entities
    public DbSet<LtCustomers> LtCustomers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureEntityPrimaryKeys(modelBuilder);
        ConfigureEntityProperties(modelBuilder);
        // ConfigureEntityRelationships(modelBuilder);
    }

    /*private static void ConfigureEntityRelationships(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }*/

    private static void ConfigureEntityProperties(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LtCustomers>()
            .Property(LTC => LTC.PlateNumber)
            .HasMaxLength(51)
            .IsRequired();

        modelBuilder.Entity<LtCustomers>()
            .Property(LTC => LTC.LtCustomerName)
            .HasMaxLength(331)
            .IsRequired();
        
        modelBuilder.Entity<LtCustomers>()
            .Property(LTC => LTC.LotPlaceTitle)
            .HasMaxLength(331)
            .IsRequired();

        modelBuilder.Entity<LtCustomers>()
            .Property(LTC => LTC.Comment)
            .HasMaxLength(724);

        modelBuilder.Entity<LtCustomers>()
            .Property(LTC => LTC.AdditionalPlateNumbers)
            .HasMaxLength(724);

        modelBuilder.Entity<LtCustomers>()
            .Property(LTC => LTC.LtcGroupName)
            .HasMaxLength(331);
    }

    private static void ConfigureEntityPrimaryKeys(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LtCustomers>()
            .HasKey(LTC => LTC.Id);
    }
}