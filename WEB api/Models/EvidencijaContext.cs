using Microsoft.EntityFrameworkCore;

namespace WEB_api.Models
{
    public class EvidencijaContext : DbContext
    {
            public DbSet<Evidencija> Evidencije { get; set; }
            public DbSet<Vozacka> Vozacke { get; set; }
            public DbSet<Kategorija> Kategorije { get; set; }
            public EvidencijaContext(DbContextOptions options) : base(options)
            {
            
            }
    }
}