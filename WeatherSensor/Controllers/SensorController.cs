using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WeatherSensor.Data;
using WeatherSensor.Models;

namespace WeatherSensor.Controllers
{
    //  /sensor
    [Route("[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly IWeatherSensorRepo _repository;

        public SensorController(IWeatherSensorRepo repository)
        {
            _repository = repository;
        }

        //GET /sensor
        [HttpGet]
        public ActionResult <IEnumerable<Sensor>> GetAllSensors()
        {
            Debug.WriteLine("GET /sensor");
            var sensorItems = _repository.GetAllSensors();

            return Ok(sensorItems);
        }

        //GET /sensor/{id}
        [HttpGet("{id}")]
        public ActionResult <Sensor> GetSensorById(Guid id)
        {
            Debug.WriteLine($"GET /sensor/{id}");
            var sensorItem = _repository.GetSensorById(id);
            if(sensorItem != null)
            {
                return Ok(sensorItem);
            }

            return NotFound();
        }

        //POST /sensor
        [HttpPost]
        public ActionResult<Sensor> CreateSensor(Sensor sensor)
        {
            Debug.WriteLine("POST /sensor");
            _repository.CreateSensor(sensor);
            return Ok(sensor);
        }

        //PUT /sensor/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSensor(Guid id, Sensor sensor)
        {
            Debug.WriteLine($"PUT /sensor/{id}");
            var sensorFromRepo = _repository.GetSensorById(id);
            if(sensorFromRepo == null)
            {
                return NotFound();
            }
            if (sensorFromRepo.City == null || sensorFromRepo.Name == null)
            {
                return NotFound();
            }

            _repository.UpdateSensor(id, sensor);

            return Ok(sensor);
        }

        //DELETE /sensor/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSensor(Guid id)
        {
            Debug.WriteLine($"DELETE /sensor/{id}");
            var sensorFromRepo = _repository.GetSensorById(id);
            if(sensorFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteSensor(id);

            return Ok();
        }
    }
}
