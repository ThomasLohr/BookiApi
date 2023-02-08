using BookApi.Helpers;
using BookApi.Models;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookApi.Repository
{

    //Repository
    public class BookRepository : IBookRepository
    {
        private readonly StreamReaderData _streamReaderData;
        private readonly IEnumerable<Book> _books;
        
        public BookRepository(StreamReaderData streamReaderData, IEnumerable<Book> books)
        {
            _streamReaderData = streamReaderData;
            _books = Task.Run(() => _streamReaderData.LoadData()).Result;
        }
      
        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }
        public async Task<Book?> FindBookById(string? id)
        {
            var listOfBooks = await _streamReaderData.LoadData();

            if (!string.IsNullOrEmpty(id))
            {
                return listOfBooks.FirstOrDefault(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase)); 
            }
            return null;
        }

        public async Task<Book?> FindBookByPrice(decimal price)
        {
            var listOfBooks = await _streamReaderData.LoadData();
      
               return listOfBooks.FirstOrDefault(x => x.Price == price);
        }

        public async Task<IEnumerable<Book>> GetAuthor(string author)
        {
            var listOfBooks = await _streamReaderData.LoadData();

            if (!string.IsNullOrEmpty(author))
            {
                return listOfBooks.Where(x => x.Author != null && x.Author.ToLower().Contains(author.ToLower())).OrderBy(x => x.Author); 
            }
            return new List<Book>();
        }

        public async Task<IEnumerable<Book>> GetTitle(string title)
        {
            var listOfBooks = await _streamReaderData.LoadData();
            
            return listOfBooks.Where(x => x.Title != null && x.Title.Contains(title)).OrderBy(x => x.Title);  
        }

        public async Task<IEnumerable<Book>> GetGenre(string genre)
        {
            var listOfBooks = await _streamReaderData.LoadData();

            return listOfBooks.Where(x => x.Genre != null && x.Genre.Contains(genre)).OrderBy(x => x.Genre);
        }

        public async Task<IEnumerable<Book>> GetPriceRange(decimal priceOne, decimal priceTwo)
        {
            var listOfBooks = await _streamReaderData.LoadData();

            return listOfBooks.Where(x => x.Price > priceOne).Where(y => y.Price < priceTwo).OrderBy(x => x.Price);
        }

        public async Task<IEnumerable<Book>> GetPublished(int? year, int? month, int? day)
        {
            var listOfBooks = await _streamReaderData.LoadData();

            if (year != null && month != null && day != null)
            {
                return listOfBooks.Where(x => x.Publish_date.Year == year
                    && x.Publish_date.Month == month 
                    && x.Publish_date.Day == day).OrderBy(x => x.Publish_date);
            }
            else if (year != null && month != null)
            {
                return listOfBooks.Where(x => x.Publish_date.Year == year
                    && x.Publish_date.Month == month).OrderBy(x => x.Publish_date);
            }
            else if (year != null)
            {
                return listOfBooks.Where(x => x.Publish_date.Year == year).OrderBy(x => x.Publish_date);
            }
            else if (month != null && day != null)
            {
                return listOfBooks.Where(x => x.Publish_date.Month == month
                    && x.Publish_date.Day == day).OrderBy(x => x.Publish_date);
            }
            else if (month != null)
            {
                return listOfBooks.Where(x => x.Publish_date.Month == month).OrderBy(x => x.Publish_date);
            }
            else if (day != null)
            {
                 return listOfBooks.Where(x => x.Publish_date.Day == day).OrderBy(x => x.Publish_date);
            }
            else
            {
                return listOfBooks;
            }   
        }

        public async Task<IEnumerable<Book>> GetDescription(string description)
        {
            var listOfBooks = await _streamReaderData.LoadData();

            return listOfBooks.Where(x => x.Description != null && x.Description.Contains(description)).OrderBy(x => x.Description);
        }

        public async void SaveBook(Book book)
        {
             await Task.Run(() => _streamReaderData.SaveBook(book));
        }
    }
}
        
    

    

