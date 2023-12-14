using Microsoft.EntityFrameworkCore;

namespace temperature.Models
{
    public class Temperature
    {
        public int Id { get; set; }
        public double Temp { get; set; }
        public String recordTime { get; set; }
        public bool alert { get; set; }
    }
}
