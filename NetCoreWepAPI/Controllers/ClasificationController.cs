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
    public class ClasificationController : ControllerBase
    {
        [HttpGet]
        [Route("getClasification")]
        public ActionResult<Clasification> GetClasification(int Id)
        {
            try
            {
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Clasification WHERE ID = {Id}";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    Clasification clasification = new Clasification();
                    while (reader.Read())
                    {
                        clasification.Id = reader.GetInt32("id");
                        clasification.Description = reader.GetString("description");
                    }
                    reader.Close();
                    connection.Close();
                    if (clasification == null)
                    {
                        return NotFound();
                    }
                    return clasification;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getClasifications")]
        public ActionResult<List<Clasification>> GetClasifications()
        {
            try
            {
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Clasification";
                    MySqlCommand command = new(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<Clasification> clasificationList = new List<Clasification>();
                    while (reader.Read())
                    {
                        Clasification clasification = new Clasification();
                        clasification.Id = reader.GetInt32("id");
                        clasification.Description = reader.GetString("description");
                        clasificationList.Add(clasification);
                    }
                    reader.Close();
                    connection.Close();
                    return clasificationList;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
