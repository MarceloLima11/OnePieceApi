using OnePiece.Application.DTOs;
using OnePiece.Domain.Entities;
using OnePiece.Domain.Pagination;

namespace OnePiece.Application.Interfaces
{
    public interface IIlhaService 
    {
        Task<PagedList<Ilha>> GetIlhas(IlhaParameters ilhaParameters);
        Task<IlhaDTO> GetById(int id);
        Task Add(IlhaDTO ilhaDto);
        Task Update(IlhaDTO ilhaDto);
        Task Remove(int id);
    }
}
