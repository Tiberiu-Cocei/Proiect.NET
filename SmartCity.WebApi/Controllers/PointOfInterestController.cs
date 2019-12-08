using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Business.PointOfInterest;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.PointOfInterest;
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
        [HttpGet("{id:guid}", Name = "GetPointOfInterestById")]
        [ProducesResponseType(typeof(PointOfInterestModel), 200)]
        public async Task<IActionResult> GetPointOfInterestById([FromRoute] Guid id)
        {
            var pointOfInterest = await _pointOfInterestService.GetByIdAsync(id).ConfigureAwait(false);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestModel>(pointOfInterest));
        }

        /*[HttpGet("{city:City}", Name = "GetPointOfInterestByCity")]
        [ProducesResponseType(typeof(PointOfInterestModel), 200)]
        public async Task<IActionResult> GetPointOfInterestByCity([FromBody] CityEntity city)
        {
            var poitOfInterest =
        }*/

        [HttpPost]
        public async Task<IActionResult> AddPointOfInterest([FromBody] CreatePointOfInterestModel createPointOfInterestModel)
        {
            var pointOfInterestEntity = _mapper.Map<PointOfInterestEntity> (createPointOfInterestModel);
            
            await _pointOfInterestService.AddAsync(pointOfInterestEntity).ConfigureAwait(false);
            
            var testCreate = await _pointOfInterestService.GetByIdAsync(pointOfInterestEntity.Id).ConfigureAwait(false);

            return CreatedAtRoute("GetPointOfInterestById", new { id = testCreate.Id }, _mapper.Map<PointOfInterestEntity>(testCreate));
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