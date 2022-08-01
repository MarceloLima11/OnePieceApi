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
    public class PersonagemRepository : IPersonagemRepository
    {
        private ApplicationDbContext _personagemContext;

        public PersonagemRepository(ApplicationDbContext personagemRepository)
        {
            _personagemContext = personagemRepository;
        }

        public async Task<IEnumerable<Personagem>> GetPersonagensAsync()
        {
            return await _personagemContext.Personagens.ToListAsync();
        }

        public async Task<Personagem> GetByIdAsync(int id)
        {
            return await _personagemContext.Personagens.Include(x => x.AkumaNoMi)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
