using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Business.Bus;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.Bus;
using Vanguard;

namespace SmartCity.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;
        private readonly IMapper _mapper;

        public BusController(IBusService busService, IMapper mapper)
        {
            Guard.ArgumentNotNull(busService, nameof(busService));
            Guard.ArgumentNotNull(mapper, nameof(mapper));

            _busService = busService;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}", Name = "GetBusById")]
        [ProducesResponseType(typeof(BusModel), 200)]
        public async Task<IActionResult> GetBusById([FromRoute] Guid id)
        {
            var bus = await _busService.GetByIdAsync(id).ConfigureAwait(false);

            if (bus == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<BusModel>(bus));
        }



        [HttpPost]
        public async Task<IActionResult> AddBus([FromBody] CreateBusModel createBusModel)
        {
            var busEntity = _mapper.Map<BusEntity>(createBusModel);

            await _busService.AddAsync(busEntity).ConfigureAwait(false);

            var testCreate = await _busService.GetByIdAsync(busEntity.Id).ConfigureAwait(false);

            return CreatedAtRoute("GetBusById", new { id = testCreate.Id }, _mapper.Map<BusEntity>(testCreate));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBus([FromRoute] Guid id, [FromBody] UpdateBusModel updateBusModel)
        {
            var bus = await _busService.GetByIdAsync(id).ConfigureAwait(false);
            if (bus == null)
            {
                return NotFound();
            }

            var entity = _mapper.Map<BusEntity>(updateBusModel);
            entity.Id = id;
            await _busService.UpdateAsync(entity).ConfigureAwait(false);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBus([FromRoute] Guid id)
        {
            await _busService.DeleteAsync(id).ConfigureAwait(false);
            return NoContent();
        }
    }
}