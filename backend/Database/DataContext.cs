using Microsoft.EntityFrameworkCore;
using Roblocks.Database.Models;
using Roblocks.Models;

namespace Roblocks.Database;


public class DataContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }
    public DataContext(DbContextOptions<DataContext> options) : base(options){}
}