using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class ColumnAutorTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Tarea");
        }
    }
}
