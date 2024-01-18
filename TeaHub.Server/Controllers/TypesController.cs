using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeaHub.Server.Models.DTO;
using TeaHub.Server.Repositories;

namespace TeaHub.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypeRepository typeRepository;
        private readonly IMapper mapper;

        public TypesController(ITypeRepository typeRepository, IMapper mapper)
        {
            this.typeRepository = typeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var typesDomain = await typeRepository.GetAllAsync();
            return Ok(mapper.Map<List<TypeDTO>>(typesDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var typesDomain = await typeRepository.GetByIdAsync(id);

            if (typesDomain == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TypeDTO>(typesDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTypeRequestDTO addTypeRequestDTO)
        {
            var typeDomainModel = mapper.Map<Models.Domain.Type>(addTypeRequestDTO);
            typeDomainModel = await typeRepository.CreateAsync(typeDomainModel);
            var typeDTO = mapper.Map<TypeDTO>(typeDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = typeDTO.Id }, typeDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateTypeRequestDTO updateTypeRequestDTO)
        {
            var typeDomainModel = mapper.Map<Models.Domain.Type>(updateTypeRequestDTO);
            typeDomainModel = await typeRepository.UpdateAsync(id, typeDomainModel);

            if(typeDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TypeDTO>(typeDomainModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var typeDomainModel = await typeRepository.DeleteAsync(id);

            if(typeDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<TypeDTO>(typeDomainModel));
        }
    }
}
