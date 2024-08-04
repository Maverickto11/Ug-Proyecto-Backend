using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Entidades
{
        public class AutenticacionRespuesta
        {
            public bool Exito { get; set; }
            public string Mensaje { get; set; }
            public Usuario Usuario { get; set; }
        }
   
}
