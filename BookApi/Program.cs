using BookApi.Helpers;
using BookApi.Repository;
using BookApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<BookService>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();
builder.Services.AddSingleton<StreamReaderData>(s => new StreamReaderData(s.GetService<IWebHostEnvironment>(), "Json/books.json"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
