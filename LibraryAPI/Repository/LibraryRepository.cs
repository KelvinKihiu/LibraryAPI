using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Net;

namespace LibraryAPI.Repository
{
    public class LibraryRepository : IRepository
    {
        private readonly LibraryDbContext dbContext;

        public LibraryRepository(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDb");

            var client = new MongoClient(connectionString);
            dbContext = LibraryDbContext.Create(client.GetDatabase("book_library"));
        }

        public async Task<Book> CreateBook(Book book)
        {
            book.Id = Guid.NewGuid().ToString();

            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();

            return book;
        }

        public async Task<int> DeleteBook(string bookId)
        {
            var book = dbContext.Books.FirstOrDefault(x => x.Id == bookId);
            if (book is null) return -1;

            dbContext.Books.Remove(book);
            await dbContext.SaveChangesAsync();

            return 1;
        }

        public async Task<Book?> GetBookById(string bookId)
        {
            return await dbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
        }

        public async Task<ICollection<Book>> GetBooks()
        {
            return await dbContext.Books.ToListAsync();
        }

        public async Task<int> UpdateBook(Book book)
        {
            var bookFromDb = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
            if (bookFromDb is null) return -1;

            bookFromDb.Title = book.Title;
            bookFromDb.Description = book.Description;
            bookFromDb.Author = book.Author;
            bookFromDb.PublicationDate = book.PublicationDate;

            await dbContext.SaveChangesAsync();

            return 1;
        }
    }
}
