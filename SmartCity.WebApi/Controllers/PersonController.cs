using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartCity.Business.Person;
using SmartCity.WebApi.Models.Person;
using Vanguard;

namespace SmartCity.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _persons;
        private readonly IMapper _mapper;

        public PersonController(IPersonService quizService, IMapper mapper)
        {
            Guard.ArgumentNotNull(quizService, nameof(quizService));
            Guard.ArgumentNotNull(mapper, nameof(mapper));

            _persons = quizService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<PersonModel>), 200)]
        public async Task<IActionResult> Get()
        {
/*            var userId = GetUserIdFromToken();
            var quizzes = await _persons.ListAsync(userId).ConfigureAwait(false);*/

            return Ok(/*_mapper.Map<IEnumerable<PersonModel>>(quizzes)*/);
        }

        [HttpGet("{id:guid}", Name = "GetPersonById")]
        [ProducesResponseType(typeof(PersonModel), 200)]
        public async Task<IActionResult> GetQuizById([FromRoute] Guid id)
        {
            /*var quiz = await _persons.GetQuiz(id).ConfigureAwait(false);
            if (quiz == null)
            {
                return NotFound();
            }

            var userId = GetUserIdFromToken();
            if (quiz.QuizCreatorId != userId)
            {
                return Unauthorized();
            }*/

            return Ok(/*_mapper.Map<PersonModel>(quiz)*/);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuiz([FromBody] CreatePersonModel quiz)
        {
            /*            var quizEntity = _mapper.Map<PersonEntity>(quiz);
                        quizEntity.QuizCreatorId = GetUserIdFromToken();

                        await _quizService.CreateAsync(quizEntity).ConfigureAwait(false);

                        var quizResult = await _quizService.GetQuizAsync(quizEntity.Id).ConfigureAwait(false);*/
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateQuiz([FromRoute] Guid id, [FromBody] UpdatePersonModel updatedQuiz)
        {
/*            if (updatedQuiz.Id != id)
            {
                return BadRequest();
            }

            var quiz = await _quizService.GetQuizAsync(id).ConfigureAwait(false);
            if (quiz == null)
            {
                return NotFound();
            }

            var userId = GetUserIdFromToken();
            if (quiz.QuizCreatorId != userId)
            {
                return Unauthorized();
            }

            var entity = _mapper.Map<PersonEntity>(updatedQuiz);
            entity.Id = userId;
            await _persons.UpdateAsync(entity).ConfigureAwait(false);*/

            return NoContent();
        }
    }
}