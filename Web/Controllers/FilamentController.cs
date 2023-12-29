using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using static Web.Controllers.FilamentTypeController;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Newtonsoft.Json;
using Web.Models;
using static Web.Models.SeoProduct;

#pragma warning disable CS8604 // Possible null reference argument.
namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilamentController : ControllerBase
    {
        public record Filament(string Color, double Price, bool Available, bool IsRefill, string Size, string Url);
        [HttpGet(Name = "GetFilaments")]
        public IEnumerable<Filament> GetFilaments([Required] string name)
        {
            //First, we need to get the URL for the filament type
            var filamentType = (new FilamentTypeController()).Get().Where(x => x.Name == name).FirstOrDefault();

            //If we don't have a filament type, we can't get any records
            if (filamentType == null)
            {
                return new List<Filament>();
            }
            //We need to download the page from the URL
            var web = new HtmlAgilityPack.HtmlWeb();
            var doc = web.Load(filamentType.Url);

            var seo_product = doc.DocumentNode.Descendants("script").Select(x => x.HasAttributes && x.Attributes["data-desc"] != null && x.Attributes["data-desc"].Value == "seo-product" ? x.InnerText : null).Where(x => x != null).Select(x => JsonConvert.DeserializeObject<Root>(x)).FirstOrDefault();

            var records = new List<Filament>();
            foreach (var item in seo_product.model)
            {
                records.Add(new Filament(
                                        item.color,
                                        item.offers.price,
                                        seo_product.offers.availability == "InStock",
                                        item.additionalProperty.Where(x => x.name == "Type").FirstOrDefault().value == "Refill",
                                        item.additionalProperty.Where(x => x.name == "Size").FirstOrDefault().value,
                                        item.image));
            }

            return records;

        }

    }
}
#pragma warning restore CS8604 // Possible null reference argument.