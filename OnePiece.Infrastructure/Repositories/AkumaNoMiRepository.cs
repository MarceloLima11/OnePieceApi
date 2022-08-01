using Microsoft.EntityFrameworkCore;
using OnePiece.Domain.Entities;
using OnePiece.Domain.Interfaces;
using OnePiece.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Infrastructure.Repositories
{
    public class AkumaNoMiRepository : IAkumaNoMiRepository
    {
        private ApplicationDbContext _akumaContext;

        public AkumaNoMiRepository(ApplicationDbContext akumaContext)
        {
            _akumaContext = akumaContext;
        }

        public async Task<IEnumerable<AkumaNoMi>> GetAkumasAsync()
        {
            return await _akumaContext.AkumaNoMis.ToListAsync();
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
