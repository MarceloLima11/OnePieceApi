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
    public interface IPersonagemService
    {
        Task<PagedList<Personagem>> GetPersonagens(PersonagemParameters personagemParameters);
        Task<PersonagemDTO> GetById(int id);
        Task Add(PersonagemDTO personagemDto);
        Task Update(PersonagemDTO personagemDto);
        Task Remove(int id);
    }
}
