using myapp.infra.repository.memory.entities;

namespace myapp.infra.repository.memory;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<PersonEntity> Persons { get; set; }
}