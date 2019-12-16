using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Business.City;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.City;
using System;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CitiesController(ICityService cityService, IMapper mapper)
        {
            Guard.ArgumentNotNull(cityService, nameof(cityService));
            Guard.ArgumentNotNull(mapper, nameof(mapper));

            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}", Name = "GetCityById")]
        [ProducesResponseType(typeof(CityModel), 200)]
        public async Task<IActionResult> GetCityById([FromRoute] Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return Unauthorized();
            }
            var city = await _cityService.GetByIdAsync(id).ConfigureAwait(false);
            if(city == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CityModel>(city));
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] CreateCityModel city)
        {
            var cityEntity = _mapper.Map<CityEntity>(city);
            var res = await _cityService.GetByNameAsync(city.Name).ConfigureAwait(false);
            if (res != null)
            {
                return BadRequest();
            }

            await _cityService.AddAsync(cityEntity).ConfigureAwait(false);
            var test = await _cityService.GetByIdAsync(cityEntity.Id).ConfigureAwait(false);

            return CreatedAtRoute("GetCityById", new { id = test.Id }, _mapper.Map<CityEntity>(test));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCity([FromRoute] Guid id, [FromBody] UpdateCityModel updateCityModel)
        {
            var city = await _cityService.GetByIdAsync(id).ConfigureAwait(false);
            if(city == null)
            {
                return NotFound();
            }
            var entity = _mapper.Map<CityEntity>(updateCityModel);
            entity.Id = id;
            await _cityService.UpdateAsync(entity).ConfigureAwait(false);
            return NoContent();
        }
    }
}