using LibraryAPI.Controllers;
using LibraryAPI.Models;
using LibraryAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace LibraryAPI.Tests.UnitTests
{
    public class BooksControllerTests
    {
        private readonly IRepository _mockRepository;
        private readonly BooksController _sut;

        public BooksControllerTests()
        {
            _mockRepository = Substitute.For<IRepository>();
            _sut = new BooksController(_mockRepository);
        }


        [Fact]
        public async Task GetBooks_ReturnsBooks()
        {
            // Arrange
            _mockRepository.GetBooks().Returns([]);

            // Act
            var results = await _sut.Get();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Book>>(results);
        }


        [Fact]
        public async Task GetBook_ReturnsBook()
        {
            // Arrange
            _mockRepository.GetBookById("").Returns(new Book());

            // Act
            var results = await _sut.Get("");

            // Assert
            Assert.IsType<Book>(results);
        }


        [Fact]
        public async Task CreateBook_ReturnsCreatedResult()
        {
            // Arrange
            var book = new Book();
            _mockRepository.CreateBook(book).Returns(book with { Id = Guid.NewGuid().ToString() });

            // Act
            var results = await _sut.Post(book);

            // Assert
            Assert.IsType<CreatedResult>(results);
            Assert.False(string.IsNullOrWhiteSpace(((CreatedResult)results).Value?.ToString()));
        }


        [Fact]
        public async Task PutBook_ReturnsOkResult()
        {
            // Arrange
            var book = new Book();
            _mockRepository.UpdateBook(book).Returns(1);

            // Act
            var results = await _sut.Put(book);

            // Assert
            Assert.IsType<NoContentResult>(results);
        }


        [Fact]
        public async Task DeleteBook_ReturnsOkResult()
        {
            // Arrange
            var book = new Book();
            _mockRepository.DeleteBook("").Returns(1);

            // Act
            var results = await _sut.Delete("");

            // Assert
            Assert.IsType<OkObjectResult>(results);
            Assert.True((((OkObjectResult)results).Value?.ToString()) == "1");
        }
    }
}
