# WeatherSensor
 
For this project to work you need to have an API client ( for example Postman)

Available requests:

1.(GET) https://localhost:44306/sensor

  Returns all weather sensors in running memory. (one sensor is precreated)
 
2.(GET) https://localhost:44306/sensor/{id}    (id - sensor id)

  Returns the weather sensor of the spicified id.
  
3.(POST) https://localhost:44306/sensor

  Input Json body text to add a weather sensor.
  example sensor layout:
  
    {
        "name": "Kaunas Sensor1",
        "city": "Kaunas"
    }

4.(PUT) https://localhost:44306/sensor/{id}    (id - sensor id)

  Updates a sensor specified by id with inputed Json body text.
  All sensor values (except id) must be inputed even if you are not changing some of them.
  
5.(DELETE) https://localhost:44306/sensor/{id}    (id - sensor id)

  Deletes a sensor specified by id.
  
6.(GET) https://localhost:44306/sensordata/{id}    (id - sensor id)

  Returns weather info for the next 5 days of the specified sensors (by id) City.
