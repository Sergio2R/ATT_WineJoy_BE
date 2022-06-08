using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using NetCoreWepAPI.Models;
using System;
using System.Collections.Generic;

namespace NetCoreWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AromaController : ControllerBase
    {
        [HttpGet]
        [Route("getAroma")]
        public ActionResult<Aroma> GetAroma(int Id)
        {
            try
            {
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Aroma WHERE ID = {Id}";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    Aroma aroma = new Aroma();
                    while (reader.Read())
                    {
                        aroma.Id = reader.GetInt32("id");
                        aroma.Description = reader.GetString("description");
                    }
                    reader.Close();
                    connection.Close();
                    if (aroma == null)
                    {
                        return NotFound();
                    }
                    return aroma;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAromaList")]
        public ActionResult<List<Aroma>> GetAromaList()
        {
            try
            {
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Aroma";
                    MySqlCommand command = new(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<Aroma> aromaList = new List<Aroma>();
                    while (reader.Read())
                    {
                        Aroma aroma = new Aroma();
                        aroma.Id = reader.GetInt32("id");
                        aroma.Description = reader.GetString("description");
                        aromaList.Add(aroma);
                    }
                    reader.Close();
                    connection.Close();
                    return aromaList;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
