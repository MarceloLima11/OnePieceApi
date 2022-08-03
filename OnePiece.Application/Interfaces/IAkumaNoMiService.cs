using OnePiece.Application.DTOs;
using OnePiece.Domain.Entities;
using OnePiece.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Application.Interfaces
{
    public interface IAkumaNoMiService
    {
        Task<PagedList<AkumaNoMi>> GetAkumas(AkumaParameters akumaParameters);
        Task<AkumaNoMiDTO> GetById(int id);
        Task Add (AkumaNoMiDTO akumasDto);
        Task Update (AkumaNoMiDTO akumasDto);
        Task Remove (int id);
    }
}
