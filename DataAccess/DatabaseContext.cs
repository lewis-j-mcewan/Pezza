namespace DataAccess;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {

    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {

    }

    public virtual DbSet<Pizza> Pizzas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PizzaMap());
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("PezzaDb");
        base.OnConfiguring(optionsBuilder);
    }
}

