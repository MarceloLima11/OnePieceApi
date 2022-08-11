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
    public class IlhaController : ControllerBase
    {
        private readonly IIlhaService _ilhaService;
        private readonly IMapper _mapper;

        public IlhaController(IIlhaService ilhaService, IMapper mapper)
        {
            _ilhaService = ilhaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IlhaDTO>>> Get([FromQuery] IlhaParameters ilhaParameters)
        {
            var ilhas = await _ilhaService.GetIlhas(ilhaParameters);

            var metadata = new
            {
                ilhas.TotalCount,
                ilhas.PageSize,
                ilhas.CurrentPage,
                ilhas.TotalPages,
                ilhas.HasNext,
                ilhas.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            var ilhasDto = _mapper.Map<PagedList<IlhaDTO>>(ilhas);

            return Ok(ilhasDto);
        }

        [HttpGet("{id}", Name = "GetIlha")]
        public async Task<ActionResult<ArcoDTO>> Get(int id)
        {
            var ilhas = await _ilhaService.GetById(id);

            if (ilhas == null)
            {
                return NotFound();
            }

            return Ok(ilhas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] IlhaDTO ilhasDto)
        {
            if (id != ilhasDto.Id)
            {
                return BadRequest();
            }

            await _ilhaService.Update(ilhasDto);

            return Ok(ilhasDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IlhaDTO>> Delete(int id)
        {
            var ilhaDto = await _ilhaService.GetById(id);

            if (ilhaDto == null)
            {
                NotFound();
            }

            await _ilhaService.Remove(id);

            return Ok(ilhaDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] IlhaDTO ilhaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ilhaService.Add(ilhaDto);

            return new CreatedAtRouteResult("GetArco",
                new { id = ilhaDto.Id }, ilhaDto);
        }
    }
}
