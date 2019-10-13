using DoughnutHelper.Domain.Entities;
using DoughnutHelper.Domain.Enumerations;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>().HasData(
                new Message
                {
                    Id = 1,
                    IsQuestion = true,
                    Title = "Do I want a doughnut?",
                    ParentId = null,
                    ByAnswer = null
                },
                new Message
                {
                    Id = 2,
                    IsQuestion = true,
                    Title = "Do I deserve it?",
                    ParentId = 1,
                    ByAnswer = Answers.Yes
                },
                new Message
                {
                    Id = 3,
                    IsQuestion = true,
                    Title = "Are you sure?",
                    ParentId = 2,
                    ByAnswer = Answers.Yes
                },
                new Message
                {
                    Id = 4,
                    IsQuestion = true,
                    Title = "Is it a good doughnut?",
                    ParentId = 2,
                    ByAnswer = Answers.No
                },
                new Message
                {
                    Id = 5,
                    IsQuestion = true,
                    Title = "Maybe you want an apple?",
                    ParentId = 1,
                    ByAnswer = Answers.No
                },
                new Message
                {
                    Id = 6,
                    IsQuestion = false,
                    Title = "Get it.",
                    ParentId = 3,
                    ByAnswer = Answers.Yes
                },
                new Message
                {
                    Id = 7,
                    IsQuestion = false,
                    Title = "Do jumping jacks first.",
                    ParentId = 3,
                    ByAnswer = Answers.No
                },
                new Message
                {
                    Id = 8,
                    IsQuestion = false,
                    Title = "What are you waiting for? Grab it now.",
                    ParentId = 4,
                    ByAnswer = Answers.Yes
                },
                new Message
                {
                    Id = 9,
                    IsQuestion = false,
                    Title = "Wait 'till you find a sinful, unforgettable doughnut.",
                    ParentId = 4,
                    ByAnswer = Answers.No
                }
            );
        }
    }
}