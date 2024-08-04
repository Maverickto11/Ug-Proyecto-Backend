using BackendProyecto.Entidades;
using BackendProyecto.TuDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public interface ILoginRepositoriy
    {
        Task<Usuario> Register(Usuario usuario, string password);
        Task<Usuario> Login(string email, string password);
    }
}
