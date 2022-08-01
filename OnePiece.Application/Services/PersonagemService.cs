﻿using AutoMapper;
using OnePiece.Application.DTOs;
using OnePiece.Application.Interfaces;
using OnePiece.Domain.Entities;
using OnePiece.Domain.Interfaces;
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

        public PersonagemService(IPersonagemRepository personagemRepository, IMapper mapper)
        {
            _personagemRepository = personagemRepository ??
                throw new ArgumentNullException(nameof(personagemRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonagemDTO>> GetPersonagens()
        {
            var personagensEntity = await _personagemRepository.GetPersonagensAsync();
            return _mapper.Map<IEnumerable<PersonagemDTO>>(personagensEntity);
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
