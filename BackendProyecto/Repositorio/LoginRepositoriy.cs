using BackendProyecto.Entidades;
using BackendProyecto.TuDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendProyecto.TuDbContext;
using Microsoft.EntityFrameworkCore;

namespace BackendProyecto.Repositorio
{
    public class LoginRepositoriy : ILoginRepositoriy
    {
        public readonly TmdbContext _context;

        public LoginRepositoriy(TmdbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Register(Usuario usuario, string password)
        {
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(password);
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        /*public async Task<Usuario> Login(string email, string password)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Email == email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(password, usuario.Password))
            {
                return null;
            }
            return usuario;
        }*/
        public async Task<Usuario> Login(string email, string password)
        {
            try
            {
                var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Email == email);
                if (usuario == null || !BCrypt.Net.BCrypt.Verify(password, usuario.Password))
                {
                    return null;
                }
                return usuario;
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente
                throw new InvalidOperationException("Ocurrió un error al intentar iniciar sesión.", ex);
            }
        }
    }
}
