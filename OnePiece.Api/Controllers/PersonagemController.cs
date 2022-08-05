using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnePiece.Application.DTOs;
using OnePiece.Application.Interfaces;
using OnePiece.Domain.Pagination;

namespace OnePiece.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class PersonagemController : Controller
    {
        private readonly IPersonagemService _personagemService;
        private readonly IMapper _mapper;

        public PersonagemController(IPersonagemService personagemService, IMapper mapper)
        {
            _personagemService = personagemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonagemDTO>>> Get([FromQuery] PersonagemParameters personagemParameters)
        {
            var personagens = await _personagemService.GetPersonagens(personagemParameters);

            var metadata = new
            {
                personagens.TotalCount,
                personagens.PageSize,
                personagens.CurrentPage,
                personagens.TotalPages,
                personagens.HasNext,
                personagens.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            var personagensDto = _mapper.Map<PagedList<PersonagemDTO>>(personagens);
            return personagensDto;
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
        public async Task<ActionResult> Post([FromBody] PersonagemDTO personagemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _personagemService.Add(personagemDto);

            return new CreatedAtRouteResult("GetPersonagem",
                new { id = personagemDto.Id}, personagemDto);
        }
    }
}
