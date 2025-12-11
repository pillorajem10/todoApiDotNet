using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoApiDotNet.Migrations
{
    /// <inheritdoc />
    public partial class RenameTodoTableAndColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "tbl_todos");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "tbl_todos",
                newName: "tbl_todos_title");

            migrationBuilder.RenameColumn(
                name: "IsComplete",
                table: "tbl_todos",
                newName: "tbl_todos_is_complete");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_todos",
                newName: "tbl_todos_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_todos",
                table: "tbl_todos",
                column: "tbl_todos_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_todos",
                table: "tbl_todos");

            migrationBuilder.RenameTable(
                name: "tbl_todos",
                newName: "Todos");

            migrationBuilder.RenameColumn(
                name: "tbl_todos_title",
                table: "Todos",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "tbl_todos_is_complete",
                table: "Todos",
                newName: "IsComplete");

            migrationBuilder.RenameColumn(
                name: "tbl_todos_id",
                table: "Todos",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Id");
        }
    }
}
