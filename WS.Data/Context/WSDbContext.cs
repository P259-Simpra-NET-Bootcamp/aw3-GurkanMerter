using Microsoft.EntityFrameworkCore;
using WS.Data.Domain;

namespace WS.Data.Context;

public class WSDbContext:DbContext
{
    public WSDbContext(DbContextOptions<WSDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
