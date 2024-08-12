using BackendProyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public interface IComentarioRepository
    {
        Task<IEnumerable<Comentario>> GetComentariosAsync();
        Task<Comentario> GetComentarioByIdAsync(int id);
        Task AddComentarioAsync(Comentario comentario);
        Task UpdateComentarioAsync(Comentario comentario);
        Task DeleteComentarioAsync(int id);
    }

}
