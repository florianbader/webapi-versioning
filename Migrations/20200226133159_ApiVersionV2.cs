using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiVersioning.Migrations
{
    public partial class ApiVersionV2 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TRIGGER MigrateWeatherForecast
                ON dbo.WeatherForecast
                AFTER INSERT, UPDATE
                AS INSERT INTO dbo.WeatherForecastV2
                SELECT * FROM inserted");
        }
    }
}