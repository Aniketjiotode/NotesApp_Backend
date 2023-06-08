using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Fourth_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "labelEntities",
                columns: table => new
                {
                    LabelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(nullable: true),
                    NoteID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_labelEntities", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_labelEntities_notesEntities_NoteID",
                        column: x => x.NoteID,
                        principalTable: "notesEntities",
                        principalColumn: "NoteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_labelEntities_NoteID",
                table: "labelEntities",
                column: "NoteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "labelEntities");
        }
    }
}
