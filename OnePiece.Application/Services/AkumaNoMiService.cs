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
    public class AkumaNoMiService : IAkumaNoMiService
    {
        private readonly IAkumaNoMiRepository _akumaRepository;
        private readonly IMapper _mapper;

        public AkumaNoMiService(IAkumaNoMiRepository akumaRepository, IMapper mapper)
        {
            _akumaRepository = akumaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AkumaNoMiDTO>> GetPersonagens()
        {
            var akumasEntity = await _akumaRepository.GetAkumasAsync();
            return _mapper.Map<IEnumerable<AkumaNoMiDTO>>(akumasEntity);   
        }

        public async Task<AkumaNoMiDTO> GetById(int id)
        {
            var akumaEntity = await _akumaRepository.GetByIdAsync(id);
            return _mapper.Map<AkumaNoMiDTO>(akumaEntity);
        }
    }
}
