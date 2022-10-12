using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using c_sharp_bookflix.Models;
using System.Data;

namespace c_sharp_bookflix.Models
{
    public class BoolflixContext : DbContext
    {
        public DbSet<TvSeries>? Series { get; set; }
        public DbSet<Film>? Films { get; set; }
        public DbSet<Episode>? Episodes { get; set; }
        public DbSet<MediaInfo>? MediaInfos { get; set; }
        public DbSet<Genre>? Genres { get; set; } 
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Feature> Features { get; set; }

        protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=localhost;" +
                "Initial Catalog=db_boolflix;" +
                "Integrated Security=True";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
