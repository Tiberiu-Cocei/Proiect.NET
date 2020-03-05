using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Business.Person;
using SmartCity.Domain.Entities;
using SmartCity.Domain.ExtensionMethods;
using SmartCity.WebApi.Models.Person;
using SmartCity.WebApi.Models.User;
using System;
using System.Threading.Tasks;
using Vanguard;

namespace SmartCity.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _persons;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            Guard.ArgumentNotNull(personService, nameof(personService));
            Guard.ArgumentNotNull(mapper, nameof(mapper));

            _persons = personService;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}", Name = "GetPersonById")]
        [ProducesResponseType(typeof(PersonModel), 200)]
        public async Task<IActionResult> GetPersonById([FromRoute] Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return Unauthorized();
            }

            var person = await _persons.GetByIdAsync(id).ConfigureAwait(false);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PersonModel>(person));
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetPersonByCredentials([FromBody] UserModel user)
        {
            var person = await _persons.GetByCredentials(user.Username, PersonExtensions.PasswordHashing(user.Password)).ConfigureAwait(false);
            if(person == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PersonModel>(person));
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] CreatePersonModel user)
        {

            var userEntity = _mapper.Map<PersonEntity>(user);

            var res = await _persons.GetByUsername(user.Username).ConfigureAwait(false);

            if(res != null)
            {
                return BadRequest();
            }

            var ress = await _persons.GetByEmail(user.Email).ConfigureAwait(false);

            if(ress != null)
            {
                return BadRequest();
            }
            userEntity.Password = PersonExtensions.PasswordHashing(userEntity.Password);
            await _persons.AddAsync(userEntity).ConfigureAwait(false);

            var userResult = await _persons.GetByIdAsync(userEntity.Id).ConfigureAwait(false);

            return CreatedAtRoute("GetPersonById", new { id = userResult.Id }, _mapper.Map<PersonEntity>(userResult));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] Guid id, [FromBody] UpdatePersonModel updatePerson)
        {
            var person = await _persons.GetByIdAsync(id).ConfigureAwait(false);
            if(person == null)
            {
                return NotFound();
            }

            var entity = _mapper.Map<PersonEntity>(updatePerson);
            entity.Id = id;
            await _persons.UpdateAsync(entity).ConfigureAwait(false);

            return NoContent();
        }
    }
}