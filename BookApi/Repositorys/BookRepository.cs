using BookApi.Helpers;
using BookApi.Models;
using BookApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookApi.Repository
{
    public class BookRepository
    {
        private readonly StreamReaderData _streamReaderData;

        public BookRepository(StreamReaderData streamReaderData)
        {
            _streamReaderData = streamReaderData;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _streamReaderData.LoadData(); 
        }
        public async Task<Book?> FindBookById(string id)
        {
            var listOfBooks = await _streamReaderData.LoadData();

            if (!string.IsNullOrEmpty(id))
            {
                return listOfBooks.FirstOrDefault(x => x.Id == id);
            }
            return null;
        }

        public async Task<Book?> FindBookByPrice(decimal priceValue)
        {
            var listOfBooks = await _streamReaderData.LoadData();
      
               return listOfBooks.FirstOrDefault(x => x.Price == priceValue);
        }

        public async Task<IEnumerable<Book>> GetAuthor(string author)
        {
            var listOfBooks = await _streamReaderData.LoadData();

            return listOfBooks.Where(x => x.Author != null && x.Author.Contains(author));
        }

        public async Task<IEnumerable<Book>> GetPriceRange(decimal priceOne, decimal priceTwo)
        {
            var listOfBooks = await _streamReaderData.LoadData();

            return listOfBooks.Where(x => x.Price > priceOne).Where(y => y.Price < priceTwo);
        }

        public async Task<IEnumerable<Book>> GetPublished(int? year, int? month, int? day)
        {
            var listOfBooks = await _streamReaderData.LoadData();

            if (year != null && month != null && day != null)
            {
                return listOfBooks.Where(x => x.Publish_date.Year == year)
                    .Where(x => x.Publish_date.Month == month)
                    .Where(x => x.Publish_date.Day == day);
            }
            else if (year != null && month != null)
            {
                return listOfBooks.Where(x => x.Publish_date.Year == year)
                    .Where(x => x.Publish_date.Month == month);
            }
            else if (year != null)
            {
                return listOfBooks.Where(x => x.Publish_date.Year == year);
            }
            else if (month != null && day != null)
            {
                return listOfBooks.Where(x => x.Publish_date.Month == month)
                    .Where(x => x.Publish_date.Day == day);
            }
            else if (month != null)
            {
                return listOfBooks.Where(x => x.Publish_date.Month == month);
            }
            else if (day != null)
            {
                 return listOfBooks.Where(x => x.Publish_date.Day == day);
            }
            else
            {
                return listOfBooks;
            }
        }
    }
}
        
    

    

