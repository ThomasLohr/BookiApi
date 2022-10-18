using BookApi.Models;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var listofBooks = await _bookService.GetAllBooks();
            return Ok(listofBooks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book?>> FindBookById(string id)
        {
            var findBookById = await _bookService.FindBookById(id);
            return Ok(findBookById);
        }

        [HttpGet("price")]
        public async Task<ActionResult<Book>> FindBookByPrice([FromQuery] decimal priceValue)
        {
            var findBookByPrice = await _bookService.FindBookByPrice(priceValue);
            return Ok(findBookByPrice);
        }

        [HttpGet("author")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAuthor([FromQuery] string author)
        {
            var getAuthor = await _bookService.GetAuthor(author);
            return Ok(getAuthor);
        }

        [HttpGet("pricerange")]
        public async Task<ActionResult<IEnumerable<Book>>> GetPriceRange([FromQuery] decimal priceOne, decimal priceTwo)
        {
            var getPriceRange = await _bookService.GetPriceRange(priceOne, priceTwo);
            return Ok(getPriceRange);
        }

        [HttpGet("published")]
        public async Task<ActionResult<IEnumerable<Book>>> GetPublished([FromQuery] int? year, int? month, int? day)
        {
            var getPublished = await _bookService.GetPublished(year, month, day);
            return Ok(getPublished);
        }

    }  
}
