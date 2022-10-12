namespace c_sharp_bookflix.Models
{
    public class FilmMediainfo
    {
        public Film Film { get; set; }

        public MediaInfo MediaInfo { get; set; }

        public List<Actor> Actors { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Feature> Features { get; set; }

        public List<int> ActorIds { get; set; }
        public List<int> GenreIds { get; set; }
        public List<int> FeatureIds { get; set; }

        public FilmMediainfo()
        {
            Film = new();
            MediaInfo = new();
        }
    }
}
