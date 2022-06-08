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
    public class SweetnessController : ControllerBase
    {
        [HttpGet]
        [Route("getSweetness")]
        public ActionResult<Sweetness> GetSweetness(int Id)
        {
            try
            {
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Swetness WHERE ID = {Id}";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    Sweetness sweetness = new Sweetness();
                    while (reader.Read())
                    {
                        sweetness.Id = reader.GetInt32("id");
                        sweetness.Description = reader.GetString("description");
                    }
                    reader.Close();
                    connection.Close();
                    if (sweetness == null)
                    {
                        return NotFound();
                    }
                    return sweetness;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getSweetnessList")]
        public ActionResult<List<Sweetness>> GetSweetnessList()
        {
            try
            {
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Swetness";
                    MySqlCommand command = new(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<Sweetness> sweetnessList = new List<Sweetness>();
                    while (reader.Read())
                    {
                        Sweetness sweetness = new Sweetness();
                        sweetness.Id = reader.GetInt32("id");
                        sweetness.Description = reader.GetString("description");
                        sweetnessList.Add(sweetness);
                    }
                    reader.Close();
                    connection.Close();
                    return sweetnessList;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
