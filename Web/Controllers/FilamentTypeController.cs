using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilamentsTypesController : ControllerBase
    {
        public record FilamentType(string Name, string Url);
        [HttpGet()]
        public IEnumerable<FilamentType> Get()
        {
            //I'm making a new record using the name and URL from https://us.store.bambulab.com/collections/bambu-lab-3d-printer-filament?skr=yes
            var records = new List<FilamentType>
            {
                new("PLA Basic", "https://us.store.bambulab.com/products/pla-basic-filament"),
                new("PLA Matte", "https://us.store.bambulab.com/products/pla-matte-filament"),
                new("PETG Basic", "https://us.store.bambulab.com/products/petg-basic"),
                new("ABS", "https://us.store.bambulab.com/products/abs-filament"),
                new("PLA Metal", "https://us.store.bambulab.com/products/pla-metal"),
                new("PLA Silk", "https://us.store.bambulab.com/products/pla-silk"),
                new("PLA Silk Dual Color", "https://us.store.bambulab.com/products/pla-silk-dual-color"),
                new("PLA Marble", "https://us.store.bambulab.com/products/pla-marble"),
                new("PLA Tough", "https://us.store.bambulab.com/products/pla-tough"),
                new("PLA Glow", "https://us.store.bambulab.com/products/pla-glow"),
                new("PLA Sparkle", "https://us.store.bambulab.com/products/pla-sparkle"),
                new("TPU 95A", "https://us.store.bambulab.com/products/tpu-filament"),
                new("PLA CMYK", "https://us.store.bambulab.com/products/pla-cmyk-lithophane"),
                new("ASA", "https://us.store.bambulab.com/products/asa-filament"),
                new("PLA Basic Gradient", "https://us.store.bambulab.com/products/pla-basic-gradient"),
                new("PLA-CF", "https://us.store.bambulab.com/products/pla-cf"),
                new("TPU 95A HF", "https://us.store.bambulab.com/products/tpu-95a-hf"),
                new("PETG-CF", "https://us.store.bambulab.com/products/petg-cf"),
                new("PAHT-CF", "https://us.store.bambulab.com/products/paht-cf"),
                new("PA6-CF", "https://us.store.bambulab.com/products/pa6-cf"),
                new("PET-CF", "https://us.store.bambulab.com/products/pet-cf"),
                new("PC", "https://us.store.bambulab.com/products/pc-filament"),
                new("PLA Aero", "https://us.store.bambulab.com/products/pla-aero"),
                new("Essential Pack", "https://us.store.bambulab.com/products/essential-pack"),
                new("PLA Basic Refill 2 Rolls", "https://us.store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-basic-refill-bundle"),
                new("PLA Matte Refill 2 Rolls", "https://us.store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-matte-refill-bundle")
            };

            return records.OrderBy(x => x.Name).ToList();

        }
    }
}