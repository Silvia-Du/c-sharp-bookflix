using c_sharp_bookflix.Models;

public class TvSerie : MediaContent
{
    public int SeasonCount { get; set; }
    public MediaInfo? MediaInfo { get; set; }
    public List<Episode>? Episodes { get; set; }

    //public int EpisodeCount { get; set; }

}

