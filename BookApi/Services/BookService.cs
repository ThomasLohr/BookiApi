using BookApi.Helpers;
using BookApi.Models;
using BookApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Services
{

    //Service class
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book>GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public async Task<Book?> FindBookById(string? id)
        {
            return await _bookRepository.FindBookById(id);
        }

        public async Task<IEnumerable<Book>> GetAuthor(string author)
        {
            return await _bookRepository.GetAuthor(author);
        }

        public async Task<IEnumerable<Book>> GetTitle(string title)
        {
            return await _bookRepository.GetTitle(title);
        }

        public async Task<IEnumerable<Book>> GetGenre(string genre)
        {
            return await _bookRepository.GetGenre(genre);
        }

        public async Task<Book?> FindBookByPrice(decimal price)
        {
            return await _bookRepository.FindBookByPrice(price);
        }

        public async Task<IEnumerable<Book>> GetPriceRange(decimal priceOne, decimal priceTwo)
        {
            return await _bookRepository.GetPriceRange(priceOne, priceTwo);  
        }

        public async Task<IEnumerable<Book>> GetPublished(int? year, int? month, int? day)
        {
            return await _bookRepository.GetPublished(year, month, day);
        }

        public async Task<IEnumerable<Book>> GetDescription(string description)
        {
            return await _bookRepository.GetDescription(description);
        }

        public async void SaveBook(Book book)
        {
              await Task.Run(() => _bookRepository.SaveBook(book)); 
        }
    }
}
