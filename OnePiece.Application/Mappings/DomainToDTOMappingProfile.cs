using AutoMapper;
using OnePiece.Application.DTOs;
using OnePiece.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Personagem, PersonagemDTO>().ReverseMap();
            CreateMap<AkumaNoMi, AkumaNoMiDTO>().ReverseMap();
        }
    }
}
