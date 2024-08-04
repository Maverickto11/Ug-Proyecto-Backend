using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Entidades
{
    public class Pelicula
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }

        public string Overview { get; set; }

    }
}
