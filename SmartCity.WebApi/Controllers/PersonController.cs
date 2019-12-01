using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Business.Person;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.Person;
using SmartCity.WebApi.Models.User;
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
            if(user == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Username))
            {
                return BadRequest();
            }

            var person = await _persons.GetByCredentials(user.Username, user.Password).ConfigureAwait(false);
            if(person == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PersonModel>(person));
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] CreatePersonModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName) || string.IsNullOrEmpty(user.Email))
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Username))
            {
                return BadRequest();
            }

            var userEntity = _mapper.Map<PersonEntity>(user);

            await _persons.AddAsync(userEntity).ConfigureAwait(false);

            var userResult = await _persons.GetByIdAsync(userEntity.Id).ConfigureAwait(false);

            return CreatedAtRoute("GetPersonById", new { id = userResult.Id }, _mapper.Map<PersonEntity>(userResult));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] Guid id, [FromBody] UpdatePersonModel updatePerson)
        {
            if (updatePerson == null)
            {
                return BadRequest();
            }

            if (updatePerson.Id != id)
            {
                return BadRequest();
            }

            if(string.IsNullOrEmpty(updatePerson.FirstName) || string.IsNullOrEmpty(updatePerson.LastName) || string.IsNullOrEmpty(updatePerson.Email))
            {
                return BadRequest();
            }

            if(string.IsNullOrEmpty(updatePerson.Password) || string.IsNullOrEmpty(updatePerson.Username))
            {
                return BadRequest();
            }

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