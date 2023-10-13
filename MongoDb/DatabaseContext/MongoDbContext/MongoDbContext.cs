using Microsoft.EntityFrameworkCore;
using MongoDb.Models;
using MongoDB.EntityFrameworkCore.Extensions;

namespace MongoDb.DatabaseContext.MongoDbContext
{
    public class MongoDbContext : DbContext
    {
        public MongoDbContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().ToCollection("movies");
        }
        public DbSet<Movie> Movies { get; init; }
    }
}
