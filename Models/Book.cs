namespace TomBookApi.Models;

public class Book
{
    public long ISBN { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string PageCount { get; set; }
    public string SmallThumbnail { get; set; }
    public string Authors { get; set; }

    public string SubstringDescription()
    {
        if (Description == null) return "";

        if (Description.Length < 205) return Description;

        return $"{Description.Substring(0, 205)} ...";
    }
}
