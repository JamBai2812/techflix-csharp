using Microsoft.AspNetCore.Mvc;
using TechFlixApi.Models.CacheService;
using TechFlixApi.Models.Response;
using TechFlixApi.Services;

namespace TechFlixApi.Controllers
{
    [ApiController]
    [Route("people")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly IFilmsService _filmsService;
        private readonly ICacheService _cacheService;

        public PeopleController(IPeopleService peopleService, IFilmsService filmsService, ICacheService cacheService)
        {
            _peopleService = peopleService;
            _filmsService = filmsService;
            _cacheService = cacheService;
        }

        [HttpGet("")]
        public ActionResult<ResultList<Person>> GetPeople()
        {
            return _peopleService.GetPeople();
        }
        
        [HttpGet("popular")]
        public ActionResult<ResultList<Person>> GetPopular()
        {
            return _peopleService.GetPeople();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetPerson([FromRoute] int id)
        {
            return _peopleService.GetPerson(id);
        }

        [HttpGet("{id}/films")]
        public ActionResult<ResultList<Film>> GetFilms([FromRoute] int id)
        {
            return _filmsService.GetFilms();
        }
    }
}