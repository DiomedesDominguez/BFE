using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Web.Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilamentsTypesController : ControllerBase
    /// <summary>
    /// Gets the list of Filament Types.
    /// </summary>
    /// <returns>An IEnumerable of FilamentType objects.</returns>
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        public FilamentsTypesController(IConfiguration configuration, IMemoryCache cache)
        {
            _configuration = configuration;
            _cache = cache;
        }


        [HttpGet()]
        /// <summary>
        /// Method to get the list of Filament Types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FilamentType> Get()
        {
            //I'm making a new record using the name and URL from https://us.store.bambulab.com/collections/bambu-lab-3d-printer-filament?skr=yes

            if (!_cache.TryGetValue("FilamentTypes", out List<FilamentType>? filamentTypes))
            {
                // If they're not in the cache, get them from the data source
                filamentTypes = _configuration.GetSection("FilamentLinks").GetChildren().ToDictionary(x => x.Key, x => x.Value).Select(x => new FilamentType
                {
                    Name = x.Key,
                    Url = x.Value
                }).ToList();

                // Set the cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromDays(1));

                // Save data in cache.
                _cache.Set("FilamentTypes", filamentTypes, cacheEntryOptions);
            }

            return filamentTypes;
        }
    }
}