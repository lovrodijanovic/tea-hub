using Microsoft.EntityFrameworkCore;
using TeaHub.Server.Models.Domain;

namespace TeaHub.Server.Data
{
    public class TeaHubDbContext : DbContext
    {
        public TeaHubDbContext(DbContextOptions<TeaHubDbContext> dbContextOptions) : base(dbContextOptions)
        {
                
        }

        public DbSet<Tea> Teas { get; set; }
        public DbSet<Models.Domain.Type> Types { get; set; }
        public DbSet<Origin> Origins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var types = new List<Models.Domain.Type>()
            {
                new Models.Domain.Type
                {
                    Id = Guid.Parse("3ec436ab-47a0-449a-9d19-1a9d8f34c3bd"),
                    Name = "White"
                },
                new Models.Domain.Type
                {
                    Id = Guid.Parse("ed5b839f-4a58-459c-ae3c-10f997b5174c"),
                    Name = "Green"
                },
                new Models.Domain.Type
                {
                    Id = Guid.Parse("0d8c977a-e5a6-42c6-808f-5b1d8fff61c2"),
                    Name = "Oolong"
                },
                new Models.Domain.Type
                {
                    Id = Guid.Parse("d8402d0c-9578-4d54-a4e3-d1a915d8c59a"),
                    Name = "Yellow"
                },
                new Models.Domain.Type
                {
                    Id = Guid.Parse("1fd3cbbb-0b22-42b1-bf17-3417d16c53c0"),
                    Name = "Black"
                }
            };
            modelBuilder.Entity<Models.Domain.Type>().HasData(types);

            var origins = new List<Origin>()
            {
                new Origin
                {
                    Id = Guid.Parse("5600c9b5-3a70-40e0-9e04-9b476b10071d"),
                    Name = "China"
                },
                new Origin
                {
                    Id = Guid.Parse("86457340-1456-44c1-a80a-2a9b0e0ad64e"),
                    Name = "Japan"
                },
                new Origin
                {
                    Id = Guid.Parse("4640705a-c3a8-4322-a0ff-cdcb7f4d9168"),
                    Name = "Taiwan"
                },
                new Origin
                {
                    Id = Guid.Parse("cd29ae67-690a-48b4-b315-57f06d8759eb"),
                    Name = "Nepal"
                },
                new Origin
                {
                    Id = Guid.Parse("24778741-c9a9-4109-b3f0-c8fd0a331211"),
                    Name = "India"
                }
            };
            modelBuilder.Entity<Origin>().HasData(origins);
        }
    }
}
