using Microsoft.AspNetCore.Mvc;
using NetCoreWepAPI.Controllers;
using NetCoreWepAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace WineJoyFeatures.Test
{
    public class WineTest1
    {


        [Fact]
        public void SetNewWine_WhenCalled_ReturnsOk()
        {
            var w = new Wine
            {
                Name = "TestWine",
                Clasification = 0,
                Year = 1999,
                Aroma = "bit coffe",
                Swetness = 3,
                Acidity = 2,
                Alcohol = 25,
                Notes = "Some stuff about wine"
            };
            WineController _controller = new WineController();
            var createdResponse = _controller.AddWine(w);
            Assert.IsType<CreatedAtActionResult>(createdResponse);

        }

        [Fact]
        public void GetWine_WhenCalled_ReturnsWineList()
        {
            WineController _controller = new WineController();
            var createdResponse = _controller.GetWineList();
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
    }
}
