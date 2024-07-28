using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendProyecto.Entidades
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public decimal Rating { get; set; }
        public int VoteCount { get; set; }
        public int? Duration { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
