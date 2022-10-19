using BookApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookApi.Helpers
{
    public class StreamReaderData
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StreamReaderData(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IEnumerable<Book>> LoadData()
        {
            List<Book> books = new List<Book>();

            using (StreamReader reader = new StreamReader($"{_webHostEnvironment.ContentRootPath}/Json/books.json"))
            {
                var options = new JsonSerializerOptions() 
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString,
                    PropertyNameCaseInsensitive = true,
                    
                };
                string? data = await reader.ReadToEndAsync();
                List<Book>? convert = JsonSerializer.Deserialize<List<Book>>(data, options);
                if (convert != null)
                {
                    return convert;
                }
            }
            return books;
        }

        public async void SaveBook(Book book)
        {
            var books = await LoadData();

            var listOfBooks = books.ToList();

            listOfBooks.Add(book);

            var path = $"{_webHostEnvironment.ContentRootPath}/Json/books.json";

            using (StreamWriter writer = new StreamWriter(path))
            {
                var options = new JsonSerializerOptions
                { 
                    WriteIndented = true
                };

                string? jsonString = JsonSerializer.Serialize(listOfBooks, options);

                if (!string.IsNullOrEmpty(jsonString))
                {
                    await writer.WriteAsync(jsonString);
                }
            }
        }
    }
}
