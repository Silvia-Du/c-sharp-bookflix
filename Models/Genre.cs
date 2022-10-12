using c_sharp_bookflix.Models;

public class Genre
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<MediaInfo>? MediaInfos { get; set; }
}
