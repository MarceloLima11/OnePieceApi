using OnePiece.Application.DTOs;
using OnePiece.Domain.Entities;
using OnePiece.Domain.Pagination;

namespace OnePiece.Application.Interfaces
{
    public interface IArcoService
    {
        Task<PagedList<Arco>> GetArcos(ArcoParameters arcoParameters);
        Task<ArcoDTO> GetById(int id);
        Task Add(ArcoDTO arcoDto);
        Task Update(ArcoDTO arcoDto);
        Task Remove(int id);
    }
}
