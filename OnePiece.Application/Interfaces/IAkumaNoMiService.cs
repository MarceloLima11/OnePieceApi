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
        Task<IEnumerable<AkumaNoMiDTO>> GetPersonagens();
        Task<AkumaNoMiDTO> GetById(int id);
    }
}
