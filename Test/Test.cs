using BookApi.Models;
using BookApi.Repository;
using BookApi.Services;

namespace BookApi
{
    public class FakeRepository : IBookRepository
    {
        private IEnumerable<Book> books;

        public FakeRepository(IEnumerable<Book> books)
        {
            this.books = books;
        }

        public Task<Book?> FindBookById(string? id)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> FindBookByPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public Task<IEnumerable<Book>> GetAuthor(string author)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetDescription(string description)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetPriceRange(decimal priceOne, decimal priceTwo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetPublished(int? year, int? month, int? day)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void SaveBook(Book book)
        {
            throw new NotImplementedException();
        }
    }

    public class Test
    {
        
        [Test]
        public async Task FirstTest()
        {
            var book = new Book();
            var books = new List<Book> { book };
            var repo = new FakeRepository(books);
            var bookService = new BookService(repo);

           

            var result = bookService.GetAllBooks();

            CollectionAssert.AreEqual(result, books);

        }
    }
}
