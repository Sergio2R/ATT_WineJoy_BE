using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
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
            //connect to sql
            string conString = "Server=remotemysql.com;Database=OxAIZvu7Va;Uid=OxAIZvu7Va;Pwd=CUeqNsd0vO;";

            List<Beer> beers = new List<Beer>();
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Beer", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Beer beer1 = new Beer();
                    beer1.Id = reader.GetInt32("id");
                    beer1.Name = reader.GetString("name");
                    //extract data
                }
            }

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
