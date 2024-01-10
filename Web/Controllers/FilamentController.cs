using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using static Web.Models.SeoProduct;
using Microsoft.Extensions.Caching.Memory;

namespace Web.Controllers
{
    /// <summary>
    /// Controller for managing filaments.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FilamentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilamentController"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public FilamentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Represents a filament.
        /// </summary>
        public record Filament(string Color, double Price, bool Available, bool IsRefill, string Size, string Url);

        /// <summary>
        /// Retrieves a list of filaments based on the specified name.
        /// </summary>
        /// <param name="name">The name of the filament type.</param>
        /// <returns>A collection of <see cref="Filament"/> objects.</returns>
        [HttpGet(Name = "GetFilaments")]
        public IEnumerable<Filament> GetFilaments([Required] string name)
        {
            //First, we need to get the URL for the filament type
            var filamentType = new FilamentsTypesController(_configuration, _cache).Get().Where(x => x.Name == name).FirstOrDefault();

            if (!_cache.TryGetValue("Filaments", out List<Filament>? filaments))
            {
                filaments = new List<Filament>();

                //If we don't have a filament type, we can't get any records
                if (filamentType == null)
                {
                    return filaments;
                }
                //We need to download the page from the URL
                var web = new HtmlAgilityPack.HtmlWeb();
                var doc = web.Load(filamentType.Url);

                var seo_product = doc.DocumentNode.Descendants("script").Select(x => x.HasAttributes && x.Attributes["data-desc"] != null && x.Attributes["data-desc"].Value == "seo-product" ? x.InnerText : null).Where(x => x != null).Select(x => JsonConvert.DeserializeObject<Root>(x)).FirstOrDefault();

                if (seo_product != null && seo_product.model != null)
                {
                    foreach (var item in seo_product.model)
                    {
                        filaments.Add(new Filament(
                            item.color,
                            item.offers.price,
                            seo_product.offers.availability == "InStock",
                            item.additionalProperty.FirstOrDefault(x => x.name == "Type")?.value == "Refill",
                            item.additionalProperty.FirstOrDefault(x => x.name == "Size")?.value ?? string.Empty,
                            item.image));
                    }
                    // Set the cache options
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        // Keep in cache for this time, reset time if accessed.
                        .SetSlidingExpiration(TimeSpan.FromDays(1));

                    // Save data in cache.
                    _cache.Set("Filaments", filaments, cacheEntryOptions);
                }
            }

            return filaments;
        }
    }
}