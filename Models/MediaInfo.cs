using System.ComponentModel.DataAnnotations;

public class MediaInfo
{
    [Key]
    public int Id { get; set; } 
    public string? Year { get; set; }
    public bool IsNew { get; set; }

    //public string VideoQuality { get; set; }

    //relations 1:1
    public int TvSeriesId { get; set; }
    public TvSeries? Series { get; set; }

    public int FilmId { get; set; }
    public Film? Film { get; set; }

    public List<Actor>? Cast { get; set; }
    public List<Genre>? Genres { get; set; }
    public List<Feature>? Features { get; set; }


}
