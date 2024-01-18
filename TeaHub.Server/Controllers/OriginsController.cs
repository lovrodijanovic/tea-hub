using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeaHub.Server.Models.Domain;
using TeaHub.Server.Models.DTO;
using TeaHub.Server.Repositories;

namespace TeaHub.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OriginsController : ControllerBase
    {
        private readonly IOriginRepository originRepository;
        private readonly IMapper mapper;

        public OriginsController(IOriginRepository originRepository, IMapper mapper)
        {
            this.originRepository = originRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var originsDomain = await originRepository.GetAllAsync();
            return Ok(mapper.Map<List<OriginDTO>>(originsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var originsDomain = await originRepository.GetByIdAsync(id);

            if (originsDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<OriginDTO>(originsDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddOriginRequestDTO addOriginRequestDTO)
        {
            var originDomainModel = mapper.Map<Origin>(addOriginRequestDTO);
            originDomainModel = await originRepository.CreateAsync(originDomainModel);
            var originDTO = mapper.Map<OriginDTO>(originDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = originDTO.Id }, originDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateOriginRequestDTO updateOriginRequestDTO, [FromRoute] Guid id)
        {
            var originDomainModel = mapper.Map<Origin>(updateOriginRequestDTO);
            originDomainModel = await originRepository.UpdateAsync(id, originDomainModel);

            if (originDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<OriginDTO>(originDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var originDomainModel = await originRepository.DeleteAsync(id);

            if (originDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<OriginDTO>(originDomainModel));
        }

    }
}
