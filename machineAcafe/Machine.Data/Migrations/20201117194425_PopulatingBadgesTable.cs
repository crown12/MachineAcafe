using Microsoft.EntityFrameworkCore.Migrations;

namespace Machine.Data.Migrations
{
    public partial class PopulatingBadgesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO badges(Serial,Name) VALUES('1234','Ali')");
            migrationBuilder.Sql("INSERT INTO badges(Serial,Name) VALUES('5678','David')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM badges WHERE Serial='1234'')");
            migrationBuilder.Sql("DELETE FROM badges WHERE Serial='5678'')");
            
        }
    }
}
