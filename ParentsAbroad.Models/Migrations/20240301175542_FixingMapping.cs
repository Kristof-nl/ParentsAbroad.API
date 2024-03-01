using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParentsAbroad.Models.Migrations
{
    /// <inheritdoc />
    public partial class FixingMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ChildId",
                table: "Languages",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ParentId",
                table: "Languages",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Children_ChildId",
                table: "Languages",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Parents_ParentId",
                table: "Languages",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Children_ChildId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Parents_ParentId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_ChildId",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_ParentId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Languages");
        }
    }
}
