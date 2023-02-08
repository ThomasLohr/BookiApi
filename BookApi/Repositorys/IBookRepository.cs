using BookApi.Helpers;
using BookApi.Models;

namespace BookApi.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();

        Task<Book?> FindBookById(string? id);

        Task<Book?> FindBookByPrice(decimal price);

        Task<IEnumerable<Book>> GetAuthor(string author);

        Task<IEnumerable<Book>> GetTitle(string title);

        Task<IEnumerable<Book>> GetGenre(string genre);

        Task<IEnumerable<Book>> GetPriceRange(decimal priceOne, decimal priceTwo);

        Task<IEnumerable<Book>> GetPublished(int? year, int? month, int? day);

        Task<IEnumerable<Book>> GetDescription(string description);

        void SaveBook(Book book);
    }
}