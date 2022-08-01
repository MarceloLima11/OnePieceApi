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

            if (personagem == null)
            {
                return NotFound();
            }
            return Ok(personagem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PersonagemDTO personagemDto)
        {
            if(id != personagemDto.Id)
            {
                return BadRequest();
            }

            await _personagemService.Update(personagemDto);

            return Ok(personagemDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonagemDTO>> Delete(int id)
        {
            var personagemDto = await _personagemService.GetById(id);

            if(personagemDto == null)
            {
                NotFound();
            }

            await _personagemService.Remove(id);

            return Ok(personagemDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonagemDTO personagemDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personagemService.Add(personagemDTO);

            return new CreatedAtRouteResult("GetPersonagem",
                new { id = personagemDTO.Id }, personagemDTO);
        }
    }
}
