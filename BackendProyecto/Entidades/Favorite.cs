using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Entidades
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string? MovieTitle { get; set; }
        public string? Overview { get; set; }

        public string? PosterPath { get; set; }
        public string? BackdropPath { get; set; }
        public DateTime? AddedDate { get; set; }

    }
}
