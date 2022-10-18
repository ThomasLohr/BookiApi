using BookApi.Helpers;
using BookApi.Models;
using BookApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<Book?> FindBookById(string id)
        {
            return await _bookRepository.FindBookById(id);
        }

        public async Task<Book?> FindBookByPrice(decimal priceValue)
        {
            return await _bookRepository.FindBookByPrice(priceValue);
        }

        public async Task<IEnumerable<Book?>> GetAuthor(string author)
        {
            return await _bookRepository.GetAuthor(author);
        }

        public async Task<IEnumerable<Book>> GetPriceRange(decimal priceOne, decimal priceTwo)
        {
            if (true)
            {

            }

            return await _bookRepository.GetPriceRange(priceOne, priceTwo);  


        }

        public async Task<IEnumerable<Book?>> GetPublished(int? year, int? month, int? day)
        {
            return await _bookRepository.GetPublished(year, month, day);
        }
    }
}
