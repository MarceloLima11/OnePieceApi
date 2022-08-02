using OnePiece.Domain.Entities;
using OnePiece.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Domain.Interfaces
{
    public interface IPersonagemRepository
    {
        Task<PagedList<Personagem>> GetPersonagensAsync(PersonagemParameters produtosParameters);
        Task<Personagem> GetByIdAsync(int id);
        Task<Personagem> CreateAsync(Personagem personagem);
        Task<Personagem> UpdateAsync(Personagem personagem);
        Task<Personagem> RemoveAsync(Personagem personagem);
    }
}
