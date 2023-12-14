using Microsoft.EntityFrameworkCore;

namespace temperature.Data
{
    /*
     * Class to  register a DB context for Temperature api
     * 
     */
    public class TemperatureContext : DbContext
    {
        public TemperatureContext(DbContextOptions<TemperatureContext> options)
          : base(options)
        {
        }

        public DbSet<temperature.Models.Temperature>? Temperatures { get; set; }
    }

}