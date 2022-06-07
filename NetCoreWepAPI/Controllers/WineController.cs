using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace NetCoreWepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        [HttpGet]
        [Route("getWine")]
        public ActionResult<Wine> GetWine(int Id)
        {
            try
            {
                using (MySqlConnection connection = new(WineControllerHelpers.conString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM Wine WHERE ID = {Id}";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    Wine wine = new Wine();
                    while (reader.Read())
                    {
                        wine.Id = reader.GetInt32("id");
                        wine.Name = reader.GetString("name");
                        wine.Clasification = reader.GetInt32("clasification");
                        wine.Year = reader.GetInt32("year");
                        wine.Aroma = reader.GetString("aroma");
                        wine.Swetness = reader.GetFloat("swetness");
                        wine.Acidity = reader.GetFloat("acidity");
                        wine.Alcohol = reader.GetFloat("alcohol");
                        wine.Notes = reader.GetString("notes");
                    }
                    reader.Close();
                    connection.Close();
                    if (wine == null)
                    {
                        return NotFound();
                    }
                    return wine;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getWineList")]
        public ActionResult<List<Wine>> GetWineList()
        {
            try
            {
                using (MySqlConnection connection = new(WineControllerHelpers.conString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Wine";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    List<Wine> wineList = new List<Wine>();
                    while (reader.Read())
                    {
                        Wine wine = new Wine();
                        wine.Id = reader.GetInt32("id");
                        wine.Name = reader.GetString("name");
                        wine.Clasification = reader.GetInt32("clasification");
                        wine.Year = reader.GetInt32("year");
                        wine.Aroma = reader.GetString("aroma");
                        wine.Swetness = reader.GetFloat("swetness");
                        wine.Acidity = reader.GetFloat("acidity");
                        wine.Alcohol = reader.GetFloat("alcohol");
                        wine.Notes = reader.GetString("notes");
                        wineList.Add(wine);
                    }
                    reader.Close();
                    connection.Close();
                    return wineList;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addWine")]
        public ActionResult<Wine> AddWine(Wine wine)
        {
            try
            {
                using (MySqlConnection connection = new(WineControllerHelpers.conString))
                {
                    connection.Open();
                    string query = @$"INSERT INTO `Wine` (`name`, `clasification`, `year`, `aroma`, `swetness`, `acidity`, `alcohol`, `notes`) 
                        VALUES ('{wine.Name}', '{wine.Clasification}', '{wine.Year}', '{wine.Aroma}', 
                        '{wine.Swetness}', '{wine.Acidity}', '{wine.Alcohol}', '{wine.Notes}')";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                    connection.Close();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("updateWine")]
        public ActionResult<Wine> UpdateWine(Wine wine)
        {
            try
            {
                using (MySqlConnection connection = new(WineControllerHelpers.conString))
                {
                    connection.Open();
                    string query = @$"UPDATE INTO `Wine` (`name`, `clasification`, `year`, `aroma`, `swetness`, `acidity`, `alcohol`, `notes`) 
                        VALUES ('{wine.Name}', '{wine.Clasification}', '{wine.Year}', '{wine.Aroma}', 
                        '{wine.Swetness}', '{wine.Acidity}', '{wine.Alcohol}', '{wine.Notes}');
                        WHERE id = {wine.Id}";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    reader.Close();
                    connection.Close();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
