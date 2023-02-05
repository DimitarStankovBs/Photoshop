namespace Photoshop.Data
{
    using Photoshop.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
