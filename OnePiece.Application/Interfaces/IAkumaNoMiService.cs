using OnePiece.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Application.Interfaces
{
    public interface IAkumaNoMiService
    {
        Task<IEnumerable<AkumaNoMiDTO>> GetAkumas();
        Task<AkumaNoMiDTO> GetById(int id);
        Task Add (AkumaNoMiDTO akumasDto);
        Task Update (AkumaNoMiDTO akumasDto);
        Task Remove (int id);
    }
}
