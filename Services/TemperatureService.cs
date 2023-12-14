using temperature.Models;
using temperature.Data;
using System;

namespace temperature.Services
{
    public class TemperatureService
    {

        private static TemperatureContext _context = default!;

        public TemperatureService(TemperatureContext context)
        {

            _context = context;

        }


        // method to return a list of all temperatures
        public static List<Temperature> GetTemperatures()
        {
            if (_context != null)
            {

                return _context.Temperatures.ToList();
            }
            return new List<Temperature>();
        }

        // method to add a temperature using a DTO object which is very converted into a temperature 
        public static void addTemp(TemperatureDTO temperaturedto)
        {
            Temperature temperature = new Temperature();
            temperature.Id = temperaturedto.Id;
            temperature.Temp = temperaturedto.Temp;
            // work out the current date and time
            temperature.recordTime = DateTime.Now.ToString();
            //if the temperature is above 28 or below 0 then we need to send an alert
            if (temperaturedto.Temp > 28 || temperaturedto.Temp <= 0)
            {
                temperature.alert = true;
                Console.WriteLine("ALERT");
            }
            else { temperature.alert = false; }
            // check the database available and then add the temperature 
            if (_context != null)
            {
                _context.Add(temperature);
                _context.SaveChanges();
            }

        }
        //method to  delete a temperature out of the database 
        public static void removeTemp(Temperature temperature)
        {
            if (temperature != null)
            {
                _context.Remove(temperature);
                _context.SaveChanges();
            }
        }
        // method to update a temperature 
        public static void updateTemp(Temperature temperature, int id)
        {

            _context.Update(temperature);
            _context.SaveChanges();
        }

        public static Temperature Get(int id) =>
            _context.Temperatures.FirstOrDefault(t => t.Id == id);

    }
}