using BookApi.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookApi.Helpers
{

    // StreamReaderData is a class to keep the code a bit seperated from the rest so it's easier to read/handle
    
    public class StreamReaderData
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _books;
        

        public StreamReaderData(IWebHostEnvironment webHostEnvironment, string books)
        {
            _webHostEnvironment = webHostEnvironment;
            _books = books;
            
        }

        //LoadData method loads the data into C# code so it can be used further down the line

        public async Task<IEnumerable<Book>> LoadData()
        {
            List<Book> books = new List<Book>();

            using (StreamReader reader = new StreamReader($"{_webHostEnvironment.ContentRootPath}{ _books }"))
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


        //SaveBook method a book and addds a new book to the json file

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
