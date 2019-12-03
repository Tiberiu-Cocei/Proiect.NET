using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Business.PointOfInterest;
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
        /*[HttpGet("{id:guid}", Name = "GetPointOfInterestById")]
        [ProducesResponseType(typeof(PointOfInterestModel), 200)]
*/
    }
}