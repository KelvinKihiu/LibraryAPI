using LibraryAPI.Models;
using LibraryAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository _repository;


        public BooksController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/books
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _repository.GetBooks();
        }


        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<Book?> Get(string id)
        {
            return await _repository.GetBookById(id);
        }


        // POST api/books
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            book = await _repository.CreateBook(book);

            return Created($"/api/books", book.Id);
        }


        // PUT api/books
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Book book)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _repository.UpdateBook(book);
            if (result == -1) return NotFound("Could not find the selected book.");

            return NoContent();
        }


        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _repository.DeleteBook(id);
            if (result == -1) return NotFound();

            return Ok(result);
        }
    }
}
