using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        public static string conString = "Server=remotemysql.com;Database=OxAIZvu7Va;Uid=OxAIZvu7Va;Pwd=CUeqNsd0vO;";
        List<Beer> Beers = new List<Beer>()
        {
            new Beer() { Id= 1, Name = "Corona" }
        };

        [HttpGet]
        public ActionResult<Beer> Get(int Id)
        {
            //connect to sql

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
                reader.Close();
                con.Close();
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


        [HttpPost]
        [Route("addBeer")]
        public async Task<ActionResult<Beer>> AddBeer(Beer beer)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO `Beer` (`Id`, `Name`) VALUES ('" + beer.Id + "', '" + beer.Name + "')", con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();
                }
                return Ok(beer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("updateBeer")]
        public async Task<ActionResult<Beer>> UpdateBeer(Beer beer)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE `Beer` SET `Name` = '" + beer.Name + "' WHERE `Beer`.`Id` = " + beer.Id + "", con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
