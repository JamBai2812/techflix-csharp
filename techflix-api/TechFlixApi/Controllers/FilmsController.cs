using Microsoft.AspNetCore.Mvc;
using TechFlixApi.Models.CacheService;
using TechFlixApi.Models.Response;
using TechFlixApi.Services;

namespace TechFlixApi.Controllers
{
    [ApiController]
    [Route("films")]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmsService _filmsService;
        private readonly IPeopleService _peopleService;
        private readonly ICacheService _cacheService;
        private readonly string _apiUrl = "http://localhost:8000/films";

        public FilmsController(IFilmsService filmsService, IPeopleService peopleService, ICacheService cacheService)
        {
            _filmsService = filmsService;
            _peopleService = peopleService;
            _cacheService = cacheService;
        }

        [HttpGet("")]
        public ActionResult<ResultList<Film>> GetFilms()
        {
            var page = _apiUrl+""; 
            
                return _cacheService.GetOrCreate(page, () => _filmsService.GetFilms());
        }

        [HttpGet("popular")]
        public ActionResult<ResultList<Film>> GetPopularFilms()
        {
            return _filmsService.GetFilms();
        }

        [HttpGet("recommended")]
        public ActionResult<ResultList<Film>> GetRecommendedFilms()
        {
            return _filmsService.GetFilms();
        }

        [HttpGet("{id}")]
        public ActionResult<Film> GetFilm([FromRoute] int id)
        {
            return _filmsService.GetFilm(id);
        }

        [HttpGet("{id}/cast")]
        public ActionResult<ResultList<Person>> GetCast([FromRoute] int id)
        {
            return _peopleService.GetPeople();
        }
        
        
        [HttpGet("{id}/similar")]
        public ActionResult<ResultList<Film>> GetSimilar([FromRoute] int id)
        {
            return _filmsService.GetFilms();
        }
    }
}