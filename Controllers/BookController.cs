using Microsoft.AspNetCore.Mvc;
using TomBookApi.Interfaces;
using TomBookApi.Models;

namespace TomBookApi.Controllers;

public class BookController : Controller
{
    private readonly IBook _BookService;

    public BookController(IBook bookService)
    {
        _BookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
    }

    [HttpGet("ByISBN/{isbn}")]
    public async Task<ActionResult<IEnumerable<Book>>> GetByISBN(long isbn)
    {
        try
        {
            var books = await _BookService.GetBooksByISBN(isbn);

            return Ok(books);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }       
    }
}
