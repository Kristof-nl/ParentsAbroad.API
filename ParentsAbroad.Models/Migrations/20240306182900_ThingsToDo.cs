using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParentsAbroad.Models.Migrations
{
    /// <inheritdoc />
    public partial class ThingsToDo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LikeToDoThings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeToDoThings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildLikeToDo",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    LikeToDoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildLikeToDo", x => new { x.ChildId, x.LikeToDoId });
                    table.ForeignKey(
                        name: "FK_ChildLikeToDo_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildLikeToDo_LikeToDoThings_LikeToDoId",
                        column: x => x.LikeToDoId,
                        principalTable: "LikeToDoThings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildLikeToDo_LikeToDoId",
                table: "ChildLikeToDo",
                column: "LikeToDoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildLikeToDo");

            migrationBuilder.DropTable(
                name: "LikeToDoThings");
        }
    }
}
