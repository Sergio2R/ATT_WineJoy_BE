using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        List<Beer> Beers = new List<Beer>()
        {
            new Beer() { Id= 1, Name = "Corona" }
        };

        [HttpGet]
        public ActionResult<Beer> Get(int Id)
        {
            var beer = Beers.Where(x => x.Id == Id).FirstOrDefault();
            if (beer == null)
            {
                return NotFound();
            }
            else
            {
                return beer;
            }
        }
    }

    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
