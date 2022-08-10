using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnePiece.Application.DTOs;
using OnePiece.Application.Interfaces;
using OnePiece.Domain.Pagination;

namespace OnePiece.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [EnableCors("ApiRequestIo")]
    [Route("api/{v:apiVersion}/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArcoController : ControllerBase
    {
        private readonly IArcoService _arcoService;
        private readonly IMapper _mapper;

        public ArcoController(IArcoService arcoService, IMapper mapper)
        {
            _arcoService = arcoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArcoDTO>>> Get([FromQuery] ArcoParameters arcoParameters)
        {
            var arcos = await _arcoService.GetArcos(arcoParameters);

            var metadata = new
            {
                arcos.TotalCount,
                arcos.PageSize,
                arcos.CurrentPage,
                arcos.TotalPages,
                arcos.HasNext,
                arcos.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            var arcosDto = _mapper.Map<PagedList<ArcoDTO>>(arcos);

            return Ok(arcosDto);
        }

        [HttpGet("{id}", Name = "GetArco")]
        public async Task<ActionResult<ArcoDTO>> Get(int id)
        {
            var arco = await _arcoService.GetById(id);

            if (arco == null)
            {
                return NotFound();
            }
            return Ok(arco);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ArcoDTO arcoDto)
        {
            if (id != arcoDto.Id)
            {
                return BadRequest();
            }

            await _arcoService.Update(arcoDto);

            return Ok(arcoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ArcoDTO>> Delete(int id)
        {
            var akumaDto = await _arcoService.GetById(id);

            if (akumaDto == null)
            {
                NotFound();
            }

            await _arcoService.Remove(id);

            return Ok(akumaDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ArcoDTO arcoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _arcoService.Add(arcoDto);

            return new CreatedAtRouteResult("GetArco",
                new { id = arcoDto.Id }, arcoDto);
        }
    }
}
