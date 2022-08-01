﻿using OnePiece.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiece.Application.Interfaces
{
    public interface IPersonagemService
    {
        Task<IEnumerable<PersonagemDTO>> GetPersonagens();
        Task<PersonagemDTO> GetById(int id);
    }
}