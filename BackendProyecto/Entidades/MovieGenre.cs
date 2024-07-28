using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BackendProyecto.Entidades
{
    public class MovieGenre
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        // Navegación
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }

        // Define la clave primaria compuesta
        /*public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
        {
            public void Configure(EntityTypeBuilder<MovieGenre> builder)
            {
                builder.HasKey(mg => new { mg.MovieId, mg.GenreId });
            }
        }*/
    }
}
