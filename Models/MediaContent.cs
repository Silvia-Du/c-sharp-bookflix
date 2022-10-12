using System.ComponentModel.DataAnnotations;

namespace c_sharp_bookflix.Models
{
    public class MediaContent
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }

        public int Duration { get; set; }

        public string? Description   { get; set; }

        public int VisualizationCount { get; set; }


    }
}
