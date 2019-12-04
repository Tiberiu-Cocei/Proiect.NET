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
        private readonly IPointOfInterestService _poitOfInterestService;
        private readonly IMapper _mapper;

        public PointOfInterestController(IPointOfInterestService pointOfInterestService, IMapper mapper)
        {
            Guard.ArgumentNotNull(pointOfInterestService, nameof(pointOfInterestService));
            Guard.ArgumentNotNull(mapper, nameof(mapper));

            _poitOfInterestService = pointOfInterestService;
            _mapper = mapper;
        }
        [HttpGet("{id:guid}", Name = "GetPointOfInterestById")]
        [ProducesResponseType(typeof(PointOfInterestModel), 200)]
        public async Task<IActionResult> GetPointOfInterestById([FromRoute] Guid id)
        {
            var pointOfIntereset = await _poitOfInterestService.GetByIdAsync(id).ConfigureAwait(false);

            if (pointOfIntereset == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestModel>(pointOfIntereset));
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
            
            await _poitOfInterestService.AddAsync(pointOfInterestEntity).ConfigureAwait(false);
            
            var testCreate = await _poitOfInterestService.GetByIdAsync(pointOfInterestEntity.Id).ConfigureAwait(false);

            return CreatedAtRoute("GetPointOfInterestById", new { id = testCreate.Id }, _mapper.Map<PointOfInterestEntity>(testCreate));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePointOfInterest([FromRoute] Guid id, [FromBody] UpdatePointOfInterestModel updatePointOfInterestModel)
        {
            var pointOfInterest = await _poitOfInterestService.GetByIdAsync(id).ConfigureAwait(false);
            if(pointOfInterest == null)
            {
                return NotFound();
            }

            var entity = _mapper.Map<PointOfInterestEntity>(updatePointOfInterestModel);
            entity.Id = id;
            await _poitOfInterestService.UpdateAsync(entity).ConfigureAwait(false);

            return NoContent();
        }
    }
}