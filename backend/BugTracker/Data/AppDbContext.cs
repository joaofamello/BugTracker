using BugTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Projeto> Projetos { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}