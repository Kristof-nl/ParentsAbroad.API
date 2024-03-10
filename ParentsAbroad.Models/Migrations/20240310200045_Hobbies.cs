using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParentsAbroad.Models.Migrations
{
    /// <inheritdoc />
    public partial class Hobbies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentHobby_Hobbys_HobbyId",
                table: "ParentHobby");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobbys",
                table: "Hobbys");

            migrationBuilder.RenameTable(
                name: "Hobbys",
                newName: "Hobbies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentHobby_Hobbies_HobbyId",
                table: "ParentHobby",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentHobby_Hobbies_HobbyId",
                table: "ParentHobby");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies");

            migrationBuilder.RenameTable(
                name: "Hobbies",
                newName: "Hobbys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobbys",
                table: "Hobbys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentHobby_Hobbys_HobbyId",
                table: "ParentHobby",
                column: "HobbyId",
                principalTable: "Hobbys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
