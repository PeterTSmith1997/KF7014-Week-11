using Microsoft.AspNetCore.Mvc;
using temperature.Models;
using temperature.Services;

namespace temperature.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureService _temperatureService;

        public TemperatureController(TemperatureService temperatureService)
        {
            _temperatureService = temperatureService;
        }

        [HttpGet]
        public ActionResult<List<Temperature>> GetAll() =>
            TemperatureService.GetTemperatures();


        [HttpGet("{id}")]
        public ActionResult<Temperature> Get(int id)
        {
            var temp = TemperatureService.Get(id);

            if (temp == null)
            {
                return NotFound();
            }
            else
            {
                return temp;
            }
        }



        [HttpPost]
        public IActionResult Create(TemperatureDTO temperature)
        {
            TemperatureService.addTemp(temperature);
            return CreatedAtAction(nameof(Get), new { id = temperature.Id }, temperature);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Temperature temperature, int id)
        {
            if (id != temperature.Id)
            {
                return BadRequest();
            }

            var existingTemp = TemperatureService.Get(id);
           if (existingTemp is null)
            {
                return NotFound();
            }

            TemperatureService.updateTemp(temperature, id);
            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var temp = TemperatureService.Get(id);

            if (temp is null)
            {
                return NotFound();
            }
            else
            {
                TemperatureService.removeTemp(temp);
                return NoContent();
            }

        }
    }
}
