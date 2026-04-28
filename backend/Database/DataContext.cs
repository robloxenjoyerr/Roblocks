using Microsoft.EntityFrameworkCore;
using Roblocks.Database.Models;

namespace Roblocks.Database;


public class DataContext : DbContext
{
    public DbSet<Games> Games { get; set; }
    public DbSet<Users> Users { get; set; }
    
    
    public DataContext(DbContextOptions<DataContext> options) : base(options){}
}