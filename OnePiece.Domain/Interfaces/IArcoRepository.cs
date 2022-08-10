using OnePiece.Domain.Entities;
using OnePiece.Domain.Pagination;

namespace OnePiece.Domain.Interfaces
{
    public interface IArcoRepository
    {
        Task<PagedList<Arco>> GetAkumasAsync(ArcoParameters arcoParameters);
        Task<Arco> GetByIdAsync(int id);
        Task<Arco> CreateAsync(Arco arco);
        Task<Arco> UpdateAsync(Arco arco);
        Task<Arco> RemoveAsync(Arco arco);
    }
}
