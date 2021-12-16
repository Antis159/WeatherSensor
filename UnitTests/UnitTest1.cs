using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using WeatherSensor.Controllers;
using WeatherSensor.Data;
using WeatherSensor.Models;
using Xunit;
using NotFoundResult = Microsoft.AspNetCore.Mvc.NotFoundResult;

namespace UnitTests
{
    public class ControllerTests
    {
        [Fact]
        public void Put_Returns_Not_Found_When_Sensor_Not_Found()
        {
            var dataStore = A.Fake<IWeatherSensorRepo>();
            SensorController sensorController = new SensorController(dataStore);
            var actionResult = sensorController.UpdateSensor(Guid.NewGuid(), new Sensor());
            var result = actionResult as NotFoundResult;

            Assert.NotNull(result);
            Assert.Equal("404", result.StatusCode.ToString());

        }
    }
}
