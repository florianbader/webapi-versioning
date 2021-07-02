using Microsoft.EntityFrameworkCore;

namespace WebApiVersioning
{
    public class WebDbContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecast { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=.\\SQLEXPRESS;Integrated Security=true;Database=WebApiVersioning");
        }
    }
}