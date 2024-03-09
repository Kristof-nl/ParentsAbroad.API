using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParentsAbroad.Models.Migrations
{
    /// <inheritdoc />
    public partial class Added_Hobby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParentHobby",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    HobbyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentHobby", x => new { x.ParentId, x.HobbyId });
                    table.ForeignKey(
                        name: "FK_ParentHobby_Hobbys_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentHobby_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParentHobby_HobbyId",
                table: "ParentHobby",
                column: "HobbyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParentHobby");

            migrationBuilder.DropTable(
                name: "Hobbys");
        }
    }
}
