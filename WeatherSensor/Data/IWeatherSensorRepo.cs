using System;
using System.Collections.Generic;
using WeatherSensor.Models;

namespace WeatherSensor.Data
{
    public interface IWeatherSensorRepo
    {
        IEnumerable<Sensor> GetAllSensors();
        Sensor GetSensorById(Guid id);
        void CreateSensor(Sensor sensor);
        void UpdateSensor(Guid id, Sensor sensor);
        void DeleteSensor(Guid id);
        void GetSensorWeather(Guid id);
    }
}
