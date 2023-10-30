#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;

namespace CRUD_Delicious.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) {}
    public DbSet<Dish> Dishes { get; set; }
}
