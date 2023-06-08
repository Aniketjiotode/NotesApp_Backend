using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Third__Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriptions",
                table: "collaboratorsEntities");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "collaboratorsEntities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descriptions",
                table: "collaboratorsEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "collaboratorsEntities",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
