using OnePiece.Domain.Entities;
using OnePiece.Domain.Interfaces;
using OnePiece.Domain.Pagination;
using OnePiece.Infrastructure.Context;

namespace OnePiece.Infrastructure.Repositories
{
    public class AkumaNoMiRepository : IAkumaNoMiRepository
    {
        private ApplicationDbContext _akumaContext;

        public AkumaNoMiRepository(ApplicationDbContext akumaContext)
        {
            _akumaContext = akumaContext;
        }

        public async Task<PagedList<AkumaNoMi>> GetAkumasAsync(AkumaParameters akumaParameters)
        {
            return await PagedList<AkumaNoMi>.ToPagedList(_akumaContext.AkumaNoMis,
                akumaParameters.PageNumber, akumaParameters.PageSize);
        }

        public async Task<AkumaNoMi> GetByIdAsync(int id)
        {
            return await _akumaContext.AkumaNoMis.FindAsync(id);
        }
        public async Task<AkumaNoMi> CreateAsync(AkumaNoMi akuma)
        {
            _akumaContext.Add(akuma);
            await _akumaContext.SaveChangesAsync();
            return akuma;
        }

        public async Task<AkumaNoMi> RemoveAsync(AkumaNoMi akuma)
        {
            _akumaContext.Remove(akuma);
            await _akumaContext.SaveChangesAsync();
            return akuma;
        }

        public async Task<AkumaNoMi> UpdateAsync(AkumaNoMi akuma)
        {
            _akumaContext.Update(akuma);
            await _akumaContext.SaveChangesAsync();
            return akuma;
        }
    }
}
