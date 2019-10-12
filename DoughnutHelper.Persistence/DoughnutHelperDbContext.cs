using DoughnutHelper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoughnutHelper.Persistence
{
    public class DoughnutHelperDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Message> Messages { get; set; }
        
        public DoughnutHelperDbContext(DbContextOptions<DoughnutHelperDbContext> options) : base(options)
        {
        }
    }
}