using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApiProject.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNameInWeatherandWeatherDtofromCountrytoCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Weathers",
                newName: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Weathers",
                newName: "Country");
        }
    }
}
