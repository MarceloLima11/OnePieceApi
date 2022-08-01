using AutoMapper;
using OnePiece.Application.DTOs;
using OnePiece.Application.Interfaces;
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
            _personagemRepository = personagemRepository;
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
    }
}
