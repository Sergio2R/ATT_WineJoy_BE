using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;

namespace NetCoreWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        public static string conString = "Server=remotemysql.com;Database=OxAIZvu7Va;Uid=OxAIZvu7Va;Pwd=CUeqNsd0vO;";

        [HttpGet]
        [Route("getWine")]
        public ActionResult<Wine> GetWine(int Id)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from Wine", con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    Wine wine = new Wine();
                    while (reader.Read())
                    {
                        wine.Id = reader.GetInt32("id");
                        wine.Name = reader.GetString("name");
                        wine.Clasification = reader.GetString("clasification");
                        //extract data
                    }
                    reader.Close();
                    con.Close();
                    if (wine == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        return wine;
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
