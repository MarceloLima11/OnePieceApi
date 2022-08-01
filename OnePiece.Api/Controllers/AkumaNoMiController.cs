using Microsoft.AspNetCore.Mvc;
using OnePiece.Application.DTOs;
using OnePiece.Application.Interfaces;

namespace OnePiece.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class AkumaNoMiController : Controller
    {
        private readonly IAkumaNoMiService _akumaService;

        public AkumaNoMiController(IAkumaNoMiService akumasService)
        {
            _akumaService = akumasService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AkumaNoMiDTO>>> Get()
        {
            var akumas = await _akumaService.GetAkumas();
            return Ok(akumas);
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
