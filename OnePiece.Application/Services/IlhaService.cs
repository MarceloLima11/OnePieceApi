using AutoMapper;
using OnePiece.Application.DTOs;
using OnePiece.Application.Interfaces;
using OnePiece.Domain.Entities;
using OnePiece.Domain.Interfaces;
using OnePiece.Domain.Pagination;
using OnePiece.Infrastructure.Context;

namespace OnePiece.Application.Services
{
    public class IlhaService : IIlhaService
    {
        private readonly IIlhaRepository _ilhaRepository;
        private readonly IMapper _mapper;
        private ApplicationDbContext _ilhaContext;

        public IlhaService(IIlhaRepository ilhaRepository, IMapper mapper, ApplicationDbContext ilhaContext)
        {
            _ilhaRepository = ilhaRepository ??
                throw new ArgumentNullException(nameof(ilhaRepository)); ;
            _mapper = mapper;
            _ilhaContext = ilhaContext;
        }

        public async Task<PagedList<Ilha>> GetIlhas(IlhaParameters ilhaParameters)
        {
            return await PagedList<Ilha>.ToPagedList(_ilhaContext.Ilhas,
                ilhaParameters.PageNumber, ilhaParameters.PageSize);
        }

        public async Task<IlhaDTO> GetById(int id)
        {
            var ilhaEntity = await _ilhaRepository.GetByIdAsync(id);
            return _mapper.Map<IlhaDTO>(ilhaEntity);
        }

        public async Task Add(IlhaDTO ilhaDto)
        {
            var ilhaEntity = _mapper.Map<Ilha>(ilhaDto);
            await _ilhaRepository.CreateAsync(ilhaEntity);
        }

        public async Task Remove(int id)
        {
            var ilhaEntity = _ilhaRepository.GetByIdAsync(id).Result;
            await _ilhaRepository.RemoveAsync(ilhaEntity);
        }

        public async Task Update(IlhaDTO ilhaDto)
        {
            var ilhaEntity = _mapper.Map<Ilha>(ilhaDto);
            await _ilhaRepository.UpdateAsync(ilhaEntity);
        }
    }
}
