using OnePiece.Domain.Entities;
using OnePiece.Domain.Pagination;

namespace OnePiece.Domain.Interfaces
{
    public interface IIlhaRepository 
    {
        Task<PagedList<Ilha>> GetIlhasAsync(IlhaParameters ilhaParameters);
        Task<Ilha> GetByIdAsync(int id);
        Task<Ilha> CreateAsync(Ilha ilha);
        Task<Ilha> UpdateAsync(Ilha ilha);
        Task<Ilha> RemoveAsync(Ilha ilha);
    }
}
