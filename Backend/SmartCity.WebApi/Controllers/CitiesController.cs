using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Business.City;
using SmartCity.Domain.Entities;
using SmartCity.Domain.ExtensionMethods;
using SmartCity.WebApi.Models.BktModel;
using SmartCity.WebApi.Models.City;
using System;
using System.Collections.Generic;
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

        [HttpGet("{startcoordonates}/{endcoordonates}/{cityname}", Name = "GetBusRoute")]
        public async Task<IActionResult> GetRout([FromRoute] string startcoordonates, [FromRoute] string endcoordonates, [FromRoute] string cityname)
        {
            if(startcoordonates == string.Empty || startcoordonates == null
                || endcoordonates == string.Empty || endcoordonates == null
                || cityname == string.Empty || cityname == null)
            {
                return BadRequest();
            }
            var res = await _cityService.GetByNameAsync(cityname).ConfigureAwait(false);
            if(res == null)
            {
                return BadRequest();
            }
            HashSet<BusStationEntity> stationEntities = new HashSet<BusStationEntity>();
            foreach(BusRouteEntity bus in res.BusRoutes)
            {
                stationEntities.UnionWith(bus.BusStations);
            }
            // Fac cast la coordonatele din input
            CoordinatesEntity coordinatesEntity = new CoordinatesEntity(Convert.ToDouble(startcoordonates.Split('_')[0]), Convert.ToDouble(startcoordonates.Split('_')[1]));
            CoordinatesEntity coordinatesEntity1 = new CoordinatesEntity (Convert.ToDouble(endcoordonates.Split('_')[0]), Convert.ToDouble(endcoordonates.Split('_')[1]));

            // Caut cea mai apropiata statie pentru punctul de start
            double longDiff = 300.0;
            double latDiff = 300.0;
            BusStationEntity station = new BusStationEntity();

            // Caut cea mai apropiata statie pentru punctul de stop
            double longDiff1 = 300.0;
            double latDiff1 = 300.0;
            BusStationEntity stationEntity = new BusStationEntity();
            foreach(BusStationEntity bus in stationEntities)
            {
                // Caut cea mai apropiata statie pentru punctul de start
                if (Math.Abs(bus.Coordinates.Latitude - coordinatesEntity.Latitude) <= latDiff && 
                    Math.Abs(bus.Coordinates.Longitude - coordinatesEntity.Longitude) <= longDiff)
                {
                    station = new BusStationEntity
                    {
                        Id = bus.Id,
                        Name = bus.Name,
                        Coordinates = bus.Coordinates,
                        Buses = bus.Buses,
                        CreationDate = bus.CreationDate,
                        ModifiedDate = bus.ModifiedDate
                    };
                    longDiff = Math.Abs(bus.Coordinates.Latitude - coordinatesEntity.Latitude);
                    latDiff = Math.Abs(bus.Coordinates.Longitude - coordinatesEntity.Longitude);
                }

                // Caut cea mai apropiata statie pentru punctul de stop
                if (Math.Abs(bus.Coordinates.Latitude - coordinatesEntity1.Latitude) <= latDiff1 && 
                    Math.Abs(bus.Coordinates.Longitude - coordinatesEntity1.Longitude) <= longDiff1)
                {
                    stationEntity = new BusStationEntity
                    {
                        Id = bus.Id,
                        Name = bus.Name,
                        Coordinates = bus.Coordinates,
                        Buses = bus.Buses,
                        CreationDate = bus.CreationDate,
                        ModifiedDate = bus.ModifiedDate
                    };
                    longDiff1 = Math.Abs(bus.Coordinates.Latitude - coordinatesEntity1.Latitude);
                    latDiff1 = Math.Abs(bus.Coordinates.Longitude - coordinatesEntity1.Longitude);
                }
            }
            string startStationName = station.Name;
            string stopStationName = stationEntity.Name;

            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> realResult = BusStationExtensions.ShortestPath(new List<BusRouteEntity>(res.BusRoutes), startStationName, stopStationName);

            List<BktModel> bktResult = new List<BktModel>();
            if (realResult == null)
            {
                return NotFound();
            }
            foreach ((string, string, CoordinatesEntity, string, CoordinatesEntity) iterator in realResult)
            {
                BktModel bktModel = new BktModel
                {
                    RouteNumber = iterator.Item1,
                    BoardingStation = iterator.Item2,
                    BoardingCoodinates = iterator.Item3,
                    ExitStation = iterator.Item4,
                    ExitCoordinates = iterator.Item5
                };
                bktResult.Add(bktModel);
            }

            if(realResult == null)
            {
                return NotFound();
            } 
            else
            {
                return Ok(bktResult);
            }
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