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
    public class WineController : ControllerBase
    {
        [HttpGet]
        [Route("getWine")]
        public ActionResult<Wine> GetWine(int Id)
        {
            try
            {
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
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
                        wine.Swetness = reader.GetInt32("swetness");
                        wine.Acidity = reader.GetInt32("acidity");
                        wine.Alcohol = reader.GetInt32("alcohol");
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
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Wine";
                    MySqlCommand command = new(query, connection);
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
                        wine.Swetness = reader.GetInt32("swetness");
                        wine.Acidity = reader.GetInt32("acidity");
                        wine.Alcohol = reader.GetInt32("alcohol");
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
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = $"INSERT INTO `Wine` (`name`, `clasification`, `year`, `aroma`, `swetness`, `acidity`, `alcohol`, `notes`) VALUES ('{wine.Name}', '{wine.Clasification}', '{wine.Year}', '{wine.Aroma}', '{wine.Swetness}', '{wine.Acidity}', '{wine.Alcohol}', '{wine.Notes}')";
                    MySqlCommand command = new(query, connection);
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

        [HttpPut]
        [Route("updateWine")]
        public ActionResult<Wine> UpdateWine(Wine wine)
        {
            try
            {
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = @$"UPDATE `Wine` SET `name`= '{wine.Name}',`clasification`='{wine.Clasification}',`year`='{wine.Year}',`aroma`='{wine.Aroma}',`swetness`='{wine.Swetness}',`acidity`='{wine.Acidity}',`alcohol`='{wine.Alcohol}',`notes`='{wine.Notes}' WHERE id = '{wine.Id}'";
                    MySqlCommand command = new(query, connection);
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

        [HttpDelete]
        [Route("deleteWine")]
        public ActionResult<Wine> DeleteWine(int id)
        {
            try
            {
                using (MySqlConnection connection = new(GeneralControllerHelpers.connectionString))
                {
                    connection.Open();
                    string query = $"DELETE FROM `Wine` WHERE id = {id}";
                    MySqlCommand command = new(query, connection);
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
