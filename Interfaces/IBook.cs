using TomBookApi.Models;

namespace TomBookApi.Interfaces;

public interface IBook
{
    Task<Book> GetBooks();
    Task<Book> GetBooksByISBN(long isbn);
}
