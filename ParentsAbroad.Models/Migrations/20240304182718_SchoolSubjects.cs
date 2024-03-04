using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParentsAbroad.Models.Migrations
{
    /// <inheritdoc />
    public partial class SchoolSubjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SchoolSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSubjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildSchoolSubjects",
                columns: table => new
                {
                    ChildId = table.Column<int>(type: "int", nullable: false),
                    SchoolSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildSchoolSubjects", x => new { x.ChildId, x.SchoolSubjectId });
                    table.ForeignKey(
                        name: "FK_ChildSchoolSubjects_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildSchoolSubjects_SchoolSubjects_SchoolSubjectId",
                        column: x => x.SchoolSubjectId,
                        principalTable: "SchoolSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildSchoolSubjects_SchoolSubjectId",
                table: "ChildSchoolSubjects",
                column: "SchoolSubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildSchoolSubjects");

            migrationBuilder.DropTable(
                name: "SchoolSubjects");
        }
    }
}
