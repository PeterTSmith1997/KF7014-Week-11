using Microsoft.EntityFrameworkCore;
using temperature.Data;
using temperature.Models;
using temperature.Services;

namespace temperature
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<TemperatureService>();
            //Add database
            var connectionString = builder.Configuration.GetConnectionString("Temperatures") ?? "Data Source=Temperature.db";
            builder.Services.AddSqlite<TemperatureContext>(connectionString);

            // 1) define a unique string
            string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // 2) define allowed domains, in this case "http://example.com" and "*" = all
            //    domains, for testing purposes only.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                  builder =>
                  {
                      builder.WithOrigins("*");
                  });
            });




            var app = builder.Build();
            app.UseCors(MyAllowSpecificOrigins);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            // use a new thread to emulate sensor
            Thread thread = new Thread(Sensor.run);
            //thread.Start();

            app.Run();
            
        }
    }
}