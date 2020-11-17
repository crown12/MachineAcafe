using Microsoft.EntityFrameworkCore.Migrations;

namespace Machine.Data.Migrations
{
    public partial class PopulatingDrinksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO drinks VALUES('Coffee')");
            migrationBuilder.Sql("INSERT INTO drinks VALUES('Tea')");
            migrationBuilder.Sql("INSERT INTO drinks VALUES('Chocolate')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM drinks WHERE name='Coffee'");
            migrationBuilder.Sql("DELETE FROM drinks WHERE name='Tea'");
            migrationBuilder.Sql("DELETE FROM drinks WHERE name='Chocolate'");

        }
    }
}
