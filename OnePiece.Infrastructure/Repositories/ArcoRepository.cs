using OnePiece.Domain.Entities;
using OnePiece.Domain.Interfaces;
using OnePiece.Domain.Pagination;
using OnePiece.Infrastructure.Context;

namespace OnePiece.Infrastructure.Repositories
{
    public class ArcoRepository : IArcoRepository
    {
        private ApplicationDbContext _arcoContext;

        public ArcoRepository(ApplicationDbContext arcoContext)
        {
            _arcoContext = arcoContext;
        }

        public async Task<PagedList<Arco>> GetArcosAsync(ArcoParameters arcoParameters)
        {
            return await PagedList<Arco>.ToPagedList(_arcoContext.Arcos,
                arcoParameters.PageNumber, arcoParameters.PageSize);
        }

        public async Task<Arco> GetByIdAsync(int id)
        {
            return await _arcoContext.Arcos.FindAsync(id);
        }
        public async Task<Arco> CreateAsync(Arco arco)
        {
            _arcoContext.Add(arco);
            await _arcoContext.SaveChangesAsync();
            return arco;
        }

        public async Task<Arco> RemoveAsync(Arco arco)
        {
            _arcoContext.Remove(arco);
            await _arcoContext.SaveChangesAsync();
            return arco;
        }

        public async Task<Arco> UpdateAsync(Arco arco)
        {
            _arcoContext.Update(arco);
            await _arcoContext.SaveChangesAsync();
            return arco;
        }
    }
}
