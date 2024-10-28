using TomBookApi.Interfaces;
using TomBookApi.Models;
using Newtonsoft.Json;

namespace TomBookApi.Services;

public class BookGoogleService : IBook
{
    private readonly HttpClient _httpClient;
    private const string BASE_PATH = "v1/volumes?q=isbn:";
    private const string KEY = "&key=AIzaSyDe914FUSV408rptTc14ByoSlB3eSc3hgs";

    public BookGoogleService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<Book> GetBooks()
    {
        return new Book();
    }

    public async Task<Book> GetBooksByISBN(long isbn)
    {
        try
        {
            var book = new Book();

            var request = await _httpClient.GetAsync(BASE_PATH + isbn + KEY);

            var dataAsString = await request.Content.ReadAsStringAsync().ConfigureAwait(false);

            var root = JsonConvert.DeserializeObject<Root>(dataAsString);

            book.ISBN = isbn;
            book.Title = root.Items.FirstOrDefault()?.VolumeInfo.Title;
            book.Authors = root.Items.FirstOrDefault()?.VolumeInfo.Authors[0];
            book.Description = root.Items.FirstOrDefault()?.VolumeInfo.Description;
            book.PageCount = root.Items.FirstOrDefault()?.VolumeInfo.PageCount;
            book.SmallThumbnail = root.Items.FirstOrDefault()?.VolumeInfo.ImageLinks?.smallThumbnail;           

            return book;
        }
        catch (Exception ex)
        {
            return new Book();
        }
    }
}
