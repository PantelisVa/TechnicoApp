using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using project_ED_training.Models;



namespace project_ED_training.Repositories;

public class TechnicoDbContext: DbContext
{
    public DbSet<Owner> Owners { get; set; }
    
    public DbSet<Property> Properties { get; set; }
    public DbSet<Repair> Repairs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        
    {
        string connectionString = “Data Source =(local); Initial Catalog = Technico - db; Integrated Security = True; TrustServerCertificate = True;”;​
        optionsBuilder.UseSqlServer(connectionString);
    }

    //configure the models and their relationships
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Properties>()
            .HasKey(o => o.VATId);
        modelBuilder.Entity<Property>()
            .HasKey(p => p.PropertyID)
            .HasOne(p => p.Owner)
            .WithMany(o => o.Properties)
            .HasForeignKey(p => p.VATId);

        modelBuilder.Entity<Repair>()
            .HasKey(r => r.RepaidID)
            .HasOne(o => o.Owner)
            .WithMany(o => o.Repair)
            .HasForeignKey(r => r.VATId);
    }
}
