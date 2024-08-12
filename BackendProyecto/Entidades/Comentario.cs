using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Entidades
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Contenido { get; set; }

        public DateTime? Fecha { get; set; } = DateTime.Now;

        // Relación con la clase Usuario
        [ForeignKey("Usuario")]
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        // Relación polimórfica
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }

        public int? SeriesId { get; set; }
        public Series? Series { get; set; }
    }

}
