using OnePiece.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Domain.Interfaces
{
    public interface IPersonagemRepository
    {
        Task<IEnumerable<Personagem>> GetPersonagensAsync();
        Task<Personagem> GetByIdAsync(int id);
    }
}
