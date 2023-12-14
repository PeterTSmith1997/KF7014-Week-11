using System.Text;
using System.Net.Http;
using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace temperature
{
    /*
     * class to emulate a temperature sensor 
     * code generated with help from chatGPT, some code adaption made 
     */
    public class Sensor
    {
        public Sensor() { }

        public static async void run()
        {
            string apiUrl = "https://localhost:7074/Temperature";
            //Console.WriteLine(apiUrl);
            Random random = new Random();

            //keep looping
            while (true)
            {
                // Create a random temperature value
                int randomTemperature = random.Next(-20, 40); // Assuming a range from -20 to 40 degrees Celsius

                // Create the JSON payload
                var payload = new
                {
                    id = 0,
                    temp = randomTemperature,
                };
                // convert the payload to JSON 
                var jsonPayload = JsonConvert.SerializeObject(payload);

                // Post the JSON payload to the API
                var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                var httpClient = new HttpClient();
                var httpResponse = httpClient.PostAsync(apiUrl, httpContent);
                Console.WriteLine(httpResponse.Result);
                // Wait for 5 minutes before posting the next temperature
                await Task.Delay(TimeSpan.FromMinutes(5));
            }
        }
    }
}