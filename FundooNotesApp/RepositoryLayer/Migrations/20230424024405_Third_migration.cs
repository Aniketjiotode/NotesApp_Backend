using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Third_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_collaboratorsEntities_UserId",
                table: "collaboratorsEntities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_collaboratorsEntities_userEntities_UserId",
                table: "collaboratorsEntities",
                column: "UserId",
                principalTable: "userEntities",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collaboratorsEntities_userEntities_UserId",
                table: "collaboratorsEntities");

            migrationBuilder.DropIndex(
                name: "IX_collaboratorsEntities_UserId",
                table: "collaboratorsEntities");
        }
    }
}
