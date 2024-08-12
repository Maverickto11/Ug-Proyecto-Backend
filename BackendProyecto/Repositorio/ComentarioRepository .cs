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
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly TmdbContext _context;

        public ComentarioRepository(TmdbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comentario>> GetComentariosAsync()
        {
            return await _context.Comentarios
                .Include(c => c.Usuario)
                .Include(c => c.Movie)
                .Include(c => c.Series)
                .ToListAsync();
        }

        public async Task<Comentario> GetComentarioByIdAsync(int id)
        {
            return await _context.Comentarios
                .Include(c => c.Usuario)
                .Include(c => c.Movie)
                .Include(c => c.Series)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddComentarioAsync(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateComentarioAsync(Comentario comentario)
        {
            _context.Comentarios.Update(comentario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComentarioAsync(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
                await _context.SaveChangesAsync();
            }
        }
    }

}
