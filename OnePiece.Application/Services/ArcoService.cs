using AutoMapper;
using OnePiece.Application.DTOs;
using OnePiece.Application.Interfaces;
using OnePiece.Domain.Entities;
using OnePiece.Domain.Interfaces;
using OnePiece.Domain.Pagination;
using OnePiece.Infrastructure.Context;

namespace OnePiece.Application.Services
{
    public class ArcoService : IArcoService
    {
        private readonly IArcoRepository _arcoRepository;
        private readonly IMapper _mapper;
        private ApplicationDbContext _arcoContext;

        public ArcoService(IArcoRepository arcoRepository, IMapper mapper, ApplicationDbContext arcoContext)
        {
            _arcoRepository = arcoRepository ??
                throw new ArgumentNullException(nameof(arcoRepository)); ;
            _mapper = mapper;
            _arcoContext = arcoContext;
        }

        public async Task<PagedList<Arco>> GetArcos(ArcoParameters arcoParameters)
        {
            return await PagedList<Arco>.ToPagedList(_arcoContext.Arcos,
                arcoParameters.PageNumber, arcoParameters.PageSize);
        }

        public async Task<ArcoDTO> GetById(int id)
        {
            var arcoEntity = await _arcoRepository.GetByIdAsync(id);
            return _mapper.Map<ArcoDTO>(arcoEntity);
        }

        public async Task Add(ArcoDTO arcoDto)
        {
            var arcoEntity = _mapper.Map<Arco>(arcoDto);
            await _arcoRepository.CreateAsync(arcoEntity);
        }

        public async Task Remove(int id)
        {
            var arcoEntity = _arcoRepository.GetByIdAsync(id).Result;
            await _arcoRepository.RemoveAsync(arcoEntity);
        }

        public async Task Update(ArcoDTO arcoDto)
        {
            var arcoEntity = _mapper.Map<Arco>(arcoDto);
            await _arcoRepository.UpdateAsync(arcoEntity);
        }
    }
}
