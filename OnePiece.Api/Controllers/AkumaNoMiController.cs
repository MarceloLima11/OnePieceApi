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
    public class AkumaNoMiController : ControllerBase
    {
        private readonly IAkumaNoMiService _akumaService;
        private readonly IMapper _mapper;

        public AkumaNoMiController(IAkumaNoMiService akumasService, IMapper mapper)
        {
            _akumaService = akumasService;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AkumaNoMiDTO>>> Get([FromQuery] AkumaParameters akumaParameters)
        {
            var akumas = await _akumaService.GetAkumas(akumaParameters);

            var metadata = new {
                akumas.TotalCount,
                akumas.PageSize,
                akumas.CurrentPage,
                akumas.TotalPages,
                akumas.HasNext,
                akumas.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            var akumasDto = _mapper.Map<PagedList<AkumaNoMiDTO>>(akumas);

            return Ok(akumasDto);
        }

        [HttpGet("{id}", Name = "GetAkumaNoMi")]
        public async Task<ActionResult<AkumaNoMiDTO>> Get(int id)
        {
            var akumaNoMi = await _akumaService.GetById(id);

            if (akumaNoMi == null)
            {
                return NotFound();
            }
            return Ok(akumaNoMi);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AkumaNoMiDTO akumaDto)
        {
            if (id != akumaDto.Id)
            {
                return BadRequest();
            }

            await _akumaService.Update(akumaDto);

            return Ok(akumaDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonagemDTO>> Delete(int id)
        {
            var akumaDto = await _akumaService.GetById(id);

            if (akumaDto == null)
            {
                NotFound();
            }

            await _akumaService.Remove(id);

            return Ok(akumaDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AkumaNoMiDTO akumaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _akumaService.Add(akumaDto);

            return new CreatedAtRouteResult("GetAkumaNoMi",
                new { id = akumaDto.Id }, akumaDto);
        }
    }
}
