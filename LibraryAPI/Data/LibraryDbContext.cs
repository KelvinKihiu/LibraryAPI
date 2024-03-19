using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace LibraryAPI.Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; init; }


        public static LibraryDbContext Create(IMongoDatabase database) =>
        new(new DbContextOptionsBuilder<LibraryDbContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options);


        public LibraryDbContext(DbContextOptions options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().ToCollection("books");
        }
    }
}
