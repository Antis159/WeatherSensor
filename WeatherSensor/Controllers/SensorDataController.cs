using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;
using WeatherSensor.Data;
using WeatherSensor.Models;

namespace WeatherSensor.Controllers
{
    //  /sensordata
    [Route("[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        private readonly IWeatherSensorRepo _repository;

        public SensorDataController(IWeatherSensorRepo repository)
        {
            _repository = repository;
        }

        //GET /sensordata/{id}
        [HttpGet("{id}")]
        [ResponseCache(Duration = 600)]
        public ActionResult <Sensor> GetSensorWeather(Guid id)
        {
            Debug.WriteLine($"GET /sensordata/{id}");
            string apiKey = "d81bd0037d2227f54777434a3ce2c754";
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&appid={1}", _repository.GetSensorById(id).City, apiKey);
            var json = new WebClient().DownloadString(url);
            return Ok(json);
        }
    }
}
