using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Freshx_API.Models;

public partial class FreshxDBContext : DbContext
{
    public FreshxDBContext(DbContextOptions<FreshxDBContext> options)
        : base(options)
    {
    }
    public DbSet<Savefile> Savefiles { get; set; }
    
    // Các DbSet khác nếu có
}
