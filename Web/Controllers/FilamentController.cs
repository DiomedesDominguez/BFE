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
            //I'm making a new record using the name and URL from https://store.bambulab.com/collections/bambu-lab-3d-printer-filament
            var records = new List<FilamentType>();
            records.Add(new FilamentType("PLA Basic", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-basic-filament"));
            records.Add(new FilamentType("PLA Matte", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-matte-filament"));
            records.Add(new FilamentType("PETG Basic", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/petg-basic"));
            records.Add(new FilamentType("ABS", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/abs-filament"));
            records.Add(new FilamentType("PLA Metal", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-metal"));
            records.Add(new FilamentType("PLA Silk", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-silk"));
            records.Add(new FilamentType("PLA Marble", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-marble"));
            records.Add(new FilamentType("PLA Tough", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-tough"));
            records.Add(new FilamentType("PLA Glow", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-glow"));
            records.Add(new FilamentType("PLA Sparkle", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-sparkle"));
            records.Add(new FilamentType("TPU 95A", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/tpu-filament"));
            records.Add(new FilamentType("PLA CMYK", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-cmyk-lithophane"));
            records.Add(new FilamentType("ASA", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/asa-filament"));
            records.Add(new FilamentType("PLA Basic Gradient", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-basic-gradient"));
            records.Add(new FilamentType("PLA-CF", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-cf"));
            records.Add(new FilamentType("TPU 95A HF", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/tpu-95a-hf"));
            records.Add(new FilamentType("PETG-CF", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/petg-cf"));
            records.Add(new FilamentType("PAHT-CF", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/paht-cf"));
            records.Add(new FilamentType("PA6-CF", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pa6-cf"));
            records.Add(new FilamentType("PET-CF", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pet-cf"));
            records.Add(new FilamentType("PC", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pc-filament"));
            records.Add(new FilamentType("PLA Aero", "https://store.bambulab.com/collections/bambu-lab-3d-printer-filament/products/pla-aero"));

            return records;

        }
    }
}