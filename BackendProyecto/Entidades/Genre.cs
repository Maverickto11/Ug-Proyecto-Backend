using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendProyecto.Entidades
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
