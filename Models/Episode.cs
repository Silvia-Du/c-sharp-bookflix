using c_sharp_bookflix.Models;

public class Episode : MediaContent
{
    public int SeasonNumber { get; set; }

    public int TvSerieId { get; set; }
    public TvSerie? TvSerie { get; set; }
}
