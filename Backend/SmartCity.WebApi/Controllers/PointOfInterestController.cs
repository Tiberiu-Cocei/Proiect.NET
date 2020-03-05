using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Business.PointOfInterest;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.PointOfInterest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        private readonly IPointOfInterestService _pointOfInterestService;
        private readonly IMapper _mapper;

        public PointOfInterestController(IPointOfInterestService pointOfInterestService, IMapper mapper)
        {
            Guard.ArgumentNotNull(pointOfInterestService, nameof(pointOfInterestService));
            Guard.ArgumentNotNull(mapper, nameof(mapper));

            _pointOfInterestService = pointOfInterestService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllPointOfInterest")]
        [ProducesResponseType(typeof(PointOfInterestModel), 200)]
        public async Task<IActionResult> GetAll()
        {
            var pointOfInterests = await _pointOfInterestService.GetAsync().ConfigureAwait(false);

            return Ok(_mapper.Map<ICollection<PointOfInterestModel>>(pointOfInterests));
        }

        [HttpGet("{cityName}", Name = "GetPointOfInterestByCityName")]
        [ProducesResponseType(typeof(PointOfInterestModel), 200)]
        public async Task<IActionResult> GetPointOfInterestByCityName([FromRoute] string cityName)
        {
            var pointOfInterests = await _pointOfInterestService.GetByCityName(cityName).ConfigureAwait(false);

            return Ok(_mapper.Map<ICollection<PointOfInterestModel>>(pointOfInterests));
        }

        [HttpGet("{personId:guid}", Name = "GetPointOfInterestByPersonId")]
        [ProducesResponseType(typeof(PointOfInterestModel), 200)]
        public async Task<IActionResult> GetPointOfInterestByPersonId([FromRoute] Guid personId)
        {
            var pointOfInterests = await _pointOfInterestService.GetByPersonIdAsync(personId).ConfigureAwait(false);

            return Ok(_mapper.Map<ICollection<PointOfInterestModel>>(pointOfInterests));
        }

        [HttpGet("{pointOfInterestId:guid}/{difference:int}", Name = "GetPointOfInterestById")]
        [ProducesResponseType(typeof(PointOfInterestModel), 200)]
        public async Task<IActionResult> GetPointOfInterestById([FromRoute] Guid pointOfInterestId, [FromRoute] int difference)
        {
            var pointOfInterests = await _pointOfInterestService.GetByPersonIdAsync(pointOfInterestId).ConfigureAwait(false);

            return Ok(_mapper.Map<ICollection<PointOfInterestModel>>(pointOfInterests));
        }

        [HttpPost]
        public async Task<IActionResult> AddPointOfInterest([FromBody] CreatePointOfInterestModel createPointOfInterestModel)
        {
            var pointOfInterestEntity = _mapper.Map<PointOfInterestEntity> (createPointOfInterestModel);
            
            await _pointOfInterestService.AddAsync(pointOfInterestEntity).ConfigureAwait(false);
            
            var testCreate = await _pointOfInterestService.GetByIdAsync(pointOfInterestEntity.Id).ConfigureAwait(false);

            return CreatedAtRoute("GetPointOfInterestById", new { pointOfInterestId = testCreate.Id, difference = 1 }, _mapper.Map<PointOfInterestEntity>(testCreate));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePointOfInterest([FromRoute] Guid id, [FromBody] UpdatePointOfInterestModel updatePointOfInterestModel)
        {
            var pointOfInterest = await _pointOfInterestService.GetByIdAsync(id).ConfigureAwait(false);
            if(pointOfInterest == null)
            {
                return NotFound();
            }

            var entity = _mapper.Map<PointOfInterestEntity>(updatePointOfInterestModel);
            entity.Id = id;
            await _pointOfInterestService.UpdateAsync(entity).ConfigureAwait(false);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePointOfInterest([FromRoute] Guid id)
        {
            await _pointOfInterestService.DeleteAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}