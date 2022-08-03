using Microsoft.EntityFrameworkCore;
using OnePiece.Domain.Entities;
using OnePiece.Domain.Interfaces;
using OnePiece.Domain.Pagination;
using OnePiece.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Infrastructure.Repositories
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private ApplicationDbContext _personagemContext;

        public PersonagemRepository(ApplicationDbContext context)
        {
            _personagemContext = context;
        }

        public async Task<PagedList<Personagem>> GetPersonagensAsync(PersonagemParameters personagemParameters)
        {
            //return await _personagemContext.Personagens
            //    .Skip((personagemParameters.PageNumber - 1) * personagemParameters.PageSize)
            //    .Take(personagemParameters.PageSize)
            //    .ToListAsync();

            return await PagedList<Personagem>.ToPagedList(_personagemContext.Personagens,
                personagemParameters.PageNumber, personagemParameters.PageSize);
        }

        public async Task<Personagem> GetByIdAsync(int id)
        {
            return await _personagemContext.Personagens.Include(x => x.AkumaNoMi)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Personagem> CreateAsync(Personagem personagem)
        {
            _personagemContext.Add(personagem);
            await _personagemContext.SaveChangesAsync();
            return personagem;
            
        }

        public async Task<Personagem> UpdateAsync(Personagem personagem)
        {
            _personagemContext.Update(personagem);
            await _personagemContext.SaveChangesAsync();
            return personagem;
        }

        public async Task<Personagem> RemoveAsync(Personagem personagem)
        {
            _personagemContext.Remove(personagem);
            await _personagemContext.SaveChangesAsync();
            return personagem;
        }
    }
}
