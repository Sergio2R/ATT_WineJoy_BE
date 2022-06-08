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
    public class AcidityController : ControllerBase
    {
        [HttpGet]
        [Route("getAcidity")]
        public ActionResult<Acidity> GetAcidity(int Id)
        {
            try
            {
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Acidity WHERE ID = {Id}";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    Acidity acidity = new Acidity();
                    while (reader.Read())
                    {
                        acidity.Id = reader.GetInt32("id");
                        acidity.Description = reader.GetString("description");
                    }
                    reader.Close();
                    connection.Close();
                    if (acidity == null)
                    {
                        return NotFound();
                    }
                    return acidity;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getAcidityList")]
        public ActionResult<List<Acidity>> GetAcidityList()
        {
            try
            {
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Acidity";
                    MySqlCommand command = new(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<Acidity> acidityList = new List<Acidity>();
                    while (reader.Read())
                    {
                        Acidity acidity = new Acidity();
                        acidity.Id = reader.GetInt32("id");
                        acidity.Description = reader.GetString("description");
                        acidityList.Add(acidity);
                    }
                    reader.Close();
                    connection.Close();
                    return acidityList;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
