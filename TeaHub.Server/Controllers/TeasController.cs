using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeaHub.Server.Models.Domain;
using TeaHub.Server.Models.DTO;
using TeaHub.Server.Repositories;

namespace TeaHub.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeasController : ControllerBase
    {
        private readonly ITeaRepository teaRepository;
        private readonly IMapper mapper;

        public TeasController(ITeaRepository teaRepository, IMapper mapper)
        {
            this.teaRepository = teaRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teaDomainModel = await teaRepository.GetAllAsync();
            return Ok(mapper.Map<List<TeaDTO>>(teaDomainModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var teaDomainModel = await teaRepository.GetByIdAsync(id);

            if (teaDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TeaDTO>(teaDomainModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTeaRequestDTO addTeaRequestDTO)
        {
            var teaDomainModel = mapper.Map<Tea>(addTeaRequestDTO);
            await teaRepository.CreateAsync(teaDomainModel);
            var teaDTO = mapper.Map<TeaDTO>(teaDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = teaDTO.Id }, teaDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromBody] UpdateTeaRequestDTO updateTeaRequestDTO, [FromRoute] Guid id)
        {
            var teaDomainModel = mapper.Map<Tea>(updateTeaRequestDTO);
            teaDomainModel = await teaRepository.UpdateAsync(teaDomainModel, id);

            if(teaDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TeaDTO>(teaDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var teaDomainModel = await teaRepository.DeleteAsync(id);

            if(teaDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TeaDTO>(teaDomainModel));
        }
    }
}
