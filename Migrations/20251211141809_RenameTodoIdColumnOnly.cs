using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoApiDotNet.Migrations
{
    /// <inheritdoc />
    public partial class RenameTodoIdColumnOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tbl_todos_id",
                table: "tbl_todos",
                newName: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "tbl_todos",
                newName: "tbl_todos_id");
        }
    }
}
