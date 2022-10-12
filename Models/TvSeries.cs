using c_sharp_bookflix.Models;

public class TvSeries : MediaContent
{
    public MediaInfo? MediaInfo { get; set; }
    public int SeasonCount { get; set; }

    //public int EpisodeCount { get; set; }

}
