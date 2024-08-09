using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendProyecto.Entidades
{
    public class SeriesGenre
    {
        public int? SeriesId { get; set; }
        public int GenreId { get; set; }

        [JsonIgnore]
        public Series? Series { get; set; }
        public Genre? Genre { get; set; }
    }
}
