using System;
using System.Collections.Generic;
using System.Linq;
using WeatherSensor.Models;

namespace WeatherSensor.Data
{
    public class MockWeatherSensorRepo : IWeatherSensorRepo
    {
        private static List<Sensor> _context = new List<Sensor>() { new Sensor { Id = new Guid(), Name = "Kaunas Sensor1", City = "Kaunas" } };

        public void CreateSensor(Sensor sensor)
        {
            if (sensor == null)
                throw new ArgumentNullException(nameof(sensor));
            if (sensor.Id == Guid.Empty)
                sensor.Id = Guid.NewGuid();

            _context.Add(sensor);
        }

        public IEnumerable<Sensor> GetAllSensors()
        {
            return _context.ToList();
        }

        public Sensor GetSensorById(Guid id)
        {
            return _context.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteSensor(Guid id)
        {
            var tempSensor = _context.FirstOrDefault(p => p.Id == id);
            int index = _context.IndexOf(tempSensor);
            _context.RemoveAt(index);
        }

        public void UpdateSensor(Guid id, Sensor sensor)
        {
            var tempSensor = _context.FirstOrDefault(p => p.Id == id);
            if (sensor.Id != id)
                sensor.Id = id;
            int index = _context.IndexOf(tempSensor);
            _context[index] = sensor;
        }

        public void GetSensorWeather(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
