using apiContact.Models.Entity;
using Microsoft.EntityFrameworkCore;
namespace apiContact.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
