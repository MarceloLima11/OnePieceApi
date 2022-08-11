using OnePiece.Domain.Entities;
using OnePiece.Domain.Interfaces;
using OnePiece.Domain.Pagination;
using OnePiece.Infrastructure.Context;

namespace OnePiece.Infrastructure.Repositories
{
    public class IlhaRepository : IIlhaRepository
    {
        private ApplicationDbContext _ilhaContext;

        public IlhaRepository(ApplicationDbContext ilhaContext)
        {
            _ilhaContext = ilhaContext;
        }

        public async Task<PagedList<Ilha>> GetIlhasAsync(IlhaParameters ilhaParameters)
        {
            return await PagedList<Ilha>.ToPagedList(_ilhaContext.Ilhas,
                ilhaParameters.PageNumber, ilhaParameters.PageSize);
        }

        public async Task<Ilha> GetByIdAsync(int id)
        {
            return await _ilhaContext.Ilhas.FindAsync(id);
        }
        public async Task<Ilha> CreateAsync(Ilha ilha)
        {
            _ilhaContext.Add(ilha);
            await _ilhaContext.SaveChangesAsync();
            return ilha;
        }

        public async Task<Ilha> RemoveAsync(Ilha ilha)
        {
            _ilhaContext.Remove(ilha);
            await _ilhaContext.SaveChangesAsync();
            return ilha;
        }

        public async Task<Ilha> UpdateAsync(Ilha ilha)
        {
            _ilhaContext.Update(ilha);
            await _ilhaContext.SaveChangesAsync();
            return ilha;
        }
    }
}
