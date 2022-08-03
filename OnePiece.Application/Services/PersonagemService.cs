using AutoMapper;
using OnePiece.Application.DTOs;
using OnePiece.Application.Interfaces;
using OnePiece.Domain.Entities;
using OnePiece.Domain.Interfaces;
using OnePiece.Domain.Pagination;
using OnePiece.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Application.Services
{
    public class PersonagemService : IPersonagemService
    {
        private IPersonagemRepository _personagemRepository;
        private readonly IMapper _mapper;
        private ApplicationDbContext _personagemContext;

        public PersonagemService(IPersonagemRepository personagemRepository, IMapper mapper, ApplicationDbContext personagemContext)
        {
            _personagemRepository = personagemRepository ??
                throw new ArgumentNullException(nameof(personagemRepository));
            _mapper = mapper;
            _personagemContext = personagemContext;
        }

        public async Task<PagedList<Personagem>> GetPersonagens(PersonagemParameters personagemParameters)
        {
            return await PagedList<Personagem>.ToPagedList(_personagemContext.Personagens, personagemParameters.PageNumber, personagemParameters.PageSize);
        }

        public async Task<PersonagemDTO> GetById(int id)
        {
            var personagemEntity = await _personagemRepository.GetByIdAsync(id);
            return _mapper.Map<PersonagemDTO>(personagemEntity);
        }

        public async Task Add(PersonagemDTO personagemDto)
        {
            var personagemEntity = _mapper.Map<Personagem>(personagemDto);
            await _personagemRepository.CreateAsync(personagemEntity);
        }

        public async Task Update(PersonagemDTO personagemDto)
        {
            var personagemEntity = _mapper.Map<Personagem>(personagemDto);
            await _personagemRepository.UpdateAsync(personagemEntity);
        }

        public async Task Remove(int id)
        {
            var personagemEntity = _personagemRepository.GetByIdAsync(id).Result;
            await _personagemRepository.RemoveAsync(personagemEntity);
        }
    }
}
