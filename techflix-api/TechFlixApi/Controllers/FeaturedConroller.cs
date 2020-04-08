using Microsoft.AspNetCore.Mvc;
using TechFlixApi.Models.CacheService;
using TechFlixApi.Models.Response;
using TechFlixApi.Services;

namespace TechFlixApi.Controllers
{
    [ApiController]
    [Route("featured")]
    public class FeaturedConroller : ControllerBase
    {
        private readonly IFeaturesService _featuresService;
        private readonly ICacheService _cacheService;
        

        public FeaturedConroller(IFeaturesService featuresService, ICacheService cacheService)
        {
            _featuresService = featuresService;
            _cacheService = cacheService;
        }

        [HttpGet("")]
        public ActionResult<FeaturedItems> GetFeatures()
        {
            return _featuresService.GetFeatures();
        }
    }
}