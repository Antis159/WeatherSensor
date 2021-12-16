using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherSensor.Models
{
    public class Sensor
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string City { get; set; }
    }
}
