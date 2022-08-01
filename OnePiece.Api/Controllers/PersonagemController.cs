using Microsoft.AspNetCore.Mvc;
using OnePiece.Application.DTOs;
using OnePiece.Application.Interfaces;

namespace OnePiece.Api.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class PersonagemController : Controller
    {
        private readonly IPersonagemService _personagemService;

        public PersonagemController(IPersonagemService personagemService)
        {
            _personagemService = personagemService;    
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonagemDTO>>> Get()
        {
            var personagens = await _personagemService.GetPersonagens();
            return Ok(personagens);
        }

        [HttpGet("{id}", Name = "GetPersonagem")]
        public async Task<ActionResult<PersonagemDTO>> Get(int id)
        {
            var personagem = await _personagemService.GetById(id);

            if(personagem == null)
            {
                return NotFound();
            }
            return Ok(personagem);
        }
    }
}
