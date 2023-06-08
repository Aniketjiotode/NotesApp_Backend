using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Fourth_migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "labelEntities",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_labelEntities_UserId",
                table: "labelEntities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_labelEntities_userEntities_UserId",
                table: "labelEntities",
                column: "UserId",
                principalTable: "userEntities",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_labelEntities_userEntities_UserId",
                table: "labelEntities");

            migrationBuilder.DropIndex(
                name: "IX_labelEntities_UserId",
                table: "labelEntities");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "labelEntities");
        }
    }
}
