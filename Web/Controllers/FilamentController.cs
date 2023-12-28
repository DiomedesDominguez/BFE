using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilamentController : ControllerBase
    {
        public record FilamentType(string Name, string Url);

        public record Filament(string Color, decimal Price, bool Available, FilamentType Type, bool IsRefill, string Size, string Url);

        [HttpGet()]
        public IEnumerable<FilamentType> Get()
        {
            //I'm making a new record using the name and URL from https://us.store.bambulab.com/collections/bambu-lab-3d-printer-filament?skr=yes
            var records = new List<FilamentType>();
            records.Add(new FilamentType("PLA Basic", "https://us.store.bambulab.com/products/pla-basic-filament"));
            records.Add(new FilamentType("PLA Matte", "https://us.store.bambulab.com/products/pla-matte-filament"));
            records.Add(new FilamentType("PETG Basic", "https://us.store.bambulab.com/products/petg-basic"));
            records.Add(new FilamentType("ABS", "https://us.store.bambulab.com/products/abs-filament"));
            records.Add(new FilamentType("PLA Metal", "https://us.store.bambulab.com/products/pla-metal"));
            records.Add(new FilamentType("PLA Silk", "https://us.store.bambulab.com/products/pla-silk"));
            records.Add(new FilamentType("PLA Marble", "https://us.store.bambulab.com/products/pla-marble"));
            records.Add(new FilamentType("PLA Tough", "https://us.store.bambulab.com/products/pla-tough"));
            records.Add(new FilamentType("PLA Glow", "https://us.store.bambulab.com/products/pla-glow"));
            records.Add(new FilamentType("PLA Sparkle", "https://us.store.bambulab.com/products/pla-sparkle"));
            records.Add(new FilamentType("TPU 95A", "https://us.store.bambulab.com/products/tpu-filament"));
            records.Add(new FilamentType("PLA CMYK", "https://us.store.bambulab.com/products/pla-cmyk-lithophane"));
            records.Add(new FilamentType("ASA", "https://us.store.bambulab.com/products/asa-filament"));
            records.Add(new FilamentType("PLA Basic Gradient", "https://us.store.bambulab.com/products/pla-basic-gradient"));
            records.Add(new FilamentType("PLA-CF", "https://us.store.bambulab.com/products/pla-cf"));
            records.Add(new FilamentType("TPU 95A HF", "https://us.store.bambulab.com/products/tpu-95a-hf"));
            records.Add(new FilamentType("PETG-CF", "https://us.store.bambulab.com/products/petg-cf"));
            records.Add(new FilamentType("PAHT-CF", "https://us.store.bambulab.com/products/paht-cf"));
            records.Add(new FilamentType("PA6-CF", "https://us.store.bambulab.com/products/pa6-cf"));
            records.Add(new FilamentType("PET-CF", "https://us.store.bambulab.com/products/pet-cf"));
            records.Add(new FilamentType("PC", "https://us.store.bambulab.com/products/pc-filament"));
            records.Add(new FilamentType("PLA Aero", "https://us.store.bambulab.com/products/pla-aero"));

            return records;

        }
    }
}