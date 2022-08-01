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
    }
}
