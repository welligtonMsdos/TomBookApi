namespace TomBookApi.Models;

public class VolumeInfo
{
    public string Title { get; set; }
    public string[] Authors { get; set; }
    public string Description { get; set; }
    public string PageCount { get; set; }
    public ImageLinks ImageLinks { get; set; }
}
