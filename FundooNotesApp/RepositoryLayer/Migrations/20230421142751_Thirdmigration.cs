using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Thirdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collaboratorsEntities",
                columns: table => new
                {
                    ColaboratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Descriptions = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    NoteID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collaboratorsEntities", x => x.ColaboratorId);
                    table.ForeignKey(
                        name: "FK_collaboratorsEntities_notesEntities_NoteID",
                        column: x => x.NoteID,
                        principalTable: "notesEntities",
                        principalColumn: "NoteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_collaboratorsEntities_NoteID",
                table: "collaboratorsEntities",
                column: "NoteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collaboratorsEntities");
        }
    }
}
