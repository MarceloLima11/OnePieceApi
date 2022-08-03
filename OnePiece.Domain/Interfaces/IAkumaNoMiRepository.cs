using OnePiece.Domain.Entities;
using OnePiece.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Domain.Interfaces
{
    public interface IAkumaNoMiRepository 
    {
        Task<PagedList<AkumaNoMi>> GetAkumasAsync(AkumaParameters akumaParameters);
        Task<AkumaNoMi> GetByIdAsync(int id);
        Task<AkumaNoMi> CreateAsync(AkumaNoMi akuma);
        Task<AkumaNoMi> UpdateAsync(AkumaNoMi akuma);
        Task<AkumaNoMi> RemoveAsync(AkumaNoMi akuma);
    }
}
