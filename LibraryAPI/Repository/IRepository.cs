using LibraryAPI.Models;

namespace LibraryAPI.Repository
{
    public interface IRepository
    {
        Task<ICollection<Book>> GetBooks();
        Task<Book?> GetBookById(string bookId);
        Task<Book> CreateBook(Book book);
        Task<int> UpdateBook(Book book);
        Task<int> DeleteBook(string bookId);
    }
}
