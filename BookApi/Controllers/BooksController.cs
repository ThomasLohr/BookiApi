using BookApi.Models;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;


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

        [HttpGet("id/{id}")]
        public async Task<ActionResult<Book?>> FindBookById(string? id)
        {
            var findBookById = await _bookService.FindBookById(id);
            return Ok(findBookById);
        }

        [HttpGet("author")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAuthor(string author)
        {
            var getAuthor = await _bookService.GetAuthor(author);
            return Ok(getAuthor);
        }

        [HttpGet("title")]
        public async Task<ActionResult<IEnumerable<Book>>> GetTitle(string title)
        {
            var getTitle = await _bookService.GetTitle(title);
            return Ok(getTitle);
        }

        [HttpGet("genre")]
        public async Task<ActionResult<IEnumerable<Book>>> GetGenre(string genre)
        {
            var getGenre = await _bookService.GetGenre(genre);
            return Ok(getGenre);
        }


        [HttpGet("price")]
        public async Task<ActionResult<Book>> FindBookByPrice(decimal price)
        {
            var findBookByPrice = await _bookService.FindBookByPrice(price);
            return Ok(findBookByPrice);
        }
        

        [HttpGet("pricerange")]
        public async Task<ActionResult<IEnumerable<Book>>> GetPriceRange(decimal priceOne, decimal priceTwo)
        {
            var getPriceRange = await _bookService.GetPriceRange(priceOne, priceTwo);
            return Ok(getPriceRange);
        }

        [HttpGet("published")]
        public async Task<ActionResult<IEnumerable<Book>>> GetPublished(int? year, int? month, int? day)
        {
            var getPublished = await _bookService.GetPublished(year, month, day);
            return Ok(getPublished);
        }

        [HttpGet("description")]
        public async Task<ActionResult<IEnumerable<Book>>> GetDescription(string description)
        {
            var getDescription = await _bookService.GetDescription(description);
            return Ok(getDescription);
        }

        [HttpPost]
        public async Task<ActionResult> SaveBook(Book book)
        {
            await Task.Run(() => _bookService.SaveBook(book));
            return StatusCode(200, "Succesfully Created a Book") ;
        }
    }  
}
