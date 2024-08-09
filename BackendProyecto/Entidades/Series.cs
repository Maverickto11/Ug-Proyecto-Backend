using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendProyecto.Entidades
{
    public class Series
    {
        public int SeriesId { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string? BackdropPath { get; set; }
        public decimal? Rating { get; set; }
        public int? VoteCount { get; set; }
        public int? NumberOfSeasons { get; set; }
        public int? NumberOfEpisodes { get; set; }
        public string? Trailer { get; set; }
        public string? Tipo { get; set; }

        [JsonIgnore]
        public ICollection<SeriesGenre?> SeriesGenres { get; set; } = new List<SeriesGenre>();
    }
}
